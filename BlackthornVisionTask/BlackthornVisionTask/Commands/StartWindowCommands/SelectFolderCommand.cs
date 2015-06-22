using System;
using System.Windows.Input;
using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Commands.StartWindowCommands
{
    class SelectFolderCommand:ICommand
    {
        private readonly StartWindowViewModel viewModel;

        public SelectFolderCommand(StartWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SelectFolderAction();
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    //add { CommandManager.RequerySuggested += value; }
        //    //remove { CommandManager.RequerySuggested -= value; }
        //}
    }
}
