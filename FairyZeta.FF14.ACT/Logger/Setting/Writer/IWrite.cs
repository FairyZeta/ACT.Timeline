using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.LogData;

namespace FairyZeta.FF14.ACT.Logger.Setting.Writer
{
    public interface IWriter
    {      
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログファイルへの通常出力機能
        /// </summary>
        /// <param name="pLogData"> ログ出力するデータ </param>
        void Write(ILogData pLogData);

        /// <summary> ログファイルへのスタックトレース出力機能
        /// </summary>
        /// <param name="ex"> 例外情報 </param>
        /// <param name="rank"> InnerException Rank </param>
        void Write_StackTrace(Exception ex, int rank);

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
