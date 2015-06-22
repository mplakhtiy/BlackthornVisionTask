using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackthornVisionTask.Events
{
    public class FolderPathEventArgs : EventArgs
    {
        public FolderPathEventArgs(string folderPath)
        {
            FolderPath = folderPath;
        }
        public string FolderPath { get; private set; }
    }
}
