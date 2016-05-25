using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FairyZeta.Framework.Data;
using Prism.Mvvm;

namespace FairyZeta.Framework.WPF.Design
{
    /// <summary> FZ／[デザイン用]カラーパレットデータ
    /// </summary>
    public class Design_ColorPaletteData : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] ColorPaletteData.ColorPalette - ＜カラーパレットデータ＞ -----
        /// <summary> カラーパレットデータ </summary>
        private ColorPaletteData _ColorPalette;
        /// <summary> カラーパレットデータ </summary>    
        public ColorPaletteData ColorPalette
        {
            get { return _ColorPalette; }
            set { this.SetProperty(ref this._ColorPalette, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／[デザイン用]カラーパレットデータ／コンストラクタ
        /// </summary>
        public Design_ColorPaletteData()
            : base()
        {
            this.initDesignData();
            this.createDesignData_P001();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デザインデータの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDesignData()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private void createDesignData_P001()
        {
            this.ColorPalette = new ColorPaletteData();
            this.ColorPalette.PaletteName = "パレット名";
            this.ColorPalette.AddColorCollection(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
            this.ColorPalette.AddColorCollection(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
            this.ColorPalette.AddColorCollection(Color.FromArgb(0xFF, 0x00, 0x00, 0xFF));
        }

    }
}
