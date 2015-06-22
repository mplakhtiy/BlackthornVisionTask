using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackthornVisionTask.Events;
using BlackthornVisionTask.ViewModels;
using BlackthornVisionTask.Views;

namespace BlackthornVisionTask.Managers
{
    class ViewManager
    {
        public void OnFindDuplicatedFilesButtonPressed(object source,FolderPathEventArgs eventArgs)
        {
            SearchProgressWindow newSearchProgressWindow= new SearchProgressWindow();
            newSearchProgressWindow.Show();

        }
    }
}
