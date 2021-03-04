using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInteraction.Core
{
    public class InteractionRequest : IInteractionRequest
    {
        public event EventHandler<InteractionRequestedEventArgs> Raised;

        public void Raise(object paramter)
        {
            this.Raise(paramter, null);
        }

        public void Raise(object paramter, Action<object> callback)
        {
            if (this.Raised != null)
            {
                Raised(this, new InteractionRequestedEventArgs(paramter, callback));
            }
        }
    }
}
