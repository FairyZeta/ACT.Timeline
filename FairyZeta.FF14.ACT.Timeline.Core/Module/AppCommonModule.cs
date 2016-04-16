using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FairyZeta.FF14.ACT.Data;
using FairyZeta.FF14.ACT.Info;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;
using FairyZeta.Framework.Process;
using FairyZeta.FF14.ACT.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／アプリケーション共通モジュール
    /// </summary>
    public class AppCommonModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグイン変更履歴管理モジュール
        /// </summary>
        public PluginHistoryObjectModel PluginHistoryObjectModel { get; set; }
        /// <summary> プラグインアップデートオブジェクトモデル
        /// </summary>
        public PluginUpdateObjectModel PluginUpdateObjectModel { get; set; }

        /// <summary> XMLシリアライズプロセス
        /// </summary>
        private XmlSerializerProcess xmlSerializerProcess;

        /// <summary> アセンブリデータ取得プロセス
        /// </summary>
        private GetAssemblyDataProcess getAssemblyDataProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／アプリケーション共通モジュール
        /// </summary>
        public AppCommonModule()
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
            this.PluginHistoryObjectModel = new PluginHistoryObjectModel();
            this.PluginUpdateObjectModel = new PluginUpdateObjectModel();
            this.xmlSerializerProcess = new XmlSerializerProcess();
            this.getAssemblyDataProcess = new GetAssemblyDataProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムラインディレクトリの状態を確認し、ステータスと機能の有効状態を変更します。
        /// </summary>
        /// <param name="pCommonDataModel"> 参照と設定に使用する共通データモデル </param>
        public void CheckTimelineResourceDirectory(CommonDataModel pCommonDataModel)
        {
            pCommonDataModel.TimelineFileCollection.Clear();
            pCommonDataModel.SelectedTimelineFileData = null;
            pCommonDataModel.AppEnableManageData.TimelineFileLoadEnabled = false;

            if (string.IsNullOrWhiteSpace(pCommonDataModel.PluginSettingsData.TimelineResourceDirectory)
                || !Directory.Exists(pCommonDataModel.PluginSettingsData.TimelineResourceDirectory))
            {
                pCommonDataModel.AppCommonData.TimelineDirectoryStatus = "Directory Not Found.";
                pCommonDataModel.AppStatusData.TimelineResourceDirectoryStatus = DirectoryStatus.NotFound;
                return;
            }

            var files = Directory.GetFiles(pCommonDataModel.PluginSettingsData.TimelineResourceDirectory, "*.txt");
            if (files.Count() > 0)
            {
                pCommonDataModel.AppStatusData.TimelineResourceDirectoryStatus = DirectoryStatus.FoundFile;
                this.CreateTimelineFileCollection(pCommonDataModel);
                pCommonDataModel.SelectedTimelineFileData = pCommonDataModel.TimelineFileCollection[0];

                pCommonDataModel.AppEnableManageData.TimelineFileLoadEnabled = true;
            }
            else
            {
                pCommonDataModel.AppStatusData.TimelineResourceDirectoryStatus = DirectoryStatus.ZeroFile;
            }

            pCommonDataModel.AppCommonData.TimelineDirectoryStatus = string.Format("Found {0} .txt Files", files.Count());

            return;
        }
        /// <summary> サウンドディレクトリの状態を確認し、ステータスと機能の有効状態を変更します。
        /// </summary>
        /// <param name="pCommonDataModel"> 参照と設定に使用する共通データモデル </param>
        public void CheckSoundResourceDirectory(CommonDataModel pCommonDataModel)
        {
            if (string.IsNullOrWhiteSpace(pCommonDataModel.PluginSettingsData.SoundResourceDirectory)
                || !Directory.Exists(pCommonDataModel.PluginSettingsData.SoundResourceDirectory))
            {
                pCommonDataModel.AppCommonData.SoundDirectoryStatus = "Directory Not Found.";
                pCommonDataModel.AppStatusData.SoundResourceDirectoryStatus = DirectoryStatus.NotFound;
                return;
            }

            var files = Directory.GetFiles(pCommonDataModel.PluginSettingsData.SoundResourceDirectory, "*.wav");
            if (files.Count() > 0)
            {
                pCommonDataModel.AppStatusData.SoundResourceDirectoryStatus = DirectoryStatus.FoundFile;

            }
            else
            {
                pCommonDataModel.AppStatusData.SoundResourceDirectoryStatus = DirectoryStatus.ZeroFile;
            }

            pCommonDataModel.AppCommonData.SoundDirectoryStatus = string.Format("Found {0} .wav Files", files.Count());

            return;
        }

        /// <summary> タイムラインファイルコレクションを生成します。
        /// </summary>
        /// <param name="pCommonDataModel"> 参照と設定に使用する共通データモデル </param>
        public void CreateTimelineFileCollection(CommonDataModel pCommonDataModel)
        {
            switch(pCommonDataModel.AppStatusData.TimelineResourceDirectoryStatus)
            {
                case DirectoryStatus.Init:
                case DirectoryStatus.NotFound:
                case DirectoryStatus.ZeroFile:
                    return;
            }

            pCommonDataModel.TimelineFileCollection.Clear();

            var files = Directory.GetFiles(pCommonDataModel.PluginSettingsData.TimelineResourceDirectory, "*.txt");
            foreach (var file in files)
            {
                TimelineFileData data = new TimelineFileData();
                data.TimelineFileName = Path.GetFileName(file);
                data.TimelineFileFullPath = file;
                pCommonDataModel.TimelineFileCollection.Add(data);
            }

            pCommonDataModel.TimelineFileViewSource.View.Refresh();
        }

        /// <summary> XML形式のプラグインセッティングデータを読み込み、データを返却します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <returns> 復元成功時 Data, 失敗時 Null </returns>
        public PluginSettingsData PluginSettingsDataLoad(string pFilePath)
        {
            return this.xmlSerializerProcess.XmlLoad(pFilePath, typeof(PluginSettingsData), true) as PluginSettingsData;
        }
        /// <summary> プラグインセッティングデータをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 書き込みファイルパス </param>
        /// <param name="pPluginSettingsData"> プラグインセッティングデータ </param>
        public void PluginSettingsDataSave(string pFilePath, PluginSettingsData pPluginSettingsData)
        {
            this.xmlSerializerProcess.XmlSave(pFilePath, pPluginSettingsData, true);
            pPluginSettingsData.SaveChangedTarget = false;
            
            return;
        }

        /// <summary> プラグインのデフォルト設定を実行します。
        /// </summary>
        /// <param name="pCommonDataModel"></param>
        public void SetDefaultPluginSettings(CommonDataModel pCommonDM)
        {
            return;
        }

        /// <summary> デフォルトリソースディレクトリを設定します。
        /// </summary>
        /// <param name="pCommonDM"> 参照と設定に使用する共通データモデル </param>
        public void SetDefaultResourceDirectory(CommonDataModel pCommonDM)
        {
            if (!string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                pCommonDM.PluginSettingsData.TimelineResourceDirectory = Globals.PluginDllDirectoryPath + @"\timeline";
                pCommonDM.PluginSettingsData.SoundResourceDirectory = Globals.PluginDllDirectoryPath + @"\wav";
            }
            else if (!string.IsNullOrWhiteSpace(pCommonDM.ApplicationData.PluginDllDirectory))
            {
                pCommonDM.PluginSettingsData.TimelineResourceDirectory = pCommonDM.ApplicationData.PluginDllDirectory + @"\timeline";
                pCommonDM.PluginSettingsData.SoundResourceDirectory = pCommonDM.ApplicationData.PluginDllDirectory + @"\wav";
            }
            else
            {
                string path = this.getAssemblyDataProcess.GetAssemblyDirectory();

                pCommonDM.PluginSettingsData.TimelineResourceDirectory = path + @"\timeline";
                pCommonDM.PluginSettingsData.SoundResourceDirectory = path + @"\wav";
            }
        }

        /// <summary> プラグインバージョン情報を生成します。
        /// </summary>
        /// <param name="pCommonDM"> データ格納する共通データモデル </param>
        public void CreateVersionInfo(CommonDataModel pCommonDM)
        {
            var ass = Assembly.GetExecutingAssembly();
            var name = ass.GetName();

            pCommonDM.PluginVersionInfo.PluginName = "FZ.Timeline";
            pCommonDM.PluginVersionInfo.PluginWebUri = "https://github.com/FairyZeta/ACT.Timeline/releases";
            pCommonDM.PluginVersionInfo.CheckPluginInfoUri = "https://raw.githubusercontent.com/FairyZeta/ACT.Timeline/master/" + pCommonDM.ApplicationData.VersionInfoFileName;
            pCommonDM.PluginVersionInfo.PluginVersion = name.Version.ToString();
            pCommonDM.PluginVersionInfo.PluginDownloadUri
                = pCommonDM.PluginVersionInfo.PluginWebUri 
                + string.Format(@"/{0}/{1}-{0}.zip", pCommonDM.PluginVersionInfo.PluginVersion, pCommonDM.PluginVersionInfo.PluginName);

            pCommonDM.PluginVersionInfo.ReleaseDay = string.Empty;
            pCommonDM.PluginVersionInfo.Priority = string.Empty;
            pCommonDM.PluginVersionInfo.Msg = string.Empty;

            pCommonDM.PluginVersionInfo.DataBaseVersion = "1.0.0.0";
            pCommonDM.PluginVersionInfo.DataBaseDownloadUri = string.Empty;

            pCommonDM.PluginVersionInfo.SummaryList = this.PluginHistoryObjectModel.UpdateHistoryDictionary[name.Version];
        }

        /// <summary> プラグインバージョン情報を保存します。
        /// </summary>
        /// <param name="pCommonDM"> 保存情報を格納した共通データモデル </param>
        public void VersionInfoSave(CommonDataModel pCommonDM)
        {
            string path = Path.Combine(pCommonDM.ApplicationData.RoamingDirectoryPath, pCommonDM.ApplicationData.VersionInfoFileName);
            this.PluginUpdateObjectModel.XmlSave(pCommonDM.PluginVersionInfo, path);
        }

        /// <summary> プラグインの更新確認を実行します。
        /// </summary>
        /// <param name="pCommonDM"> 設定情報を参照する共通データモデル </param>
        /// <returns> 正常にアップデート確認できた場合 True </returns>
        public bool PluginUpdateCheck(CommonDataModel pCommonDM)
        {
            var ass = Assembly.GetExecutingAssembly();
            var name = ass.GetName();

            UpdateCheckSettingsData data = new UpdateCheckSettingsData();
            
            data.PluginVersion = name.Version;
            pCommonDM.LogDataCollection.Add(
                Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write(string.Format("PluginVersion: {0}", name.Version)));
            data.InfoDonwloadUri = pCommonDM.PluginVersionInfo.CheckPluginInfoUri;
            data.SaveInfoDirectory = pCommonDM.ApplicationData.RoamingDirectoryPath;
            data.SaveInfoFileName = "New" + pCommonDM.ApplicationData.VersionInfoFileName;
            if (!string.IsNullOrWhiteSpace(pCommonDM.ApplicationData.PluginDllDirectory))
            {
                data.SaveZipDirectory = pCommonDM.ApplicationData.PluginDllDirectory + @"\Download";
            }
            else
            {
                data.SaveZipDirectory = this.getAssemblyDataProcess.GetAssemblyDirectory() + @"\Download";
            }
            Task.Run(() => this.PluginUpdateObjectModel.UpdateCheck(data));
            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
