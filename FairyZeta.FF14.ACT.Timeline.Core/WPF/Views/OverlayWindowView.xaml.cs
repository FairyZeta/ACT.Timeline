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
using FairyZeta.Framework;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Views
{
    /// <summary> オーバーレイ表示ウィンドウ
    /// </summary>
    public partial class OverlayWindowView : Window
    {
        public OverlayWindowView()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();
        }
        
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            var helper = new WindowInteropHelper(this);
            var exStyle = WindowsServices.GetWindowLontPtr(helper.Handle, (int)WindowsServices.GetWindowLongFields.GWL_EXSTYLE).ToInt32();
            exStyle = exStyle | (int)WindowsServices.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            WindowsServices.SetWindowLongPtr(helper.Handle, (int)WindowsServices.GetWindowLongFields.GWL_EXSTYLE, new IntPtr(exStyle));
        }
        
    }
}
