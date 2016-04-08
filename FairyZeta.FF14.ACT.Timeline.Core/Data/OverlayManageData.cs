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

        #region #- [Property] bool.ModalBaseVisibility - ＜モーダルベース表示状態＞ -----
        /// <summary> モーダルベース表示状態 </summary>
        private bool _ModalBaseVisibility;
        /// <summary> モーダルベース表示状態 </summary>
        public bool ModalBaseVisibility
        {
            get { return this._ModalBaseVisibility; }
            set
            {
                if (this._ModalBaseVisibility == value) return;

                this._ModalBaseVisibility = value;
                base.OnPropertyChanged("ModalBaseVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.NowOverlayAddModal - ＜新規オーバーレイ追加モーダル表示＞ -----
        /// <summary> 新規オーバーレイ追加モーダル表示 </summary>
        private bool _NowOverlayAddModalVisibility;
        /// <summary> 新規オーバーレイ追加モーダル表示 </summary>
        public bool NowOverlayAddModalVisibility
        {
            get { return this._NowOverlayAddModalVisibility; }
            set
            {
                if (this._NowOverlayAddModalVisibility == value) return;

                this._NowOverlayAddModalVisibility = value;
                base.OnPropertyChanged("NowOverlayAddModalVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.OverlayDeleteModalVisibility - ＜オーバーレイ削除モーダル表示状態＞ -----
        /// <summary> オーバーレイ削除モーダル表示状態 </summary>
        private bool _OverlayDeleteModalVisibility;
        /// <summary> オーバーレイ削除モーダル表示状態 </summary>
        public bool OverlayDeleteModalVisibility
        {
            get { return this._OverlayDeleteModalVisibility; }
            set
            {
                if (this._OverlayDeleteModalVisibility == value) return;

                this._OverlayDeleteModalVisibility = value;
                base.OnPropertyChanged("OverlayDeleteModalVisibility");
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
            this.ModalBaseVisibility = false;
            this.NowOverlayAddModalVisibility = false;
            this.OverlayDeleteModalVisibility = false;
            this.OverlayManageWindowClosed = false;

            return true;
        }
    }
}
