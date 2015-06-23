using System;
using System.Collections.Generic;
using System.Threading;
using BlackthornVisionTask.EventArgsExtension;

namespace BlackthornVisionTask.Managers
{
    internal class EventManager
    {
        #region FindDuplicatedFilesButtonPressedEventHandler Members

        public static string FolderPath { get; private set; }

        public delegate void FindDuplicatedFilesButtonPressedEventHandler(object source, FolderPathEventArgs eventArgs);

        public static event FindDuplicatedFilesButtonPressedEventHandler FindDuplicatedFilesButtonPressed;

        public static void OnFindDuplicatedFilesButtonPressed(object source, string folderPath)
        {
            FolderPath = folderPath;
            if (FindDuplicatedFilesButtonPressed != null)
            {
                FindDuplicatedFilesButtonPressed(source, new FolderPathEventArgs(folderPath));
            }
        }

        #endregion

        #region DuplicatedFilesFoundEventHandler Members

        public static Dictionary<string, string> ResultDictionary { get; private set; }

        public delegate void DuplicatedFilesFoundEventHandler(object source, ResultDictionaryEventArgs eventArgs);

        public static event DuplicatedFilesFoundEventHandler DuplicatedFilesFound;

        public static void OnDuplicatedFilesFound(object source, Dictionary<string, string> resultDictionary)
        {
            ResultDictionary = resultDictionary;
            if (DuplicatedFilesFound != null)
            {
                DuplicatedFilesFound(source, new ResultDictionaryEventArgs(resultDictionary));
            }
        }

        #endregion

        #region CancelButtonPressedEventHandler Members

        public delegate void CancelButtonPressedEventHandler(object source, EventArgs eventArgs);

        public static event CancelButtonPressedEventHandler CancelButtonPressed;

        public static void OnCancelButtonPressed(object source, EventArgs eventArgs)
        {
            if (CancelButtonPressed != null)
            {
                CancelButtonPressed(source, EventArgs.Empty);
            }
        }

        #endregion

        #region NewThreadStartedEventHandler Members

        public delegate void NewThreadStartedEventHandler(object source, ThreadEventArgs eventArgs);

        public static event NewThreadStartedEventHandler NewThreadStarted;

        public static void OnNewThreadStarted(object source, Thread thread)
        {
            if (NewThreadStarted != null)
            {
                NewThreadStarted(source,new ThreadEventArgs(thread));
            }
        }

        #endregion
    }
}
