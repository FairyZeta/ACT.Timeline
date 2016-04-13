using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FairyZeta.Core.Process
{
    /// <summary> FZ／パーサープロセス
    /// </summary>
    public class StringParserProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／パーサープロセス
        /// </summary>
        public StringParserProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 文字列から指定文字を検索し、そこまでを一つの文字列として切り出したリストを返却します。
        /// <para> => 文字入力パラメータが null/empty/space の場合 null を返却します。 </para>
        /// </summary>
        /// <param name="pTargetString"> 切り出し対象となる元の文字列 </param>
        /// <param name="pParseString"> 切り出し検索をする文字(.や,など) </param>
        /// <param name="pTrimEnable"> 文字をトリムする場合 true </param>
        /// <param name="pReplaceParseString"> 切り出し対象文字を空白化する場合 true </param>
        /// <returns>  </returns>
        public List<string> CreateParseStringList(string pTargetString, string pParseString, bool pTrimEnable, bool pReplaceParseString)
        {
            if (string.IsNullOrWhiteSpace(pTargetString) || string.IsNullOrWhiteSpace(pTargetString)) 
                return null;

            List<string> resultList = new List<string>();

            string tmpStr = pTargetString.Trim();

            for (int i = tmpStr.IndexOf(pParseString); i != -1; i = tmpStr.IndexOf(pParseString))
            {
                string addStr = tmpStr.Substring(0, i + pParseString.Length);
                tmpStr = tmpStr.Substring(addStr.Length, tmpStr.Length - addStr.Length);

                if (pReplaceParseString)
                {
                    addStr = addStr.Replace(pParseString, "");
                    if (!string.IsNullOrWhiteSpace(addStr))
                        resultList.Add(addStr);
                }
                else
                {
                    resultList.Add(addStr);
                }

                if(pTrimEnable)
                {
                    tmpStr = tmpStr.Trim();
                }
            }

            resultList.Add(tmpStr);
            
            return resultList;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
