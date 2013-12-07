using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class MultiViewModel
        : MvxViewModel
    {
        private string _textValue1;
        public string TextValue1 
        {   
            get { return _textValue1; }
            set { _textValue1 = value; RaisePropertyChanged(() => TextValue1); }
        }

        private string _textValue2;
        public string TextValue2 
        {   
            get { return _textValue2; }
            set { _textValue2 = value; RaisePropertyChanged(() => TextValue2); }
        }

        private bool _checkValue1;
        public bool CheckValue1 
        {   
            get { return _checkValue1; }
            set { _checkValue1 = value; RaisePropertyChanged(() => CheckValue1); }
        }

        private bool _checkValue2;
        public bool CheckValue2 
        {   
            get { return _checkValue2; }
            set { _checkValue2 = value; RaisePropertyChanged(() => CheckValue2); }
        }

        private double _doubleValue1;
        public double DoubleValue1 
        {   
            get { return _doubleValue1; }
            set { _doubleValue1 = value; RaisePropertyChanged(() => DoubleValue1); }
        }
    }
}