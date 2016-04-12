using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using FirstFloor.ModernUI.Windows.Controls;

namespace FairyZeta.Framework.Controls
{
    public class ColorDialog
    {
        private ColorDialogContent content = new ColorDialogContent();

        public Color Color
        {
            get { return this.content.Color; }
            set { this.content.Color = value; }
        }

        public bool? ShowDialog(
            Window owner = null)
        {
            var dialog = new ModernDialog
            {
                Title = "Please select a color.",
                Content = this.content,
                Owner = owner,
                MaxWidth = 1280,
                MaxHeight = 768,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            dialog.Buttons = new Button[] { dialog.OkButton, dialog.CancelButton };
            dialog.OkButton.Click += (s, e) => this.content.Apply();

            return dialog.ShowDialog();
        }
    }
}
