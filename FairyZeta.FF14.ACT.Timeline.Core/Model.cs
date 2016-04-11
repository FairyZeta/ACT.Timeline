using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    using TimelineInterval = IntervalTree.Interval<double>;

    public class ModelException : Exception
    {
        public ModelException() { }
        public ModelException(string message) : base(message) { }
    }

    public class DuplicateAlertSoundAliasException : ModelException
    {
        public DuplicateAlertSoundAliasException(string alias)
            : base(String.Format("AlertSound alias \"{0}\" is already used.", alias)) { }
    }
    public class ResourceNotFoundException : ModelException
    {
        public ResourceNotFoundException(string alias)
            : base(String.Format("Resource \"{0}\" could not be found.", alias)) { }
    }

    public class AlertSound
    {
        public string Filename { get; private set; }

        List<string> aliases;
        public IEnumerable<string> Aliases { get { return aliases; } }

        public void AddAlias(string alias)
        {
            aliases.Add(alias);
        }

        public AlertSound(string filename)
        {
            aliases = new List<string>();
            Filename = filename;
        }
    };
    //TTS用クラス
    public class AlertTTS : AlertSound
    {
        public AlertTTS(string txt) : base(txt)
        {
        }
    }

    public class AlertSoundAssets
    {
        List<AlertSound> allAlertSounds;
        Dictionary<string, AlertSound> aliasMap;

        public AlertSoundAssets()
        {
            allAlertSounds = new List<AlertSound>();
            aliasMap = new Dictionary<string, AlertSound>();
        }

        public AlertSound Get(string filenameOrAlias)
        {
            AlertSound sound;
            if (aliasMap.TryGetValue(filenameOrAlias, out sound))
            {
                return sound;
            }

            // not alias => must be filename

            if (!File.Exists(filenameOrAlias))
            {
                //tts判定
                if (filenameOrAlias.IndexOf("tts ") == 0)
                    return new AlertTTS(filenameOrAlias.Substring(4));

                // try prepending resource path
                string filenameWithResourcePath = String.Format("{0}/{1}", Globals.SoundFilesRoot, filenameOrAlias);
                if (!File.Exists(filenameWithResourcePath))
                    throw new ResourceNotFoundException(filenameOrAlias);

                sound = Get(filenameWithResourcePath);
                // register filepath without the resource path as an alias
                RegisterAlias(sound, filenameOrAlias);
                return sound;
            }

            sound = new AlertSound(filenameOrAlias);
            allAlertSounds.Add(sound);
            return sound;
        }

        public void RegisterAlias(AlertSound sound, string alias)
        {
            try
            {
                sound.AddAlias(alias);
                aliasMap.Add(alias, sound);
            }
            catch(ArgumentException) {
                throw new DuplicateAlertSoundAliasException(alias);
            }
        }

        public IEnumerable<AlertSound> All
        {
            get { return allAlertSounds; }
        }
    };

    public class ActivityAlert : IComparable<ActivityAlert>
    {
        public double TimeFromStart {
            get {
                return Activity.TimeFromStart - ReminderTimeOffset;
            }  
        }
        public double ReminderTimeOffset { get; set; }
        public AlertSound Sound { get; set; }
        public TimelineActivity Activity { get; set; }
        public bool Processed { get; set; }

        public const double TooOldThreshold = 3.0;

        public ActivityAlert()
        {
            Processed = false;
        }
    
        public int CompareTo(ActivityAlert other)
        {
            return TimeFromStart.CompareTo(other.TimeFromStart);
        }
    };


    public class TimelineActivity
    {
        public int Index { get; set; }
        const int IndexNotYetSet = -1;

        public string Name { get; set; }
        public double TimeFromStart { get; set; }

        const double Instant = 0.1;
        public double Duration { get; set; }
        public double Jump { get; set; }

        public bool Hidden { get; set; }

        public double EndTime
        {
            get
            {
                return TimeFromStart + Duration;
            }
        }

        private class CompareByEndTimeKlass : IComparer<TimelineActivity>
        {
            int IComparer<TimelineActivity>.Compare(TimelineActivity x, TimelineActivity y)
            {
                return x.EndTime.CompareTo(y.EndTime);
            }
        }
        static public readonly IComparer<TimelineActivity> CompareByEndTime = new CompareByEndTimeKlass();

        public TimelineInterval Interval
        {
            get
            {
                return new TimelineInterval(TimeFromStart, TimeFromStart + Duration);
            }
        }

        // for TimeLeft{Column,Cell}
        public TimelineActivity Self { get { return this; } }

        public TimelineActivity()
        {
            Index = IndexNotYetSet;
            Name = "何かすごい攻撃";
            TimeFromStart = 5;
            Duration = Instant;
            Hidden = false;
        }
    }

    public class RelativeClock
    {
        System.Diagnostics.Stopwatch sw;
        private double offset;

        public RelativeClock()
        {
            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
        }

        public double CurrentTime
        {
            get
            {
                return offset + ((double)sw.ElapsedMilliseconds) / 1000;
            }
            set
            {
                sw.Restart();
                offset = value;
            }
        }
    }
}
