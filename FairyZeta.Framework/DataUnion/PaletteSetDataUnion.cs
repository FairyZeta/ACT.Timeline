using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FairyZeta.Framework.Data;
using Prism.Mvvm;

namespace FairyZeta.Framework.DataUnion
{
    /// <summary> FZ／パレットセットデータユニオン
    /// </summary>
    public class PaletteSetDataUnion : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.PaletteSetName - ＜パレットセット名＞ -----
        /// <summary> パレットセット名 </summary>
        private string _PaletteSetName;
        /// <summary> パレットセット名 </summary>    
        public string PaletteSetName
        {
            get { return _PaletteSetName; }
            set { this.SetProperty(ref this._PaletteSetName, value); }
        }
        #endregion

        #region #- [Property] string.PaletteSetMemo - ＜パレットセットメモ＞ -----
        /// <summary> パレットセットメモ </summary>
        private string _PaletteSetMemo;
        /// <summary> パレットセットメモ </summary>    
        public string PaletteSetMemo
        {
            get { return _PaletteSetMemo; }
            set { this.SetProperty(ref this._PaletteSetMemo, value); }
        }
        #endregion

        #region #- [Property] string.PaletteSetCreatorName - ＜パレットセット作成者名＞ -----
        /// <summary> パレットセット作成者名 </summary>
        private string _PaletteSetCreatorName;
        /// <summary> パレットセット作成者名 </summary>    
        public string PaletteSetCreatorName
        {
            get { return _PaletteSetCreatorName; }
            set { this.SetProperty(ref this._PaletteSetCreatorName, value); }
        }
        #endregion

        #region #- [Property] Version.PaletteSetVersion - ＜パレットセットバージョン＞ -----
        /// <summary> パレットセットバージョン
        /// </summary>
        public string Version;
        /// <summary> パレットセットバージョン 
        /// </summary>    
        public Version PaletteSetVersion
        {
            get { return new Version(this.Version); }
            set { this.SetProperty(ref this.Version, value.ToString()); }
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

        /// <summary> カラーパレットコレクション
        /// </summary>
        public ObservableCollection<ColorPaletteData> ColorPaletteCollection { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／パレットセットデータユニオン／コンストラクタ
        /// </summary>
        public PaletteSetDataUnion()
        {
            this.initDataUnion();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データユニオンの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataUnion()
        {
            this.PaletteSetName = string.Empty;
            this.PaletteSetMemo = string.Empty;
            this.PaletteSetCreatorName = string.Empty;

            this.ColorPaletteCollection = new ObservableCollection<ColorPaletteData>();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
