using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class GermanViewModel
        : MvxViewModel
    {
        private IMvxLanguageBinder _textSource = new GermanTextSource();
        public IMvxLanguageBinder TextSource { get { return _textSource; } }
    }
}