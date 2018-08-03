using System;
using System.Globalization;
using Xamarin.Forms;

namespace XpenceShared.Converters
{
    public class DecimalToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (decimal.TryParse(value != null ? value.ToString() : "0", out var dcm))
            {
                return dcm.ToString("F2",culture);
            }
            return 0.ToString("F2", culture);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

