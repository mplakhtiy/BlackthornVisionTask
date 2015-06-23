using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using BlackthornVisionTask.EventArgsExtension;
using BlackthornVisionTask.Views;

namespace BlackthornVisionTask.Managers
{
    internal class ViewManager
    {
        private class WinThr
        {
            public Thread ThreadForSearching { get; private set; }
            public SearchProgressWindow SearchProgressWindow { get; private set; }

            public WinThr(SearchProgressWindow searchProgressWindow, Thread threadForSearching)
            {
                SearchProgressWindow = searchProgressWindow;
                ThreadForSearching = threadForSearching;
            }
        }

        private SearchProgressWindow searchProgressWindow;
        private ResultWindow resultWindow;
        private Thread threadForSearching;

        private readonly Dictionary<int, WinThr> dictionary = new Dictionary<int, WinThr>();
        private int key;

        public ViewManager(StartWindow startWindow)
        {
            startWindow.Show();
            EventManager.FindDuplicatedFilesButtonPressed += onFindDuplicatedFilesButtonPressed;
            EventManager.NewThreadStarted += onNewThreadStarted;
            EventManager.CancelButtonPressed += onCancelButtonPressed;
            EventManager.DuplicatedFilesFound += onDuplicatedFilesFound;
        }

        private void onNewThreadStarted(object source, ThreadEventArgs eventArgs)
        {
            threadForSearching = eventArgs.Thread;
        }

        private void onDuplicatedFilesFound(object source, ResultDictionaryEventArgs eventargs)
        {
            key--;
            dictionary[key].SearchProgressWindow.Close();
            resultWindow = new ResultWindow();
            resultWindow.Show();
        }

        private void onCancelButtonPressed(object source, EventArgs eventargs)
        {
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                foreach (var dict in dictionary.Where(dict => dict.Value.SearchProgressWindow.Equals(window)))
                {
                    dict.Value.SearchProgressWindow.Close();
                    break;
                }
            }
        }

        private void onFindDuplicatedFilesButtonPressed(object source, FolderPathEventArgs eventArgs)
        {
            searchProgressWindow = new SearchProgressWindow();
            searchProgressWindow.Show();
            dictionary.Add(key, new WinThr(searchProgressWindow, threadForSearching));
            key++;
            searchProgressWindow.Closed += onSearchProgressWindowClosed;
        }

        private void onSearchProgressWindowClosed(object source, EventArgs eventArgs)
        {
            dictionary[key].ThreadForSearching.Abort();
            dictionary.Remove(key);
        }
    }
}
