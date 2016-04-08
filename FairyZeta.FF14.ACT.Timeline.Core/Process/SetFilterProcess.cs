using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataFilter;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／フィルタセットプロセス
    /// </summary>
    public class SetFilterProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 汎用フィルタ
        /// </summary>
        private CommonFilter commonFilter;
        /// <summary> アクティビティ名データフィルタ
        /// </summary>
        private ActivityNameFilter activityNameFilter;
        /// <summary> タイプデータフィルタ
        /// </summary>
        private TypeFilter typeFilter;
        /// <summary> ジョブデータフィルタ
        /// </summary>
        private JobFilter jobFilter;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／フィルタセットプロセス／コンストラクタ
        /// </summary>
        public SetFilterProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            this.commonFilter = new CommonFilter();
            this.activityNameFilter = new ActivityNameFilter();
            this.typeFilter = new TypeFilter();
            this.jobFilter = new JobFilter();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> CollectionViewSourceにフィルタリセットを設定します。
        /// <para> ＊ pAccepted のboolに注意すること。意味が逆になってる。 </para>
        /// </summary>
        /// <param name="pCollectionViewSource"> フィルタ設定するCollectionViewSource </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        public void SetResetFilter(CollectionViewSource pCollectionViewSource, bool pAccepted)
        {
            this.ascceptedFilter(pCollectionViewSource, new FilterEventHandler(this.commonFilter.Filter_Reset), pAccepted);

            return;
        }

        /// <summary> TimelineTypeによるフィルタを設定します。
        /// <para> ＊ pAccepted のboolに注意すること。意味が逆になってる。 </para>
        /// </summary>
        /// <param name="pCollectionViewSource"> フィルタ設定するCollectionViewSource </param>
        /// <param name="pTimelineType"> 設定対象のTimelineType </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        public void SetTimelineTypeFilter(CollectionViewSource pCollectionViewSource, TimelineType pTimelineType, bool pAccepted)
        {
            FilterEventHandler filter = null;
            switch (pTimelineType)
            {
                case TimelineType.UNKNOWN:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeENEMY);
                    break;
                case TimelineType.ENEMY:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeENEMY);
                    break;
                case TimelineType.TANK:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeTANK);
                    break;
                case TimelineType.DPS:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeDPS);
                    break;
                case TimelineType.HEALER:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeHEALER);
                    break;
                case TimelineType.PET:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypePET);
                    break;
                case TimelineType.GIMMICK:
                    filter = new FilterEventHandler(this.typeFilter.Filter_TypeGIMMICK);
                    break;

                default:
                    return;
            }
            
            if (filter == null) return;

            this.ascceptedFilter(pCollectionViewSource, filter, pAccepted);

            return;
        }

        /// <summary> Jobによるフィルタを設定します。
        /// <para> ＊ pAccepted のboolに注意すること。意味が逆になってる。 </para>
        /// </summary>
        /// <param name="pCollectionViewSource"> フィルタ設定するCollectionViewSource </param>
        /// <param name="pJob"> 設定対象のJob </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        public void SetJobFilter(CollectionViewSource pCollectionViewSource, Job pJob, bool pAccepted)
        {
            FilterEventHandler filter = null;
            switch (pJob)
            {
                case Job.UNKNOWN:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobUNKNOWN);
                    break;
                case Job.NON:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobNON);
                    break;

                case Job.PLD:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobPLD);
                    break;
                case Job.WAR:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobWAR);
                    break;
                case Job.DKN:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobDKN);
                    break;

                case Job.MNK:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobMNK);
                    break;
                case Job.DRG:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobDRG);
                    break;
                case Job.BRD:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobBRD);
                    break;
                case Job.NIN:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobNIN);
                    break;
                case Job.BLM:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobBLM);
                    break;
                case Job.SMN:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobSMN);
                    break;
                case Job.MCN:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobMCN);
                    break;

                case Job.WHM:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobWHM);
                    break;
                case Job.SCH:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobSCH);
                    break;
                case Job.AST:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobAST);
                    break;

                case Job.EGI:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobEGI);
                    break;
                case Job.FAIRY:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobFAIRY);
                    break;
                case Job.TURRET:
                    filter = new FilterEventHandler(this.jobFilter.Filter_JobTURRET);
                    break;

                default:
                    return;
            }

            if (filter == null) return;

            this.ascceptedFilter(pCollectionViewSource, filter, pAccepted);

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フィルタの設定／解除を実行します。
        /// </summary>
        /// <param name="pCollectionViewSource"> フィルタ設定するCollectionViewSource </param>
        /// <param name="pFilter"> 対象フィルタ </param>
        /// <param name="pAccepted"> フィルタ追加する場合は False, フィルタ解除する場合は True </param>
        private void ascceptedFilter(CollectionViewSource pCollectionViewSource, FilterEventHandler pFilter, bool pAccepted)
        {
            if (!pAccepted)
            {
                pCollectionViewSource.Filter += pFilter;
            }
            else
            {
                pCollectionViewSource.Filter -= pFilter;
            }

            if (pCollectionViewSource.View != null) pCollectionViewSource.View.Refresh();

        }
    }
}
