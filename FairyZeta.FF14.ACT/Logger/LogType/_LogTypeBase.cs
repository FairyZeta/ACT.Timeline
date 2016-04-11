using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.Setting;
using FairyZeta.FF14.ACT.Logger.LogType.LogResult;

namespace FairyZeta.FF14.ACT.Logger.LogType
{
    public abstract class _LogTypeBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 出力するログの成功と失敗の成果を表します。
        /// <para>Success: 成功の成果。(ログインの成功、画面遷移の成功など)</para>
        /// </summary>
        public Success Success { get; private set; }
        /// <summary> 出力するログの成功と失敗の成果を表します。
        /// <para>Failure: 失敗の成果。(保存の失敗、更新の失敗など)</para>
        /// </summary>
        public Failure Failure { get; private set; }
        /// <summary> 出力するログの成功と失敗の成果を表します。
        /// <para>NonState: 成果として表現できない場合。</para>
        /// </summary>
        public NonState NonState { get; private set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public _LogTypeBase(LogStatusDefinition in_LD,LoggerSetting in_LS, LogTypeEnum in_LogType)
        {
            LogStatusDefinition ld = new LogStatusDefinition()
            { 
                LogLevelEnum = in_LD.LogLevelEnum, 
                LogResultEnum = in_LD.LogResultEnum,
                LogTypeEnum = in_LogType 
            };

            this.InitData(ld, in_LS);
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData(LogStatusDefinition in_LD,LoggerSetting in_LS)
        {
            this.Failure = new Failure(in_LD, in_LS);
            this.Success = new Success(in_LD, in_LS);
            this.NonState = new NonState(in_LD, in_LS);
        }


      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
