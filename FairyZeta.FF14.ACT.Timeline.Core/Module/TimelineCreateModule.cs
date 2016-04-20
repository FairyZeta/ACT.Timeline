using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムラインデータ生成モジュール
    /// </summary>
    public class TimelineCreateModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- Proccess ---

        /// <summary> [Util] double処理用プロセス
        /// </summary>
        private DoubleToAdjustProcess doubleToAdjustProcess;
        /// <summary> タイムラインアイテム解析プロセス
        /// </summary>
        private TimelineItemAnalyzProcess timelineItemAnalyzProcess;

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインデータ生成モジュール／コンストラクタ
        /// </summary>
        public TimelineCreateModule()
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
            this.doubleToAdjustProcess = new DoubleToAdjustProcess();
            this.timelineItemAnalyzProcess = new TimelineItemAnalyzProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインデータモデルを生成します。
        /// </summary>
        /// <param name="pCommonDM"> 共通データモデル </param>
        /// <param name="pTimelineDM"> 作成データを格納するタイムラインデータモデル </param>
        /// <param name="pTimerDM"> タイマーデータモデル </param>
        //public void CreateTimelineDataModel(CommonDataModel pCommonDM, TimelineDataModel pTimelineDM, TimerDataModel pTimerDM)
        public void CreateTimelineDataModel(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            switch(pCommonDM.AppStatusData.TimelineLoadStatus)
            {
                case TimelineLoadStatus.NowLoading:
                    return;
            }

            this.TimelineDataClear(pCommonDM, pTimelineOM);

            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.NowLoading;
            this.TimelineFunctionEnabledChange(pCommonDM);

            Globals.SoundFilesRoot = pCommonDM.PluginSettingsData.SoundResourceDirectory;

            if (pCommonDM.SelectedTimelineFileData == null)
            {
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                this.TimelineFunctionEnabledChange(pCommonDM);
                return;
            }

            try
            {
                TimelineLoader.LoadFromFile(pTimelineOM, pCommonDM.SelectedTimelineFileData.TimelineFileFullPath);
            }
            catch (Exception e)
            {
                pCommonDM.LogDataCollection.Add(Globals.SysLogger.WriteSystemLog.Failure.ERROR.Write(e.Message,Globals.ProjectName));
                Globals.ErrLogger.WriteStackTrace(e);
                pCommonDM.AppCommonData.TimelineLoadErrorMsg = "LoadError: " + e.Message;
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                this.TimelineFunctionEnabledChange(pCommonDM);

                pCommonDM.SelectedTimelineFileData.TimelineFileName = string.Empty;
                pCommonDM.SelectedTimelineFileData.TimelineFileFullPath = string.Empty;

                return;
            }
            finally
            {
            }
            
            // タイムラインアイテムコレクションの生成
            foreach (var data in pTimelineOM.ActivityCollection)
            {
                // タイムラインタイプとジョブを設定
                this.timelineItemAnalyzProcess.SetTimelineType(data);
                this.timelineItemAnalyzProcess.SetTimelineJob(data);
            }

            // 最終ロードファイルの変更
            pCommonDM.PluginSettingsData.LastLoadTimelineFileName = pCommonDM.SelectedTimelineFileData.TimelineFileName;
            pCommonDM.PluginSettingsData.LastLoadTimelineFullPath = pCommonDM.SelectedTimelineFileData.TimelineFileFullPath;

            pCommonDM.ViewRefresh();
            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Success;
            this.TimelineFunctionEnabledChange(pCommonDM);
        }

        /// <summary> タイムラインデータのクリアを実行し、ステータスを変更します。
        /// </summary>
        /// <param name="pCommonDM"></param>
        /// <param name="pTimelineDM"></param>
        public void TimelineDataClear(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            pTimelineOM.TimerData.Clear();
            pTimelineOM.Clear();

            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.NonLoad;
            this.TimelineFunctionEnabledChange(pCommonDM);

            pCommonDM.ViewRefresh();

            return;
        }

        /// <summary> タイムラインロードステータスを参照し、機能の有効状態を更新します。
        /// </summary>
        /// <param name="pCommonDM"></param>
        public void TimelineFunctionEnabledChange(CommonDataModel pCommonDM)
        {
            switch (pCommonDM.AppStatusData.TimelineLoadStatus)
            {
                case TimelineLoadStatus.NowLoading:

                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = false;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = false;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = false;

                    break;

                case TimelineLoadStatus.Success:
                    
                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = true;
                    if (pCommonDM.SelectedTimelineFileData == null)
                    {
                        pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    }
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = true;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = true;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = true;

                    break;

                case TimelineLoadStatus.NonLoad:
                case TimelineLoadStatus.NotFoundTimeline:
                case TimelineLoadStatus.Failure:
                    
                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = true;
                    if (pCommonDM.SelectedTimelineFileData == null)
                    {
                        pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    }
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = true;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = false;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = false;

                    break;
            }

            pCommonDM.ViewRefresh();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
