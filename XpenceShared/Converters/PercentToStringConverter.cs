using System;
using System.Globalization;
using Xamarin.Forms;

namespace XpenceShared.Converters
{
    public class PercentToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (double)value;

            return item.ToString() + " %";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
