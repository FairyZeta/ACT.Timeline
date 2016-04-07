using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ一般設定データ
    /// </summary>
    public class OverlayGenericSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] double.HeaderFontSize - ＜ヘッダーフォントサイズ＞ -----
        /// <summary> ヘッダーフォントサイズ </summary>
        private double _HeaderFontSize;
        /// <summary> ヘッダーフォントサイズ </summary>
        public double HeaderFontSize
        {
            get { return this._HeaderFontSize; }
            set
            {
                if (this._HeaderFontSize == value) return;

                this._HeaderFontSize = value;
                base.OnPropertyChanged("HeaderFontSize");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.ContentFontSize - ＜コンテンツフォントサイズ＞ -----
        /// <summary> コンテンツフォントサイズ </summary>
        private double _ContentFontSize;
        /// <summary> コンテンツフォントサイズ </summary>
        public double ContentFontSize
        {
            get { return this._ContentFontSize; }
            set
            {
                if (this._ContentFontSize == value) return;

                this._ContentFontSize = value;
                base.OnPropertyChanged("ContentFontSize");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] double.ContentOpacity - ＜コンテンツの透過率＞ -----
        /// <summary> コンテンツの透過率 </summary>
        private double _ContentOpacity;
        /// <summary> コンテンツの透過率 </summary>
        public double ContentOpacity
        {
            get { return this._ContentOpacity; }
            set
            {
                if (this._ContentOpacity == value) return;

                this._ContentOpacity = value;
                base.OnPropertyChanged("ContentOpacity");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.BackgroundOpacity - ＜背景の透過率＞ -----
        /// <summary> 背景の透過率 </summary>
        private double _BackgroundOpacity;
        /// <summary> 背景の透過率 </summary>
        public double BackgroundOpacity
        {
            get { return this._BackgroundOpacity; }
            set
            {
                if (this._BackgroundOpacity == value) return;

                this._BackgroundOpacity = value;
                base.OnPropertyChanged("BackgroundOpacity");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ一般設定データ／コンストラクタ
        /// </summary>
        public OverlayGenericSettingsData()
            : base()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.HeaderFontSize = 12.0;
            this.ContentFontSize = 12.0;
            this.ContentOpacity = 0.7;
            this.BackgroundOpacity = 0.7;

            return true;
        }

    }
}
