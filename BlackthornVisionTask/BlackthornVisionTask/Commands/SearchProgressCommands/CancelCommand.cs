using System;
using System.Windows.Input;
using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Commands.SearchProgressCommands
{
    internal class CancelCommand : ICommand
    {
        private readonly SearchProgressWindowViewModel viewModel;

        public CancelCommand(SearchProgressWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.CancelAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
