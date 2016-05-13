using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using FairyZeta.Framework;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using System.Windows.Forms.Integration;
using Advanced_Combat_Tracker;

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
        public void NewOverlayOpen(CommonDataModel pCommonDM, TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            switch(pOverlayViewComponent.OverlayDataModel.OverlayWindowData.OverlayType)
            {
                case OverlayType.StandardTimeline:
                    this.openStandardTimelineView(pCommonDM, pTimelineComponent, pOverlayViewComponent);
                    break;
                case OverlayType.TimelineControl:
                    this.openOverlayControlView(pCommonDM, pTimelineComponent, pOverlayViewComponent);
                    break;
                default:
                    return;
            }

            return;
        }

        /// <summary> 新しいオーバーレイカスタムウィンドウを作成し、表示します。
        /// </summary>
        /// <param name="pOverlayViewComponent"> カスタム対象のオーバーレイコンポーネント </param>
        public void NewOverlayCustomWindowOpen(CommonDataModel pCommonDM, OverlayViewComponent pOverlayViewComponent)
        {
            pOverlayViewComponent.OverlayDataModel.OverlayViewData.OverlayCustomClosed = false;

            OverlayCustomWindow window = new OverlayCustomWindow();
            ElementHost.EnableModelessKeyboardInterop(window);
            var vm = window.DataContext as OverlayCustomWindowViewModel;
            if (vm == null) return;

            vm.OverlayViewComponent = pOverlayViewComponent;

            if (pOverlayViewComponent.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }

            // ViewのIntPtrを採取
            IntPtr intPtr = new WindowInteropHelper(window).Handle;
            if (!pCommonDM.AppCommonData.ViewIntPtrList.Contains(intPtr))
            {
                pCommonDM.AppCommonData.ViewIntPtrList.Add(intPtr);
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 標準型タイムラインビューを開きます。
        /// </summary>
        /// <param name="pTimelineC"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewC"> オーバーレイ表示コンポーネント </param>
        private void openStandardTimelineView(CommonDataModel pCommonDM, TimelineComponent pTimelineC, OverlayViewComponent pOverlayViewC)
        {
            OverlayWindow window = new OverlayWindow();

            window.Topmost = true;
            var vm = window.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineC;
                vm.OverlayViewComponent = pOverlayViewC;
            }

            if (pOverlayViewC.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }

            // ViewのIntPtrを採取
            IntPtr intPtr = new WindowInteropHelper(window).Handle;
            pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr = intPtr;
            if (!pCommonDM.AppCommonData.ViewIntPtrList.Contains(intPtr))
            {
                pCommonDM.AppCommonData.ViewIntPtrList.Add(intPtr);
            }

            if(pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }

        /// <summary> タイムラインコントロールビューを開きます。
        /// </summary>
        /// <param name="pTimelineC"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewC"> オーバーレイ表示コンポーネント </param>
        private void openOverlayControlView(CommonDataModel pCommonDM, TimelineComponent pTimelineC, OverlayViewComponent pOverlayViewC)
        {
            OverlayWindow window = new OverlayWindow();

            window.Topmost = true;
            window.ResizeMode = System.Windows.ResizeMode.NoResize;
            pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowHeight = 30;
            pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowWidth = 170;

            var vm = window.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineC;
                vm.OverlayViewComponent = pOverlayViewC;
            }

            if (pOverlayViewC.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                window.Show();
            }

            // ViewのIntPtrを採取
            IntPtr intPtr = new WindowInteropHelper(window).Handle;
            pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr = intPtr;
            if (!pCommonDM.AppCommonData.ViewIntPtrList.Contains(intPtr))
            {
                pCommonDM.AppCommonData.ViewIntPtrList.Add(intPtr);
            }

            if (pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }
    }
}
