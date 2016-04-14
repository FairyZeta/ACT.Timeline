using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;
using FairyZeta.Framework.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／アプリケーション共通モジュール
    /// </summary>
    public class AppCommonModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

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
            this.xmlSerializerProcess = new XmlSerializerProcess();
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
            else if (!string.IsNullOrWhiteSpace(pCommonDM.PluginSettingsData.PluginDllPath))
            {
                pCommonDM.PluginSettingsData.TimelineResourceDirectory = pCommonDM.PluginSettingsData.PluginDllPath + @"\timeline";
                pCommonDM.PluginSettingsData.SoundResourceDirectory = pCommonDM.PluginSettingsData.PluginDllPath + @"\wav";
            }
            else
            {
                string path = this.getAssemblyDataProcess.GetAssemblyDirectory();

                pCommonDM.PluginSettingsData.TimelineResourceDirectory = path + @"\timeline";
                pCommonDM.PluginSettingsData.SoundResourceDirectory = path + @"\wav";
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
