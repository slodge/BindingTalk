using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class FullCommandViewModel
        : MvxViewModel
    {
        public FullCommandViewModel()
        {
            _goCommand = new MvxCommand(() => DoGo(), () => CanGo);
        }

        private MvxCommand _goCommand;
        public ICommand GoCommand
        {
            get { return _goCommand; }
        }

        private int _clicked;
        public int Clicked 
        {   
            get { return _clicked; }
            set { _clicked = value; RaisePropertyChanged(() => Clicked); }
        }

        private bool _canGo;
        public bool CanGo 
        {   
            get { return _canGo; }
            set { _canGo = value; RaisePropertyChanged(() => CanGo); _goCommand.RaiseCanExecuteChanged(); }
        }

        private void DoGo()
        {
            Clicked++;
        }
    }
}