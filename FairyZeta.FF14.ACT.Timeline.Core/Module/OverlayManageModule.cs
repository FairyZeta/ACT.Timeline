using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;
using Microsoft.Win32;
using FairyZeta.Framework;
using FairyZeta.Framework.Unit;
using FairyZeta.Framework.Proc;
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

        /// <summary> 汎用ダウンロードユニット
        /// </summary>
        private DownloadUnit downloadUnit;

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
        /// <summary> オーバーレイデータ補正プロセス
        /// </summary>
        private OverlayDataRevisionProcess overlayDataRevisionProcess;

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
            this.downloadUnit = new DownloadUnit();

            this.overlayViewOpenProcess = new OverlayViewOpenProcess();
            this.xmlSerializerProcess = new XmlSerializerProcess();
            this.setFilterProcess = new SetFilterProcess();
            this.appDataFileManageProcess = new AppDataFileManageProcess();
            this.saveChangedResetProcess = new SaveChangedResetProcess();
            this.ovarlayDefaultSetProcess = new OvarlayDefaultSetProcess();
            this.overlayDataRevisionProcess = new OverlayDataRevisionProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 新しいオーバーレイを作成します。
        /// </summary>
        public void AddNewOverlay(CommonDataModel pCommonDM, OverlayDataModel pAddOverlayDM, TimelineComponent pTimelineC, OverlayManageDataModel pOverlayManageM, bool IsImport)
        {
            // ID設定
            if (pOverlayManageM.OverlayViewComponentCollection.Count > 0)
            {
                pAddOverlayDM.OverlayWindowData.ID = pOverlayManageM.OverlayViewComponentCollection.Max(m => m.OverlayDataModel.OverlayWindowData.ID) + 1;
            }
            else
            {
                pAddOverlayDM.OverlayWindowData.ID = 1;
            }

            OverlayViewComponent component = new OverlayViewComponent(pCommonDM);
            component.OverlayDataModel = pAddOverlayDM;

            if (IsImport)
            {
                pAddOverlayDM.OverlayWindowData.WindowTop = 10;
                pAddOverlayDM.OverlayWindowData.WindowLeft = 10;
                pAddOverlayDM.OverlayWindowData.WindowVisibility = false;
                pAddOverlayDM.OverlayWindowData.WindowLock = false;
            }
            else
            {
                this.SetDefaultOverlayWindowData(component.OverlayDataModel.OverlayWindowData);
                this.SetDefaultOverlaySettingData(component.OverlayDataModel.OverlayOptionData);
            }

            component.OverlayDataModel.OverlayViewData.TimelineViewSource = new CollectionViewSource() { Source = pTimelineC.TimelineObjectModel.ActivityCollection };
            this.setFilterProcess.SetResetFilter(component.OverlayDataModel.OverlayViewData.TimelineViewSource, false);

            // バージョン設定
            component.OverlayDataModel.DataVersion = pCommonDM.ApplicationData.ApplicationVersion;

            pOverlayManageM.OverlayViewComponentCollection.Add(component);
            pCommonDM.ViewCollection.Add(component);
        }

        /// <summary> 保存されているオーバーレイを全てロードします。
        /// </summary>
        /// <param name="pCommonDataModel"> 共通データモデル </param>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayManageDataModel"> 読込データを追加する管理データモデル </param>
        public void OverlayDataModelLoad(CommonDataModel pCommonDataModel, TimelineComponent pTimelineComponent, OverlayManageDataModel pOverlayManageDataModel)
        {
            if (pCommonDataModel == null || pCommonDataModel.ApplicationData == null) return;
            if (pCommonDataModel.ApplicationData.OverlayDataFilePathList.Count == 0) return;

            var dataList = this.OverlayDataModelLoad(pCommonDataModel.ApplicationData.OverlayDataFilePathList, true);

            if (dataList.Count == 0) return;

            foreach (var data in dataList)
            {
                OverlayViewComponent component = new OverlayViewComponent(pCommonDataModel);

                this.overlayDataRevisionProcess.DataRevisionExecute(data);

                // バージョン設定
                data.DataVersion = pCommonDataModel.ApplicationData.ApplicationVersion;

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
        public void ShowOverlay(CommonDataModel pCommonDM, TimelineComponent pTimelineComponent, IList<OverlayViewComponent> pOverlayViewList)
        {
            foreach (var overlay in pOverlayViewList)
            {
                this.ShowOverlay(pCommonDM, pTimelineComponent, overlay);
            }

        }
        /// <summary> オーバーレイを表示します。
        /// </summary>
        /// <param name="pTimelineComponent"> タイムラインコンポーネント </param>
        /// <param name="pOverlayViewComponent">  </param>
        public void ShowOverlay(CommonDataModel pCommonDM, TimelineComponent pTimelineComponent, OverlayViewComponent pOverlayViewComponent)
        {
            if (!pOverlayViewComponent.OverlayDataModel.OverlayWindowData.WindowVisibility) return;

            this.overlayViewOpenProcess.NewOverlayOpen(pCommonDM, pTimelineComponent, pOverlayViewComponent);
        }

        /// <summary> オーバーレイカスタムを表示します。
        /// </summary>
        /// <param name="pOverlayViewComponent"> カスタム対象のオーバーレイコンポーネント </param>
        public void ShowCustomWindow(CommonDataModel pCommonDM, OverlayViewComponent pOverlayViewComponent)
        {
            this.overlayViewOpenProcess.NewOverlayCustomWindowOpen(pCommonDM, pOverlayViewComponent);
        }

      #region  - [REGINO] - Overlay IO

        /// <summary> XML形式のオーバーレイデータモデルを読み込み、データリストを返却します。
        /// </summary>
        /// <param name="pFilePathList"> 読み込みファイルパスリスト </param>
        /// <returns> 復元成功時 DataList, 失敗時 空List </returns>
        public IList<OverlayDataModel> OverlayDataModelLoad(IList<string> pFilePathList, bool pCatchFLG)
        {
            List<OverlayDataModel> list = new List<OverlayDataModel>();

            foreach (string path in pFilePathList)
            {
                var data = this.OverlayDataModelLoad(path, pCatchFLG);
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
        /// <param name="pCatchFLG"> 読込エラーを無視する場合 True, しない場合 False </param>
        public OverlayDataModel OverlayDataModelLoad(string pFilePath, bool pCatchFLG)
        {
            return this.xmlSerializerProcess.XmlLoad(pFilePath, typeof(OverlayDataModel), pCatchFLG) as OverlayDataModel;
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
                this.OverlayDataModelSave(pApplicationData, data, true);
            }

            return;
        }
        /// <summary> オーバーレイデータモデルをXML形式で保存します。
        /// </summary>
        /// <param name="pApplicationData"> 保存するパス情報が格納されたアプリケーション情報 </param>
        /// <param name="pOverlayDataModel"> 保存するオーバーレイ情報 </param>
        /// <param name="pCatchFLG"> 保存エラーを無視する場合 True, しない場合 False </param>
        public void OverlayDataModelSave(ApplicationData pApplicationData, OverlayDataModel pOverlayDataModel, bool pCatchFLG)
        {
            if (pApplicationData == null || pOverlayDataModel == null) return;

            string fileName = pApplicationData.OverlayDataPartName + String.Format("{0:0000}", pOverlayDataModel.OverlayWindowData.ID) + ".xml"; 
            string fullPath = Path.Combine(pApplicationData.OverlayDataDirectoryPath, fileName);

            this.OverlayDataModelSave(fullPath, pOverlayDataModel, pCatchFLG);

            this.saveChangedResetProcess.OverlayDataSaveChangedReset(pOverlayDataModel);

            return;
        }
        /// <summary> オーバーレイデータモデルをXML形式で保存します。
        /// </summary>
        /// <param name="pFilePath"> 保存ファイルパス </param>
        /// <param name="pOverlayDataModel"> 保存するオーバーレイ情報 </param>
        /// <param name="pCatchFLG"> 保存エラーを無視する場合 True, しない場合 False </param>
        public void OverlayDataModelSave(string pFilePath, OverlayDataModel pOverlayDataModel, bool pCatchFLG)
        {
            this.xmlSerializerProcess.XmlSave(pFilePath, pOverlayDataModel, pCatchFLG);
            return;
        }

      #endregion

        /// <summary> オーバーレイファイルのダウンロードを実行します。
        /// </summary>
        /// <param name="pCommonDM"> 共通データモデル </param>
        /// <param name="pDownloadURI"> ダウンロードするファイルのURI </param>
        /// <returns></returns>
        public bool DownloadOverlay(CommonDataModel pCommonDM, string pDownloadURI)
        {
            bool result = false;
            try
            {
                result = this.downloadUnit.FileDownload(pDownloadURI, pCommonDM.ApplicationData.TempDirectoryPath, pCommonDM.ApplicationData.TempOverlayName, SaveType.OverRide);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        /// <summary> ファイル選択ダイアログを表示後、オーバーレイをインポートします。
        /// </summary>
        public bool ImportOverlay(CommonDataModel pCommonDataModel, TimelineComponent pTimelineComponent, OverlayManageDataModel pOverlayManageDataModel)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "Overlay Xml|*.xml|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = pCommonDataModel.ApplicationData.PluginDllDirectory;
            openFileDialog.Title = "Import Overlay Data";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                return this.ImportOverlay(pCommonDataModel, pTimelineComponent, pOverlayManageDataModel, openFileDialog.FileName, string.Empty);
            }

            return false;
        }
        /// <summary> オーバーレイをインポートします。
        /// </summary>
        public bool ImportOverlay(CommonDataModel pCommonDataModel, TimelineComponent pTimelineComponent, OverlayManageDataModel pOverlayManageDataModel, string pOverlayFullPath, string pImportOverlayName)
        {
            var data = this.OverlayDataModelLoad(pOverlayFullPath, false);
            if (data != null)
            {
                this.overlayDataRevisionProcess.DataRevisionExecute(data);
                if(!string.IsNullOrWhiteSpace(pImportOverlayName))
                {
                    data.OverlayWindowData.OverlayName = pImportOverlayName;
                }

                this.AddNewOverlay(pCommonDataModel, data, pTimelineComponent, pOverlayManageDataModel, true);
            }
            else
            {
                throw new FileLoadException();
            }

            return true;
        }

        /// <summary> オーバーレイをエクスポートします。
        /// </summary>
        /// <param name="pCommonDataModel"> 共通データモデル </param>
        /// <param name="pOverlayDataModel"> 保存するオーバーレイ情報 </param>
        public void ExportOverlay(CommonDataModel pCommonDataModel, OverlayDataModel pOverlayDataModel)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Filter = "Overlay Xml|*.xml|All Files (*.*)|*.*";
            saveFileDialog.InitialDirectory = pCommonDataModel.ApplicationData.PluginDllDirectory;
            saveFileDialog.Title = "Export Overlay Data";
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    this.OverlayDataModelSave(saveFileDialog.FileName, pOverlayDataModel, false);
                }
                catch (Exception e)
                {
                    string msg = string.Format("Overlay Export Error: {0}", e.Message);
                    pCommonDataModel.LogDataCollection.Add(
                        Globals.ErrLogger.WriteSystemLog.Failure.ERROR.Write(msg, Globals.ProjectName));
                        
                }
            }
            
        }

        /// <summary> オーバーレイのコピー作成を実行します。
        /// </summary>
        /// <param name="pOverlayVC"> コピーするオーバーレイコンポーネント </param>
        /// <param name="pTimelineC"> コピーしたオーバーレイに搭載するタイムラインコンポーネント </param>
        /// <param name="pOverlayManageDM"> オーバーレイ管理データモデル </param>
        /// <param name="pNewOverlayName"> コピー後に設定するオーバーレイの名前 </param>
        public void CopyOverlay(OverlayViewComponent pOverlayVC, TimelineComponent pTimelineC, OverlayManageDataModel pOverlayManageDM, string pNewOverlayName)
        {
            this.OverlayDataModelSave(pOverlayVC.CommonDataModel.ApplicationData.GetTempOverlayFullPath, pOverlayVC.OverlayDataModel, false);
            this.ImportOverlay(pOverlayVC.CommonDataModel, pTimelineC, pOverlayManageDM, pOverlayVC.CommonDataModel.ApplicationData.GetTempOverlayFullPath, pNewOverlayName);
        }

        
        public void SetDefaultOverlayWindowData(OverlayWindowData pWindowData)
        {
            pWindowData.WindowTop = 100;
            pWindowData.WindowLeft = 100;
            pWindowData.WindowWidth = 400;
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
