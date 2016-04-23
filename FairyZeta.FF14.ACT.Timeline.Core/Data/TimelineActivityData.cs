using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    using TimelineInterval = IntervalTree.Interval<double>;

    /// <summary> タイムライン／アクティビティデータ
    /// </summary>
    public class TimelineActivityData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインアイテムのジョブタイプ
        /// </summary>
        public Job JobType { get; set; }
        /// <summary> タイムラインアイテムタイプ
        /// </summary>
        public TimelineType TimelineType { get; set; }

        /// <summary> タイムライン番号
        /// </summary>
        public int Index { get; set; }

        /// <summary> アラート
        /// </summary>
        public TimelineAlertObjectModel TimelineAlert { get; set; }

        /// <summary> タイムラインアイテム名
        /// </summary>
        public string Name { get; set; }
        /// <summary> タイムライン開始時間
        /// </summary>
        public double TimeFromStart { get; set; }
        /// <summary> キャスト時間
        /// </summary>
        public double Duration { get; set; }
        /// <summary> ジャンプ判定
        /// </summary>
        public double Jump { get; set; }
        /// <summary> (get) タイムラインリスト表示判定フラグ 
        /// </summary>
        public bool TimelineVisibility
        {
            get
            {
                if (this.ActiveTime <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary> (get) タイムラインの終了時間 </summary>
        public TimeSpan EndTimeSpan
        {
            get
            {
                return new TimeSpan(0, 0, Convert.ToInt32(this.EndTime));
            }
        }
        /// <summary> タイムラインの終了時間
        /// </summary>
        public double EndTime
        {
            get
            {
                return TimeFromStart + Duration;
            }
        }

        /// <summary> タイムラインインターバル
        /// </summary>
        public TimelineInterval Interval
        {
            get
            {
                return new TimelineInterval(TimeFromStart, TimeFromStart + Duration);
            }
        }

        /// <summary> (get) アクティブになるまでの残り時間 
        /// </summary>
        public double ActiveTime
        {
            get
            {
                if (this.TimerData == null) return 0;

                return this.EndTime - this.TimerData.CurrentCombatTime;
            }
        }

        /// <summary> (参照専用) タイマーデータ
        /// </summary>
        public TimerData TimerData { get; set; }

        /// <summary> このアクティビティのアンカーデータ
        /// </summary>
        public TimelineAnchorData TimelineAnchorData { get; set; } 

        /// <summary> (get) アンカータイプをstring1文字で返却
        /// </summary>
        public string AncType
        {
            get
            {
                if(this.TimelineAnchorData == null)
                {
                    return string.Empty;
                }
                else if(this.TimelineAnchorData.Jump == -1)
                {
                    return "S";
                }
                else
                {
                    return "J";
                }
            }
        }

        /// <summary> アクティブインジケータ最小値 </summary>
        public double ActiveIndicatorMinValue
        {
            get
            {
                return this.TimeFromStart - 12.0;
            }
        }

        public bool DurationIndicatorVisibility
        {
            get
            {
                if (this.TimeFromStart - this.TimerData.CurrentCombatTime <= 0) return true;

                return false;
            }

        }
        const int IndexNotYetSet = -1;
        const double Instant = 0.1;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineActivityData()
        {
            Index = IndexNotYetSet;
            Name = "何かすごい攻撃";
            TimeFromStart = 5;
            Duration = Instant;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void SetTimerData(TimerData pTimerData)
        {
            if (pTimerData != null)
            {
                this.TimerData = pTimerData;
                pTimerData.CombatTimeChangedRefreshList.Add(this);
            }   
        }

        /// <summary> OnPropertyChangedを発行し、画面を更新します。
        /// </summary>
        public void ViewRefresh()
        {
            base.OnPropertyChanged("ActiveTime");
            base.OnPropertyChanged("DurationIndicatorVisibility");
            base.OnPropertyChanged("TimelineVisibility");
        }

        public static readonly IComparer<TimelineActivityData> CompareByEndTime = new CompareByEndTimeKlass();

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private class CompareByEndTimeKlass : IComparer<TimelineActivityData>
        {
            int IComparer<TimelineActivityData>.Compare(TimelineActivityData x, TimelineActivityData y)
            {
                return x.EndTime.CompareTo(y.EndTime);
            }
        }

    }
}
