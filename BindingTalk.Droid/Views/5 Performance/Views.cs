using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BindingTalk.Core.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Speed 1")]
    public class Speed1View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed1);
        }
    }

    public class MyTextView
        : Android.Widget.TextView
    {
        public MyTextView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            /*
            this.TextChanged += (sender, e) => {
                ReflectTextChanged.Raise(this);
            };
            */
        }
        public string ReflectText
        {
            get { return Text; }
            set { Text = value; }
        }

        public event EventHandler ReflectTextChanged;
    }


    [Activity(Label = "Speed 2")]
    public class Speed2View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed2);
        }
    }

    [Activity(Label = "Speed 3")]
    public class Speed3View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed3);
        }
    }

    [Activity(Label = "Speed 4")]
    public class Speed4View : MvxActivity
    {
        private MyTextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed4);

            _textView = FindViewById<MyTextView>(Resource.Id.myTextView);
            ((Speed4ViewModel)ViewModel).PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Value")
                {
                    _textView.ReflectText = ((Speed4ViewModel)ViewModel).Value.ToString();
                }
            };
        }
    }

    [Activity(Label = "Speed 5")]
    public class Speed5View : MvxActivity
    {
        private Android.Widget.TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed5);

            _textView = FindViewById<Android.Widget.TextView>(Resource.Id.myTextView);
            ((Speed5ViewModel)ViewModel).PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Value")
                {
                    _textView.Text = ((Speed5ViewModel)ViewModel).Value.ToString();
                }
            };
        }
    }

    [Activity(Label = "Speed 6")]
    public class Speed6View : MvxActivity
    {
        private Android.Widget.TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed6);

            _textView = FindViewById<Android.Widget.TextView>(Resource.Id.myTextView);
            var viewModel = (Speed6ViewModel)ViewModel;
            viewModel.PropertyChanged += (sender, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Value":
                        {
                            _textView.Text = viewModel.Value.ToString();
                        }
                        break;
                    case "TimeTaken":
                        {
                            var tt = FindViewById<Android.Widget.TextView>(Resource.Id.timeTakenText);
                            tt.Text = viewModel.TimeTaken;
                        }
                        break;
                }
            };
            _textView.TextChanged += (sender, args) => { };
            var b = FindViewById<Android.Widget.Button>(Resource.Id.goButton);
            b.Click += (sender, e) => viewModel.GoCommand.Execute(null);

        }
    }

    [Activity(Label = "Speed 7")]
    public class Speed7View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Speed7);
        }
    }
}