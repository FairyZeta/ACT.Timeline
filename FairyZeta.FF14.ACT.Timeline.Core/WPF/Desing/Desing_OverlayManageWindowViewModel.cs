using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Desing
{
    /// <summary> [デザイン用] オーバーレイ管理ビューモデル
    /// </summary>
    public class Desing_OverlayManageWindowViewModel : OverlayManageWindowViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        DataModel.CommonDataModel model;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [デザイン用] オーバーレイ管理ビューモデル／コンストラクタ
        /// </summary>
        public Desing_OverlayManageWindowViewModel()
            : base()
        {
            this.initViewModel();

            base.OverlayManageComponent = new Component.OverlayManageComponent(new TimelineComponent(model), model);
            this.createDesingData_P001();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.model = new DataModel.CommonDataModel();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デザイン用データの生成（パターン１）
        /// </summary>
        private void createDesingData_P001()
        {
            for(int i = 0; i<30;i++)
            {
                OverlayViewComponent component = new OverlayViewComponent(model);
                component.OverlayDataModel.OverlayWindowData.OverlayName = "デザイン用オーバーレイ" + i.ToString();
                component.OverlayDataModel.OverlayWindowData.OverlayType = OverlayType.StandardTimeline;

                base.OverlayManageComponent.OverlayManageDataModel.OverlayViewComponentCollection.Add(component);
            }
        }
    }
}
