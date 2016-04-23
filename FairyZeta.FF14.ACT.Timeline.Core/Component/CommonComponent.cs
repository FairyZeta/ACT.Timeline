using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prism.Commands;
using FairyZeta.FF14.ACT.Module;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／共通機能コンポーネント
    /// </summary>
    public class CommonComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      #region - [REGION] - Modules -
        
        /// <summary> アプリケーションデータ生成モジュール
        /// </summary>
        public AppDataCreateModule AppDataCreateModule { get; private set; }

        /// <summary> アプリケーション汎用タイマー処理モジュール
        /// </summary>
        public AppCommonTimerModule AppCommonTimerModule { get; private set; }

        /// <summary> アプリケーション共通モジュール
        /// </summary>
        public AppCommonModule AppCommonModule { get; private set; }
        
      #endregion

      #region - [REGION] - Commands -

        #region #- [Command] DelegateCommand.TimelineResourceDirectoryCahngedCommand - ＜タイムラインリソースディレクトリ更新コマンド＞ -----
        /// <summary> タイムラインリソースディレクトリ更新コマンド＜コマンド＞ </summary>
        private DelegateCommand _TimelineResourceDirectoryCahngedCommand;
        /// <summary> タイムラインリソースディレクトリ更新コマンド＜コマンド＞ </summary>
        public DelegateCommand TimelineResourceDirectoryCahngedCommand
        {
            get { return _TimelineResourceDirectoryCahngedCommand = _TimelineResourceDirectoryCahngedCommand ?? new DelegateCommand(this._TimelineResourceDirectoryCahngedExecute, this._CanTimelineResourceDirectoryCahngedExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.SoundResourceDirectoryCahngedCommand - ＜サウンドリソースディレクトリ更新コマンド＞ -----
        /// <summary> サウンドリソースディレクトリ更新コマンド＜コマンド＞ </summary>
        private DelegateCommand _SoundResourceDirectoryCahngedCommand;
        /// <summary> サウンドリソースディレクトリ更新コマンド＜コマンド＞ </summary>
        public DelegateCommand SoundResourceDirectoryCahngedCommand
        {
            get { return _SoundResourceDirectoryCahngedCommand = _SoundResourceDirectoryCahngedCommand ?? new DelegateCommand(this._SoundResourceDirectoryCahngedExecute, this._CanSoundResourceDirectoryCahngedExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.TimelineFileListRefreshCommand - ＜タイムラインファイルリスト再作成コマンド＞ -----
        /// <summary> タイムラインファイルリスト再作成コマンド＜コマンド＞ </summary>
        private DelegateCommand _TimelineFileListRefreshCommand;
        /// <summary> タイムラインファイルリスト再作成コマンド＜コマンド＞ </summary>
        public DelegateCommand TimelineFileListRefreshCommand
        {
            get { return _TimelineFileListRefreshCommand = _TimelineFileListRefreshCommand ?? new DelegateCommand(this._TimelineFileListRefreshExecute, this._CanTimelineFileListRefreshExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.FolderBrowserDialogOpenCommand - ＜フォルダ選択ダイアログオープン＞ -----
        /// <summary> フォルダ選択ダイアログオープン＜コマンド＞ </summary>
        private DelegateCommand<string> _FolderBrowserDialogOpenCommand;
        /// <summary> フォルダ選択ダイアログオープン＜コマンド＞ </summary>
        public DelegateCommand<string> FolderBrowserDialogOpenCommand
        {
            get { return _FolderBrowserDialogOpenCommand = _FolderBrowserDialogOpenCommand ?? new DelegateCommand<string>(this._FolderBrowserDialogOpenExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.SetDefaultResourceDirectoryCommand - ＜デフォルトリソースディレクトリ設定コマンド＞ -----
        /// <summary> デフォルトリソースディレクトリ設定コマンド＜コマンド＞ </summary>
        private DelegateCommand _SetDefaultResourceDirectoryCommand;
        /// <summary> デフォルトリソースディレクトリ設定コマンド＜コマンド＞ </summary>
        public DelegateCommand SetDefaultResourceDirectoryCommand
        {
            get { return _SetDefaultResourceDirectoryCommand = _SetDefaultResourceDirectoryCommand ?? new DelegateCommand(this._SetDefaultResourceDirectoryExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.OpenTimelineResourceDirectoryCommand - ＜タイムラインリソースディレクトリオープンコマンド＞ -----
        /// <summary> タイムラインリソースディレクトリオープンコマンド＜コマンド＞ </summary>
        private DelegateCommand _OpenTimelineResourceDirectoryCommand;
        /// <summary> タイムラインリソースディレクトリオープンコマンド＜コマンド＞ </summary>
        public DelegateCommand OpenTimelineResourceDirectoryCommand
        {
            get { return _OpenTimelineResourceDirectoryCommand = _OpenTimelineResourceDirectoryCommand ?? new DelegateCommand(this._OpenTimelineResourceDirectoryExecute); }
        }
        #endregion 

      #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通機能コンポーネント／コンストラクタ
        /// </summary>
        /// <param name="pCommonDataModel"> 共通データモデル </param>
        public CommonComponent(CommonDataModel pCommonDataModel)
            : base(pCommonDataModel)
        {
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.AppDataCreateModule = new AppDataCreateModule();
            this.AppCommonTimerModule = new AppCommonTimerModule();
            this.AppCommonModule = new AppCommonModule();

            return true;
        }

        /// <summary> コンポーネントのセットアップを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns>
        public bool SetupComponent()
        {
            if (base.CommonDataModel == null) return false;

            // --- 初期設定 ---
            this.AppDataCreateModule.AppDataConstSetup(base.CommonDataModel.ApplicationData);
            this.AppDataCreateModule.CreateTimelinePath(base.CommonDataModel);
            this.AppDataCreateModule.CreateTimelineDirectory(base.CommonDataModel.ApplicationData);
            this.AppDataCreateModule.UpdateDataList(base.CommonDataModel.ApplicationData);

            // --- プラグイン設定 ---
            var loadSettingData = this.AppCommonModule.PluginSettingsDataLoad(this.CommonDataModel.ApplicationData.GetTimelineSettingsFullPath);
            if (loadSettingData != null)
            {
                this.CommonDataModel.PluginSettingsData = loadSettingData;
            }
            else
            {
                this.AppCommonModule.SetDefaultPluginSettings(this.CommonDataModel);
            }

            if (string.IsNullOrWhiteSpace(this.CommonDataModel.PluginSettingsData.TimelineResourceDirectory)
                && string.IsNullOrWhiteSpace(this.CommonDataModel.PluginSettingsData.SoundResourceDirectory))
            {
                this.AppCommonModule.SetDefaultResourceDirectory(this.CommonDataModel);
            }

            // --- バージョンアップ管理 ---
            this.AppCommonModule.CreateVersionInfo(base.CommonDataModel);
            this.AppCommonModule.VersionInfoSave(base.CommonDataModel);
            this.AppCommonModule.PluginUpdateCheck(base.CommonDataModel);

            // --- プラグイン画面情報更新 ---
            this.AppCommonModule.CheckTimelineResourceDirectory(this.CommonDataModel);
            this.AppCommonModule.CheckSoundResourceDirectory(this.CommonDataModel);

            return true;
        }

        /// <summary> 自動実行系の処理を開始します。
        /// </summary>
        /// <returns> 正常に開始した場合 True </returns>
        public bool AutoProcessStart()
        {
            // プラグイン設定自動セーブ開始
            this.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.PluginSettingAutoSaveEvent);
            this.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.NewPluginCheckEvent);
            this.AppCommonTimerModule.SecTimer01.Start();

            return true;
        }

        /// <summary> 自動実行系の処理を終了します。
        /// </summary>
        /// <returns> 正常に終了した場合 True </returns>
        public bool AutoProcessEnd()
        {
            // プラグイン設定自動セーブ終了
            this.AppCommonTimerModule.SecTimer01.Stop();
            this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.PluginSettingAutoSaveEvent);
            this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.NewPluginCheckEvent);

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [TimerEvent] プラグイン設定の自動セーブを実行します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void PluginSettingAutoSaveEvent(object o, EventArgs e)
        {
            if (this.CommonDataModel.ApplicationData == null) return;

            this.AppCommonModule.PluginSettingsDataSave(this.CommonDataModel.ApplicationData.GetTimelineSettingsFullPath, this.CommonDataModel.PluginSettingsData);

        }


        /// <summary> [TimerEvent] プラグインの新バージョンがあるかを確認します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void NewPluginCheckEvent(object o, EventArgs e)
        {
            if (!base.CommonDataModel.PluginSettingsData.AutoUpdateChackEnabled)
            {
                return;
            }

            if (this.AppCommonModule.PluginUpdateObjectModel.UpdateClose)
            {
                this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.NewPluginCheckEvent);
            }
            else if (this.AppCommonModule.PluginUpdateObjectModel.NewPlugin)
            {
                this.CommonDataModel.PluginSettingsData.LastUpdateCheckTime = DateTime.Now;
                this.AppCommonModule.PluginUpdateObjectModel.DialogOpen();
            }


        }

        #region #- [Command] DelegateCommand<string>.VisiTestCommand - ＜一時非表示のテストコマンド＞ -----
        /// <summary> 一時非表示のテストコマンド＜コマンド＞ </summary>
        private DelegateCommand<bool?> _VisiTestCommand;
        /// <summary> 一時非表示のテストコマンド＜コマンド＞ </summary>
        public DelegateCommand<bool?> VisiTestCommand
        {
            get { return _VisiTestCommand = _VisiTestCommand ?? new DelegateCommand<bool?>(this._VisiTestExecute); }
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ VisiTestCommand - ＜一時非表示のテストコマンド＞ -----

        /// <summary> コマンド実行＜一時非表示のテストコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _VisiTestExecute(bool? para)
        {
            if (!para.HasValue)
                return;

            this.CommonDataModel.PluginSettingsData.ActCheckBoxValue = para.Value;

            this.CommonDataModel.ViewRefresh();

            if (para.Value)
            {
                this.CommonDataModel.LogDataCollection.Add(
                    Globals.SysLogger.WriteActionLog.Success.INFO.Write("Overlay View Changed: All Visible", Globals.ProjectName));
            }
            else
            {
                this.CommonDataModel.LogDataCollection.Add(
                    Globals.SysLogger.WriteActionLog.Success.INFO.Write("Overlay View Changed: All Hide", Globals.ProjectName));
            }
        }
        #endregion 

        /// <summary> ACT本体に表示されるチェックボックスの値変更コマンド
        /// </summary>
        public void ActCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as System.Windows.Forms.CheckBox;
            this.CommonDataModel.PluginSettingsData.ActCheckBoxValue = chk.Checked;

            this.CommonDataModel.ViewRefresh();
            
            if (chk.Checked)
            {
                this.CommonDataModel.LogDataCollection.Add(
                    Globals.SysLogger.WriteActionLog.Success.INFO.Write("Overlay View Changed: All Visible", Globals.ProjectName));
            }
            else
            {
                this.CommonDataModel.LogDataCollection.Add(
                    Globals.SysLogger.WriteActionLog.Success.INFO.Write("Overlay View Changed: All Hide", Globals.ProjectName));
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Method] CanExecute,Execute @ TimelineResourceDirectoryCahngedCommand - ＜タイムラインリソースディレクトリ更新コマンド＞ -----
        /// <summary> 実行可能確認＜タイムラインリソースディレクトリ更新コマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanTimelineResourceDirectoryCahngedExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜タイムラインリソースディレクトリ更新コマンド＞ </summary>
        private void _TimelineResourceDirectoryCahngedExecute()
        {
            this.AppCommonModule.CheckTimelineResourceDirectory(this.CommonDataModel);
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ SoundResourceDirectoryCahngedCommand - ＜サウンドリソースディレクトリ更新コマンド＞ -----
        /// <summary> 実行可能確認＜サウンドリソースディレクトリ更新コマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanSoundResourceDirectoryCahngedExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜サウンドリソースディレクトリ更新コマンド＞ </summary>
        private void _SoundResourceDirectoryCahngedExecute()
        {
            this.AppCommonModule.CheckSoundResourceDirectory(this.CommonDataModel);
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ TimelineFileListRefreshCommand - ＜タイムラインファイルリスト再作成コマンド＞ -----
        /// <summary> 実行可能確認＜タイムラインファイルリスト再作成コマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanTimelineFileListRefreshExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜タイムラインファイルリスト再作成コマンド＞ </summary>
        private void _TimelineFileListRefreshExecute()
        {
            this.AppCommonModule.CheckTimelineResourceDirectory(this.CommonDataModel);
        }
        #endregion 
        
        #region #- [Method] Execute @ FolderBrowserDialogOpenCommand - ＜フォルダ選択ダイアログオープン＞ -----

        /// <summary> コマンド実行＜フォルダ選択ダイアログオープン＞ </summary>
        /// <param name="para"> パラメータ </param>
        private void _FolderBrowserDialogOpenExecute(string para)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = string.Format("Selected Resource Directory : {0}", para);
            switch (para)
            {
                case "Timeline":

                    if (Directory.Exists(this.CommonDataModel.PluginSettingsData.TimelineResourceDirectory))
                        dialog.SelectedPath =this.CommonDataModel.PluginSettingsData.TimelineResourceDirectory;

                    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    this.CommonDataModel.PluginSettingsData.TimelineResourceDirectory = dialog.SelectedPath;

                    break;

                case "Sound":

                    if (Directory.Exists(this.CommonDataModel.PluginSettingsData.SoundResourceDirectory))
                        dialog.SelectedPath = this.CommonDataModel.PluginSettingsData.SoundResourceDirectory;

                    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    this.CommonDataModel.PluginSettingsData.SoundResourceDirectory = dialog.SelectedPath;
                    break;
            }
        }

        #endregion 

        #region #- [Method] CanExecute,Execute @ SetDefaultResourceDirectoryCommand - ＜デフォルトリソースディレクトリ設定コマンド＞ -----

        /// <summary> コマンド実行＜デフォルトリソースディレクトリ設定コマンド＞ </summary>
        private void _SetDefaultResourceDirectoryExecute()
        {
            this.AppCommonModule.SetDefaultResourceDirectory(this.CommonDataModel);
        }

        #endregion 

        
        #region #- [Method] CanExecute,Execute @ OpenTimelineResourceDirectoryCommand - ＜タイムラインリソースディレクトリオープンコマンド＞ -----

        /// <summary> コマンド実行＜タイムラインリソースディレクトリオープンコマンド＞ </summary>
        private void _OpenTimelineResourceDirectoryExecute()
        {
            System.Diagnostics.Process.Start(
                "EXPLORER.EXE", base.CommonDataModel.PluginSettingsData.TimelineResourceDirectory);
        }
        #endregion 
    }
}
