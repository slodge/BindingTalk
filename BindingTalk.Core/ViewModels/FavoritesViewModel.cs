using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class FavoritesViewModel
        : MvxViewModel
    {
        private bool _isFavorite1;
        public bool IsFavorite1 
        {   
            get { return _isFavorite1; }
            set { _isFavorite1 = value; RaisePropertyChanged(() => IsFavorite1); }
        }

        private bool _isFavorite2;
        public bool IsFavorite2
        {
            get { return _isFavorite2; }
            set { _isFavorite2 = value; RaisePropertyChanged(() => IsFavorite2); }
        }

        private bool _isFavorite3;
        public bool IsFavorite3
        {
            get { return _isFavorite3; }
            set { _isFavorite3 = value; RaisePropertyChanged(() => IsFavorite3); }
        }
    }
}