using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace FairyZeta.Framework.Controls
{
    public class ColorDialogViewModel : INotifyPropertyChanged
    {
        private PredefinedColor[] predefinedColors;

        public PredefinedColor[] PredefinedColors
        {
            get { return this.predefinedColors ?? (this.predefinedColors = this.EnumlatePredefinedColors()); }
            set
            {
                this.predefinedColors = value;
                this.RaisePropertyChanged();
            }
        }

        private PredefinedColor[] EnumlatePredefinedColors()
        {
            var colors = typeof(Colors).GetProperties();

            var list = new List<PredefinedColor>();
            foreach (var color in colors)
            {
                try
                {
                    list.Add(new PredefinedColor()
                    {
                        Name = color.Name,
                        Color = (Color)ColorConverter.ConvertFromString(color.Name)
                    });
                }
                catch
                {
                }
            }

            return list.OrderBy(x => x.Color.ToString()).ToArray();
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion
    }

    public class PredefinedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
