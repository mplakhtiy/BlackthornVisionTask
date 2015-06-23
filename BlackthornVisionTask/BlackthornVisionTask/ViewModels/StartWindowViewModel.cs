using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BlackthornVisionTask.Commands.StartWindowCommands;
using BlackthornVisionTask.Managers;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BlackthornVisionTask.ViewModels
{
    class StartWindowViewModel:INotifyPropertyChanged
    {
        private string folderPath;

        private bool canExecuteFindDuplicatedFiles;
        public bool CanExecuteFindDuplicatedFiles
        {
            get { return canExecuteFindDuplicatedFiles; }
           private set
            {
                canExecuteFindDuplicatedFiles = value;
                OnPropertyChanged();
            }
        }

        public StartWindowViewModel()
        {
            SelectFolder = new SelectFolderCommand(this);
            FindDuplicatedFiles = new FindDuplicatedFilesCommand(this);
        }

        public ICommand SelectFolder { get; private set; }

        public ICommand FindDuplicatedFiles { get; private set; }

        public void SelectFolderAction()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false
            };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                folderPath = dialog.FileName;
            CanExecuteFindDuplicatedFiles = true;
        }

        public void FindDuplicatedFilesAction()
        {
           EventManager.OnFindDuplicatedFilesButtonPressed(this,folderPath);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
