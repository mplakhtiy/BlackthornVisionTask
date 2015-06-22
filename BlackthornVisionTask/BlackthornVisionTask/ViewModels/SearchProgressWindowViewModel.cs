using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlackthornVisionTask.Commands.SearchProgressCommands;

namespace BlackthornVisionTask.ViewModels
{
    class SearchProgressWindowViewModel
    {
        public ICommand Cancel { get; private set; }

        public SearchProgressWindowViewModel()
        {
            Cancel = new CancelCommand(this);

        }

        public void CancelAction()
        {
            
        }
    }
}
