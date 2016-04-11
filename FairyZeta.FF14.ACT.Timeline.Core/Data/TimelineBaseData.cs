using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    public class TimelineBaseData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public string Name { get; private set; }

        public IEnumerable<TimelineActivity> Items
        {
            get { return items; }
        }

        private List<TimelineActivity> items;
        private List<double> itemsEndTime;

        private List<TimelineAnchorData> anchors;
        private IntervalTree.IntervalTree<double, TimelineAnchorData> anchorsTree;

        public AlertSoundAssets AlertSoundAssets { get; private set; }

        public double EndTime { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineBaseData(string name, List<TimelineActivity> items_, List<TimelineAnchorData> anchors_, List<TimelineAlertObjectModel> alerts_, AlertSoundAssets soundAssets)
        {
            Name = name;
            items = items_;
            int i = 0;
            foreach (TimelineActivity a in items_)
            {
                a.Index = i++;
            }
            items.Sort(TimelineActivity.CompareByEndTime);
            itemsEndTime = items.Select(a => a.EndTime).ToList();

            anchors = anchors_.OrderBy(anchor => anchor.TimeFromStart).ToList();
            anchorsTree = new IntervalTree.IntervalTree<double, TimelineAnchorData>();
            foreach (TimelineAnchorData a in anchors)
                anchorsTree.Add(a.Interval, a);

            alerts = alerts_;
            alerts.Sort();
            alertsTimeFromStart = alerts.Select(a => a.TimeFromStart).ToList();
            AlertSoundAssets = soundAssets;

            EndTime = Items.Any() ? Items.Last().EndTime : 0;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private int FindFirstItemIndexAfterEndTime(double t)
        {
            int i = itemsEndTime.BinarySearch(t);
            if (i < 0)
                return ~i;

            for (; i < itemsEndTime.Count && itemsEndTime[i] == t; ++i)
                ;

            return i;
        }
        private IEnumerable<TimelineActivity> ItemsBeforeEndTime(double t)
        {
            int itemsToSkip = FindFirstItemIndexAfterEndTime(t);
            return Items.Skip(itemsToSkip);
        }
        public IEnumerable<TimelineActivity> VisibleItemsAt(double t, int limit)
        {
            return (from e in ItemsBeforeEndTime(t)
                    where !e.Hidden
                    select e).Take(limit);
        }

        public IEnumerable<TimelineAnchorData> Anchors
        {
            get { return anchors; }
        }
        public IEnumerable<TimelineAnchorData> ActiveAnchorsAt(double t)
        {
            return anchorsTree
                .GetIntervalsIncludingPoint(t)
                .Select(kv => kv.Value);
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


        #region --- alert --- ※移植済
        List<TimelineAlertObjectModel> alerts;

        /// <summary> アラートの開始時間リスト
        /// </summary>
        List<double> alertsTimeFromStart;

        public IEnumerable<TimelineAlertObjectModel> Alerts 
        { 
            get 
            { 
                return alerts; 
            } 
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

            return alerts.Skip(firstAlertIndex).TakeWhile(a => (a.TimeFromStart < t)).Where(a => !a.Processed);
        }

        public void ResetAllAlerts()
        {
            foreach (TimelineAlertObjectModel alert in Alerts)
                alert.Processed = false;
        }

        #endregion
    }
    
}
