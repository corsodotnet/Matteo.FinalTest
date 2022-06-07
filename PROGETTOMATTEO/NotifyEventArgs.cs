using System;

namespace PROGETTOMATTEO
{
    public class NotifyEventArgs : EventArgs
    {
        public long NPositivi;
        public NotifyEventArgs(long _NPositivi)
        {
            NPositivi = _NPositivi; 
        }

    }
}
