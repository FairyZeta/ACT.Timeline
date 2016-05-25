using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FairyZeta.Framework.Data;
using FairyZeta.Framework.DataUnion;
using FairyZeta.Framework.Process;
using System.IO;
using Prism.Mvvm;
using Prism.Commands;

namespace FairyZeta.Framework.ObjectModel
{
    /// <summary> FZ／パレットオブジェクトモデル
    /// </summary>
    public class PaletteObjectModel : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] TempColorPaletteData.TempColorPaletteData - ＜作業用カラーパレットデータ＞ -----
        /// <summary> 作業用カラーパレットデータ </summary>
        private TempColorPaletteData _TempColorPaletteData;
        /// <summary> 作業用カラーパレットデータ </summary>    
        public TempColorPaletteData TempColorPaletteData
        {
            get { return _TempColorPaletteData; }
            set { this.SetProperty(ref this._TempColorPaletteData, value); }
        }
        #endregion

        #region #- [Property] ColorPaletteData.EditColorPalette - ＜編集対象のカラーパレット＞ -----
        /// <summary> 編集対象のカラーパレット </summary>
        private ColorPaletteData _EditColorPalette;
        /// <summary> 編集対象のカラーパレット </summary>    
        public ColorPaletteData EditColorPalette
        {
            get { return _EditColorPalette; }
            set { this.SetProperty(ref this._EditColorPalette, value); }
        }
        #endregion
        #region #- [Property] PaletteSetDataUnion.CurrentPaletteSet - ＜現在のパレットセット＞ -----
        /// <summary> 現在のパレットセット </summary>
        private PaletteSetDataUnion _CurrentPaletteSet;
        /// <summary> 現在のパレットセット </summary>    
        public PaletteSetDataUnion CurrentPaletteSet
        {
            get { return _CurrentPaletteSet; }
            set { this.SetProperty(ref this._CurrentPaletteSet, value); }
        }
        #endregion

        /// <summary> 全カラーパレットコレクション
        /// </summary>
        public ObservableCollection<ColorPaletteData> AllColorPaletteCollection { get; private set; }
        /// <summary> パレットセットコレクション
        /// </summary>
        public ObservableCollection<PaletteSetDataUnion> PaletteSetCollection { get; private set; }

        /// <summary> パレットタイプコレクション
        /// </summary>
        public ObservableCollection<PaletteType> PaletteTypeCollection { get; private set; }

        /// <summary> XMLシリアライズプロセス
        /// </summary>
        private XmlSerializerProcess xmlSerializerProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／パレットオブジェクトモデル／コンストラクタ
        /// </summary>
        public PaletteObjectModel()
        {
            this.initObjectModel();

            this.CreatePaletteTypeCollection();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.AllColorPaletteCollection = new ObservableCollection<ColorPaletteData>();
            this.PaletteSetCollection = new ObservableCollection<PaletteSetDataUnion>();
            this.PaletteTypeCollection = new ObservableCollection<PaletteType>();
            this.TempColorPaletteData = new TempColorPaletteData();
            this.TempColorPaletteData.AddColorStringCollection.Add(string.Empty);
            this.TempColorPaletteData.AddColorStringCollection.Add(string.Empty);
            this.TempColorPaletteData.AddColorStringCollection.Add(string.Empty);
            this.TempColorPaletteData.AddColorStringCollection.Add(string.Empty);
            this.TempColorPaletteData.AddColorStringCollection.Add(string.Empty);

            this.xmlSerializerProcess = new XmlSerializerProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> パレットタイプコレクションの生成を実行します。
        /// </summary>
        public void CreatePaletteTypeCollection()
        {
            this.PaletteTypeCollection.Clear();

            foreach (PaletteType type in Enum.GetValues(typeof(PaletteType)))
            {
                this.PaletteTypeCollection.Add(type);
            }
        }

        /// <summary> 新しいパレットセットを生成し、コレクションに追加します。
        /// </summary>
        /// <param name="pName"> パレットセット名 </param>
        /// <param name="pCreatorName"> パレットセット作成者名 </param>
        /// <param name="pMemo"> パレットセットメモ </param>
        /// <param name="pVersion"> バージョン </param>
        public void CreateNewPaletteSet(string pName, string pCreatorName, string pMemo, Version pVersion)
        {
            PaletteSetDataUnion paletteSet = new PaletteSetDataUnion() {
                PaletteSetName = pName,
                PaletteSetCreatorName = pCreatorName,
                PaletteSetMemo = pMemo,
                PaletteSetVersion = pVersion,
                Updated = DateTime.Now
                };

            this.PaletteSetCollection.Add(paletteSet);
        }

        /// <summary> 新しいカラーパレットを生成し、パレットセットに追加します。
        /// </summary>
        /// <param name="pAddPaletteSet"> 追加するパレットセット </param>
        /// <param name="pName"> カラーパレット名 </param>
        /// <param name="pCategory"> カラーカテゴリ名 </param>
        /// <param name="pElement"> カラーエレメント名 </param>
        /// <param name="pMemo"> カラーメモ </param>
        /// <param name="pType"> カラータイプ</param>
        /// <param name="pCreatorName"> カラー作成者名 </param>
        /// <param name="pColors"> カラーデータ </param>
        public void AddNewColorPalette(
            PaletteSetDataUnion pAddPaletteSet, string pName, string pCategory, string pElement, string pMemo, PaletteType pType, string pCreatorName, IEnumerable<Color> pColors)
        {
            ColorPaletteData paletteData = new ColorPaletteData() { 
                PaletteName = pName,
                PaletteCategory = pCategory,
                PaletteElement = pElement,
                PaletteMemo = pMemo,
                PaletteType = pType,
                CreatorName = pCreatorName
                };

            foreach (var color in pColors)
            {
                paletteData.ColorCollection.Add(color);
            }

            this.AddNewColorPalette(pAddPaletteSet, paletteData);
        }

        /// <summary> 新しいカラーパレットを生成し、パレットセットに追加します。
        /// </summary>
        /// <param name="pAddPaletteSet"> 追加するパレットセット </param>
        /// <param name="pColorPalette"> 追加するカラーパレット </param>
        public void AddNewColorPalette(PaletteSetDataUnion pAddPaletteSet, ColorPaletteData pColorPalette)
        {
            pColorPalette.Updated = DateTime.Now;
            pAddPaletteSet.ColorPaletteCollection.Add(pColorPalette);
        }

        /// <summary> PaletteSetCollectionを元に、全カラーパレットのコレクション(AllColorPaletteCollection)を生成します。
        /// </summary>
        public void CreateAllColorCollection()
        {
            foreach (var pSet in this.PaletteSetCollection)
            {
                foreach (var palette in pSet.ColorPaletteCollection)
                {
                    this.AllColorPaletteCollection.Add(palette);
                }
            }
        }

        public void SavePaletteSet(string pSaveDir, string pFileName, PaletteSetDataUnion pPaletteSetDU)
        {
            this.SavePaletteSet(Path.Combine(pSaveDir, pFileName), pPaletteSetDU);
        }
        public void SavePaletteSet(string pSaveFullPath, PaletteSetDataUnion pPaletteSetDU)
        {
            this.xmlSerializerProcess.XmlSave(pSaveFullPath, pPaletteSetDU, true);
        }

        public PaletteSetDataUnion LoadPaletteSet(string pLoadDir, string pFileName)
        {
            return LoadPaletteSet(Path.Combine(pLoadDir, pFileName));
        }
        public PaletteSetDataUnion LoadPaletteSet(string pLoadFullPath)
        {
            return this.xmlSerializerProcess.XmlLoad<PaletteSetDataUnion>(pLoadFullPath, true);
        }

        public void SaveColorPalette()
        {

        }

        public void LoadColorPalette()
        {

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
