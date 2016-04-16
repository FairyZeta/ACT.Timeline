using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Component;

namespace FairyZeta.FF14.ACT.WPF.ViewModels
{
    /// <summary> ACT／アップデートダイアログビューモデル
    /// </summary>
    public class UpdateDialogWindowViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アップデートダイアログコンポーネント
        /// </summary>
        public UpdateDialogComponent UpdateDialogComponent { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／アップデートダイアログビューモデル／コンストラクタ
        /// </summary>
        public UpdateDialogWindowViewModel()
        {
            this.initViewModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.UpdateDialogComponent = new UpdateDialogComponent();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
