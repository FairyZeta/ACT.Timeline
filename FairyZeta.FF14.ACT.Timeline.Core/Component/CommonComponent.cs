using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prism.Commands;
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

      #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通機能コンポーネント／コンストラクタ
        /// </summary>
        /// <param name="pCommonDataModel"> 共通データモデル </param>
        /// <param name="pSetupCommonDataFLG"> アプリケーションセットアップを実行する場合 True </param>
        public CommonComponent(CommonDataModel pCommonDataModel, bool pAppInitSetupFLG)
            : base(pCommonDataModel)
        {
            this.initComponent();

            if(pAppInitSetupFLG)
            {
                this.SetupApplication(base.CommonDataModel);
            }
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

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーションのセットアップを実行します。
        /// </summary>
        /// <param name="pCommonDataModel"> セットアップに使用するアプリケーションデータ </param>
        public void SetupApplication(CommonDataModel pCommonDataModel)
        {
            // ロガー生成
            this.AppDataCreateModule.CreateLogger();

            if (pCommonDataModel == null) return;

            // --- 初期設定 ---
            this.AppDataCreateModule.AppDataConstSetup(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.CreateTimelinePath(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.CreateTimelineDirectory(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.UpdateDataList(pCommonDataModel.ApplicationData);

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

            // --- プラグイン画面情報更新 ---
            this.AppCommonModule.CheckTimelineResourceDirectory(this.CommonDataModel);
            this.AppCommonModule.CheckSoundResourceDirectory(this.CommonDataModel);
        }

        /// <summary> [TimerEvent] プラグイン設定の自動セーブを実行します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void PluginSettingAutoSaveEvent(object o, EventArgs e)
        {
            if (this.CommonDataModel.ApplicationData == null) return;

            this.AppCommonModule.PluginSettingsDataSave(this.CommonDataModel.ApplicationData.GetTimelineSettingsFullPath, this.CommonDataModel.PluginSettingsData);

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

    }
}
