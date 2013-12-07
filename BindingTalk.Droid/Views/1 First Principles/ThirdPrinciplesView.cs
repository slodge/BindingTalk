using Android.App;
using Android.OS;
using Android.Views.Animations;
using BindingTalk.Droid.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Third Principles")]
    public class ThirdPrinciplesView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            DataContext = new SimpleViewModel();
            SetContentView(Resource.Layout.ThirdPrinciplesView);
        }
    }
}