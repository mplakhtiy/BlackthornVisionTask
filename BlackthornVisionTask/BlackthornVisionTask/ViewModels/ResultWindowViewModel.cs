using System.Collections.Generic;
using BlackthornVisionTask.Managers;

namespace BlackthornVisionTask.ViewModels
{
    internal class ResultWindowViewModel
    {
        public Dictionary<string, string> ResultDictionary { get; private set; }
 
        public ResultWindowViewModel()
        {
            ResultDictionary = EventManager.ResultDictionary;
        }
    }
}
