using System;
using System.Threading;

namespace BlackthornVisionTask.EventArgsExtension
{
    internal class ThreadEventArgs : EventArgs
    {
        public Thread Thread { get; private set; }

        public ThreadEventArgs(Thread thread)
        {
            Thread = thread;
        }
    }
}
