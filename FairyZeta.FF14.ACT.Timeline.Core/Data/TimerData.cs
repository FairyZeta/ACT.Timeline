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

        #region #- [Property] decimal.MainTimerTime - ＜メインタイマーの時間＞ -----
        /// <summary> メインタイマーの時間 </summary>
        private decimal _MainTimerTime;
        /// <summary> メインタイマーの時間 </summary>
        public decimal MainTimerTime
        {
            get { return this._MainTimerTime; }
            set
            {
                if (this._MainTimerTime == value) return;

                this._MainTimerTime = value;
                base.OnPropertyChanged("MainTimerTime");
            }
        }
        #endregion

        #region #- [Property] decimal.MainTimerEndTime - ＜メインタイマーの終了時間＞ -----
        /// <summary> メインタイマーの終了時間 </summary>
        private decimal _MainTimerEndTime;
        /// <summary> メインタイマーの終了時間 </summary>
        public decimal MainTimerEndTime
        {
            get { return this._MainTimerEndTime; }
            set
            {
                if (this._MainTimerEndTime == value) return;

                this._MainTimerEndTime = value;
                base.OnPropertyChanged("MainTimerEndTime");
            }
        }
        #endregion

        #region #- [Property] decimal.MainTimerStartTime - ＜メインタイマーの開始時間＞ -----
        /// <summary> メインタイマーの開始時間 </summary>
        private decimal _MainTimerStartTime;
        /// <summary> メインタイマーの開始時間 </summary>
        public decimal MainTimerStartTime
        {
            get { return this._MainTimerStartTime; }
            set
            {
                if (this._MainTimerStartTime == value) return;

                this._MainTimerStartTime = value;
                base.OnPropertyChanged("MainTimerStartTime");
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
