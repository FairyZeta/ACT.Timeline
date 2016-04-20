using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataFilter;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／タイムラインデータモデル
    /// </summary>
    public class TimelineDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 現在のタイムラインアイテム
        /// </summary>
        public TimelineObjectModel Timeline { get; set; }

        /// <summary> タイムラインアイテムコレクション
        /// </summary>
        public ObservableCollection<TimelineItemData> TimelineItemCollection { get; private set; }
        /// <summary> アンカーデータコレクション
        /// </summary>
        public ObservableCollection<TimelineAnchorData> TimelineAnchorDataCollection { get; private set; }
        /// <summary> タイムラインアラートコレクション
        /// </summary>
        public ObservableCollection<TimelineAlertObjectModel> TimelineAlertCollection { get; private set; }

        /// <summary> jumpまたはsync発生時の対象データ
        /// </summary>
        public TimelineAnchorData SynchroAnchorData { get; set; }

        /// <summary> アラートの開始時間リスト
        /// </summary>
        public List<double> AlertStartTimeList { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインデータモデル
        /// </summary>
        public TimelineDataModel()
        {
            this.initDataModel();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.TimelineItemCollection = new ObservableCollection<TimelineItemData>();
            this.TimelineAnchorDataCollection = new ObservableCollection<TimelineAnchorData>();
            this.TimelineAlertCollection = new ObservableCollection<TimelineAlertObjectModel>();
            this.AlertStartTimeList = new List<double>();
            
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        #region --- alert ---

        public int FindFirstAlertIndexAfterStartTime(double t)
        {
            int i = AlertStartTimeList.BinarySearch(t);

            if (i < 0)
                return ~i;

            for (; i < AlertStartTimeList.Count && AlertStartTimeList[i] == t; ++i)
                ;

            return i;
        }
        /// <summary> サウンド再生対象を選定し、リストで返却します。
        /// </summary>
        /// <param name="pCurrentTime"> 現在の時間 </param>
        /// <param name="pTooOldThreshold"> 検索有効範囲 </param>
        /// <returns></returns>
        public IEnumerable<TimelineAlertObjectModel> PendingAlertsAt(double pCurrentTime, double pTooOldThreshold)
        {
            int firstAlertIndex = FindFirstAlertIndexAfterStartTime(pCurrentTime - pTooOldThreshold);

            return this.TimelineAlertCollection.Skip(firstAlertIndex).TakeWhile(a => (a.TimeFromStart < pCurrentTime)).Where(a => !a.Processed);
        }


        #endregion

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

        /// <summary> アラートの再生状況をリセットします。
        /// </summary>
        public void ResetAllAlerts()
        {
            foreach (TimelineAlertObjectModel alert in this.TimelineAlertCollection)
            {
                alert.Processed = false;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.TimelineItemCollection.Clear();
            this.TimelineAnchorDataCollection.Clear();
            this.TimelineAlertCollection.Clear();
            this.AlertStartTimeList.Clear();
            this.SynchroAnchorData = null;

            return true;
        }
    }
}
