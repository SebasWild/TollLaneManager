using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AutomatedRoadTollingSystem.Converters
{
    class StatusToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Incoming value will be an int. An int with value 0 means green - all clear, 1 means yellow - some issues, and 2 means red - fatal issues with the toll lane.
            int status = (int)value;
            Brush result;                           //SolidColorBrush that represents the color of the Ellipses
            switch(status)
            {
                case 0: result  = Brushes.Green;
                    break;
                case 1: result = Brushes.DarkOrange;
                    break;
                case 2: result = Brushes.Red;
                    break;
                default: result  = Brushes.Green;
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
