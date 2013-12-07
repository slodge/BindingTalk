using System.Threading;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class AnimatedViewModel
        : MvxViewModel
    {
        private Timer _timer;

        public AnimatedViewModel()
        {
            _timer = new Timer(ignored => Value++, null, 1000, 3000);
        }        

        private int _value;
        public int Value 
        {   
            get { return _value; }
            set { _value = value; RaisePropertyChanged(() => Value); }
        }
    }
}