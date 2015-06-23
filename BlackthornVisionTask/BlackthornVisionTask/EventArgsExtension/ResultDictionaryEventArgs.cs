using System;
using System.Collections.Generic;

namespace BlackthornVisionTask.EventArgsExtension
{
    internal class ResultDictionaryEventArgs : EventArgs
    {
        public Dictionary<string, string> ResultDictionary { get; private set; }

        public ResultDictionaryEventArgs(Dictionary<string, string> resultDictionary)
        {
            ResultDictionary = resultDictionary;
        }
    }
}
