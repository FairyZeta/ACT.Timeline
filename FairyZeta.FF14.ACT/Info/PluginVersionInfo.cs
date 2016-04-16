using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Info
{
    /// <summary> ACT／プラグインバージョン情報
    /// </summary>
    public class PluginVersionInfo
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグイン名
        /// </summary>
        public string PluginName { get; set; }
        /// <summary> 最新版プラグインバージョン
        /// </summary>
        public string PluginVersion { get; set; }
        /// <summary> 最新版マスタデータバージョン
        /// </summary>
        public string DataBaseVersion { get; set; }
        /// <summary> 最新版プラグインネットワークパス
        /// </summary>
        public string PluginDownloadUri { get; set; }
        /// <summary> 最新版マスタデータネットワークパス
        /// </summary>
        public string DataBaseDownloadUri { get; set; }

        /// <summary> 最新プラグイン情報のURI
        /// </summary>
        public string CheckPluginInfoUri { get; set; }
        /// <summary> プラグインが公開されているWEBURI
        /// </summary>
        public string PluginWebUri { get; set;}

        /// <summary> リリース日
        /// </summary>
        public string ReleaseDay { get; set; }
        /// <summary> 更新重要度
        /// </summary>
        public string Priority { get; set; }
        /// <summary> 更新情報リスト
        /// </summary>
        public List<string> SummaryList { get; set; }

        /// <summary> プラグイン製作者メッセージ
        /// </summary>
        public string Msg { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／プラグインバージョン情報／コンストラクタ
        /// </summary>
        public PluginVersionInfo()
        {
            this.initInfo();
            this.Clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> 情報の初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initInfo()
        {
            this.SummaryList = new List<string>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool Clear()
        {
            this.PluginName = string.Empty;
            this.PluginVersion = string.Empty;
            this.DataBaseVersion = string.Empty;
            this.PluginDownloadUri = string.Empty;
            this.DataBaseDownloadUri = string.Empty;
            this.CheckPluginInfoUri = string.Empty;
            this.PluginWebUri = string.Empty;
            this.ReleaseDay = string.Empty;
            this.Priority = string.Empty;
            this.Msg = string.Empty;

            this.SummaryList.Clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
    }
}
