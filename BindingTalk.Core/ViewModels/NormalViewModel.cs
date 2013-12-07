using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class NormalViewModel
        : MvxViewModel
    {
        private string _firstName = "Dr";

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
                RaisePropertyChanged(() => FullName);
            }
        }

        private string _secondName = "Who";

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                RaisePropertyChanged(() => SecondName);
                RaisePropertyChanged(() => FullName);
            }
        }

        public string FullName
        {
            get { return _firstName + " " + _secondName; }
        }

        public IMvxCommand Reset
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
    }
}