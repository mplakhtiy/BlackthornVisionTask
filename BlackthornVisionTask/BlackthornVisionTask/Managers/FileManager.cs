using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace BlackthornVisionTask.Managers
{
    class FileManager
    {
        private readonly List<string> filesPathList = new List<string>();

        public Dictionary<string, List<string>> FindDuplicatedFiles(string folderPath)
        {
            searchAllNestedFiles(folderPath);

            Dictionary<string, List<string>> duplicatedFilesDictionary = new Dictionary<string, List<string>>();

            List<int> checkedFileIndexes = new List<int>();

            for (int i = 0; i < filesPathList.Count; i++)
            {
                if (!checkedFileIndexes.Contains(i))
                {
                    List<string> duplicatedFilesList = new List<string>();

                    for (int j = i + 1; j < filesPathList.Count; j++)
                    {
                        try
                        {
                            if (compareFileHashes(filesPathList[i], filesPathList[j]))
                            {
                                if (!checkedFileIndexes.Contains(j))
                                {
                                    checkedFileIndexes.Add(j);
                                    duplicatedFilesList.Add(filesPathList[j]);
                                }
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            duplicatedFilesList.Add("This file can not be opened");
                        }
                    }
                    duplicatedFilesDictionary.Add(filesPathList[i], duplicatedFilesList);
                }
            }
            return duplicatedFilesDictionary;
        }

        private void searchAllNestedFiles(string folderPath)
        {

            string[] filePathArray = Directory.GetFiles(folderPath);
            foreach (var filePath in filePathArray)
            {
                filesPathList.Add(filePath);
            }
            string[] subFolderPathArray = Directory.GetDirectories(folderPath);
            foreach (var subfolderPath in subFolderPathArray)
            {
                searchAllNestedFiles(subfolderPath);
            }
        }

        private static bool compareFileSizes(string filePath1, string filePath2)
        {
            bool isFileSizeEqual = true;

            FileInfo fileInfo1 = new FileInfo(filePath1);
            FileInfo fileInfo2 = new FileInfo(filePath2);

            if (fileInfo1.Length != fileInfo2.Length)
            {
                isFileSizeEqual = false;
            }

            return isFileSizeEqual;
        }

        //private static bool compareFileBytes(string filePath1, string filePath2)
        //{
        //    if (compareFileSizes(filePath1, filePath2))
        //    {
        //        int file1Byte ;
        //        int file2Byte ;

        //        using (FileStream fileStream1 = new FileStream(filePath1, FileMode.Open),
        //                          fileStream2 = new FileStream(filePath2, FileMode.Open))
        //        {
        //            do
        //            {
        //                file1Byte = fileStream1.ReadByte();
        //                file2Byte = fileStream2.ReadByte();
        //            }
        //            while ((file1Byte == file2Byte) && (file1Byte != -1));
        //        }
        //        return ((file1Byte - file2Byte) == 0);
        //    }
        //    return false;
        //}

        private static bool compareFileHashes(string filePath1, string filePath2)
        {
            if (compareFileSizes(filePath1, filePath2))
            {

                HashAlgorithm hash = HashAlgorithm.Create();

                byte[] fileHash1;
                byte[] fileHash2;

                using (FileStream fileStream1 = new FileStream(filePath1, FileMode.Open),
                    fileStream2 = new FileStream(filePath2, FileMode.Open))
                {
                    fileHash1 = hash.ComputeHash(fileStream1);
                    fileHash2 = hash.ComputeHash(fileStream2);
                }
                return BitConverter.ToString(fileHash1) == BitConverter.ToString(fileHash2);
            }
            return false;
        }
    }
}
