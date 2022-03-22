using System;
using System.Globalization;
using System.Windows.Data;

namespace CreateMapSample.Converters
{
    public class HalfDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double visiable))
            {
                return visiable / 2;
            }

            return targetType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
