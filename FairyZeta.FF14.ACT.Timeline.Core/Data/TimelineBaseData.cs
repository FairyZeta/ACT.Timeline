using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<TimelineAnchor> anchors;
        private IntervalTree.IntervalTree<double, TimelineAnchor> anchorsTree;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineBaseData(string name, List<TimelineActivity> items_, List<TimelineAnchor> anchors_, List<ActivityAlert> alerts_, AlertSoundAssets soundAssets)
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
            anchorsTree = new IntervalTree.IntervalTree<double, TimelineAnchor>();
            foreach (TimelineAnchor a in anchors)
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

        public IEnumerable<TimelineAnchor> Anchors
        {
            get { return anchors; }
        }
        public IEnumerable<TimelineAnchor> ActiveAnchorsAt(double t)
        {
            return anchorsTree
                .GetIntervalsIncludingPoint(t)
                .Select(kv => kv.Value);
        }
        public TimelineAnchor FindAnchorMatchingLogline(double t, string line)
        {
            foreach (TimelineAnchor anchor in ActiveAnchorsAt(t))
            {
                if (anchor.Regex.IsMatch(line))
                    return anchor;
            }

            return null;
        }

        List<ActivityAlert> alerts;
        List<double> alertsTimeFromStart;
        public IEnumerable<ActivityAlert> Alerts { get { return alerts; } }
        public int FindFirstAlertIndexAfterStartTime(double t)
        {
            int i = alertsTimeFromStart.BinarySearch(t);
            if (i < 0)
                return ~i;

            for (; i < alertsTimeFromStart.Count && alertsTimeFromStart[i] == t; ++i)
                ;

            return i;
        }
        public IEnumerable<ActivityAlert> PendingAlertsAt(double t)
        {
            int firstAlertIndex = FindFirstAlertIndexAfterStartTime(t - ActivityAlert.TooOldThreshold);
            return alerts
                .Skip(firstAlertIndex)
                .TakeWhile(a => (a.TimeFromStart < t))
                .Where(a => !a.Processed);
        }

        public void ResetAllAlerts()
        {
            foreach (ActivityAlert alert in Alerts)
                alert.Processed = false;
        }

        public AlertSoundAssets AlertSoundAssets { get; private set; }

        public double EndTime { get; private set; }

    }
    
}
