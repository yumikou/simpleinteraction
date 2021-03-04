using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace SimpleInteraction.WPF
{
    public class InteractionRequestTrigger: EventTrigger
    {
        protected override string GetEventName()
        {
            return "Raised";
        }
    }
}
