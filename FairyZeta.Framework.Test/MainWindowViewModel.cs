using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using FairyZeta.Framework;
using FairyZeta.Framework.Dropbox;
using FairyZeta.Framework.Unit;

namespace FairyZeta.Framework.Test
{
    /// <summary> FZ.TEST／メインウィンドウビューモデル
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.TestString - ＜テストストリング＞ -----
        /// <summary> テストストリング </summary>
        private string _TestString;
        /// <summary> テストストリング </summary>    
        public string TestString
        {
            get { return _TestString; }
            set { this.SetProperty(ref this._TestString, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
    
        /// <summary> FZ.TEST／メインウィンドウビューモデル／コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            :base ()
        {
            this.initViewModel();

           // ASEConverter asec = new ASEConverter();
            //asec.Read(@"D:\realcolors_swatch1.ase");

            //AseUnit unit = new AseUnit();
            //unit.Load(@"D:\realcolors_swatch1.ase");

            //DropTest.Main();
            //var task = Task.Run((Func<Task>)DropTest.ListRootFolder);
            //task.Wait();
            //var task2 = Task.Run((Func<Task>)DropTest.Download);
            //task2.Wait();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.TestString = "バインドテスト";
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
