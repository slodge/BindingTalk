using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Normal")]
    public class NormalActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.NormalView);
        }
    }
}