using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using FairyZeta.Core.Process;

namespace FairyZeta.Framework.WPF.Converters
{
    public class StringToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringParserProcess parser = new StringParserProcess();

            var list = parser.CreateParseStringList(value.ToString(), ",", true, true);

            return new Thickness(System.Convert.ToDouble(list[0]), System.Convert.ToDouble(list[1]), System.Convert.ToDouble(list[2]), System.Convert.ToDouble(list[3]));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness t = (Thickness)parameter;
            return  string.Format("{0},{1},{2},{3}",t.Left, t.Top, t.Right, t.Bottom);
        }
    }
}
