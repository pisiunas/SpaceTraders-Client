using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceTraders.ViewModels.NavigationGrid;

public class CoordinateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double coordinate = (double)value;
        return 250 + coordinate; // Convert logical coordinate to physical pixel
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
