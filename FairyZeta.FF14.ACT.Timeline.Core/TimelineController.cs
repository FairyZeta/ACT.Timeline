using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FairyZeta.Framework.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    public class TimelineController
    {

        private string timelineTxtFilePath;
        public string TimelineTxtFilePath
        {
            get { return timelineTxtFilePath; }
            set
            {
                if (value == null || value == "")
                    return;

                try
                {
                    if (!System.IO.File.Exists(value))
                        throw new ResourceNotFoundException(value);

                    timelineTxtFilePath = value;
                    Timeline = TimelineLoader.LoadFromFile(timelineTxtFilePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(String.Format("Failed to load timeline. Error: {0}", e.Message), "ACT Timeline Plugin");
                }
            }
        }

        private TimelineBaseData timeline;
        public TimelineBaseData Timeline
        {
            get { return timeline; }
            set
            {
                timeline = value;
                OnTimelineUpdate();
            }
        }

        public event EventHandler TimelineUpdate;
        public void OnTimelineUpdate()
        {
            CurrentTime = 0;

            if (TimelineUpdate != null)
                TimelineUpdate(this, EventArgs.Empty);
        }

        public event EventHandler CurrentTimeUpdate;
        public void OnCurrentTimeUpdate()
        {
            if (CurrentTimeUpdate != null)
                CurrentTimeUpdate(this, EventArgs.Empty);
        }

        private RelativeClock relativeClock;
        private double currentTime;
        public double CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                relativeClock.CurrentTime = value;
                if (value == 0.0)
                    timeline.ResetAllAlerts();
                OnCurrentTimeUpdate();
            }
        }
        
        private Timer timer;

        private bool paused;
        public bool Paused {
            get { return paused; }
            set {
                if (paused == value)
                    return;

                paused = value;
                OnPausedUpdate();
            }
        }

        public event EventHandler PausedUpdate;
        public void OnPausedUpdate()
        {
            if (!paused)
                relativeClock.CurrentTime = currentTime;

            if (PausedUpdate != null)
                PausedUpdate(this, EventArgs.Empty);
        }

        public TimelineController()
        {
            timer = new Timer();
            timer.Tick += (object sender, EventArgs e) => { Synchronize(); };
            timer.Interval = 50;
            timer.Start();

            relativeClock = new RelativeClock(true);
            Paused = true;

            ActGlobals.oFormActMain.OnLogLineRead += act_OnLogLineRead;
        }

        private void act_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (isImport || timeline == null)
                return;

            string line = logInfo.logLine;

            TimelineAnchorData anchor = timeline.FindAnchorMatchingLogline(CurrentTime, logInfo.logLine);
            if (anchor != null)
            {
                if (anchor.Jump == 0)
                {
                    CurrentTime = 0;
                    Paused = true;
                }
                else
                {
                    CurrentTime = anchor.Jump > 0 ? anchor.Jump : anchor.TimeFromStart;
                    Paused = false;
                }
            }
        }

        public void Stop()
        {
            timer.Stop();
            timeline = null;

            ActGlobals.oFormActMain.OnLogLineRead -= act_OnLogLineRead;
        }

        private void Synchronize()
        {
            if (timeline == null)
                return;

            if (Paused)
                return;

            currentTime = relativeClock.CurrentTime;
            OnCurrentTimeUpdate();
        }
    }
}
