using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BookRegister.ValueConverters
{
    class BusyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isBusy = (bool)value;
            return isBusy ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
