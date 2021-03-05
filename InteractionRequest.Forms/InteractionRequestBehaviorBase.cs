using SimpleInteraction.Core;
using System;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SimpleInteraction.Forms
{
	public abstract class InteractionRequestBehaviorBase : InheritBindingBehavior<VisualElement>
	{
		public static readonly BindableProperty SourceObjectProperty =
			BindableProperty.Create("SourceObject", typeof(IInteractionRequest), typeof(InteractionRequestBehaviorBase), propertyChanged: OnSourceObjectChanged);

		public IInteractionRequest SourceObject
		{
			get => (IInteractionRequest)GetValue(SourceObjectProperty);
			set => SetValue(SourceObjectProperty, value);
		}

		private static void OnSourceObjectChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (InteractionRequestBehaviorBase)bindable;
			var oldRequest = (IInteractionRequest)oldValue;
			if (oldRequest != null)
			{
				oldRequest.Raised -= behavior.OnRaised;
			}
			var newRequest = (IInteractionRequest)newValue;
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
