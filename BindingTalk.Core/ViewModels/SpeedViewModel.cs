using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public abstract class SpeedViewModel
        : MvxViewModel
    {
        protected SpeedViewModel()
        {
            this.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        private string _timeTaken;
        public string TimeTaken
        {
            get
            {
                return _timeTaken;
            }
            set
            {
                _timeTaken = value;
                RaisePropertyChanged(() => TimeTaken);
            }
        }

        public ICommand GoCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        var start = Environment.TickCount;
                        for (var i = 0; i < 10000; i++)
                        {
                            Value = i;
                        }
                        var end = Environment.TickCount;
                        var time = end - start;
                        TimeTaken = time.ToString();
                    });
            }
        }
    }
}