using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Logger.Setting.OutputSetting
{
    /// <summary> ファイルログ出力の設定
    /// </summary>
    public class FileLogSetting : _OutputSettingBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログファイルパス
        /// <para> --- Default Value ---</para>
        /// <para> string = string.Empty;</para>
        /// </summary>
        public string FilePath { get; set; }

        /// <summary> ログファイル名（拡張子を除く）
        /// <para> --- Default Value ---</para>
        /// <para> string = string.Empty;</para>
        /// </summary>
        public string FileName { get; set; }

        /// <summary> ログファイル拡張子
        /// <para> --- Default Value ---</para>
        /// <para> string = string.Empty;</para>
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary> ファイル名に日付を付与するか
        /// <para> --- bool Para --- </para>
        /// <para> true: 付与する（filename_yyyyMMdd.zzz）</para>
        /// <para> false: 付与しない（filename.zzz）</para>
        /// <para> --- Default Value ---</para>
        /// <para> bool = false;</para>
        /// </summary>
        public bool AddFileNameDate { get; set; }

        /// <summary> ファイル名に日付を付与する場合のフォーマット形式
        /// </summary>
        public string FileNameDateFormat { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        public FileLogSetting()
            :base()
        {
            this.InitData();
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData()
        {
            this.FilePath = string.Empty;
            this.FileName = string.Empty;
            this.FileExtension = string.Empty;
            this.AddFileNameDate = false;
            this.FileNameDateFormat = string.Empty;
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
