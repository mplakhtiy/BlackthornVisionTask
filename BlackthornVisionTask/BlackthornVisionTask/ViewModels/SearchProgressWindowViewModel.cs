using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using BlackthornVisionTask.Commands.SearchProgressCommands;
using BlackthornVisionTask.Managers;

namespace BlackthornVisionTask.ViewModels
{
    internal class SearchProgressWindowViewModel
    {
        private Thread threadForSearching;
        private readonly Thread currentThread = Thread.CurrentThread;
        private readonly Dispatcher mainThreadDispatcher = Dispatcher.CurrentDispatcher;

        private readonly FileManager fileManager = new FileManager();

        private readonly string folderPath;
        private Dictionary<string, string> resultDictionary;

        public ICommand Cancel { get; private set; }

        public SearchProgressWindowViewModel()
        {
            folderPath = EventManager.FolderPath;
            Cancel = new CancelCommand(this);      
            startSearchingInNewThread();       
        }

        public void CancelAction()
        {
            threadForSearching.Abort();
            EventManager.OnCancelButtonPressed(this, EventArgs.Empty);
        }

        private void startSearchingInNewThread()
        {
            threadForSearching = new Thread(findDuplicatedFiles);
            configureThreads();
            threadForSearching.Start();
            onNewThreadStarted();
        }

        private void findDuplicatedFiles()
        {
            resultDictionary = fileManager.FindDuplicatedFiles(folderPath);
            mainThreadDispatcher.Invoke(onDuplicatedFilesFound);
        }

        private void configureThreads()
        {
            currentThread.Priority = ThreadPriority.BelowNormal;
            threadForSearching.Priority = ThreadPriority.BelowNormal;
            threadForSearching.SetApartmentState(ApartmentState.STA);
        }

        private void onDuplicatedFilesFound()
        {
            EventManager.OnDuplicatedFilesFound(this, resultDictionary);
        }

        private void onNewThreadStarted()
        {
            EventManager.OnNewThreadStarted(this, threadForSearching);
        }

    }
}
