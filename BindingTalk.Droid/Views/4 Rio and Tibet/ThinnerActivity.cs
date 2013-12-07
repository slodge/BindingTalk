using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Thinner")]
    public class ThinnerActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ThinningView);
        }
    }
}