using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／オーバーレイ管理モジュール
    /// </summary>
    public class OverlayManageModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ管理モジュール／コンストラクタ
        /// </summary>
        public OverlayManageModule()
            : base()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 新しいオーバーレイを作成します。
        /// </summary>
        public void AddNewOverlay()
        {

        }

        /// <summary> 既存のオーバーレイを削除します。
        /// </summary>
        public void DeleteOverlay()
        {

        }

        public void SaveOverlayWindowInfo()
        {

        }

        public void LoadOverlayWindowInfo()
        {

        }

        /// <summary> オーバーレイをインポートします。
        /// </summary>
        public void ImportOverlay()
        {
            
        }

        /// <summary> オーバーレイをエクスポートします。
        /// </summary>
        public void ExportOverlay()
        {
            
        }

        public void SetDefaultOverlayWindowData(OverlayWindowData pWindowData)
        {
            pWindowData.OverlayName = "NewOverlay";
            pWindowData.OverlayType = OverlayType.StandardTimeline;

            pWindowData.WindowTop = 10;
            pWindowData.WindowLeft = 10;
            pWindowData.WindowWidth = 300;
            pWindowData.WindowHeight = 300;
        }

        public void SetDefaultOverlaySettingData(OverlaySettingsData pSettingsData)
        {

        }

        /// <summary> オーバーレイタイプコレクションを生成します。
        /// </summary>
        /// <param name="pDataModel"> 格納するデータモデル </param>
        public void CreateOverlayTypeCollection(OverlayDataModel pDataModel)
        {
            pDataModel.OverlayTypeCollection.Clear();

            foreach (OverlayType value in Enum.GetValues(typeof(OverlayType)))
            {
                pDataModel.OverlayTypeCollection.Add(value);
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
