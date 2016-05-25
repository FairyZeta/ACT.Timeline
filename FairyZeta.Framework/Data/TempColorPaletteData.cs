using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／作業用カラーパレットデータ
    /// </summary>
    public class TempColorPaletteData : ColorPaletteData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 追加カラー文字コレクション
        /// </summary>
        public ObservableCollection<string> AddColorStringCollection { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／作業用カラーパレットデータ／コンストラクタ
        /// </summary>
        public TempColorPaletteData()
            : base()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.AddColorStringCollection = new ObservableCollection<string>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
