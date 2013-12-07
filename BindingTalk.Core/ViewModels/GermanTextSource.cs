using System;
using Cirrious.MvvmCross.Localization;

namespace BindingTalk.Core.ViewModels
{
    public class GermanTextSource : IMvxLanguageBinder
    {
        public string GetText(string entryKey)
        {
            switch (entryKey)
            {
                case "Hello":
                    return "Guten Tag";

                case "Yes":
                    return "Ja";
            }

            return "?";
        }

        public string GetText(string entryKey, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}