using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    public class FavoritesButtonBinding
        : MvxAndroidTargetBinding
    {
        protected Button Button
        {
            get { return (Button)Target; }
        }

        private bool _currentValue;

        public FavoritesButtonBinding(Button button)
            : base(button)
        {
            button.Click += ButtonOnClick;
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            _currentValue = !_currentValue;
            SetButtonBackground();
            FireValueChanged(_currentValue);
        }

        protected override void SetValueImpl(object target, object value)
        {
            var boolValue = (bool)value;
            _currentValue = boolValue;
            SetButtonBackground();
        }

        private void SetButtonBackground()
        {
            var button = Button;
            if (button == null)
                return;

            if (_currentValue)
            {
                button.SetBackgroundResource(Resource.Drawable.star_gold_selector);
            }
            else
            {
                button.SetBackgroundResource(Resource.Drawable.star_grey_selector);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var button = Button;
                if (button != null)
                {
                    button.Click -= ButtonOnClick;
                }
            }
            base.Dispose(isDisposing);
        }

        public override Type TargetType
        {
            get { return typeof(bool); }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }
    }

    [Activity(Label = "Favorites")]
    public class FavoritesActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FavoritesView);
        }
    }

}