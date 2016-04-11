using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IntervalTree;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    using TimelineInterval = IntervalTree.Interval<double>;

    /// <summary> タイムライン／アンカーデータ
    /// </summary>
    public class TimelineAnchorData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デフォルトのアンカー有効範囲
        /// </summary>
        public const double DefaultWindow = 5.0;

        /// <summary> このアンカーの開始時間
        /// </summary>
        public double TimeFromStart { get; set; }
        /// <summary> シンク／ジャンプのキーワード
        /// </summary>
        public Regex Regex { get; set; }

        /// <summary> アンカーの有効範囲：開始時間
        /// </summary>
        public double WindowBefore { get; set; }
        /// <summary> アンカーの有効範囲：終了時間
        /// </summary>
        public double WindowAfter { get; set; }

        /// <summary> (set) WindowBeforeとWindowAfterをセット
        /// </summary>
        public double Window
        {
            set
            {
                WindowBefore = value / 2;
                WindowAfter = value / 2;
            }
        }

        /// <summary> ジャンプアドレス
        /// <para> => -1: ジャンプ無効</para>
        /// </summary>
        public double Jump { get; set; }

        /// <summary> タイムラインインターバル
        /// </summary>
        public TimelineInterval Interval
        {
            get
            {
                return new TimelineInterval(TimeFromStart - WindowBefore, TimeFromStart + WindowAfter);
            }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アンカーデータ／コンストラクタ
        /// </summary>
        public TimelineAnchorData()
            : base()
        {
            Window = DefaultWindow;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> このアンカーがパラメータ値の有効範囲であるかのbool値を返却
        /// </summary>
        /// <param name="t"> 確認する時間 </param>
        /// <returns> 有効範囲外の場合 True, 有効範囲外の場合 False </returns>
        public bool ActiveAt(double t)
        {
            return (TimeFromStart - WindowBefore) < t && t < (TimeFromStart + WindowAfter);
        }
    }
}
