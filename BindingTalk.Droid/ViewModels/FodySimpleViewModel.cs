using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using PropertyChanged;

namespace BindingTalk.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class FodySimpleViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName { get { return FirstName + " " + SecondName; } }

        public ICommand Reset
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        FirstName = "Dr";
                        SecondName = "Who";
                    });
            }
        }

        public FodySimpleViewModel()
        {
            FirstName = "First";
            SecondName = "Second";
        }
    }
}