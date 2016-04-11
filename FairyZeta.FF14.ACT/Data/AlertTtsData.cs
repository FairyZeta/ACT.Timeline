using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Data
{
    /// <summary> ACT／アラートTTSデータ
    /// </summary>
    public class AlertTtsData : AlertSoundData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／アラートTTSデータ／コンストラクタ
        /// </summary>
        public AlertTtsData(string pFileName)
            : base(pFileName)
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
