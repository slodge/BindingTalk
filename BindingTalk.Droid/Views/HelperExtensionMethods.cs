using System;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Droid.Views
{
    public static class HelperExtensionMethods
    {
        public static MvxValueEventSubscription<T> WeakSubscribe<T>(this IMvxInteraction<T> interaction, Action<T> action)
        {
            EventHandler<MvxValueEventArgs<T>> wrappedAction = (sender, args) => action(args.Value);
            return interaction.WeakSubscribe(wrappedAction);
        }
    }
}