using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／カラーパレットデータ
    /// </summary>
    public class ColorPaletteData : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.PaletteName - ＜パレット名＞ -----
        /// <summary> パレット名 </summary>
        private string _PaletteName;
        /// <summary> パレット名 </summary>    
        public string PaletteName
        {
            get { return _PaletteName; }
            set { this.SetProperty(ref this._PaletteName, value); }
        }
        #endregion

        #region #- [Property] string.PaletteCategory - ＜パレットカテゴリ＞ -----
        /// <summary> パレットカテゴリ </summary>
        private string _PaletteCategory;
        /// <summary> パレットカテゴリ </summary>    
        public string PaletteCategory
        {
            get { return _PaletteCategory; }
            set { this.SetProperty(ref this._PaletteCategory, value); }
        }
        #endregion

        #region #- [Property] string.PaletteElement - ＜パレット属性＞ -----
        /// <summary> パレット属性 </summary>
        private string _PaletteElement;
        /// <summary> パレット属性 </summary>    
        public string PaletteElement
        {
            get { return _PaletteElement; }
            set { this.SetProperty(ref this._PaletteElement, value); }
        }
        #endregion

        #region #- [Property] PaletteType.PaletteType - ＜パレットタイプ＞ -----
        /// <summary> パレットタイプ </summary>
        private PaletteType _PaletteType;
        /// <summary> パレットタイプ </summary>    
        public PaletteType PaletteType
        {
            get { return _PaletteType; }
            set { this.SetProperty(ref this._PaletteType, value); }
        }
        #endregion

        #region #- [Property] string.PaletteMemo - ＜パレットメモ＞ -----
        /// <summary> パレットメモ </summary>
        private string _PaletteMemo;
        /// <summary> パレットメモ </summary>    
        public string PaletteMemo
        {
            get { return _PaletteMemo; }
            set { this.SetProperty(ref this._PaletteMemo, value); }
        }
        #endregion

        #region #- [Property] DateTime.Updated - ＜更新日＞ -----
        /// <summary> 更新日 </summary>
        private DateTime _Updated;
        /// <summary> 更新日 </summary>    
        public DateTime Updated
        {
            get { return _Updated; }
            set { this.SetProperty(ref this._Updated, value); }
        }
        #endregion

        #region #- [Property] string.CreatorName - ＜作成者名＞ -----
        /// <summary> 作成者名 </summary>
        private string _CreatorName;
        /// <summary> 作成者名 </summary>    
        public string CreatorName
        {
            get { return _CreatorName; }
            set { this.SetProperty(ref this._CreatorName, value); }
        }
        #endregion

        /// <summary> カラーコレクション
        /// </summary>
        public ObservableCollection<Color> ColorCollection { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／カラーパレットデータ／コンストラクタ
        /// </summary>
        public ColorPaletteData()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.PaletteName = string.Empty;
            this.PaletteCategory = string.Empty;
            this.PaletteElement = string.Empty;
            this.PaletteMemo = string.Empty;
            this.CreatorName = string.Empty;
            
            this.PaletteType = PaletteType.NonType;

            this.ColorCollection = new ObservableCollection<Color>();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public int AddColorCollection(Color pColor)
        {
            this.ColorCollection.Add(pColor);
            this.Updated = DateTime.Now;

            return this.ColorCollection.Count() - 1;
        }

        public bool SetColorCollection(Color pColor, int pSetSchemeNo)
        {
            if (this.ColorCollection.Count < pSetSchemeNo)
                return false;

            this.ColorCollection[pSetSchemeNo] = pColor;
            this.Updated = DateTime.Now;

            return true;
        }

        public Color GetColorCollection(int pGetSchemeNo)
        {
            if (this.ColorCollection.Count < pGetSchemeNo)
                return Color.FromArgb(0x00, 0x00, 0x00, 0x00);

            return this.ColorCollection[pGetSchemeNo];
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
