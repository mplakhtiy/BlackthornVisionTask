using System;
using BlackthornVisionTask.EventArgsExtension;
using BlackthornVisionTask.Views;

namespace BlackthornVisionTask.Managers
{
    class ViewManager
    {
        private SearchProgressWindow searchProgressWindowWindow;

        public ViewManager(StartWindow startWindow)
        {
            startWindow.Show();
            EventManager.FindDuplicatedFilesButtonPressed += OnFindDuplicatedFilesButtonPressed;
            EventManager.CancelButtonPressed += OnCancelButtonPressed;
            EventManager.DuplicatedFilesFound += OnDuplicatedFilesFound;
        }

        private void OnDuplicatedFilesFound(object source, ResultDictionaryEventArgs eventargs)
        {
            searchProgressWindowWindow.Close();
            ResultWindow resultWindow = new ResultWindow();
            resultWindow.Show();
        }

        private void OnCancelButtonPressed(object source, EventArgs eventargs)
        {
            searchProgressWindowWindow.Close();
        }

        private void OnFindDuplicatedFilesButtonPressed(object source, FolderPathEventArgs eventArgs)
        {
            searchProgressWindowWindow=new SearchProgressWindow();
            searchProgressWindowWindow.Show();
        }
    }
}
