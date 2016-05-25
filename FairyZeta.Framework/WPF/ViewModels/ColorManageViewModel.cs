using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Component;

namespace FairyZeta.Framework.WPF.ViewModels
{
    /// <summary> FZ／カラー管理ビューモデル
    /// </summary>
    public class ColorManageViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> カラーツールコンポーネント
        /// </summary>
        public ColorToolComponent ColorToolComponent { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／カラー管理ビューモデル
        /// </summary>
        public ColorManageViewModel()
        {
            this.initViewModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.ColorToolComponent = new ColorToolComponent();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
