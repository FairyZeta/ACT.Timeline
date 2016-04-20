using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FairyZeta.Framework.ObjectModel
{
    /// <summary> 補正機能付きストップウォッチ
    /// </summary>
    public class RelativeClock
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 現在の経過時間を表します。
        /// <para> get: ストップウォッチの経過時間 + オフセットによる補正時間 </para>
        /// <para> set: 補正用オフセットを設定後、ストップウォッチをリスタート </para>
        /// </summary>
        public double CurrentTime
        {
            get
            {
                return offset + ((double)stopwatch.ElapsedMilliseconds) / 1000;
            }
            set
            {
                this.stopwatch.Restart();
                offset = value;
            }
        }

        /// <summary> 経過時間の計測用ストップウォッチ
        /// </summary>
        private Stopwatch stopwatch;
        /// <summary> 時間補正用オフセット
        /// </summary>
        private double offset;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 補正機能付きストップウォッチ／コンストラクタ
        /// </summary>
        /// <param name="pInitStart"> インスタンス生成後に自動開始する場合 True </param>
        /// <param name="pOffsetTime"> 初期設定するオフセットタイム </param>
        public RelativeClock(bool pInitStart, double pOffsetTime)
            : this(pInitStart)
        {
            this.offset = pOffsetTime;
        }

        /// <summary> 補正機能付きリレーシブクロック／コンストラクタ
        /// </summary>
        /// <param name="pInitStart"> インスタンス生成後に自動開始する場合 True </param>
        public RelativeClock(bool pInitStart)
        {
            this.initObjectModel();

            if (pInitStart)
                this.stopwatch.Start();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.stopwatch = new Stopwatch();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 時間計測を停止します。
        /// </summary>
        /// <param name="pCurrentTime"> 停止後にオフセットする時間 </param>
        public void StopClock(double pCurrentTime)
        {
            this.stopwatch.Stop();
            this.offset = pCurrentTime;
        }

        /// <summary> 時間計測を停止します。
        /// </summary>
        public void StopClock()
        {
            this.stopwatch.Stop();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
