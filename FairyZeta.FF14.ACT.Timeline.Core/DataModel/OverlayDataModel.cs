using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／オーバーレイ追加用データモデル
    /// </summary>
    public class OverlayDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 新規追加確定フラグ
        /// <para> => 確定時 True, キャンセル時 False, 既定値は False </para>
        /// </summary>
        public bool AddDecisionFLG { get; set; }

        /// <summary> オーバーレイタイプコレクション
        /// </summary>
        public ObservableCollection<OverlayType> OverlayTypeCollection { get; private set; }

        /// <summary> 新オーバーレイ画面データ
        /// </summary>
        public OverlayWindowData OverlayWindowData { get; set; }

        /// <summary> オーバーレイ設定データ
        /// </summary>
        public OverlaySettingsData OverlaySettingsData { get; set; }

        /// <summary> オーバーレイ表示データ
        /// </summary>
        public OverlayViewData OverlayViewData { get; set; }


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ追加用データモデル／コンストラクタ
        /// </summary>
        public OverlayDataModel()
            : base()
        {
            this.initDataModel();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.OverlayWindowData = new OverlayWindowData();
            this.OverlaySettingsData = new OverlaySettingsData();
            this.OverlayTypeCollection = new ObservableCollection<OverlayType>();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.AddDecisionFLG = false;
            this.OverlayTypeCollection.Clear();

            return true;
        }
    }
}
