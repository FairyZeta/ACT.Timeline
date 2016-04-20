using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataFilter
{
    /// <summary> タイムライン／ジョブフィルタ
    /// </summary>
    public class JobFilter : _DataFilter
    {   
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ジョブフィルタ／コンストラクタ
        /// </summary>
        public JobFilter()
            : base()
        {
            this.initFilter();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フィルタの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initFilter()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> Job.UNKNOWNを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobUNKNOWN(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.UNKNOWN);
            return;
        }
        /// <summary> Job.NONを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobNON(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.NON);
            return;
        }

        /// <summary> Job.PLDを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobPLD(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.PLD);
            return;
        }
        /// <summary> Job.WARを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobWAR(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.WAR);
            return;
        }
        /// <summary> Job.DKNを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobDKN(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.DKN);
            return;
        }

        /// <summary> Job.MNKを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobMNK(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.MNK);
            return;
        }
        /// <summary> Job.DRGを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobDRG(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.DRG);
            return;
        }
        /// <summary> Job.BRDを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobBRD(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.BRD);
            return;
        }
        /// <summary> Job.NINを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobNIN(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.NIN);
            return;
        }
        /// <summary> Job.BLMを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobBLM(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.BLM);
            return;
        }
        /// <summary> Job.SMNを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobSMN(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.SMN);
            return;
        }
        /// <summary> Job.MCNを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobMCN(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.MCN);
            return;
        }

        /// <summary> Job.WHMを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobWHM(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.WHM);
            return;
        }
        /// <summary> Job.SCHを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobSCH(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.SCH);
            return;
        }
        /// <summary> Job.ASTを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobAST(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.AST);
            return;
        }

        /// <summary> Job.EGIを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobEGI(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.EGI);
            return;
        }
        /// <summary> Job.FAIRYを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobFAIRY(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.FAIRY);
            return;
        }
        /// <summary> Job.TURRETを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_JobTURRET(object sender, FilterEventArgs e)
        {
            this.setJobFilter(e, Job.TURRET);
            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> パラメータ指定されたJobのアイテムを非表示にします。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pTimelineType"></param>
        private void setJobFilter(FilterEventArgs e, Job pJob)
        {
            if (e.Accepted == false) return;

            var data = e.Item as TimelineActivityData;
            if (data == null || data.JobType != pJob) return;

            e.Accepted = false;

            return;
            
        }
    }
}
