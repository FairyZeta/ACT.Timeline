using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.Setting;

namespace FairyZeta.FF14.ACT.Logger.LogType
{
    public class SystemLog : _LogTypeBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public SystemLog(LogStatusDefinition in_LD, LoggerSetting in_LS)
            : base(in_LD, in_LS, LogTypeEnum.System)
        {
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData()
        {
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
