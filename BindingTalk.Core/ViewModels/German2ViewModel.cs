using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class German2ViewModel
        : MvxViewModel
    {
        private GermanTextSource _textSource = new GermanTextSource();
        public string this[string index]
        {
            get { return _textSource.GetText(index); }
        }
    }
}