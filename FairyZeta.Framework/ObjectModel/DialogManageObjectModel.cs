using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using FirstFloor.ModernUI.Windows.Controls;
using FairyZeta.Framework.WPF.Views;
using FairyZeta.Framework.Data;

namespace FairyZeta.Framework.ObjectModel
{
    /// <summary> FZ／ダイアログ管理オブジェクトモデル
    /// <para> * ダイアログを開いたり、ダイアログデータを取得したりする機能を提供 * </para>
    /// </summary>
    public class DialogManageObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> カラーダイアログに設定されているカラーを取得します。
        /// </summary>
        public Color Color
        {
            get { return this.colorDialogView.Color; }
            set { this.colorDialogView.Color = value; }
        }
        /// <summary> フォントダイアログに設定されているフォント情報を取得します。
        /// </summary>
        public FontInfo Font
        {
            get { return this.fontDialogView.FontInfo; }
            set { this.fontDialogView.FontInfo = value; }
        }

        /// <summary> カラーダイアログビュー
        /// </summary>
        private ColorDialogView colorDialogView = new ColorDialogView();
        /// <summary> フォントダイアログビュー
        /// </summary>
        private FontDialogView fontDialogView = new FontDialogView();

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ダイアログ管理オブジェクトモデル／コンストラクタ
        /// </summary>
        public DialogManageObjectModel()
            : base()
        {
            this.initObjectModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.colorDialogView = new ColorDialogView();
            this.fontDialogView = new FontDialogView();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> カラーダイアログを開き、結果をbool値で返却します。
        /// </summary>
        /// <param name="owner"> ダイアログのオーナーウィンドウ </param>
        /// <returns> ダイアログのボタン押下結果 </returns>
        public bool? ShowColorDialog(Window owner = null)
        {
            var dialog = new ModernDialog
            {
                Title = "Please select a color.",
                Content = this.colorDialogView,
                Owner = owner,
                MaxWidth = 1280,
                MaxHeight = 768,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.CanResize,
                Topmost = true,
            };

            dialog.Buttons = new Button[] { dialog.OkButton, dialog.CancelButton };
            dialog.OkButton.Click += (s, e) => this.colorDialogView.Apply();
            dialog.MouseLeftButtonDown += (sender, e) => dialog.DragMove();

            if (dialog.BackgroundContent == null)
            {
                Rectangle rct = new Rectangle();
                rct.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                dialog.BackgroundContent = rct;
            }

            return dialog.ShowDialog();
        }

        /// <summary> フォントダイアログを開き、結果をbool値で返却します。
        /// </summary>
        /// <param name="owner"> ダイアログのオーナーウィンドウ </param>
        /// <returns> ダイアログのボタン押下結果 </returns>
        public bool? ShowFontDialog(Window owner = null)
        {
            var dialog = new ModernDialog
            {
                Title = "Please select a font.",
                Content = this.fontDialogView,
                Owner = owner,
                MaxWidth = 1280,
                MaxHeight = 768,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.CanResize,
                Topmost = true,
            };

            dialog.Buttons = new Button[] { dialog.OkButton, dialog.CancelButton };
            dialog.OkButton.Click += this.fontDialogView.OKBUtton_Click;
            dialog.MouseLeftButtonDown += (sender, e) => dialog.DragMove();

            return dialog.ShowDialog();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
