using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／タイマーデータモデル
    /// </summary>
    public class TimerDataModel : _DataModel
    {
        /// <summary> タイマーデータ
        /// </summary>
        public TimerData TimerDeta { get; private set; }

        /// <summary> タイムライン／タイマーデータモデル／コンストラクタ
        /// </summary>
        public TimerDataModel()
            : base()
        {
            this.initDataModel();
        }

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.TimerDeta = new TimerData();

            return true;
        }

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
