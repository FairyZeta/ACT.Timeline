using System;
using System.Windows.Data;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Converter
{
    public class ColorToShadowColorConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only touch the shadow color if it's a solid color, do not mess up other fancy effects
            if (value is SolidColorBrush)
            {
                Color color = ((SolidColorBrush)value).Color;
                var r = Transform(color.R);
                var g = Transform(color.G);
                var b = Transform(color.B);

                // return with Color and not SolidColorBrush, otherwise it will not work
                // This means that most likely the Color -> SolidBrushColor conversion does the RBG -> sRBG conversion somewhere...
                return Color.FromArgb(color.A, r, g, b);
            }

            return value;
        }

        private byte Transform(byte source)
        {
            // see http://en.wikipedia.org/wiki/SRGB
            return (byte)(Math.Pow(source / 255d, 1 / 2.2d) * 255);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ColorToShadowColorConverter is a OneWay converter.");
        }

        #endregion
    }
}
