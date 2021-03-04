using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInteraction.Core
{
    public class InteractionRequestedEventArgs : EventArgs
    {
        public InteractionRequestedEventArgs() { }

        public InteractionRequestedEventArgs(object paramter)
        {
            this.Parameter = paramter;
        }

        public InteractionRequestedEventArgs(object paramter, Action<object> callback)
        {
            this.Parameter = paramter;
            this.Callback = callback;
        }

        public object Parameter { get; set; }

        public Action<object> Callback { get; set; }
    }
}
