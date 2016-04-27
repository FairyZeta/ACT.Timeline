using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;
using FairyZeta.Framework.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／アプリケーションデータ作成モジュール
    /// </summary>
    public class AppDataCreateModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーション初期設定プロセス
        /// </summary>
        private AppDataConstProcess appDataConstProcess;
        /// <summary> アプリケーションパス生成プロセス
        /// </summary>
        private AppDataPathCreateProcess appDataPathCreateProcess;
        /// <summary> ファイル管理プロセス
        /// </summary>
        private AppDataFileManageProcess appDataFileManageProcess;

        private GetAssemblyDataProcess getAssemblyDataProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アプリケーションデータ作成モジュール／コンストラクタ
        /// </summary>
        public AppDataCreateModule()
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
            this.appDataConstProcess = new AppDataConstProcess();
            this.appDataPathCreateProcess = new AppDataPathCreateProcess();
            this.appDataFileManageProcess = new AppDataFileManageProcess();
            this.getAssemblyDataProcess = new GetAssemblyDataProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーションデータの初期設定を実行します
        /// </summary>
        /// <param name="pApplicationData"></param>
        public void AppDataConstSetup(ApplicationData pApplicationData)
        {
            var ass = Assembly.GetExecutingAssembly();
            var name = ass.GetName();

            pApplicationData.ApplicationVersion = name.Version;

            // Name Set
            this.appDataConstProcess.SetFileName(pApplicationData);
        }

        /// <summary> タイムラインの各種パスを生成します。
        /// </summary>
        /// <param name="pApplicationData"> パス情報を設定するアプリケーションデータ </param>
        public void CreateTimelinePath(CommonDataModel pCommonDM)
        {
            // Roaming
            pCommonDM.ApplicationData.RoamingDirectoryPath = this.appDataPathCreateProcess.CreateRoamingDirectoryPath();
            // DLL
            if(!string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                pCommonDM.ApplicationData.PluginDllDirectory = Globals.PluginDllDirectoryPath;
                pCommonDM.LogDataCollection.Add(
                    Globals.SysLogger.WriteSystemLog.Success.DEBUG.Write(string.Format("DllPath-Globals {0}", Globals.PluginDllDirectoryPath)));
            }
            else
            {
                pCommonDM.ApplicationData.PluginDllDirectory = getAssemblyDataProcess.GetAssemblyDirectory();
                pCommonDM.LogDataCollection.Add(
                    Globals.SysLogger.WriteSystemLog.Success.DEBUG.Write(string.Format("DllPath-Assembly {0}", Globals.PluginDllDirectoryPath)));
            }

            // Overlay
            this.appDataPathCreateProcess.SetOverlayDirectoryPath(pCommonDM.ApplicationData);

            return;
        }

        /// <summary> タイムラインの各種ディレクトリを生成します。
        /// </summary>
        /// <param name="pApplicationData"> 情報を参照するアプリケーションデータ </param>
        public void CreateTimelineDirectory(ApplicationData pApplicationData)
        {
            // Roaming
            this.appDataFileManageProcess.CreateTimelineRoamingDirectory(pApplicationData);
            // Overlay
            this.appDataFileManageProcess.CreateOverlayDataDirectory(pApplicationData);

            return;
        }

        /// <summary> データリストの更新を実行します
        /// </summary>
        /// <param name="pApplicationData"> 設定を参照に使うアプリケーションデータ </param>
        public void UpdateDataList(ApplicationData pApplicationData)
        {
            // Overlay
            this.appDataFileManageProcess.UpdateOverlayFileList(pApplicationData);

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
