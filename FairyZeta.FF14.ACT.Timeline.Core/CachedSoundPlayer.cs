﻿using System;
using System.Collections.Generic;
using System.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    class CachedSoundPlayer
    {
        Dictionary<string, SoundPlayer> cache;

        public CachedSoundPlayer()
        {
            cache = new Dictionary<string,SoundPlayer>();
        }

        public void WarmUpCache(string filepath)
        {
            EnsureSoundPlayer(filepath);
        }
    
        private SoundPlayer EnsureSoundPlayer(string filepath)
        {
            SoundPlayer player;
            if (!cache.TryGetValue(filepath, out player))
            {
                player = new SoundPlayer(filepath);
                cache.Add(filepath, player);
            }

            return player;
        }

        public void PlaySound(string filepath)
        {
            Console.WriteLine("playing sound: {0}", filepath);
            EnsureSoundPlayer(filepath).Play();
        } 
    }
}
