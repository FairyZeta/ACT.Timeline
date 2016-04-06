using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／オーバーレイ管理コンポーネント
    /// </summary>
    public class OverlayManageComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインコンポーネント（OverlayView引渡し用）
        /// </summary>
        public TimelineComponent TimelineComponent { get; set; }

        #region #- [Property] OverlayManageDataModel.OverlayManageDataModel - ＜オーバーレイ管理データモデル＞ -----
        /// <summary> オーバーレイ管理データモデル </summary>
        private OverlayManageDataModel _OverlayManageDataModel;
        /// <summary> オーバーレイ管理データモデル </summary>
        public OverlayManageDataModel OverlayManageDataModel
        {
            get { return this._OverlayManageDataModel; }
            set
            {
                if (this._OverlayManageDataModel == value) return;

                this._OverlayManageDataModel = value;
                base.OnPropertyChanged("OverlayManageDataModel");
            }
        }
        #endregion
        #region #- [Property] AddOverlayDataModel.AddOverlayDataModel - ＜新規オーバーレイ追加用データモデル＞ -----
        /// <summary> 新規オーバーレイ追加用データモデル </summary>
        private OverlayDataModel _AddOverlayDataModel;
        /// <summary> 新規オーバーレイ追加用データモデル </summary>
        public OverlayDataModel AddOverlayDataModel
        {
            get { return this._AddOverlayDataModel; }
            set
            {
                if (this._AddOverlayDataModel == value) return;

                this._AddOverlayDataModel = value;
                base.OnPropertyChanged("AddOverlayDataModel");
            }
        }
        #endregion

        /// <summary> オーバーレイ管理モジュール
        /// </summary>
        public OverlayManageModule OverlayManageModule { get; private set; }
        
        #region #- [Command] DelegateCommand.NewOverlayAppendCommand - ＜新規オーバーレイ作成コマンド＞ -----
        /// <summary> 新規オーバーレイ作成コマンド＜コマンド＞ </summary>
        private DelegateCommand _NewOverlayAppendCommand;
        /// <summary> 新規オーバーレイ作成コマンド＜コマンド＞ </summary>
        public DelegateCommand NewOverlayAppendCommand
        {
            get { return _NewOverlayAppendCommand = _NewOverlayAppendCommand ?? new DelegateCommand(this._NewOverlayAppendExecute, this._CanNewOverlayAppendExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand<bool?>.OverlayAddEnterCommand - ＜新規オーバーレイ追加確定コマンド＞ -----
        /// <summary> 新規オーバーレイ追加確定コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _OverlayAddEnterCommand;
        /// <summary> 新規オーバーレイ追加確定コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> OverlayAddEnterCommand
        {
            get { return _OverlayAddEnterCommand = _OverlayAddEnterCommand ?? new DelegateCommand<string>(this._OverlayAddEnterExecute, this._CanOverlayAddEnterExecute); }
        }
        #endregion 
        
        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayViewCommand - ＜オーバーレイ表示コマンド＞ -----
        /// <summary> オーバーレイ表示コマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayViewCommand;
        /// <summary> オーバーレイ表示コマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayViewCommand
        {
            get { return _OverlayViewCommand = _OverlayViewCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayViewExecute, this._CanOverlayViewExecute); }
        }
        #endregion 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ管理コンポーネント／コンストラクタ
        /// </summary>
        public OverlayManageComponent()
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
            this.OverlayManageDataModel = new OverlayManageDataModel();
            this.OverlayManageModule = new OverlayManageModule();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] CanExecute,Execute @ NewOverlayAppendCommand - ＜新規オーバーレイ作成コマンド＞ -----
        /// <summary> 実行可能確認＜新規オーバーレイ作成コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanNewOverlayAppendExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜新規オーバーレイ作成コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _NewOverlayAppendExecute()
        {
            // --- 追加用データ生成
            this.AddOverlayDataModel = new OverlayDataModel();
            this.OverlayManageModule.CreateOverlayTypeCollection(this.AddOverlayDataModel);

            // --- ウィンドウを開く
            this.OverlayManageDataModel.OverlayManageData.NewOverlayAddWindowCloesd = false;
            NewOverlayAddWindowView window = new NewOverlayAddWindowView();

            window.Width = 400;
            window.Height = 180;

            var vm = window.DataContext as NewOverlayAddWindowViewModel;
            if (vm == null) return; // ERROR!

            vm.OverlayManageComponent.AddOverlayDataModel = this.AddOverlayDataModel;
            vm.OverlayManageComponent.OverlayManageDataModel = this.OverlayManageDataModel;

            window.ShowDialog();

            // --- 追加判定後、追加
            if (!this.AddOverlayDataModel.AddDecisionFLG) return;

            OverlayViewComponent component = new OverlayViewComponent();
            component.OverlayDataModel = this.AddOverlayDataModel;
            this.OverlayManageModule.SetDefaultOverlayWindowData(component.OverlayDataModel.OverlayWindowData);
            this.OverlayManageModule.SetDefaultOverlaySettingData(component.OverlayDataModel.OverlaySettingsData);

            this.OverlayManageDataModel.OverlayViewComponentCollection.Add(component);

        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayAddEnterCommand - ＜新規オーバーレイ追加確定コマンド＞ -----
        /// <summary> 実行可能確認＜新規オーバーレイ追加確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayAddEnterExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜新規オーバーレイ追加確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayAddEnterExecute(string para)
        {
            switch (para)
            {
                case "Add":
                    this.AddOverlayDataModel.AddDecisionFLG = true;
                    break;
            }

            this.OverlayManageDataModel.OverlayManageData.NewOverlayAddWindowCloesd = true;
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ OverlayViewCommand - ＜オーバーレイ表示コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイ表示コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayViewExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイ表示コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayViewExecute(OverlayViewComponent para)
        {
        }
        #endregion 
    }
}
