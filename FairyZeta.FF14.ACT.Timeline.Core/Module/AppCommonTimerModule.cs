using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> アプリケーション汎用タイマー処理モジュール
    /// </summary>
    public class AppCommonTimerModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーション起動後1秒毎に処理するタイマー
        /// </summary>
        public Timer SecTimer01 { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> アプリケーション汎用タイマー処理モジュール
        /// </summary>
        public AppCommonTimerModule()
            : base()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.SecTimer01 = new Timer(1000);

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
