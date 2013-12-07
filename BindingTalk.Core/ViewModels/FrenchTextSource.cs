using System;
using Cirrious.MvvmCross.Localization;

namespace BindingTalk.Core.ViewModels
{
    public class FrenchTextSource : IMvxLanguageBinder
    {
        public string GetText(string entryKey)
        {
            switch (entryKey)
            {
                case "Hello":
                    return "Bonjour";

                case "Yes":
                    return "Oui";
            }

            return "?";
        }

        public string GetText(string entryKey, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}