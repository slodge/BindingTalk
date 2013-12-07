using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using BindingTalk.Core.ViewModels;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Droid.Views
{
    public class ConfirmationView : View
    {
        protected ConfirmationView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ConfirmationView(Context context) : base(context)
        {
        }

        public ConfirmationView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public ConfirmationView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        private IDisposable _subscription;
        private IMvxInteraction<YesNoQuestion> _confirmInteraction;
        public IMvxInteraction<YesNoQuestion> Confirm
        {
            get { return _confirmInteraction; }
            set
            {
                if (_subscription != null)
                {
                    _subscription.Dispose();
                    _subscription = null;
                }
                _confirmInteraction = value;
                if (_confirmInteraction != null)
                {
                    _subscription = _confirmInteraction.WeakSubscribe(DoConfirm);
                }
            }
        }

        private async void DoConfirm(YesNoQuestion question)
        {
            if (await DoConfirm(question.QuestionText))
                question.YesAction();
            else
                question.NoAction();
        }

        private async Task<bool> DoConfirm(string text)
        {
            var tcs = new TaskCompletionSource<bool>();
            
            var builder = new AlertDialog.Builder(Context);
            builder.SetPositiveButton("OK", (s, e) => tcs.SetResult(true));
            builder.SetNegativeButton("Cancel", (s, e) => tcs.SetResult(false));
            builder.SetTitle(text);
            var dlg = builder.Show();
            dlg.CancelEvent += (s, e) => tcs.SetResult(false);

            return await tcs.Task;
        }
    }

    [Activity(Label = "Question")]
    public class QuestionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.QuestionView);
        }
    }
}