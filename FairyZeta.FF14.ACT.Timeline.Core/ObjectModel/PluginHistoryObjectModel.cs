using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.ObjectModel
{
    /// <summary> タイムライン／プラグイン履歴管理オブジェクトモデル
    /// </summary>
    public class PluginHistoryObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アップデート履歴ディクショナリ
        /// </summary>
        public Dictionary<Version, List<string>> UpdateHistoryDictionary { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／プラグイン履歴管理オブジェクトモデル／コンストラクタ
        /// </summary>
        public PluginHistoryObjectModel()
        {
            this.initObjectModel();
            this.CreateUpdateHistory();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.UpdateHistoryDictionary = new Dictionary<Version, List<string>>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグインの変更履歴を生成します。
        /// </summary>
        public void CreateUpdateHistory()
        {
            this.UpdateHistoryDictionary.Clear();

            List<string> v0010 = new List<string>();
            v0010.Add("身内テスト版の公開。処理パフォーマンス最低です。");
            v0010.Add("一般な方は安定版「1.0.0.0」までお待ち下さい。");
            v0010.Add("PCが爆発しても責任取りません。");
            this.UpdateHistoryDictionary.Add(new Version(0, 0, 1, 0), v0010);

            List<string> v0020 = new List<string>();
            v0020.Add("Bug：デフォルトリソースフォルダが間違っていたのを修正");
            v0020.Add("Bug：オートアップデート直接ダウンロードの仕様修正(0.0.1 =>2は100 % 失敗します)");
            v0020.Add("Bug：オーバーレイがAlt + Tabで表示されないように修正");
            v0020.Add("Bug：アクティブウインドウチェックで落ちる可能性があるため修正");
            v0020.Add("Bug：バーの最大値が間違っていたので修正");
            v0020.Add("調整：新規オーバーレイの初期サイズと項目の変更");
            v0020.Add("調整：シャドウかけた文字のメモリ使用率がヤバイため一時的にOFF");
            v0020.Add("調整：軽度のデザイン修正");
            this.UpdateHistoryDictionary.Add(new Version(0, 0, 2, 0), v0020);

            List<string> v0021 = new List<string>();
            v0020.Add("Bug：ACTが停止、最悪ブルースクリーンもありえる為、アクティブ画面チェックを停止");
            this.UpdateHistoryDictionary.Add(new Version(0, 0, 2, 1), v0021);

            List<string> v0030 = new List<string>();
            v0020.Add("Bug：タイムラインがsyncでズレる問題の修正");
            v0020.Add("調整：タイムラインの測定コア関連を一度ぶっ壊して作り直し");
            v0020.Add("調整：バーをデザイン重視から視認性重視に一時的変更（時間ズレ確認の為）");
            v0020.Add("その他：ベースライブラリ整理、配色カスタム準備（未実装）");
            this.UpdateHistoryDictionary.Add(new Version(0, 0, 3, 0), v0030);

            List<string> v0040 = new List<string>();
            v0030.Add("バグ：オーバーレイが削除できない不具合の修正");
            v0030.Add("バグ：データ読み込み失敗時に、行が消える不具合の修正");
            v0030.Add("バグ：フィルタ（UNKNOWN）が間違っていたので修正");
            v0030.Add("バグ：初回ロード後にタイムラインを停止してもLoadボタンが押せない不具合の修正");
            v0030.Add("追加：カラーカスタム機能の追加（anoyetta様のご提供。ありがとうございます）");
            v0030.Add("追加：バーカスタム機能の追加");
            v0030.Add("追加：リソースフォルダを開くボタン追加");
            this.UpdateHistoryDictionary.Add(new Version(0, 0, 4, 0), v0040);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
