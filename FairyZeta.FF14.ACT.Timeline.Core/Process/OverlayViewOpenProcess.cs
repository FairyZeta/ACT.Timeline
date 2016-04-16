using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using FairyZeta.Framework;
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
                case OverlayType.TimelineControl:
                    this.openOverlayControlView(pTimelineComponent, pOverlayViewComponent);
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
            pOverlayViewComponent.OverlayDataModel.OverlayViewData.OverlayCustomClosed = false;

            OverlayCustomWindow window = new OverlayCustomWindow();

            var vm = window.DataContext as OverlayCustomWindowViewModel;
            if (vm == null) return;

            vm.OverlayViewComponent = pOverlayViewComponent;

            if (pOverlayViewComponent.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 標準型タイムラインビューを開きます。
        /// </summary>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewComponent"> オーバーレイ表示コンポーネント </param>
        private void openStandardTimelineView(TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            OverlayWindowView window = new OverlayWindowView();

            window.Topmost = true;
            var vm = window.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineComponent;
                vm.OverlayViewComponent = pOverlayViewComponent;
            }

            if (pOverlayViewComponent.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }

            pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowIntPtr = new WindowInteropHelper(window).Handle;

            if(pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }

        /// <summary> タイムラインコントロールビューを開きます。
        /// </summary>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewComponent"> オーバーレイ表示コンポーネント </param>
        private void openOverlayControlView(TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            OverlayWindowView window = new OverlayWindowView();

            window.Topmost = true;
            window.ResizeMode = System.Windows.ResizeMode.NoResize;
            pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowHeight = 24;
            pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowWidth = 150;

            var vm = window.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineComponent;
                vm.OverlayViewComponent = pOverlayViewComponent;
            }

            if (pOverlayViewComponent.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }

            pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowIntPtr = new WindowInteropHelper(window).Handle;

            if (pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }
    }
}
