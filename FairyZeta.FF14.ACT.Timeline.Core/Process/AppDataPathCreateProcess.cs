using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／各種アプリケーションパス生成プロセス
    /// </summary>
    public class AppDataPathCreateProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／各種アプリケーションパス生成プロセス
        /// </summary>
        public AppDataPathCreateProcess()
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

        /// <summary> タイムラインのRoamingパスを生成して返却します
        /// </summary>
        /// <returns> Roaming Path </returns>
        public string CreateRoamingDirectoryPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ACT.FairyZeta", "Timeline");
        }

        /// <summary> オーバーレイデータのフォルダパスを設定します。
        /// </summary>
        /// <param name="pApplicationData"> 設定と参照に使用するアプリケーションデータ </param>
        public void SetOverlayDirectoryPath(ApplicationData pApplicationData)
        {
            if (string.IsNullOrWhiteSpace(pApplicationData.RoamingDirectoryPath)) return;

            pApplicationData.OverlayDataDirectoryPath = Path.Combine(pApplicationData.RoamingDirectoryPath, "OverlayData");
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
