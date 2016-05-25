using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using FairyZeta.Framework.Data;

namespace FairyZeta.Framework.WPF.Views
{
    /// <summary> FZ／ColorPaletteView
    /// </summary>
    public partial class ColorPaletteView : UserControl
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty ColorPaletteProperty
            = DependencyProperty.Register("ColorPalette", typeof(string), typeof(ColorPaletteView), new FrameworkPropertyMetadata(null, OnColorPaletteChanged));

        public ColorPaletteData ColorPalette
        {
            get { return (ColorPaletteData)GetValue(ColorPaletteProperty); }
            set { SetValue(ColorPaletteProperty, value); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ColorPaletteView／コンストラクタ
        /// </summary>
        public ColorPaletteView()
        {
            this.InitializeComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ColorPalette変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnColorPaletteChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ColorPaletteView ctrl = obj as ColorPaletteView;
            if (ctrl != null)
            {
            }
        }
    }
}
