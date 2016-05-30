using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FairyZeta.FF14.ACT.Data;
using FairyZeta.FF14.ACT.Info;
using FairyZeta.FF14.ACT.WPF.Views;
using FairyZeta.FF14.ACT.WPF.ViewModels;
using FairyZeta.Framework.Unit;
using FairyZeta.Framework.Proc;


namespace FairyZeta.FF14.ACT.ObjectModel
{
    /// <summary> ACT／プラグインアップデートオブジェクトモデル
    /// </summary>
    public class PluginUpdateObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- Data Object ---

        /// <summary> 新しいプラグインバージョン情報
        /// </summary>
        public PluginVersionInfo NewPluginVersionInfo { get; set; }

        /// <summary> アップデートステータスデータ
        /// </summary>
        public UpdateStatusData UpdateStatusData { get; set; }

        /// <summary> アップデートチェック設定データ
        /// </summary>
        public UpdateCheckSettingsData UpdateCheckSettingsData { get; private set; }

        /// <summary> 新しいプラグインを見つけた場合 True
        /// </summary>
        public bool NewPlugin { get; private set; }

        /// <summary>
        /// </summary>
        public bool UpdateClose { get; set; }

        public bool DialogOpenFLG { get; set; }

        #endregion

        #region --- Logic Object ---

        /// <summary> FW/ダウンロードユニット
        /// </summary>
        private DownloadUnit downloadUnit;
        /// <summary> XMLシリアライズプロセス
        /// </summary>
        private XmlSerializerProcess xmlSerializerProcess;

        #endregion
      
      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
            
        /// <summary> ACT／プラグインアップデートオブジェクトモデル／コンストラクタ
        /// </summary>
        public PluginUpdateObjectModel()
            : base()
        {
            this.initObjectModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.NewPluginVersionInfo = new PluginVersionInfo();
            this.UpdateStatusData = new UpdateStatusData();

            this.downloadUnit = new DownloadUnit();
            this.xmlSerializerProcess = new XmlSerializerProcess();
            this.NewPlugin = false;

            this.DialogOpenFLG = false;
            this.UpdateClose = false;
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public Task<bool> UpdateCheckAsync(UpdateCheckSettingsData pSettingsData)
        {
            return new Task<bool>(() => this.UpdateCheck(pSettingsData));
        }

        public bool UpdateCheck(UpdateCheckSettingsData pSettingsData)
        {
            Console.WriteLine("アップデート確認開始");
            this.UpdateCheckSettingsData = pSettingsData;

            bool downloadResult = this.downloadUnit.FileDownload(pSettingsData.InfoDonwloadUri, pSettingsData.SaveInfoDirectory, pSettingsData.SaveInfoFileName, Framework.SaveType.OverRide);
            if (!downloadResult)
            {
                Console.WriteLine("アップデート確認NG: バージョンファイル取得失敗");
                return false;
            }

            this.NewPluginVersionInfo = this.xmlSerializerProcess.XmlLoad(Path.Combine(pSettingsData.SaveInfoDirectory, pSettingsData.SaveInfoFileName), typeof(PluginVersionInfo), true) as PluginVersionInfo;
            if (this.NewPluginVersionInfo == null)
            {
                Console.WriteLine("アップデート確認NG: シリアライズ失敗");
                return false;
            }

            Version v = new Version(this.NewPluginVersionInfo.PluginVersion);
            if (pSettingsData.PluginVersion >= v)
            {
                Console.WriteLine("アップデート確認OK: 最新版なし");
                return true;
            }

            this.NewPlugin = true;
            Console.WriteLine("アップデート確認OK: 最新版あり");
            return true;

        }

        /// <summary> アップデート確認のダイアログを開きます。
        /// </summary>
        public void DialogOpen()
        {
            if (this.DialogOpenFLG)
                return;

            UpdateDialogWindow window = new UpdateDialogWindow();
            UpdateDialogWindowViewModel vm = window.DataContext as UpdateDialogWindowViewModel;
            vm.UpdateDialogComponent.PluginUpdateObjectModel = this;

            window.Topmost = true;
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            this.DialogOpenFLG = true;
            window.Show();
        }

        /// <summary> PluginVersionInfoをシリアル化してセーブします。
        /// </summary>
        /// <param name="pPluginVersionInfo"> シリアル化したいPluginVersionInfo </param>
        /// <param name="pSaveFullPath"> (ファイル名を含む)セーブパス </param>
        public void XmlSave(PluginVersionInfo pPluginVersionInfo, string pSaveFullPath)
        {
            this.xmlSerializerProcess.XmlSave(pSaveFullPath, pPluginVersionInfo, true);
        }


        /// <summary> 自身に格納されている新バージョン情報を参照し、WEBブラウザを開きます。
        /// </summary>
        public void WebOpen()
        {
            if (this.NewPluginVersionInfo == null)
                return;

            System.Diagnostics.Process.Start(this.NewPluginVersionInfo.PluginWebUri);
        }

        /// <summary> 自身に格納されている新バージョン情報を参照し、ディレクトリを開きます。
        /// </summary>
        public void DirectoryOpen()
        {
            if (this.NewPluginVersionInfo == null)
                return;

            System.Diagnostics.Process.Start(
                "EXPLORER.EXE", this.UpdateCheckSettingsData.SaveZipDirectory);
        }

        /// <summary> 自身に格納されている新バージョン情報を参照し、ZIPファイルをダウンロードします。
        /// </summary>
        public bool ZipDownload()
        {
            this.UpdateStatusData.ZipDownloadStatus = DownloadStatus.NowDownloading;
            this.UpdateStatusData.CommandButtonEnabled = false;

            if (this.NewPluginVersionInfo == null)
            {
                this.UpdateStatusData.ZipDownloadStatus = DownloadStatus.Failure;
                this.UpdateStatusData.CommandButtonEnabled = true;
                return false;
            }

            string dName = Path.GetFileName(this.NewPluginVersionInfo.PluginDownloadUri);

            if (!Directory.Exists(this.UpdateCheckSettingsData.SaveZipDirectory))
            {
                Directory.CreateDirectory(this.UpdateCheckSettingsData.SaveZipDirectory);
            }

            bool downloadResult = this.downloadUnit.FileDownload(this.NewPluginVersionInfo.PluginDownloadUri, this.UpdateCheckSettingsData.SaveZipDirectory, dName, Framework.SaveType.OverRide);
            if (!downloadResult)
            {
                this.UpdateStatusData.ZipDownloadStatus = DownloadStatus.Failure;
                this.UpdateStatusData.CommandButtonEnabled = true;
                return false;
            }

            this.UpdateStatusData.ZipDownloadStatus = DownloadStatus.Success;
            this.UpdateStatusData.CommandButtonEnabled = true;
            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
