using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／オーバーレイコントロールモジュール
    /// </summary>
    public class OverlayControlModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フィルタ設定モジュール
        /// </summary>
        private SetFilterProcess setFilterProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイコントロールモジュール／コンストラクタ
        /// </summary>
        public OverlayControlModule()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.setFilterProcess = new SetFilterProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの値を参照し、全てのフィルター設定を実行します。
        /// </summary>
        /// <param name="pOverlayDM"> 設定するデータモデル </param>
        public void SetAllFilter(OverlayDataModel pOverlayDM)
        {
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.UNKNOWN);
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.ENEMY  );
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.TANK   );
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.DPS    );
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.HEALER );
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.PET    );
            this.SetTimelineTypeFilter(pOverlayDM, TimelineType.GIMMICK);

            this.SetJobFilter(pOverlayDM, Job.UNKNOWN);
            this.SetJobFilter(pOverlayDM, Job.NON    );
            this.SetJobFilter(pOverlayDM, Job.PLD    );
            this.SetJobFilter(pOverlayDM, Job.MNK    );
            this.SetJobFilter(pOverlayDM, Job.WAR    );
            this.SetJobFilter(pOverlayDM, Job.DRG    );
            this.SetJobFilter(pOverlayDM, Job.BRD    );
            this.SetJobFilter(pOverlayDM, Job.NIN    );
            this.SetJobFilter(pOverlayDM, Job.WHM    );
            this.SetJobFilter(pOverlayDM, Job.BLM    );
            this.SetJobFilter(pOverlayDM, Job.SMN    );
            this.SetJobFilter(pOverlayDM, Job.SCH    );
            this.SetJobFilter(pOverlayDM, Job.DKN    );
            this.SetJobFilter(pOverlayDM, Job.AST    );
            this.SetJobFilter(pOverlayDM, Job.MCN    );
            this.SetJobFilter(pOverlayDM, Job.EGI    );
            this.SetJobFilter(pOverlayDM, Job.FAIRY  );
            this.SetJobFilter(pOverlayDM, Job.TURRET );

            //this.SetJobFilter(pOverlayDM, TankModeNON = true;
            //this.SetJobFilter(pOverlayDM, TankModeMT = true;
            //this.SetJobFilter(pOverlayDM, TankModeST = true;
            //this.SetJobFilter(pOverlayDM, TankModeOT = true;

        }

        /// <summary> タイムラインタイプのフィルタを設定します。
        /// </summary>
        /// <param name="pOverlayDataModel"> フィルタ設定するデータモデル </param>
        /// <param name="pType"> 設定するタイムラインタイプ </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        public void SetTimelineTypeFilter(OverlayDataModel pOverlayDataModel, TimelineType pType)
        {
            switch (pType)
            {
                case TimelineType.UNKNOWN:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeUNKNOWN);
                    break;
                case TimelineType.ENEMY:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeENEMY);
                    break;
                case TimelineType.TANK:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeTANK);
                    break;
                case TimelineType.DPS:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeDPS);
                    break;
                case TimelineType.HEALER:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeHEALER);
                    break;
                case TimelineType.PET:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypePET);
                    break;
                case TimelineType.GIMMICK:
                    this.setFilterProcess.SetTimelineTypeFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pType, pOverlayDataModel.OverlayFilterSettingsData.TypeGIMMICK);
                    break;

                default:
                    return;
            }
        }

        /// <summary> ジョブタイプのフィルタを設定します。
        /// </summary>
        /// <param name="pOverlayDataModel"> フィルタ設定するデータモデル </param>
        /// <param name="pJob"> 設定するジョブタイプ </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        public void SetJobFilter(OverlayDataModel pOverlayDataModel, Job pJob)
        {
            switch (pJob)
            {
                case Job.UNKNOWN:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobUNKNOWN);
                    break;
                case Job.NON:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobNON);
                    break;

                case Job.PLD:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobPLD);
                    break;
                case Job.WAR:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobWAR);
                    break;
                case Job.DKN:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobDKN);
                    break;

                case Job.MNK:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobMNK);
                    break;
                case Job.DRG:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobDRG);
                    break;
                case Job.BRD:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobBRD);
                    break;
                case Job.NIN:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobNIN);
                    break;
                case Job.BLM:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobBLM);
                    break;
                case Job.SMN:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobSMN);
                    break;
                case Job.MCN:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobMCN);
                    break;

                case Job.WHM:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobWHM);
                    break;
                case Job.SCH:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobSCH);
                    break;
                case Job.AST:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobAST);
                    break;

                case Job.EGI:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobEGI);
                    break;
                case Job.FAIRY:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobFAIRY);
                    break;
                case Job.TURRET:
                    this.setFilterProcess.SetJobFilter(
                        pOverlayDataModel.OverlayViewData.TimelineViewSource, pJob, pOverlayDataModel.OverlayFilterSettingsData.JobTURRET);
                    break;

                default:
                    return;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
