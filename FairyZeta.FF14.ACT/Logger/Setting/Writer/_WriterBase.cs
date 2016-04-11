using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.LogData;
using FairyZeta.FF14.ACT.Logger.Setting.OutputLevel;

namespace FairyZeta.FF14.ACT.Logger.Setting.Writer
{
    /// <summary> [基底クラス] ログ出力
    /// </summary>
    public abstract class _WriterBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public _WriterBase()
        {
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログデータのレベルとログセッティングの出力レベルを比較し、出力対象であれば"true"を、非出力対象であれば"false"を返します。
        /// </summary>
        /// <param name="in_logData">出力ログデータ</param>
        /// <param name="in_lvlSetting">出力レベル設定</param>
        /// <returns>bool: true/false</returns>
        public bool WriteLevelCheck(ILogData in_logData, OutputLevelSetting in_lvlSetting)
        {
            switch(in_logData.LogStatus.LogLevelEnum)
            {
                case LogLevelEnum.FATAL:
                    if(in_lvlSetting.FATAL)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.ERROR:
                    if (in_lvlSetting.ERROR)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.WARNING:
                    if (in_lvlSetting.WARNING)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.NOTICE:
                    if (in_lvlSetting.NOTICE)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.INFO:
                    if (in_lvlSetting.INFO)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.MEMO:
                    if (in_lvlSetting.MEMO)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.DEBUG:
                    if (in_lvlSetting.DEBUG)
                    {
                        return true;
                    }
                    break;

                case LogLevelEnum.TRACE:
                    if (in_lvlSetting.TRACE)
                    {
                        return true;
                    }
                    break;

                default:
                    break;
            }

            return false;
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
