using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> [基底] タイムライン／コンポーネント
    /// </summary>
    public abstract class _Component : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] CommonDataModel.CommonDataModel - ＜共通データモデル＞ -----
        /// <summary> 共通データモデル </summary>
        private CommonDataModel _CommonDataModel;
        /// <summary> 共通データモデル </summary>
        public CommonDataModel CommonDataModel
        {
            get { return this._CommonDataModel; }
            private set
            {
                if (this._CommonDataModel == value) return;

                this._CommonDataModel = value;
                base.OnPropertyChanged("CommonDataModel");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [基底] タイムライン／コンポーネント／コンストラクタ
        /// </summary>
        public _Component(CommonDataModel pCommondDataModel)
        {
            this.initComponent(pCommondDataModel);
        }

        /// <summary> [基底] タイムライン／コンポーネント／コンストラクタ
        /// </summary>
        public _Component()
        {
            this.initComponent(null);
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent(CommonDataModel pCommondDataModel)
        {
            this.CommonDataModel = pCommondDataModel;

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
