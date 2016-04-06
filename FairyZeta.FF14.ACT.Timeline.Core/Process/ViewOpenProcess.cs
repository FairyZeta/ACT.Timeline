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
    public class ViewOpenProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ビューオープンプロセス／コンストラクタ
        /// </summary>
        public ViewOpenProcess()
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

        public void NewWindowOpen(TimelineComponent pTimelineComponent, OverlayViewComponent pViewControlComponent)
        {
            OverlayWindowView view = new OverlayWindowView();

            view.Topmost = true;
            var vm = view.DataContext as OverlayWindowViewModel;
            if (vm != null)
            {
                vm.TimelineComponent = pTimelineComponent;
                vm.ViewControlComponent = pViewControlComponent;
            }

            view.Show();

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
