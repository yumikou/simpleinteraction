using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInteraction.Core
{
    public interface IInteractionRequest
    {
        event EventHandler<InteractionRequestedEventArgs> Raised;
    }
}
