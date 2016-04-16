using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.ObjectModel;

namespace FairyZeta.FF14.ACT.Component
{
    /// <summary> ACT／アップデートダイアログコンポーネント
    /// </summary>
    public class UpdateDialogComponent : _Compoent
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] PluginUpdateObjectModel.PluginUpdateObjectModel - ＜プラグインアップデートオブジェクトモデル＞ -----
        /// <summary> プラグインアップデートオブジェクトモデル </summary>
        private PluginUpdateObjectModel _PluginUpdateObjectModel;
        /// <summary> プラグインアップデートオブジェクトモデル </summary>
        public PluginUpdateObjectModel PluginUpdateObjectModel
        {
            get { return this._PluginUpdateObjectModel; }
            set
            {
                if (this._PluginUpdateObjectModel == value) return;

                this._PluginUpdateObjectModel = value;
                base.OnPropertyChanged("PluginUpdateObjectModel");
            }
        }
        #endregion

        #region #- [Command] DelegateCommand<string>.DiarogResultCommand - ＜ダイアログ応答コマンド＞ -----
        /// <summary> ダイアログ応答コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _DiarogResultCommand;
        /// <summary> ダイアログ応答コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> DiarogResultCommand
        {
            get { return _DiarogResultCommand = _DiarogResultCommand ?? new DelegateCommand<string>(this._DiarogResultExecute, this._CanDiarogResultExecute); }
        }
        #endregion 


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／アップデートダイアログコンポーネント／コンストラクタ
        /// </summary>
        public UpdateDialogComponent()
            : base()
        {
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] CanExecute,Execute @ DiarogResultCommand - ＜ダイアログ応答コマンド＞ -----
        /// <summary> 実行可能確認＜ダイアログ応答コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanDiarogResultExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜ダイアログ応答コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _DiarogResultExecute(string para)
        {
            if (this.PluginUpdateObjectModel == null)
                return;

            switch(para)
            {
                case "DirectoryOpen":
                    this.PluginUpdateObjectModel.UpdateStatusData.UpdateDialogResult = UpdateDialogResult.DirectoryOpen;
                    this.PluginUpdateObjectModel.DirectoryOpen();
                    this.PluginUpdateObjectModel.UpdateStatusData.DialogClosed = true;
                    break;

                case "WebOpen":
                    this.PluginUpdateObjectModel.UpdateStatusData.UpdateDialogResult = UpdateDialogResult.WebOpen;
                    this.PluginUpdateObjectModel.WebOpen();
                    this.PluginUpdateObjectModel.UpdateStatusData.DialogClosed = true;
                    break;

                case "ZipDownload":
                    this.PluginUpdateObjectModel.UpdateStatusData.UpdateDialogResult = UpdateDialogResult.ZipDownload;
                    Task.Run(() =>  this.PluginUpdateObjectModel.ZipDownload());
                    
                    break;
            
                case "Close":
                default:
                    this.PluginUpdateObjectModel.UpdateStatusData.UpdateDialogResult = UpdateDialogResult.Unknown;
                    this.PluginUpdateObjectModel.UpdateStatusData.DialogClosed = true;
                    break;
            }
        }
        #endregion 

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
