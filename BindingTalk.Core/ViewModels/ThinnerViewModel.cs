using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class ThinnerViewModel
        : MvxViewModel
    {
        public INC<string> FirstName = new NC<string>("Dr");
        public INC<string> SecondName = new NC<string>("Who");

        public void Reset()
        {
            FirstName.Value = "Dr";
            SecondName.Value = "Who";
        }
    }
}