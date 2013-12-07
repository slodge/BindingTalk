using Android.App;
using Android.Locations;
using Android.OS;
using BindingTalk.Droid.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Fody")]
    public class FodyActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            DataContext = new FodySimpleViewModel();
            SetContentView(Resource.Layout.ThinningView);
        }
    }
}