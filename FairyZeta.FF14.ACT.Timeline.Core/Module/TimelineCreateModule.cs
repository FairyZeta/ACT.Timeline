using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

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
        public DoubleToAdjustProcess DoubleToAdjustProcess { get; private set; }

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
            this.DoubleToAdjustProcess = new DoubleToAdjustProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインデータモデルを生成します。
        /// </summary>
        /// <param name="pCommonDM"> 共通データモデル </param>
        /// <param name="pTimelineDM"> 作成データを格納するタイムラインデータモデル </param>
        public void CreateTimelineDataModel(CommonDataModel pCommonDM, TimelineDataModel pTimelineDM, TimerDataModel pTimerDM)
        {
            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.NonLoad;

            if (pCommonDM.SelectedTimelineFileData == null)
            {
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                return;
            }

            try
            {
                pTimelineDM.Timeline = TimelineLoader.LoadFromFile(pCommonDM.SelectedTimelineFileData.TimelineFileFullPath);
            }
            catch
            {
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                return;
            }

            var baseData = pTimelineDM.Timeline;

            if (baseData.Items.Count() == 0) return;

            // アンカーコレクション
            foreach (var anc in pTimelineDM.Timeline.Anchors)
            {
                pTimelineDM.TimelineAnchorDataCollection.Add(anc);
            }

            //// ジャンプコレクションの生成
            //var jumpList = baseData.Anchors.Where(j => j.Jump >= 0);
            //foreach (var anc in jumpList)
            //{
            //    pTimelineDM.JumpItemCollection.Add(anc);
            //}
            //
            //// シンクコレクションの生成
            //var syncList = baseData.Anchors.Where(s => s.Jump == -1.0);
            //foreach (var anc in syncList)
            //{
            //    pTimelineDM.SyncItemCollection.Add(anc);
            //}

            // タイムラインアイテムコレクションの生成
            foreach (var data in baseData.Items)
            {
                TimelineItemData target = new TimelineItemData(pTimerDM.TimerDeta);

                target.ActivityNo = this.DoubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1);
                target.ActivityIndex = Convert.ToInt32(target.ActivityNo * 10);
                target.Duration = data.Duration;
                target.ActivityName = data.Name;
                target.TimelineType = TimelineType.ENEMY;
                target.JobType = Job.NON;
                target.ActivityTime = new TimeSpan(0, 0, Convert.ToInt32(target.EndTime));

                target.ActiveIndicatorStartTime = target.ActiveTime - target.ActiveIndicatorMaxValue;
                if(target.DurationIndicatorMaxValue > 0)
                {
                    target.DurationIndicatorVisibility = true;
                }


                if(target.ActivityName.IndexOf("[T]") > -1)
                {
                    target.TimelineType = TimelineType.TANK;
                }
                else if (target.ActivityName.IndexOf("[H]") > -1)
                {
                    target.TimelineType = TimelineType.HEALER;
                }
                else if (target.ActivityName.IndexOf("[D]") > -1)
                {
                    target.TimelineType = TimelineType.DPS;
                }
                else if (target.ActivityName.IndexOf("[G]") > -1)
                {
                    target.TimelineType = TimelineType.GIMMICK;
                }

                else if (target.ActivityName.IndexOf("[PLD]") > -1)
                {
                    target.TimelineType = TimelineType.TANK;
                }
                else if (target.ActivityName.IndexOf("[WHM]") > -1)
                {
                    target.TimelineType = TimelineType.HEALER;
                }
                else if (target.ActivityName.IndexOf("[DRG]") > -1)
                {
                    target.TimelineType = TimelineType.DPS;
                }
                else if (target.ActivityName.IndexOf("[SCH]") > -1)
                {
                    target.JobType = Job.SCH;
                    target.TimelineType = TimelineType.HEALER;
                }
                else if (target.ActivityName.IndexOf("[FAIRY]") > -1)
                {
                    target.JobType = Job.FAIRY;
                    target.TimelineType = TimelineType.PET;
                }

                target.SyncItemData = pTimelineDM.TimelineAnchorDataCollection.FirstOrDefault(s => s.TimeFromStart == target.ActivityNo);
                // ジャンプとシンクの設定
                //if(pTimelineDM.SyncItemCollection.Count > 0)
                //{
                //    target.SyncItemData = pTimelineDM.SyncItemCollection.FirstOrDefault(s => s.TimeFromStart == target.ActivityNo);
                //}
                //if(pTimelineDM.JumpItemCollection.Count > 0)
                //{
                //    target.JumpItemData = pTimelineDM.JumpItemCollection.FirstOrDefault(j => j.TimeFromStart == target.ActivityNo);
                //}

                pTimelineDM.TimelineItemCollection.Add(target);
                
            }

            // アラートコレクションの生成
            foreach (var data in baseData.Alerts)
            {
                var targt = pTimelineDM.TimelineItemCollection.FirstOrDefault(item => item.ActivityNo == this.DoubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1));
                if(targt != null)
                {
                    targt.ActivityAlert = data;
                }
            }

            //var activeItems = pDataModel.TimelineItemCollection.Where(i => !string.IsNullOrWhiteSpace(i.ActivityName));
            //foreach (var item in activeItems)
            //{
            //    pDataModel.TimelineActiveItemCollection.Add(item);
            //}
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
