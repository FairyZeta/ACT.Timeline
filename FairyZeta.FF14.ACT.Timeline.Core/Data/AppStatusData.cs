using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／アプリケーションステータスデータ
    /// </summary>
    public class AppStatusData : _Data
    { 
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] DirectoryStatus.TimelineResourceDirectoryStatus - ＜タイムラインリソースディレクトリ状態＞ -----
        /// <summary> タイムラインリソースディレクトリ状態 </summary>
        private DirectoryStatus _TimelineResourceDirectoryStatus;
        /// <summary> タイムラインリソースディレクトリ状態 </summary>
        public DirectoryStatus TimelineResourceDirectoryStatus
        {
            get { return this._TimelineResourceDirectoryStatus; }
            set
            {
                if (this._TimelineResourceDirectoryStatus == value) return;

                this._TimelineResourceDirectoryStatus = value;
                base.OnPropertyChanged("TimelineResourceDirectoryStatus");
            }
        }
        #endregion
        #region #- [Property] DirectoryStatus.SoundResourceDirectoryStatus - ＜サウンドリソースディレクトリ状態＞ -----
        /// <summary> サウンドリソースディレクトリ状態 </summary>
        private DirectoryStatus _SoundResourceDirectoryStatus;
        /// <summary> サウンドリソースディレクトリ状態 </summary>
        public DirectoryStatus SoundResourceDirectoryStatus
        {
            get { return this._SoundResourceDirectoryStatus; }
            set
            {
                if (this._SoundResourceDirectoryStatus == value) return;

                this._SoundResourceDirectoryStatus = value;
                base.OnPropertyChanged("SoundResourceDirectoryStatus");
            }
        }
        #endregion

        #region #- [Property] TimerStatus.CurrentCombatTimerStatus - ＜現在の戦闘タイマー状態＞ -----
        /// <summary> 現在の戦闘タイマー状態 </summary>
        private TimerStatus _CurrentCombatTimerStatus;
        /// <summary> 現在の戦闘タイマー状態 </summary>
        public TimerStatus CurrentCombatTimerStatus
        {
            get { return this._CurrentCombatTimerStatus; }
            set
            {
                if (this._CurrentCombatTimerStatus == value) return;

                this._CurrentCombatTimerStatus = value;
                base.OnPropertyChanged("CurrentCombatTimerStatus");
            }
        }
        #endregion

        #region #- [Property] TimelineLoadStatus.TimelineLoadStatus - ＜タイムラインロード状態＞ -----
        /// <summary> タイムラインロード状態 </summary>
        private TimelineLoadStatus _TimelineLoadStatus;
        /// <summary> タイムラインロード状態 </summary>
        public TimelineLoadStatus TimelineLoadStatus
        {
            get { return this._TimelineLoadStatus; }
            set
            {
                if (this._TimelineLoadStatus == value) return;

                this._TimelineLoadStatus = value;
                base.OnPropertyChanged("TimelineLoadStatus");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／アプリケーションステータスデータ／コンストラクタ
        /// </summary>
        public AppStatusData()
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
            this.TimelineResourceDirectoryStatus = DirectoryStatus.Init;
            this.SoundResourceDirectoryStatus = DirectoryStatus.Init;
            this.CurrentCombatTimerStatus = TimerStatus.Init;
            this.TimelineLoadStatus = TimelineLoadStatus.Init;
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
