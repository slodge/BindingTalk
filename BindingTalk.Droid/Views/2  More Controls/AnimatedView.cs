using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views.Animations;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{

    public class AnimatingTextView : TextView
    {
        protected AnimatingTextView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public AnimatingTextView(Context context)
            : base(context)
        {
        }

        public AnimatingTextView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public AnimatingTextView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public string AnimatingText
        {
            get { return base.Text; }
            set
            {                
                var animationFadeOut = new AlphaAnimation(1.0f, 0.0f);
                animationFadeOut.Duration = 500;
                animationFadeOut.AnimationEnd += (sender, args) =>
                {
                    base.Text = value;
                    var animationFadeIn = new AlphaAnimation(0.0f, 1.0f);
                    animationFadeIn.Duration = 500;

                    this.Animation = animationFadeIn;
                };
                this.Animation = animationFadeOut;
            }
        }
    }

    [Activity(Label = "Animated")]
    public class AnimatedActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AnimatedView);
        }
    }
}