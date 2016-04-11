using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／タイマーデータ
    /// </summary>
    public class TimerData : _Data
    {

      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] double.CurrentCombatTime - ＜現在の戦闘時間＞ -----
        /// <summary> 現在の時間 </summary>
        private double _CurrentCombatTime;
        /// <summary> 現在の時間 </summary>
        public double CurrentCombatTime
        {
            get { return this._CurrentCombatTime; }
            set
            {
                if (this._CurrentCombatTime == value) return;

                this._CurrentCombatTime = value;
                base.OnPropertyChanged("CurrentCombatTime");
            }
        }
        #endregion

        #region #- [Property] double.CurrentCombatEndTime - ＜現在の戦闘終了時間＞ -----
        /// <summary> 現在の終了時間 </summary>
        private double _CurrentCombatEndTime;
        /// <summary> 現在の終了時間 </summary>
        public double CurrentCombatEndTime
        {
            get { return this._CurrentCombatEndTime; }
            set
            {
                if (this._CurrentCombatEndTime == value) return;

                this._CurrentCombatEndTime = value;
                base.OnPropertyChanged("CurrentCombatEndTime");
            }
        }
        #endregion

        #region #- [Property] double.CurrentCombatStartTime - ＜現在の開始時間＞ -----
        /// <summary> 現在の開始時間 </summary>
        private double _CurrentCombatStartTime;
        /// <summary> 現在の開始時間 </summary>
        public double CurrentCombatStartTime
        {
            get { return this._CurrentCombatStartTime; }
            set
            {
                if (this._CurrentCombatStartTime == value) return;

                this._CurrentCombatStartTime = value;
                base.OnPropertyChanged("CurrentCombatStartTime");
            }
        }
        #endregion


        /// <summary> タイムライン／タイマーデータ／コンストラクタ
        /// </summary>
        public TimerData()
            : base()
        {
            this.initData();
        }

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            return true;
        }

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
