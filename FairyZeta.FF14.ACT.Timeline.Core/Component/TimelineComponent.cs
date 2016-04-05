//-------------------------
// code by FairyZeta.
//-------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／タイムラインコンポーネント
    /// </summary>
    public class TimelineComponent
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- DataModels ---
        
        public TimelineDataModel TimelineDataModel { get; private set; }
        
        #endregion

        #region --- Modules ---

        public TimelineCreateModule TimelineCreateModule { get; private set; }

        public TimelineControlModule TimelineControlModule { get; private set; }

        public ViewControlModule ViewControlModule { get; private set; }

        #endregion

        #region --- Commands ---
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインコンポーネント／コンストラクタ
        /// </summary>
        public TimelineComponent()
        {
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.TimelineDataModel = new TimelineDataModel();

            this.TimelineCreateModule = new TimelineCreateModule();
            this.TimelineControlModule = new TimelineControlModule();
            this.ViewControlModule = new ViewControlModule();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void TimelineLoda()
        {
            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
