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

        /// <summary> 戦闘時間変更時にOnPropertyChangedを発行させたいアイテムリスト
        /// </summary>
        public List<TimelineItemData> CombatTimeChangedRefreshList { get; private set; }

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
                base.OnPropertyChanged("CurrentCombatTimeSpan");

                this.CurrentTimeChangedRefresh();
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
                base.OnPropertyChanged("CurrentCombatEndTimeSpan");
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
                base.OnPropertyChanged("CurrentCombatStartTimeSpan");
            }
        }
        #endregion

        public TimeSpan CurrentCombatStartTimeSpan
        {
            get { return new TimeSpan(0, 0, Convert.ToInt32(this._CurrentCombatStartTime)); }
        }

        TimeSpan s;
        public TimeSpan CurrentCombatTimeSpan
        {
            get 
            {
                return s;//new TimeSpan(0, 0, Convert.ToInt32(this._CurrentCombatTime)); 
            }
        }

        public TimeSpan CurrentCombatEndTimeSpan
        {
            get { return new TimeSpan(0, 0, Convert.ToInt32(this._CurrentCombatEndTime)); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイマーデータ／コンストラクタ
        /// </summary>
        public TimerData()
            : base()
        {
            s = new TimeSpan(0, 0, 1);
            this.initData();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.CombatTimeChangedRefreshList = new List<TimelineItemData>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> CurrentTime変更時に画面を更新します。
        /// </summary>
        public void CurrentTimeChangedRefresh()
        {
            foreach (var item in this.CombatTimeChangedRefreshList)
            {
                item.ViewRefresh();
            }

            //await this.CombatTimeChangedRefreshList.Select(async item =>
            //    {
            //        item.ViewRefresh();
            //    }).WhenAll();

            Console.WriteLine(string.Format("CurrentTimeChangedRefresh End: {0}", this._CurrentCombatTime));
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

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
            this.CurrentCombatTime = 0;
            this.CurrentCombatStartTime = 0;
            this.CurrentCombatEndTime = 0;

            this.CurrentTimeChangedRefresh();

            return true;
        }
    }


    public static class TaskEnumerableExtensions
    {
        public static Task WhenAll(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks);
        }

        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            return Task.WhenAll(tasks);
        }
    }
}
