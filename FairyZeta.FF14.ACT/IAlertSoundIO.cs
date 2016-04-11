using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Data;

namespace FairyZeta.FF14.ACT
{
    /// <summary> [IF] アラートサウンドデータ保有
    /// </summary>
    public interface IAlertSoundIO
    {
        /// <summary> アラートサウンドデータ
        /// </summary>
        AlertSoundData AlertSoundData { get; set; }
    }
}
