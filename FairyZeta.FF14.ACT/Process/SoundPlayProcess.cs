using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;
using FairyZeta.FF14.ACT.Data;

namespace FairyZeta.FF14.ACT.Process
{
    /// <summary> ACT／サウンド再生プロセス
    /// </summary>
    public class SoundPlayProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        private CachedSoundPlayer soundplayer;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／サウンド再生プロセス／コンストラクタ
        /// </summary>
        public SoundPlayProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            this.soundplayer = new CachedSoundPlayer();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アラートの再生を実行します。
        /// </summary>
        /// <param name="alert"> [IF] アラートサウンドIO </param>
        /// <param name="pPlaySoundByACT"> ACT本体で再生する場合 True, 外部再生の場合 False </param>
        /// <returns></returns>
        public bool PlayAlert(IAlertSoundIO pIAlertSoundIO, bool pPlaySoundByACT)
        {
            //TTSクラスならACT本体に読み上げさせる
            if (pIAlertSoundIO.AlertSoundData is AlertTtsData)
            {
                if (ActGlobals.oFormActMain != null)
                {
                    ActGlobals.oFormActMain.TTS(pIAlertSoundIO.AlertSoundData.Filename);
                }
            }
            else if (pPlaySoundByACT && ActGlobals.oFormActMain != null)
            {
                ActGlobals.oFormActMain.PlaySoundMethod(pIAlertSoundIO.AlertSoundData.Filename, 100);
            }
            else
            {
                soundplayer.PlaySound(pIAlertSoundIO.AlertSoundData.Filename);
            }

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
