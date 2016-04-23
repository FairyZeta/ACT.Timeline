using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;
using FairyZeta.Framework;
using FairyZeta.Framework.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;


namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／オーバーレイ管理モジュール
    /// </summary>
    public class OverlayManageModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイオープンプロセス
        /// </summary>
        private OverlayViewOpenProcess overlayViewOpenProcess;
        /// <summary> XMLシリアライズプロセス
        /// </summary>
        private XmlSerializerProcess xmlSerializerProcess;
        /// <summary> フィルタセットプロセス
        /// </summary>
        private SetFilterProcess setFilterProcess;
        /// <summary> ファイル管理プロセス
        /// </summary>
        private AppDataFileManageProcess appDataFileManageProcess;
        /// <summary> セーブ対象状態リセットプロセス
        /// </summary>
        private SaveChangedResetProcess saveChangedResetProcess;
        /// <summary> オーバーレイデフォルトカラーセットプロセス
        /// </summary>
        private OvarlayDefaultSetProcess ovarlayDefaultSetProcess;

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
            this.overlayViewOpenProcess = new OverlayViewOpenProcess();
            this.xmlSerializerProcess = new XmlSerializerProcess();
            this.setFilterProcess = new SetFilterProcess();
            this.appDataFileManageProcess = new AppDataFileManageProcess();
            this.saveChangedResetProcess = new SaveChangedResetProcess();
            this.ovarlayDefaultSetProcess = new OvarlayDefaultSetProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 新しいオーバーレイを作成します。
        /// </summary>
        public void AddNewOverlay(OverlayManageDataModel pOverlayManageDataModel, OverlayDataModel pAddOverlayDataModel, TimelineComponent pTimelineComponent, CommonDataModel pCommonDataModel)
        {
            // ID設定
            if (pOverlayManageDataModel.OverlayViewComponentCollection.Count > 0)
            {
                pAddOverlayDataModel.OverlayWindowData.ID = pOverlayManageDataModel.OverlayViewComponentCollection.Max(m => m.OverlayDataModel.OverlayWindowData.ID) + 1;
            }
            else
            {
                pAddOverlayDataModel.OverlayWindowData.ID = 1;
            }
            
            OverlayViewComponent component = new OverlayViewComponent(pCommonDataModel);
            component.OverlayDataModel = pAddOverlayDataModel;
            this.SetDefaultOverlayWindowData(component.OverlayDataModel.OverlayWindowData);
            this.SetDefaultOverlaySettingData(component.OverlayDataModel.OverlayOptionData);

            component.OverlayDataModel.OverlayViewData.TimelineViewSource = new CollectionViewSource() { Source = pTimelineComponent.TimelineObjectModel.ActivityCollection };
            this.setFilterProcess.SetResetFilter(component.OverlayDataModel.OverlayViewData.TimelineViewSource, false);

            pOverlayManageDataModel.OverlayViewComponentCollection.Add(component);
            pCommonDataModel.ViewCollection.Add(component);
        }

        /// <summary> 保存されているオーバーレイを全てロードします。
        /// </summary>
        public void OverlayDataModelLoad(CommonDataModel pCommonDataModel, TimelineComponent pTimelineComponent, OverlayManageDataModel pOverlayManageDataModel)
        {
            if (pCommonDataModel == null || pCommonDataModel.ApplicationData == null) return;
            if (pCommonDataModel.ApplicationData.OverlayDataFilePathList.Count == 0) return;

            var dataList = this.OverlayDataModelLoad(pCommonDataModel.ApplicationData.OverlayDataFilePathList);

            if (dataList.Count == 0) return;

            foreach (var data in dataList)
            {
                OverlayViewComponent component = new OverlayViewComponent(pCommonDataModel);
                
                component.OverlayDataModel = data;

                component.OverlayDataModel.OverlayViewData.TimelineViewSource = new CollectionViewSource() { Source = pTimelineComponent.TimelineObjectModel.ActivityCollection };

                this.setFilterProcess.SetResetFilter(component.OverlayDataModel.OverlayViewData.TimelineViewSource, false);

                pOverlayManageDataModel.OverlayViewComponentCollection.Add(component);
                pCommonDataModel.ViewCollection.Add(component);
            }
        }

        /// <summary> 既存のオーバーレイを削除します。
        /// </summary>
        /// <param name="pOverlayViewC"> 削除するオーバーレイデータ </param>
        /// <param name="pCommonDM"> 値参照用の共通データモデル </param>
        /// <param name="pOverlayManageDM"> 削除データのコレクションを持つオーバーレイ管理モデル </param>
        public void DeleteOverlay(OverlayViewComponent pOverlayViewC, CommonDataModel pCommonDM, OverlayManageDataModel pOverlayManageDM)
        {
            if (pCommonDM == null || pCommonDM.ApplicationData == null) return;

            string fileName = pCommonDM.ApplicationData.OverlayDataPartName + String.Format("{0:0000}", pOverlayViewC.OverlayDataModel.OverlayWindowData.ID) + ".xml";
            string path = Path.Combine(pCommonDM.ApplicationData.RoamingDirectoryPath,"OverlayData", fileName);

            pOverlayManageDM.OverlayViewComponentCollection.Remove(pOverlayViewC);
            pCommonDM.ViewCollection.Remove(pOverlayViewC);

            WindowsServices.WindowCloseSendMessage(pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            pOverlayViewC.OverlayDataModel.OverlayWindowData.WindowIntPtr = IntPtr.Zero;

            pOverlayViewC = null;

            if (File.Exists(path))
                File.Delete(path);
            
        }

        /// <summary> オーバーレイを全て表示します。
        /// </summary>
        /// <param name="pTimelineComponent"> オーバーレイに搭載するタイムラインコンポーネント </param>
        /// <param name="pOverlayViewList"> 表示するオーバーレイのリスト(IF) </param>
        public void ShowOverlay(TimelineComponent pTimelineComponent, IList<OverlayViewComponent> pOverlayViewList)
        {
            foreach (var overlay in pOverlayViewList)
            {
                this.ShowOverlay(pTimelineComponent, overlay);
            }

        }
        /// <summary> オーバーレイを表示します。
        /// </summary>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewComponent">  </param>
        public void ShowOverlay(TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            if (!pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowVisibility) return;

            this.overlayViewOpenProcess.NewOverlayOpen(pTimelineComponent, pOverlayViewComponent);
        }

        /// <summary> オーバーレイカスタムを表示します。
        /// </summary>
        /// <param name="pOverlayViewComponent"> カスタム対象のオーバーレイコンポーネント </param>
        public void ShowCustomWindow(OverlayViewComponent pOverlayViewComponent)
        {
            this.overlayViewOpenProcess.NewOverlayCustomWindowOpen(pOverlayViewComponent);
        }

      #region  - [REGINO] - Overlay IO

        /// <summary> XML形式のオーバーレイデータモデルを読み込み、データリストを返却します。
        /// </summary>
        /// <param name="pFilePathList"> 読み込みファイルパスリスト </param>
        /// <returns> 復元成功時 DataList, 失敗時 空List </returns>
        public IList<OverlayDataModel> OverlayDataModelLoad(IList<string> pFilePathList)
        {
            List<OverlayDataModel> list = new List<OverlayDataModel>();

            foreach (string path in pFilePathList)
            {
                var data = this.OverlayDataModelLoad(path);
                if (data != null)
                {
                    list.Add(data);
                }
            }
            return list;
        }
        /// <summary> XML形式のオーバーレイデータモデルを読み込み、データを返却します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <returns> 復元成功時 Data, 失敗時 Null </returns>
        public OverlayDataModel OverlayDataModelLoad(string pFilePath)
        {
            return this.xmlSerializerProcess.XmlLoad(pFilePath, typeof(OverlayDataModel), true) as OverlayDataModel;
        }
        /// <summary> XML形式のオーバーレイウィンドウ情報を読み込み、データリストを返却します。
        /// </summary>
        /// <param name="pFilePathList"> 読み込みファイルパスリスト </param>
        /// <returns> 復元成功時 DataList, 失敗時 空List </returns>
        public IList<OverlayWindowData> OverlayWindowLoad(IList<string> pFilePathList)
        {
            List<OverlayWindowData> list = new List<OverlayWindowData>();

            foreach (string path in pFilePathList)
            {
                var data = this.OverlayWindowLoad(path);
                if (data != null)
                {
                    list.Add(data);
                }
            }
            return list;
        }
        /// <summary> XML形式のオーバーレイウィンドウ情報を読み込み、データを返却します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <returns> 復元成功時 Data, 失敗時 Null </returns>
        public OverlayWindowData OverlayWindowLoad(string pFilePath)
        {
            return this.xmlSerializerProcess.XmlLoad(pFilePath, typeof(OverlayWindowData), false) as OverlayWindowData;
        }
        /// <summary> XML形式のオーバーレイオプション情報を読み込み、データリストを返却します。
        /// </summary>
        /// <param name="pFilePathList"> 読み込みファイルパスリスト </param>
        /// <returns> 復元成功時 DataList, 失敗時 空List </returns>
        public IList<OverlayOptionData> OverlayOptionLoad(IList<string> pFilePathList)
        {
            List<OverlayOptionData> list = new List<OverlayOptionData>();

            foreach (string path in pFilePathList)
            {
                var data = this.OverlayOptionLoad(path);
                if (data != null)
                {
                    list.Add(data);
                }
            }
            return list;
        }
        /// <summary> XML形式のオーバーレイオプション情報を読み込み、データを返却します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <returns> 復元成功時 Data, 失敗時 Null </returns>
        public OverlayOptionData OverlayOptionLoad(string pFilePath)
        {
            return this.xmlSerializerProcess.XmlLoad(pFilePath, typeof(OverlayOptionData), false) as OverlayOptionData;
        }

        /// <summary> オーバーレイデータモデルリストをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 書き込みファイルパス </param>
        /// <param name="pOverlayDataModelList"> オーバーレイ情報リスト </param>
        public void OverlayDataModelSave(ApplicationData pApplicationData, IList<OverlayDataModel> pOverlayDataModelList)
        {
            if (pApplicationData == null || pOverlayDataModelList == null) return;

            foreach (var data in pOverlayDataModelList)
            {
                this.OverlayDataModelSave(pApplicationData, data);
            }

            return;
        }
        /// <summary> オーバーレイデータモデルをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <param name="pOverlayDataModel"> オーバーレイ情報 </param>
        public void OverlayDataModelSave(ApplicationData pApplicationData, OverlayDataModel pOverlayDataModel)
        {
            if (pApplicationData == null || pOverlayDataModel == null) return;

            string fileName = pApplicationData.OverlayDataPartName + String.Format("{0:0000}", pOverlayDataModel.OverlayWindowData.ID) + ".xml"; 
            string fullPath = Path.Combine(pApplicationData.OverlayDataDirectoryPath, fileName);

            this.xmlSerializerProcess.XmlSave(fullPath, pOverlayDataModel, true);

            this.saveChangedResetProcess.OverlayDataSaveChangedReset(pOverlayDataModel);

            return;
        }
        /// <summary> オーバーレイウィンドウ情報リストをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 書き込みファイルパス </param>
        /// <param name="pOverlayWindowDataList"> オーバーレイ情報リスト </param>
        public void OverlayWindowSave(string pFilePath, IList<OverlayWindowData> pOverlayWindowDataList)
        {
            foreach (var data in pOverlayWindowDataList)
            {
                this.OverlayWindowSave(pFilePath, data);
            }

            return;
        }
        /// <summary> オーバーレイウィンドウ情報をXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 読み込みファイルパス </param>
        /// <param name="pOverlayWindowData"> オーバーレイ情報 </param>
        public void OverlayWindowSave(string pFilePath, OverlayWindowData pOverlayWindowData)
        {
            this.xmlSerializerProcess.XmlSave(pFilePath, pOverlayWindowData, false);
            return;
        }
        /// <summary> オーバーレイセッティング情報リストをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 書き込みファイルパス </param>
        /// <param name="pOverlayOptionDataList"> オーバーレイオプションデータリスト </param>
        public void OverlayOptionSave(string pFilePath, IList<OverlayOptionData> pOverlayOptionDataList)
        {
            foreach (var data in pOverlayOptionDataList)
            {
                this.OverlayOptionSave(pFilePath, data);
            }

            return;
        }
        /// <summary> オーバーレイセッティング情報をXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 書き込みファイルパス </param>
        /// <param name="pOverlayOptionData"> オーバーレイオプションデータ </param>
        public void OverlayOptionSave(string pFilePath, OverlayOptionData pOverlayOptionData)
        {
            this.xmlSerializerProcess.XmlSave(pFilePath, pOverlayOptionData, false);
            return;
        }

      #endregion

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
            pWindowData.WindowTop = 100;
            pWindowData.WindowLeft = 100;
            pWindowData.WindowWidth = 390;
            pWindowData.WindowHeight = 150;
        }

        public void SetDefaultOverlaySettingData(OverlayOptionData pOptionData)
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
