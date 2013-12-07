using System;
using System.Windows.Input;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class Speed7ViewModel
        : MvxViewModel
    {
        public Speed7ViewModel()
        {
            this.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
        }

        public INC<int> Value = new NC<int>(); 

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
                            Value.Value = i;
                        }
                        var end = Environment.TickCount;
                        var time = end - start;
                        TimeTaken = time.ToString();
                    });
            }
        }
    }
}