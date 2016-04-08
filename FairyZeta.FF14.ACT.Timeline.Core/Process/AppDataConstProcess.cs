using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／アプリケーションデータ初期設定プロセス
    /// </summary>
    public class AppDataConstProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アプリケーションデータ初期設定プロセス
        /// </summary>
        public AppDataConstProcess()
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
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーションデータに各種ファイル名を設定します。
        /// </summary>
        /// <param name="pApplicationData"> 設定するファイル名 </param>
        public void SetFileName(ApplicationData pApplicationData)
        {
            pApplicationData.TimelineSettingsFileName = "TimelineSettings.xml";
            pApplicationData.OverlayDataPartName = "OverlayData";

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
