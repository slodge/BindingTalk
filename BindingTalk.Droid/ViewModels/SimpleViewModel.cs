namespace BindingTalk.Droid.ViewModels
{
    public class SimpleViewModel
        : BaseViewModel
    {
        private string _firstName = "Dr";
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        private string _secondName = "Who";
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return _firstName + " " + _secondName; }
        }
    }
}