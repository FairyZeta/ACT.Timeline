using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Data
{
    /// <summary> ACT／アラートサウンドデータ
    /// </summary>
    public class AlertSoundData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public string Filename { get; private set; }

        List<string> aliases;
        public IEnumerable<string> Aliases { get { return aliases; } }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／アラートサウンドデータ／コンストラクタ
        /// </summary>
        /// <param name="pFileName"
        public AlertSoundData(string pFileName)
        {
            this.Filename = pFileName;

            this.initData();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            aliases = new List<string>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void AddAlias(string alias)
        {
            aliases.Add(alias);
        }

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
