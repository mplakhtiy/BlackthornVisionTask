using System;
using System.Windows.Input;
using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Commands.StartWindowCommands
{
    internal class FindDuplicatedFilesCommand : ICommand
    {
        private readonly StartWindowViewModel viewModel;

        public FindDuplicatedFilesCommand(StartWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.FindDuplicatedFilesAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}