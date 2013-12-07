using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }

    // then converters, more complex paths, nested objects, collections, weak references, ....
    // is this interesting? hopefully so
    // speed/performance
    // FallbackValue

    // stuff not convered: trigger, validation, Relative, ElementName
    // doNothing
    // UnsetValue

    // MultiBinding
    // Rio
    // Tibet

    // i18n

    // Commmands
    // Dialogs
    // Collections
}