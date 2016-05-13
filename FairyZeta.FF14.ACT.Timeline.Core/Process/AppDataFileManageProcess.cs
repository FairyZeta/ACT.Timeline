using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／アプリケーションディレクトリ管理プロセス
    /// </summary>
    public class AppDataFileManageProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アプリケーションディレクトリ管理プロセス／コンストラクタ
        /// </summary>
        public AppDataFileManageProcess()
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

        /// <summary> タイムラインのRoamingディレクトリを生成します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        public void CreateTimelineRoamingDirectory(ApplicationData pApplicationData)
        {
            if (string.IsNullOrWhiteSpace(pApplicationData.RoamingDirectoryPath)) return;
            if (Directory.Exists(pApplicationData.RoamingDirectoryPath)) return;

            Directory.CreateDirectory(pApplicationData.RoamingDirectoryPath);

            return;
        }
        /// <summary> 一時作業ディレクトリを生成します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        public void CreatTempDirectory(ApplicationData pApplicationData)
        {
            if (string.IsNullOrWhiteSpace(pApplicationData.TempDirectoryPath)) return;
            if (Directory.Exists(pApplicationData.TempDirectoryPath)) return;

            Directory.CreateDirectory(pApplicationData.TempDirectoryPath);

            return;
        }
        /// <summary> オーバーレイデータのディレクトリを生成します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        public void CreateOverlayDataDirectory(ApplicationData pApplicationData)
        {
            if (string.IsNullOrWhiteSpace(pApplicationData.OverlayDataDirectoryPath)) return;
            if (Directory.Exists(pApplicationData.OverlayDataDirectoryPath)) return;

            Directory.CreateDirectory(pApplicationData.OverlayDataDirectoryPath);

            return;
        }

        /// <summary> オーバーレイディレクトリに入っているxmlファイル一覧を更新します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        public void UpdateOverlayFileList(ApplicationData pApplicationData)
        {
            pApplicationData.OverlayDataFilePathList.Clear();

            if (!Directory.Exists(pApplicationData.OverlayDataDirectoryPath)) return;
            string[] files = Directory.GetFiles(pApplicationData.OverlayDataDirectoryPath, "*.xml", SearchOption.AllDirectories);

            foreach (string path in files)
            {
                if(path.IndexOf(pApplicationData.OverlayDataPartName)> -1)
                {
                    pApplicationData.OverlayDataFilePathList.Add(path);
                }
            }

        }
        /// <summary> オーバーレイのxml設定ファイルを削除します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        /// <param name="pFileName"> 削除ファイル名 </param>
        public void DeleteOverlayXaml(ApplicationData pApplicationData, string pFileName)
        {
            if (string.IsNullOrWhiteSpace(pFileName)) return;

            string fullPath = Path.Combine(pApplicationData.OverlayDataDirectoryPath, pFileName);
            if (!File.Exists(fullPath)) return;

            File.Delete(fullPath);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
