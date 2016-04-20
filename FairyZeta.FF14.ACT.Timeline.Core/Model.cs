using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FairyZeta.FF14.ACT.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core
{

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

    public class AlertSoundAssets
    {
        List<AlertSoundData> allAlertSounds;
        Dictionary<string, AlertSoundData> aliasMap;

        public AlertSoundAssets()
        {
            allAlertSounds = new List<AlertSoundData>();
            aliasMap = new Dictionary<string, AlertSoundData>();
        }

        public AlertSoundData Get(string filenameOrAlias)
        {
            AlertSoundData sound;
            if (aliasMap.TryGetValue(filenameOrAlias, out sound))
            {
                return sound;
            }

            // not alias => must be filename

            if (!File.Exists(filenameOrAlias))
            {
                //tts判定
                if (filenameOrAlias.IndexOf("tts ") == 0)
                    return new AlertTtsData(filenameOrAlias.Substring(4));

                // try prepending resource path
                string filenameWithResourcePath = String.Format("{0}/{1}", Globals.SoundFilesRoot, filenameOrAlias);
                if (!File.Exists(filenameWithResourcePath))
                    throw new ResourceNotFoundException(filenameOrAlias);

                sound = Get(filenameWithResourcePath);
                // register filepath without the resource path as an alias
                RegisterAlias(sound, filenameOrAlias);
                return sound;
            }

            sound = new AlertSoundData(filenameOrAlias);
            allAlertSounds.Add(sound);
            return sound;
        }

        public void RegisterAlias(AlertSoundData sound, string alias)
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

        public IEnumerable<AlertSoundData> All
        {
            get { return allAlertSounds; }
        }
    };

}
