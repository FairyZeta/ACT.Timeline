using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prism.Commands;
using FairyZeta.Framework.ObjectModel;
using FairyZeta.Framework.DataUnion;

namespace FairyZeta.Framework.Component
{
    /// <summary> FZ／カラーツールコンポーネント
    /// </summary>
    public class ColorToolComponent
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> パレットオブジェクトモデル
        /// </summary>
        public PaletteObjectModel PaletteObjectModel { get; set; }

        #region #- [Command] DelegateCommand.AddColorCommand - ＜カラー追加コマンド＞ -----
        /// <summary> カラー追加コマンド＜コマンド＞ </summary>
        private DelegateCommand _AddColorCommand;
        /// <summary> カラー追加コマンド＜コマンド＞ </summary>
        public DelegateCommand AddColorCommand
        {
            get { return _AddColorCommand = _AddColorCommand ?? new DelegateCommand(this._AddColorExecute, this._CanAddColorExecute); }
        }
        #endregion 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／カラーツールコンポーネント／コンストラクタ
        /// </summary>
        public ColorToolComponent()
        {
            this.initComponent();
            this.SetupComponent();
        }

        public void SetupComponent()
        {
            var loadPaletteSet = this.PaletteObjectModel.LoadPaletteSet(@"D:\DefaultPaletteSet.xml");
            if (loadPaletteSet != null)
            {
                this.PaletteObjectModel.PaletteSetCollection.Add(loadPaletteSet);
            }

            if (this.PaletteObjectModel.PaletteSetCollection.Count == 0)
            {
                PaletteSetDataUnion pSet = new PaletteSetDataUnion();
                pSet.PaletteSetCreatorName = "FairyZeta";
                pSet.PaletteSetName = "DefaultPaletteSet";
                pSet.PaletteSetVersion = new Version(1, 0);
                pSet.PaletteSetMemo = "Default";
                pSet.Updated = DateTime.Now;

                this.PaletteObjectModel.PaletteSetCollection.Add(pSet);
                this.PaletteObjectModel.CurrentPaletteSet = pSet;
            }
            else
            {
                this.PaletteObjectModel.CurrentPaletteSet = this.PaletteObjectModel.PaletteSetCollection[0];
            }


        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.PaletteObjectModel = new PaletteObjectModel();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] CanExecute,Execute @ AddColorCommand - ＜カラー追加コマンド＞ -----
        /// <summary> 実行可能確認＜カラー追加コマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanAddColorExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜カラー追加コマンド＞ </summary>
        private void _AddColorExecute()
        {
            List<Color> colors = new List<Color>();

            foreach (var color in this.PaletteObjectModel.TempColorPaletteData.AddColorStringCollection)
            {
                try
                {
                    colors.Add((Color)ColorConverter.ConvertFromString(color));
                }
                catch
                {
                    Console.WriteLine(string.Format("Color Convert Error: {0}", color));
                }
            }

            this.PaletteObjectModel.AddNewColorPalette(
                PaletteObjectModel.CurrentPaletteSet,
                PaletteObjectModel.TempColorPaletteData.PaletteName,
                PaletteObjectModel.TempColorPaletteData.PaletteCategory,
                PaletteObjectModel.TempColorPaletteData.PaletteElement,
                PaletteObjectModel.TempColorPaletteData.PaletteMemo,
                PaletteObjectModel.TempColorPaletteData.PaletteType,
                PaletteObjectModel.TempColorPaletteData.CreatorName,
                colors
                );

            string path = System.IO.Path.Combine(@"D:\", this.PaletteObjectModel.CurrentPaletteSet.PaletteSetName) + @".xml";
            this.PaletteObjectModel.SavePaletteSet(path, this.PaletteObjectModel.CurrentPaletteSet);
        }
        #endregion 
    }
}
