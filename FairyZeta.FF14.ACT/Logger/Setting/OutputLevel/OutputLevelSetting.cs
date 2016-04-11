using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Logger.Setting.OutputLevel
{
    /// <summary> ログ出力のレベル
    /// </summary>
    public class OutputLevelSetting
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [列挙定義] ログ出力の簡易設定に使用します。
        /// <para> --- enum Lv --- </para>
        /// <para> All: 全てのレベルのログを出力します。 </para>
        /// <para> Normal: 通常構成として、INFO以上のレベルを出力し、MEMO,DEBUG,TRACEを未出力とします。 </para>
        /// <para> Minimum: 最小構成として、FATAL,ERROR,WARNINGの異常レベルのみ出力します。</para>
        /// </summary>
        public enum LevelPreset 
        {
            All,
            Normal,
            Minimum
        }

        /// <summary> FATAL(致命異常)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool FATAL { get; set; }

        /// <summary> ERROR(異常)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool ERROR { get; set; }

        /// <summary> WARNING(警告)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool WARNING { get; set; }

        /// <summary> NOTICE(通知)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool NOTICE { get; set; }

        /// <summary> INFO(情報)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool INFO { get; set; }

        /// <summary> MEMO(情報)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool MEMO { get; set; }

        /// <summary> DEBUG(開発)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool DEBUG { get; set; }

        /// <summary> TRACE(開発)ログ出力の設定
        /// <para> --- bool Para --- </para>
        /// <para> true: 出力する </para>
        /// <para> false: 出力しない </para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = true;</para>
        /// </summary>
        public bool TRACE { get; set; } 

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public OutputLevelSetting()
            :base()
        {
            this.InitData();
        }
      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData()
        {
            this.SetOutputLevel(LevelPreset.All);
        }

        /// <summary> ログ出力のboolをPresetに合わせて簡易設定します。
        /// </summary>
        /// <param name="in_preset"></param>
        public void SetOutputLevel(LevelPreset in_preset)
        {
            switch(in_preset)
            {
                case LevelPreset.All:
                    this.presetAll();
                    break;
                case LevelPreset.Normal:
                    this.presetNormal();
                    break;
                case LevelPreset.Minimum:
                    this.presetMinimum();
                    break;
                default:
                    break;
            }
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> bool値をAllPresetに設定します。
        /// </summary>
        private void presetAll()
        {
            this.FATAL = true;
            this.ERROR = true;
            this.WARNING = true;
            this.NOTICE = true;
            this.INFO = true;
            this.MEMO = true;
            this.DEBUG = true;
            this.TRACE = true;
        }

        /// <summary> bool値をNormalPresetに設定します。
        /// </summary>
        private void presetNormal()
        {
            this.FATAL = true;
            this.ERROR = true;
            this.WARNING = true;
            this.NOTICE = true;
            this.INFO = true;
            this.MEMO = false;
            this.DEBUG = false;
            this.TRACE = false;
        }

        /// <summary> bool値をMinimumPresetに設定します。
        /// </summary>
        private void presetMinimum()
        {
            this.FATAL = true;
            this.ERROR = true;
            this.WARNING = true;
            this.NOTICE = false;
            this.INFO = false;
            this.MEMO = false;
            this.DEBUG = false;
            this.TRACE = false;
        }
    }
}
