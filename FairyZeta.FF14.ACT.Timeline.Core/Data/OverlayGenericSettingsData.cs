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

        #region #- [Property] double.TitleBarFontSize - ＜タイトルバーフォントサイズ＞ -----
        /// <summary> タイトルバーフォントサイズ </summary>
        private double _TitleBarFontSize;
        /// <summary> タイトルバーフォントサイズ </summary>
        public double TitleBarFontSize
        {
            get { return this._TitleBarFontSize; }
            set
            {
                if (this._TitleBarFontSize == value) return;

                this._TitleBarFontSize = value;
                base.OnPropertyChanged("TitleBarFontSize");
            }
        }
        #endregion
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

        #region #- [Property] int.ContentOpacity - ＜コンテンツの透過率＞ -----
        /// <summary> コンテンツの透過率 </summary>
        private int _ContentOpacity;
        /// <summary> コンテンツの透過率 </summary>
        public int ContentOpacity
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
        #region #- [Property] int.BackgroundOpacity - ＜背景の透過率＞ -----
        /// <summary> 背景の透過率 </summary>
        private int _BackgroundOpacity;
        /// <summary> 背景の透過率 </summary>
        public int BackgroundOpacity
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

        #region #- [Property] bool.TitleBarVisibility - ＜タイトルバーの表示状態＞ -----
        /// <summary> タイトルバーの表示状態 </summary>
        private bool _TitleBarVisibility;
        /// <summary> タイトルバーの表示状態 </summary>
        public bool TitleBarVisibility
        {
            get { return this._TitleBarVisibility; }
            set
            {
                if (this._TitleBarVisibility == value) return;

                this._TitleBarVisibility = value;
                base.OnPropertyChanged("TitleBarVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.ContentHeaderVisibility - ＜コンテンツヘッダーの表示状態＞ -----
        /// <summary> コンテンツヘッダーの表示状態 </summary>
        private bool _ContentHeaderVisibility;
        /// <summary> コンテンツヘッダーの表示状態 </summary>
        public bool ContentHeaderVisibility
        {
            get { return this._ContentHeaderVisibility; }
            set
            {
                if (this._ContentHeaderVisibility == value) return;

                this._ContentHeaderVisibility = value;
                base.OnPropertyChanged("ContentHeaderVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.ContentScrollBarVisibility - ＜コンテンツスクロールバーの表示状態＞ -----
        /// <summary> コンテンツスクロールバーの表示状態 </summary>
        private bool _ContentScrollBarVisibility;
        /// <summary> コンテンツスクロールバーの表示状態 </summary>
        public bool ContentScrollBarVisibility
        {
            get { return this._ContentScrollBarVisibility; }
            set
            {
                if (this._ContentScrollBarVisibility == value) return;

                this._ContentScrollBarVisibility = value;
                base.OnPropertyChanged("ContentScrollBarVisibility");
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
            this.clear();
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
            this.TitleBarFontSize = 12.0;
            this.HeaderFontSize = 12.0;
            this.ContentFontSize = 12.0;
            this.ContentOpacity = 0;
            this.BackgroundOpacity = 60;

            this.TitleBarVisibility = true;
            this.ContentHeaderVisibility = true;
            this.ContentScrollBarVisibility = true;

            return true;
        }

    }
}
