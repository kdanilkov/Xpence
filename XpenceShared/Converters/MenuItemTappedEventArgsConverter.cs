using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
using XpenceShared.Models;

namespace XpenceShared.Converters
{

    public class MenuItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemTappedEventArgs = value as ItemTappedEventArgs;
            if (itemTappedEventArgs == null)
            {
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
            }
            return (itemTappedEventArgs.Item as HomeMenuItem)?.NavigateUrl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

       
    }

}