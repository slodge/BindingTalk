using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class FrenchViewModel
        : MvxViewModel
    {
        private IMvxLanguageBinder _textSource = new FrenchTextSource();
        public IMvxLanguageBinder TextSource { get { return _textSource; } }
    }
}