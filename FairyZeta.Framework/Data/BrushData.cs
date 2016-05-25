using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／ブラシデータ
    /// </summary>
    public class BrushData : ColorPaletteData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> イメージコレクション
        /// </summary>
        public ObservableCollection<Byte[]> ImageByteCollection { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／ブラシデータ／コンストラクタ
        /// </summary>
        public BrushData()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.ImageByteCollection = new ObservableCollection<byte[]>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public Brush GetBrush(BrushType pBrushType, int[] pGetSchemeNoAreg)
        {
            switch (pBrushType)
            {
                case BrushType.SolidColorBrush:
                    return new SolidColorBrush(base.GetColorCollection(pGetSchemeNoAreg[0]));
                default:
                    return new SolidColorBrush(base.GetColorCollection(pGetSchemeNoAreg[0]));
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
