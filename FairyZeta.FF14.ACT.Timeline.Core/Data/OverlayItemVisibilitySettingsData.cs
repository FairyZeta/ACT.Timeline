using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイアイテム表示設定データ
    /// </summary>
    public class OverlayItemVisibilitySettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.TimeNoVisibility - ＜タイム番号表示＞ -----
        /// <summary> タイム番号表示 </summary>
        private bool _TimeNoVisibility;
        /// <summary> タイム番号表示 </summary>
        public bool TimeNoVisibility
        {
            get { return this._TimeNoVisibility; }
            set
            {
                if (this._TimeNoVisibility == value) return;

                this._TimeNoVisibility = value;
                base.OnPropertyChanged("TimeNoVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.ActionTimeVisibility - ＜アクション時間表示＞ -----
        /// <summary> アクション時間表示 </summary>
        private bool _ActionTimeVisibility;
        /// <summary> アクション時間表示 </summary>
        public bool ActionTimeVisibility
        {
            get { return this._ActionTimeVisibility; }
            set
            {
                if (this._ActionTimeVisibility == value) return;

                this._ActionTimeVisibility = value;
                base.OnPropertyChanged("ActionTimeVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeVisibility - ＜タイプ表示＞ -----
        /// <summary> タイプ表示 </summary>
        private bool _TypeVisibility;
        /// <summary> タイプ表示 </summary>
        public bool TypeVisibility
        {
            get { return this._TypeVisibility; }
            set
            {
                if (this._TypeVisibility == value) return;

                this._TypeVisibility = value;
                base.OnPropertyChanged("TypeVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobVisibility - ＜ジョブ表示＞ -----
        /// <summary> ジョブ表示 </summary>
        private bool _JobVisibility;
        /// <summary> ジョブ表示 </summary>
        public bool JobVisibility
        {
            get { return this._JobVisibility; }
            set
            {
                if (this._JobVisibility == value) return;

                this._JobVisibility = value;
                base.OnPropertyChanged("JobVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TankModeVisibility - ＜タンクモード表示＞ -----
        /// <summary> タンクモード表示 </summary>
        private bool _TankModeVisibility;
        /// <summary> タンクモード表示 </summary>
        public bool TankModeVisibility
        {
            get { return this._TankModeVisibility; }
            set
            {
                if (this._TankModeVisibility == value) return;

                this._TankModeVisibility = value;
                base.OnPropertyChanged("TankModeVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.ActionVisibility - ＜アクション表示＞ -----
        /// <summary> アクション表示 </summary>
        private bool _ActionVisibility;
        /// <summary> アクション表示 </summary>
        public bool ActionVisibility
        {
            get { return this._ActionVisibility; }
            set
            {
                if (this._ActionVisibility == value) return;

                this._ActionVisibility = value;
                base.OnPropertyChanged("ActionVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.ActiveVisibility - ＜アクティブ表示＞ -----
        /// <summary> アクティブ表示 </summary>
        private bool _ActiveVisibility;
        /// <summary> アクティブ表示 </summary>
        public bool ActiveVisibility
        {
            get { return this._ActiveVisibility; }
            set
            {
                if (this._ActiveVisibility == value) return;

                this._ActiveVisibility = value;
                base.OnPropertyChanged("ActiveVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.AlertVisibility - ＜アラート表示＞ -----
        /// <summary> アラート表示 </summary>
        private bool _AlertVisibility;
        /// <summary> アラート表示 </summary>
        public bool AlertVisibility
        {
            get { return this._AlertVisibility; }
            set
            {
                if (this._AlertVisibility == value) return;

                this._AlertVisibility = value;
                base.OnPropertyChanged("AlertVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JumpVisibility - ＜ジャンプ表示＞ -----
        /// <summary> ジャンプ表示 </summary>
        private bool _JumpVisibility;
        /// <summary> ジャンプ表示 </summary>
        public bool JumpVisibility
        {
            get { return this._JumpVisibility; }
            set
            {
                if (this._JumpVisibility == value) return;

                this._JumpVisibility = value;
                base.OnPropertyChanged("JumpVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイアイテム表示設定データ
        /// </summary>
        public OverlayItemVisibilitySettingsData()
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
            this.TimeNoVisibility = true;
            this.ActionTimeVisibility = false;
            this.TypeVisibility = false;
            this.JobVisibility = false;
            this.TankModeVisibility = false;
            this.ActionVisibility = true;
            this.ActiveVisibility = true;
            this.AlertVisibility = false;
            this.JumpVisibility = false;

            return true;
        }
    }
}
