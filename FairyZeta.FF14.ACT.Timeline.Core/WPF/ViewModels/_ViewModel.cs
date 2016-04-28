using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> [基底] タイムライン／ビューモデル
    /// </summary>
    public abstract class _ViewModel : BindableBase, IDisposable
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> [基底] タイムライン／ビューモデル／コンストラクタ
        /// </summary>
        public _ViewModel()
            : base()
        {
            this.initViewModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> デストラクタ
        /// </summary>
        ~_ViewModel()
        {
            this.OnDispose(false);
            return;
        }

        /// <summary>
        /// 開放処理されたかどうかを取得|設定します。
        /// </summary>
        public bool IsDisposed
        {
            get; protected set;
        }

        /// <summary>
        /// 内部リソース解放処理を行います。<br/>
        /// 参照系の内部変数をnullに初期化したり、
        /// イベントからハンドラメソッドを削除します。
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.OnDispose(true);
            }
            catch (Exception)
            {
            }

            return;
        }

        /// <summary>
        /// 内部リソース解放処理を行います。<br/>
        /// </summary>
        /// <param name="disposing">false:アンマネージドリソースのみ解放する</param>
        protected virtual void OnDispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.IsDisposed = true;

            if (disposing)
            {
            }
        }
            /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
