using Android.App;
using Android.OS;
using Android.Widget;
using BindingTalk.Droid.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Fourth Principles")]
    public class FourthPrinciplesView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            DataContext = new SimpleViewModel();
            SetContentView(Resource.Layout.FourthPrinciplesView);

            var firstNameEdit = FindViewById<EditText>(Resource.Id.FirstNameEdit);
            var secondNameEdit = FindViewById<EditText>(Resource.Id.SecondNameEdit);
            var fullNameLabel = FindViewById<TextView>(Resource.Id.FullNameLabel);

            var set = this.CreateBindingSet<FourthPrinciplesView, SimpleViewModel>();
            set.Bind(firstNameEdit).For(v => v.Text).To(vm => vm.FirstName).TwoWay();
            set.Bind(secondNameEdit).For(v => v.Text).To(vm => vm.SecondName).TwoWay();
            set.Bind(fullNameLabel).For(v => v.Text).To(vm => vm.FullName).OneWay();
            set.Apply();
        }
    }
}