using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.ObjectModel
{
    /// <summary> タイムライン／タイムラインオブジェクトモデル
    /// <para> => 再生中のタイムライン情報を格納 </para>
    /// </summary>
    public class TimelineObjectModel : _ObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイマーデータ
        /// </summary>
        public TimerData TimerData { get; set; }

        /// <summary> タイムライン名
        /// </summary>
        public string Name { get; private set; }

        /// <summary> アクティビティアイテムコレクション
        /// </summary>
        public ObservableCollection<TimelineActivityData> ActivityCollection { get; private set; }

        /// <summary> アクティビティ終了時間リスト
        /// </summary>
        private List<double> activityEndTimeList;
        /// <summary> アンカーアイテムリスト
        /// </summary>
        public List<TimelineAnchorData> AnchorList { get; private set; }

        private IntervalTree.IntervalTree<double, TimelineAnchorData> anchorsTree;

        public AlertSoundAssets AlertSoundAssets { get; private set; }

        public double EndTime { get; private set; }

        /// <summary> アラートの開始時間リスト
        /// </summary>
        List<double> alertsTimeFromStart;
        /// <summary> アラートアイテムリスト
        /// </summary>
        public List<TimelineAlertObjectModel> AlertList { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／タイムラインオブジェクトモデル／コンストラクタ
        /// </summary>
        public TimelineObjectModel()
        {
            this.initObjectModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.TimerData = new TimerData();
            this.ActivityCollection = new ObservableCollection<TimelineActivityData>();
            this.activityEndTimeList = new List<double>();
            this.AnchorList = new List<TimelineAnchorData>();
            this.alertsTimeFromStart = new List<double>();
            this.AlertList = new List<TimelineAlertObjectModel>();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインデータを生成します。
        /// </summary>
        /// <param name="pName"> タイムライン名 </param>
        /// <param name="pActivityList"> アクティビティリスト </param>
        /// <param name="pAnchorList"> アンカーリスト </param>
        /// <param name="pAlertList"> アラートリスト </param>
        /// <param name="pSoundAssets"> サウンドアセット </param>
        public void SetTimelineData(string pName, List<TimelineActivityData> pActivityList, List<TimelineAnchorData> pAnchorList, List<TimelineAlertObjectModel> pAlertList, AlertSoundAssets pSoundAssets)
        {
            this.Name = pName;
            this.AlertSoundAssets = pSoundAssets;

            pAlertList.Sort();
            this.AlertList = pAlertList;

            this.AnchorList = pAnchorList.OrderBy(anchor => anchor.TimeFromStart).ToList();
            anchorsTree = new IntervalTree.IntervalTree<double, TimelineAnchorData>();
            foreach (TimelineAnchorData a in this.AnchorList)
                anchorsTree.Add(a.Interval, a);

            int i = 0;
            pActivityList.Sort(TimelineActivityData.CompareByEndTime);
            foreach (TimelineActivityData a in pActivityList)
            {
                a.Index = i++;
                a.TimerData = this.TimerData;
                a.TimelineAlert = this.AlertList.FirstOrDefault(s => s.Activity == a);
                a.TimelineAnchorData = this.AnchorList.FirstOrDefault(anc => anc.TimeFromStart == a.TimeFromStart);
                this.ActivityCollection.Add(a);
                this.TimerData.CombatTimeChangedRefreshList.Add(a);
            }

            this.activityEndTimeList = this.ActivityCollection.Select(a => a.EndTime).ToList();



            alertsTimeFromStart = AlertList.Select(a => a.TimeFromStart).ToList();

            this.EndTime = this.ActivityCollection.Any() ? this.ActivityCollection.Last().EndTime : 0;

            this.TimerData.CurrentCombatEndTime = this.EndTime;
            
        }

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public bool Clear()
        {
            this.Name = string.Empty;
            this.ActivityCollection.Clear();

            this.activityEndTimeList.Clear();
            this.AnchorList.Clear();
            this.alertsTimeFromStart.Clear();

            this.AlertList.Clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private int FindFirstItemIndexAfterEndTime(double t)
        {
            int i = this.activityEndTimeList.BinarySearch(t);
            if (i < 0)
                return ~i;

            for (; i < this.activityEndTimeList.Count && this.activityEndTimeList[i] == t; ++i)
                ;

            return i;
        }

        private IEnumerable<TimelineActivityData> ItemsBeforeEndTime(double t)
        {
            int itemsToSkip = FindFirstItemIndexAfterEndTime(t);
            return this.ActivityCollection.Skip(itemsToSkip);
        }
        public IEnumerable<TimelineActivityData> VisibleItemsAt(double t, int limit)
        {
            return (from e in ItemsBeforeEndTime(t)
                    where !e.TimelineVisibility
                    select e).Take(limit);
        }

        public IEnumerable<TimelineAnchorData> ActiveAnchorsAt(double t)
        {
            return anchorsTree
                .GetIntervalsIncludingPoint(t)
                .Select(kv => kv.Value);
        }
        public TimelineAnchorData FindAnchorMatchingLogline(string line)
        {
            foreach (TimelineAnchorData anchor in ActiveAnchorsAt(this.TimerData.CurrentCombatTime))
            {
                if (anchor.Regex.IsMatch(line))
                    return anchor;
            }

            return null;
        }
        public TimelineAnchorData FindAnchorMatchingLogline(double t, string line)
        {
            foreach (TimelineAnchorData anchor in ActiveAnchorsAt(t))
            {
                if (anchor.Regex.IsMatch(line))
                    return anchor;
            }

            return null;
        }


        public int FindFirstAlertIndexAfterStartTime(double t)
        {
            int i = alertsTimeFromStart.BinarySearch(t);

            if (i < 0)
                return ~i;

            for (; i < alertsTimeFromStart.Count && alertsTimeFromStart[i] == t; ++i)
                ;

            return i;
        }
        public IEnumerable<TimelineAlertObjectModel> PendingAlertsAt(double t, double pTooOldThreshold)
        {
            int firstAlertIndex = FindFirstAlertIndexAfterStartTime(t - pTooOldThreshold);

            return AlertList.Skip(firstAlertIndex).TakeWhile(a => (a.TimeFromStart < t)).Where(a => !a.Processed);
        }

        /// <summary> アラートの再生状況を全てリセットします。
        /// </summary>
        public void ResetAllAlerts()
        {
            foreach (TimelineAlertObjectModel alert in this.AlertList)
                alert.Processed = false;
        }

    }
    
}
