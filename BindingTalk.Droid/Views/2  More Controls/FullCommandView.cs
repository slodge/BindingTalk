using System;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    public class FullButton : Button
    {
        protected FullButton(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Click += OnClick;
        }

        public FullButton(Context context) : base(context)
        {
            Click += OnClick;
        }

        public FullButton(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Click += OnClick;
        }

        public FullButton(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Click += OnClick;
        }

        private IDisposable _subscription;

        private object _commandParameter;
        public object CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                UpdateEnabled();
            }
        }

        private ICommand _command;
        public ICommand Command
        {
            get { return _command; }
            set
            {
                if (_subscription != null)
                {
                    _subscription.Dispose();
                    _subscription = null;
                }
                
                _command = value;

                if (_command != null)
                {

                    var cec = typeof (ICommand).GetEvent("CanExecuteChanged");
                    _subscription = cec.WeakSubscribe(_command, (s, e) =>
                        {
                            UpdateEnabled();
                        });
                }

                UpdateEnabled();
            }
        }

        private void OnClick(object sender, EventArgs eventArgs)
        {
            if (Command == null)
                return;

            if (Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        private void UpdateEnabled()
        {
            Enabled = ShouldBeEnabled();
        }

        private bool ShouldBeEnabled()
        {
            if (_command == null)
                return false;

            return _command.CanExecute(CommandParameter);
        }
    }

    [Activity(Label = "FullCommand")]
    public class FullCommandView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FullCommandView);
        }
    }
}