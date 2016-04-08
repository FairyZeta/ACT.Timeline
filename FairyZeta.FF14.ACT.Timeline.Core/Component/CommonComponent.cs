using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーションのセットアップを実行します。
        /// </summary>
        /// <param name="pCommonDataModel"> セットアップに使用するアプリケーションデータ </param>
        public void SetupApplication(CommonDataModel pCommonDataModel)
        {
            if (pCommonDataModel == null) return;

            this.AppDataCreateModule.AppDataConstSetup(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.CreateTimelinePath(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.CreateTimelineDirectory(pCommonDataModel.ApplicationData);
            this.AppDataCreateModule.UpdateDataList(pCommonDataModel.ApplicationData);

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
