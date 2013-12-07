using System;
using System.Collections.Generic;
using Cirrious.CrossCore.UI;
using Cirrious.MvvmCross.Plugins.Color;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private List<Type> _types;
        public List<Type> Types
        {
            get { return _types; }
        }

        public IMvxCommand Go
        {
            get { return new MvxCommand<Type>(t => ShowViewModel(t));}
        }

        public FirstViewModel()
        {
            _types = new List<Type>()
                {
                    typeof(FirstPrinciplesViewModel),
                    typeof(SecondPrinciplesViewModel),
                    typeof(ThirdPrinciplesViewModel),
                    typeof(FourthPrinciplesViewModel),
                    typeof(PathViewModel),
                    typeof(ConvertersViewModel),
                    typeof(AnimatedViewModel),
                    typeof(FavoritesViewModel),
                    typeof(MappingViewModel),
                    typeof(CustomControlViewModel),
                    typeof(FullCommandViewModel),
                    typeof(QuestionViewModel),
                    typeof(FrenchViewModel),
                    typeof(GermanViewModel),
                    typeof(German2ViewModel),
                    typeof(FodyViewModel),
                    typeof(NormalViewModel),
                    typeof(ThinnerViewModel),
                    typeof(MultiViewModel),
                    typeof(Speed1ViewModel),
                    typeof(Speed2ViewModel),
                    typeof(Speed3ViewModel),
                    typeof(Speed4ViewModel),
                    typeof(Speed5ViewModel),
                    typeof(Speed6ViewModel),
                    typeof(Speed7ViewModel),
                };
        }
    }
}
