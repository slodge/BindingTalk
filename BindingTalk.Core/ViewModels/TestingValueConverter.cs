using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace BindingTalk.Core.ViewModels
{
    public class ConvertThisValueConverter
        : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Blue":
                case "Red":
                case "Green":
                    return value;

                case "Ignored":
                    return MvxBindingConstant.DoNothing;
                
                case "Invalid":
                default:
                    return MvxBindingConstant.UnsetValue;
            }
        }
    }
}