using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class ConvertersViewModel
        : MvxViewModel
    {
        private string value;
        public string Value 
        {   
            get { return value; }
            set { this.value = value; RaisePropertyChanged(() => Value); }
        }

        private List<string> _choices = new List<string>()
            {
                "Blue",
                "Red",
                "Green",
                "Invalid",
                "Ignored"
            };
        public List<string> Choices 
        {   
            get { return _choices; }
            set { _choices = value; RaisePropertyChanged(() => Choices); }
        }
    }
}