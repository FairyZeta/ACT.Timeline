using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ画面データ
    /// </summary>
    public class OverlayWindowData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public int WindowID;

        public string WindowName;

        public double WindowWidth;
        public double WindowHeight;
        public double WindowTop;
        public double WindowLeft;

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
            }
        }
        #endregion

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
            return true;
        }
    }
}
