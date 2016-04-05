using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FairyZeta.FF14.ACT.DataModel
{
    public class TimerDataModel
    {
        public bool TimerAutoReset { get; set; }

        public double TimerInterval { get; set; }

        public ElapsedEventHandler TimerEvent { get; set; }

    }
}
