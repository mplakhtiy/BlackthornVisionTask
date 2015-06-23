using System;

namespace BlackthornVisionTask.EventArgsExtension
{
    public class FolderPathEventArgs : EventArgs
    {
        public string FolderPath { get; private set; }

        public FolderPathEventArgs(string folderPath)
        {
            FolderPath = folderPath;
        }
    }
}
