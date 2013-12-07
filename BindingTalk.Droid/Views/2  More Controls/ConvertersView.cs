using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Converters")]
    public class ConvertersView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ConvertersView);
        }
    }

    public class ColoredView : View
    {
        protected ColoredView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ColoredView(Context context) : base(context)
        {
        }

        public ColoredView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public ColoredView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        private string _showColor;
        public string ShowColor 
        {   
            get { return _showColor; }
            set
            {
                if (_showColor == value)
                    return;

                _showColor = value;
                switch (_showColor)
                {
                    case "Blue":
                        SetBackgroundColor(Color.Blue);
                        return;
                    case "Red":
                        SetBackgroundColor(Color.Red);
                        return;
                    case "Green":
                        SetBackgroundColor(Color.Green);
                        return;
                    case "White":
                        SetBackgroundColor(Color.White);
                        return;
                }
            }
        }
    }
}