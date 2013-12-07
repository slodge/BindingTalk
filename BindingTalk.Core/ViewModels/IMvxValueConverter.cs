using System;
using System.Globalization;

namespace BindingTalk.Core.ViewModels
{
    public interface IMvxValueConverter
    {
        object Convert(object value, 
                       Type targetType, 
                       object parameter, 
                       CultureInfo culture);
        object ConvertBack(object value, 
                           Type targetType, 
                           object parameter, 
                           CultureInfo culture);
    }
}