using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイ管理データ
    /// </summary>
    public class OverlayManageData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.NewOverlayAddWindowCloesd - ＜新規オーバーレイウィンドウクローズフラグ＞ -----
        /// <summary> 新規オーバーレイウィンドウクローズフラグ </summary>
        private bool _NewOverlayAddWindowCloesd;
        /// <summary> 新規オーバーレイウィンドウクローズフラグ </summary>
        public bool NewOverlayAddWindowCloesd
        {
            get { return this._NewOverlayAddWindowCloesd; }
            set
            {
                if (this._NewOverlayAddWindowCloesd == value) return;

                this._NewOverlayAddWindowCloesd = value;
                base.OnPropertyChanged("NewOverlayAddWindowCloesd");
            }
        }
        #endregion

        #region #- [Property] bool.OverlayManageWindowClosed - ＜オーバーレイ管理ウィンドウクローズフラグ＞ -----
        /// <summary> オーバーレイ管理ウィンドウクローズフラグ </summary>
        private bool _OverlayManageWindowClosed;
        /// <summary> オーバーレイ管理ウィンドウクローズフラグ </summary>
        public bool OverlayManageWindowClosed
        {
            get { return this._OverlayManageWindowClosed; }
            set
            {
                if (this._OverlayManageWindowClosed == value) return;

                this._OverlayManageWindowClosed = value;
                base.OnPropertyChanged("OverlayManageWindowClosed");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイ管理データ
        /// </summary>
        public OverlayManageData()
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
            this.NewOverlayAddWindowCloesd = false;
            this.OverlayManageWindowClosed = false;

            return true;
        }
    }
}
