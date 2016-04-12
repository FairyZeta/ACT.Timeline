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
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ロガーの生成を実行します。
        /// </summary>
        public void CreateLogger()
        {
            if (string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                Globals.PluginDllDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            // Globals設定
            Globals.ProjectName = "Timeline.Core";

            // システムメッセージ用ロガー生成
            Globals.SysLogger = new FF14.ACT.Logger.ActLogger();
            Globals.SysLogger.Setting.FileLogSetting.FilePath = Globals.PluginDllDirectoryPath + "/Log/System";
            Globals.SysLogger.Setting.FileLogSetting.FileName = "SysLog";
            Globals.SysLogger.Setting.FileLogSetting.FileExtension = ".txt";
            Globals.SysLogger.Setting.FileLogSetting.AddFileNameDate = true;
            Globals.SysLogger.Setting.FileLogSetting.FileNameDateFormat = "yyyyMMdd";
            Globals.SysLogger.Setting.SetupTextLogger(Globals.SysLogger.Setting.FileLogSetting);
            // スタックトレース用ロガー生成
            Globals.ErrLogger = new FF14.ACT.Logger.ActLogger();
            Globals.ErrLogger.Setting.FileLogSetting.FilePath = Globals.PluginDllDirectoryPath + "/Log/Error";
            Globals.ErrLogger.Setting.FileLogSetting.FileName = "ErrorLog";
            Globals.ErrLogger.Setting.FileLogSetting.FileExtension = ".txt";
            Globals.ErrLogger.Setting.FileLogSetting.AddFileNameDate = true;
            Globals.ErrLogger.Setting.FileLogSetting.FileNameDateFormat = "yyyyMMdd_HHmmss";
            Globals.ErrLogger.Setting.SetupTextLogger(Globals.ErrLogger.Setting.FileLogSetting);
        }

        /// <summary> アプリケーションデータの初期設定を実行します
        /// </summary>
        /// <param name="pApplicationData"></param>
        public void AppDataConstSetup(ApplicationData pApplicationData)
        {
            // Name Set
            this.appDataConstProcess.SetFileName(pApplicationData);
        }

        /// <summary> タイムラインの各種パスを生成します。
        /// </summary>
        /// <param name="pApplicationData"> パス情報を設定するアプリケーションデータ </param>
        public void CreateTimelinePath(ApplicationData pApplicationData)
        {
            // Roaming
            pApplicationData.RoamingDirectoryPath = this.appDataPathCreateProcess.CreateRoamingDirectoryPath();
            // Overlay
            this.appDataPathCreateProcess.SetOverlayDirectoryPath(pApplicationData);

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
