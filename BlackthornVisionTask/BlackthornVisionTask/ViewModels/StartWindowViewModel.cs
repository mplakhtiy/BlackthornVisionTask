using System;
using System.Windows;
using System.Windows.Input;
using BlackthornVisionTask.Commands.StartWindowCommands;
using BlackthornVisionTask.Events;
using BlackthornVisionTask.Managers;
using BlackthornVisionTask.Views;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BlackthornVisionTask.ViewModels
{
   

    class StartWindowViewModel
    {
        private string folderPath;
       

        public ICommand SelectFolder { get; private set; }

        public ICommand FindDuplicatedFiles { get; private set; }

        public StartWindowViewModel()
        {
            SelectFolder = new SelectFolderCommand(this);
            FindDuplicatedFiles= new FindDuplicatedFilesCommand(this);
        }

        public void SelectFolderAction()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Multiselect = false;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                folderPath = dialog.FileName;
        }

        public void FindDuplicatedFilesAction()
        {
           OnFindDuplicatedFilesButtonPressed(); 
        }
        //public delegate void FindDuplicatedFilesButtonPressedEventHandler(object source, FolderPathEventArgs eventArgs); 

        //public static readonly RoutedEvent FindDuplicatedFilesButtonPressed =
        //    EventManager.RegisterRoutedEvent("FindDuplicatedFilesButtonPressed", RoutingStrategy.Bubble,
        //        typeof (FindDuplicatedFilesButtonPressedEventHandler), typeof (StartWindowViewModel));

        //public event FindDuplicatedFilesButtonPressedEventHandler FindDuplicatedFilesButton;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public delegate void FindDuplicatedFilesButtonPressedEventHandler(object source, FolderPathEventArgs eventArgs);

        public static event FindDuplicatedFilesButtonPressedEventHandler FindDuplicatedFilesButtonPressed;

        public void OnFindDuplicatedFilesButtonPressed()
        {
            if (FindDuplicatedFilesButtonPressed != null)
            {
                FindDuplicatedFilesButtonPressed(this, new FolderPathEventArgs(folderPath));
            }
        }

    }

    
}
