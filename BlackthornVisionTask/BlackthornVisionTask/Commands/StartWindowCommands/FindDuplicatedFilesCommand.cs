using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Commands.StartWindowCommands
{
    class FindDuplicatedFilesCommand:ICommand
    {
         private readonly StartWindowViewModel viewModel;

         public FindDuplicatedFilesCommand(StartWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;//Should depend in ViewModel
        }

        public void Execute(object parameter)
        {
            viewModel.FindDuplicatedFilesAction();
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    //add { CommandManager.RequerySuggested += value; }
        //    //remove { CommandManager.RequerySuggested -= value; }
        //}
    }
}
