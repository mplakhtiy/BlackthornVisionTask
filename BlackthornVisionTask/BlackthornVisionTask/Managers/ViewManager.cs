using System;
using System.Threading;
using BlackthornVisionTask.EventArgsExtension;
using BlackthornVisionTask.Views;

namespace BlackthornVisionTask.Managers
{
    internal class ViewManager
    {
        private SearchProgressWindow searchProgressWindowWindow;
        private ResultWindow resultWindow;
        private Thread threadForSearching;

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
            searchProgressWindowWindow.Close();
            resultWindow = new ResultWindow();
            resultWindow.Show();
        }

        private void onCancelButtonPressed(object source, EventArgs eventargs)
        {
            searchProgressWindowWindow.Close();
        }

        private void onFindDuplicatedFilesButtonPressed(object source, FolderPathEventArgs eventArgs)
        {
            searchProgressWindowWindow = new SearchProgressWindow();
            searchProgressWindowWindow.Show();
            searchProgressWindowWindow.Closed += onSearchProgressWindowClosed;
        }

        private void onSearchProgressWindowClosed(object source, EventArgs eventArgs)
        {
            threadForSearching.Abort();
        }
    }
}
