using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ画面データ
    /// </summary>
    [Serializable]
    public class OverlayWindowData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] double.WindowWidth - ＜ウィンドウの幅＞ -----
        /// <summary> ウィンドウの高さ </summary>
        private double _WindowWidth;
        /// <summary> ウィンドウの高さ </summary>
        public double WindowWidth
        {
            get { return this._WindowWidth; }
            set
            {
                if (this._WindowWidth == value) return;

                this._WindowWidth = value;
                base.OnPropertyChanged("WindowWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.WindowHeight - ＜ウィンドウの高さ＞ -----
        /// <summary> ウィンドウの高さ </summary>
        private double _WindowHeight;
        /// <summary> ウィンドウの高さ </summary>
        public double WindowHeight
        {
            get { return this._WindowHeight; }
            set
            {
                if (this._WindowHeight == value) return;

                this._WindowHeight = value;
                base.OnPropertyChanged("WindowHeight");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.WindowTop - ＜ウィンドウ軸Y＞ -----
        /// <summary> ウィンドウ軸Y </summary>
        private double _WindowTop;
        /// <summary> ウィンドウ軸Y </summary>
        public double WindowTop
        {
            get { return this._WindowTop; }
            set
            {
                if (this._WindowTop == value) return;

                this._WindowTop = value;
                base.OnPropertyChanged("WindowTop");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.WindowLeft - ＜ウィンドウ軸X＞ -----
        /// <summary> ウィンドウ軸X </summary>
        private double _WindowLeft;
        /// <summary> ウィンドウ軸X </summary>
        public double WindowLeft
        {
            get { return this._WindowLeft; }
            set
            {
                if (this._WindowLeft == value) return;

                this._WindowLeft = value;
                base.OnPropertyChanged("WindowLeft");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.WindowVisibility - ＜ウィンドウの表示状態＞ -----
        /// <summary> ウィンドウの表示状態 </summary>
        private bool _WindowVisibility;
        /// <summary> ウィンドウの表示状態 </summary>
        public bool WindowVisibility
        {
            get { return this._WindowVisibility; }
            set
            {
                if (this._WindowVisibility == value) return;

                this._WindowVisibility = value;
                base.OnPropertyChanged("WindowVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] OverlayType.OverlayType - ＜オーバーレイタイプ＞ -----
        /// <summary> オーバーレイタイプ </summary>
        private OverlayType _OverlayType;
        /// <summary> オーバーレイタイプ </summary>
        public OverlayType OverlayType
        {
            get { return this._OverlayType; }
            set
            {
                if (this._OverlayType == value) return;

                this._OverlayType = value;
                base.OnPropertyChanged("OverlayType");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.OverlayName - ＜オーバーレイ名称＞ -----
        /// <summary> オーバーレイ名称 </summary>
        private string _OverlayName;
        /// <summary> オーバーレイ名称 </summary>
        public string OverlayName
        {
            get { return this._OverlayName; }
            set
            {
                if (this._OverlayName == value) return;

                this._OverlayName = value;
                base.OnPropertyChanged("OverlayName");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.WindowLock - ＜ウィンドウロック状態＞ -----
        /// <summary> ウィンドウロック状態 </summary>
        private bool _WindowLock;
        /// <summary> ウィンドウロック状態 </summary>
        public bool WindowLock
        {
            get { return this._WindowLock; }
            set
            {
                if (this._WindowLock == value) return;

                this._WindowLock = value;
                base.OnPropertyChanged("WindowLock");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        /// <summary> 画面のIntPrt
        /// </summary>
        [XmlIgnore]
        public IntPtr WindowIntPrt { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ画面データ／コンストラクタ
        /// </summary>
        public OverlayWindowData()
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
            this.WindowVisibility = false;
            this.WindowLock = false;
            return true;
        }
    }
}
