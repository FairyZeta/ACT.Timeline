using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Desing
{
    /// <summary> [画面デザイン用] タイムライン／タイムラインデータモデル
    /// </summary>
    public class Desing_BaseWindowViewModel : OverlayWindowViewModel
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        private DataModel.CommonDataModel model;

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [画面デザイン用] タイムライン／タイムラインデータモデル／コンストラクタ
        /// </summary>
        public Desing_BaseWindowViewModel()
            : base()
        {
            this.initComponent();
            this.createDesingData_P001();
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            model = new DataModel.CommonDataModel();
            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デザイン用データ（パターン１）の生成
        /// </summary>
        private void createDesingData_P001()
        {
                base.TimelineComponent = new Component.TimelineComponent(model);
                base.OverlayViewComponent = new Component.OverlayViewComponent(model);

                for (double d = 0; d < (double)60.0; d += (double)1.0)
                {
                    TimelineItemData item = new TimelineItemData(new TimerData());
                    item.ActivityIndex = Convert.ToInt32(d * 10);
                    item.ActivityNo = d;
                    item.ActivityName = "デザイン＠" + item.ActivityNo.ToString();
                    item.TimelineType = TimelineType.ENEMY;

                    base.TimelineComponent.TimelineDataModel.TimelineItemCollection.Add(item);
                    base.OverlayViewComponent.OverlayDataModel.OverlayViewData.TimelineViewSource = new System.Windows.Data.CollectionViewSource() { Source = base.TimelineComponent.TimelineDataModel.TimelineItemCollection };
                }

        }
    }
}
