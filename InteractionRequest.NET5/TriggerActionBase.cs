using Microsoft.SqlServer.Server;
using Microsoft.Xaml.Behaviors;
using SimpleInteraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleInteraction.NET5
{
    public abstract class TriggerActionBase : TriggerAction<FrameworkElement>
    {

        protected override void Invoke(object parameter)
        {
            var requestEventArgs = (InteractionRequestedEventArgs)parameter;
            if (requestEventArgs != null)
            {
                Execute(requestEventArgs.Parameter, requestEventArgs.Callback);
            }
        }

        protected abstract void Execute(object parameter, Action<object> callback);
    }
}
