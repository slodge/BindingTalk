using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using BindingTalk.Core.ViewModels;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    public class CustomDrawShapeView : View
    {
        private CustomControlViewModel.Shape _theShape;

        protected CustomDrawShapeView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Init();
        }


        public CustomDrawShapeView(Context context)
            : base(context)
        {
            Init();
        }

        public CustomDrawShapeView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Init();
        }

        public CustomDrawShapeView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Init();
        }

        private void Init()
        {
            this.Clickable = true;
            this.Click += (sender, args) =>
                {
                    switch (TheShape)
                    {
                        case CustomControlViewModel.Shape.Circle:
                            TheShape = CustomControlViewModel.Shape.Square;
                            break;
                        case CustomControlViewModel.Shape.Square:
                            TheShape = CustomControlViewModel.Shape.Triangle;
                            break;
                        case CustomControlViewModel.Shape.Triangle:
                            TheShape = CustomControlViewModel.Shape.Circle;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                };
        }

        public event EventHandler TheShapeChanged;

        public CustomControlViewModel.Shape TheShape
        {
            get { return _theShape; }
            set { _theShape = value; Invalidate(); TheShapeChanged.Raise(this); }
        }
        
        public override void Draw(Android.Graphics.Canvas canvas)
        {
            base.Draw(canvas);

            var rect = new RectF(0, 0, 300, 300);
            switch (TheShape)
            {
                case CustomControlViewModel.Shape.Circle:
                    canvas.DrawOval(rect, new Paint() { Color = Color.Aqua });
                    break;
                case CustomControlViewModel.Shape.Square:
                    canvas.DrawRect(rect, new Paint() { Color = Color.Red });
                    break;
                case CustomControlViewModel.Shape.Triangle:
                    var path = new Path();
                    path.MoveTo(rect.CenterX(), 0);
                    path.LineTo(0, rect.Height());
                    path.LineTo(rect.Width(), rect.Height());
                    path.Close();

                    var paint = new Paint() { Color = Color.Magenta };
                    paint.SetStyle(Paint.Style.Fill);
                    canvas.DrawPath(path, paint);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    [Activity(Label = "Custom Control")]
    public class CustomControlActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CustomControlView);
        }
    }
}