using FairyZeta.FF14.ACT.Logger.LogType;
using FairyZeta.FF14.ACT.Logger.Setting;
using System;

namespace FairyZeta.FF14.ACT.Logger
{
    /// <summary> ACT用にカスタムしたログ出力機能を提供します。
    /// </summary>
    public class ActLogger : _LoggerBase
    { 
      /* --- プロパティ/フィールド定義 --------------------------------------------------------------------------------------------------------------------------------- */

        /// <summary> このロガーのセッティング情報を格納します。ロガーのセットアップもこのクラスで実行します。
        /// </summary>
        public LoggerSetting Setting { get; private set; }

        /// <summary> 出力するログの種類を表します。
        /// <para>Action: 「ユーザー側の操作」による出力。（ボタン押下、テキスト入力など)</para>
        /// </summary>
        public ActionLog ActionLog { get; private set; }
        /// <summary> 出力するログの種類を表します。
        /// <para>System: 「コード内部の動作」による出力。（算出の終了、分岐の判定結果など）</para>
        /// </summary>
        public SystemLog SystemLog { get; private set; }

      /* --- コンストラクタ -------------------------------------------------------------------------------------------------------------------------------------------- */

        public ActLogger()
            : base ()
        {
            // セッティングファイルの生成
            this.Setting = new LoggerSetting();
            // ログ定義を生成
            this.ActionLog = new ActionLog(new LogStatusDefinition(), this.Setting);
            this.SystemLog = new SystemLog(new LogStatusDefinition(), this.Setting);

            // ファイルロガーをセットアップ
            this.Setting.SetupTextLogger();
        }

      /* --- インタフェース実装 ---------------------------------------------------------------------------------------------------------------------------------------- */

      /* --- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------ */

        /// <summary> ログファイルへのスタックトレース書き込みを実行します。
        /// </summary>
        public void WriteStackTrace(Exception ex)
        {
            this.Setting.LogWriter.Write_StackTrace(ex, 0);
        }

      /* --- メソッド：Private ----------------------------------------------------------------------------------------------------------------------------------------- */
    
    }
}
