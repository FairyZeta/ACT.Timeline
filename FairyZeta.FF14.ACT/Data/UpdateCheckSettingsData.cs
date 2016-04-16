using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Data
{
    /// <summary> ACT／プラグインアップデートチェック設定データ
    /// </summary>
    public class UpdateCheckSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> 現在のプラグインバージョン
        /// </summary>
        public Version PluginVersion { get; set;}
  
        /// <summary> 最新プラグイン情報のダウンロードURI
        /// </summary>
        public string InfoDonwloadUri { get; set; }

        /// <summary> Infoセーブファイルディレクトリパス
        /// </summary>
        public string SaveInfoDirectory { get; set; }
        /// <summary> Infoセーブファイル名
        /// </summary>
        public string SaveInfoFileName { get; set; }
        /// <summary> ZIPファイルセーブディレクトリ
        /// </summary>
        public string SaveZipDirectory { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／プラグインアップデートチェック設定データ／コンストラクタ
        /// </summary>
        public UpdateCheckSettingsData()
            : base()
        {
            this.initData();
            this.clear();
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
            this.PluginVersion = new Version();
            this.InfoDonwloadUri = string.Empty;
            this.SaveInfoDirectory = string.Empty;
            this.SaveInfoFileName = string.Empty;
            this.SaveZipDirectory = string.Empty;

            return true;
        }
    }
}
