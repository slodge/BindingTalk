using System;
using Cirrious.CrossCore.Converters;

namespace BindingTalk.Core.ViewModels
{
    public class SimpleNameValueConverter
        : MvxValueConverter<Type,string>
    {
        protected override string Convert(Type value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            return value.Name.Replace("ViewModel", "").Replace("Principles", " Principles");
        }
    }
}