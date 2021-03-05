using Microsoft.Xaml.Interactions.Core;
using Microsoft.Xaml.Interactivity;
using SimpleInteraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace InteractionRequest.UWP
{
    public abstract class InteractionRequestBehaviorBase: Behavior
    {
		public static readonly DependencyProperty SourceObjectProperty =
			DependencyProperty.Register("SourceObject", typeof(IInteractionRequest), typeof(InteractionRequestBehaviorBase), new PropertyMetadata(null, OnSourceObjectChanged));

		public IInteractionRequest SourceObject
		{
			get => (IInteractionRequest)GetValue(SourceObjectProperty);
			set => SetValue(SourceObjectProperty, value);
		}

		private static void OnSourceObjectChanged(DependencyObject dpobj, DependencyPropertyChangedEventArgs e)
		{
			var behavior = (InteractionRequestBehaviorBase)dpobj;
			var oldRequest = (IInteractionRequest)e.OldValue;
			if (oldRequest != null)
			{
				oldRequest.Raised -= behavior.OnRaised;
			}
			var newRequest = (IInteractionRequest)e.NewValue;
			if (newRequest != null)
			{
				newRequest.Raised += behavior.OnRaised;
			}
		}

		protected void OnRaised(object sender, InteractionRequestedEventArgs eventArgs)
		{
			if (eventArgs != null)
			{
				Execute(eventArgs.Parameter, eventArgs.Callback);
			}
		}

		protected abstract void Execute(object parameter, Action<object> callback);
	}
}
