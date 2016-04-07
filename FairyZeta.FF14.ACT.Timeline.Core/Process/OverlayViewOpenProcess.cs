using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／ビューオープンプロセス
    /// </summary>
    public class OverlayViewOpenProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ビューオープンプロセス／コンストラクタ
        /// </summary>
        public OverlayViewOpenProcess()
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
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 新しいオーバーレイを作成し、表示します。
        /// </summary>
        /// <param name="pTimelineComponent"></param>
        /// <param name="pViewControlComponent"></param>
        public void NewOverlayOpen(TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            switch(pOverlayViewComponent.OverlayDataModel.OverlayWindowData.OverlayType)
            {
                case OverlayType.StandardTimeline:
                    this.openStandardTimelineView(pTimelineComponent, pOverlayViewComponent);
                    break;
                default:
                    return;
            }

            return;
        }

        /// <summary> 新しいオーバーレイカスタムウィンドウを作成し、表示します。
        /// </summary>
        /// <param name="pOverlayViewComponent"> カスタム対象のオーバーレイコンポーネント </param>
        public void NewOverlayCustomWindowOpen(OverlayViewComponent pOverlayViewComponent)
        {
            OverlayCustomWindow window = new OverlayCustomWindow();

            var vm = window.DataContext as OverlayCustomWindowViewModel;
            if (vm == null) return;

            vm.OverlayViewComponent = pOverlayViewComponent;

            window.Show();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 標準型タイムラインビューを開きます。
        /// </summary>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewComponent"> オーバーレイ表示コンポーネント </param>
        private void openStandardTimelineView(TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            OverlayWindowView view = new OverlayWindowView();

            view.Topmost = true;
            var vm = view.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineComponent;
                vm.OverlayViewComponent = pOverlayViewComponent;
            }

            view.Show();

            pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowIntPrt = new WindowInteropHelper(view).Handle;
        }

    }
}
