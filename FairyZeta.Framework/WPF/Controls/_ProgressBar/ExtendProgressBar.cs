using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FairyZeta.Framework.WPF.Controls
{
    /// <summary> FZ／機能拡張型プログレスバー
    /// </summary>
    public class ExtendProgressBar : GradientProgressBar
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty BaseCornerRadiusProperty =
                    DependencyProperty.Register("BaseCornerRadius", typeof(CornerRadius), typeof(GradientProgressBar), new FrameworkPropertyMetadata(default(CornerRadius)));
        public static readonly DependencyProperty InnerCornerRadiusProperty =
                    DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(GradientProgressBar), new FrameworkPropertyMetadata(default(CornerRadius)));


        public CornerRadius BaseCornerRadius
        {
            get { return (CornerRadius)GetValue(BaseCornerRadiusProperty); }
            set { SetValue(BaseCornerRadiusProperty, value); }
        }
        public CornerRadius InnerCornerRadius
        {
            get { return (CornerRadius)GetValue(InnerCornerRadiusProperty); }
            set { SetValue(InnerCornerRadiusProperty, value); }
        }

        public ObservableCollection<Brush> ProgressValueBrushCollection { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／機能拡張型プログレスバー／コンストラクタ
        /// </summary>
        public ExtendProgressBar()
            : base()
        {
            this.initControl();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コントロールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initControl()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
