using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／オーバーレイ表示コンポーネント
    /// </summary>
    public class OverlayViewComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイデータモデル
        /// </summary>
        public OverlayDataModel OverlayDataModel { get; set; }

        /// <summary> オーバーレイコントロールモジュール
        /// </summary>
        public OverlayControlModule OverlayControlModule { get; set; }

        #region #- [Command] DelegateCommand.OverlayClosedCommand - ＜オーバーレイ終了コマンド＞ -----
        /// <summary> オーバーレイ終了コマンド＜コマンド＞ </summary>
        private DelegateCommand _OverlayClosedCommand;
        /// <summary> オーバーレイ終了コマンド＜コマンド＞ </summary>
        public DelegateCommand OverlayClosedCommand
        {
            get { return _OverlayClosedCommand = _OverlayClosedCommand ?? new DelegateCommand(this._OverlayClosedExecute, this._CanOverlayClosedExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<TimelineType>.OverlayTypeFilterCommand - ＜オーバーレイタイムラインタイプフィルタ設定コマンド＞ -----
        /// <summary> オーバーレイタイムラインタイプフィルタ設定コマンド＜コマンド＞ </summary>
        private DelegateCommand<TimelineType?> _OverlayTypeFilterCommand;
        /// <summary> オーバーレイタイムラインタイプフィルタ設定コマンド＜コマンド＞ </summary>
        public DelegateCommand<TimelineType?> OverlayTypeFilterCommand
        {
            get { return _OverlayTypeFilterCommand = _OverlayTypeFilterCommand ?? new DelegateCommand<TimelineType?>(this._OverlayTypeFilterExecute, this._CanOverlayTypeFilterExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<Job>.OverlayJobFilterCommand - ＜オーバーレイジョブフィルタ設定コマンド＞ -----
        /// <summary> オーバーレイジョブフィルタ設定コマンド＜コマンド＞ </summary>
        private DelegateCommand<Job?> _OverlayJobFilterCommand;
        /// <summary> オーバーレイジョブフィルタ設定コマンド＜コマンド＞ </summary>
        public DelegateCommand<Job?> OverlayJobFilterCommand
        {
            get { return _OverlayJobFilterCommand = _OverlayJobFilterCommand ?? new DelegateCommand<Job?>(this._OverlayJobFilterExecute, this._CanOverlayJobFilterExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<TankMode>.OverlayTankModeFilterCommand - ＜オーバーレイタンクモードフィルタ設定コマンド＞ -----
        /// <summary> オーバーレイタンクモードフィルタ設定コマンド＜コマンド＞ </summary>
        private DelegateCommand<TankMode?> _OverlayTankModeFilterCommand;
        /// <summary> オーバーレイタンクモードフィルタ設定コマンド＜コマンド＞ </summary>
        public DelegateCommand<TankMode?> OverlayTankModeFilterCommand
        {
            get { return _OverlayTankModeFilterCommand = _OverlayTankModeFilterCommand ?? new DelegateCommand<TankMode?>(this._OverlayTankModeFilterExecute, this._CanOverlayTankModeFilterExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<double?>.WidthValueUpCommand - ＜横幅プラスコマンド＞ -----
        /// <summary> 横幅プラスコマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _WidthValueUpCommand;
        /// <summary> 横幅プラスコマンド＜コマンド＞ </summary>
        public DelegateCommand<string> WidthValueUpCommand
        {
            get { return _WidthValueUpCommand = _WidthValueUpCommand ?? new DelegateCommand<string>(this._WidthValueUpExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<double?>.WidthValueDownCommand - ＜横幅マイナスコマンド＞ -----
        /// <summary> 横幅マイナスコマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _WidthValueDownCommand;
        /// <summary> 横幅マイナスコマンド＜コマンド＞ </summary>
        public DelegateCommand<string> WidthValueDownCommand
        {
            get { return _WidthValueDownCommand = _WidthValueDownCommand ?? new DelegateCommand<string>(this._WidthValueDownExecute); }
        }
        #endregion 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ表示コンポーネント／コンストラクタ
        /// </summary>
        public OverlayViewComponent(CommonDataModel pCommonDataModel)
            : base(pCommonDataModel)
        {
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.OverlayDataModel = new OverlayDataModel();
            this.OverlayControlModule = new OverlayControlModule();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] CanExecute,Execute @ OverlayClosedCommand - ＜オーバーレイ終了コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイ終了コマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayClosedExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイ終了コマンド＞ </summary>
        private void _OverlayClosedExecute()
        {
            this.OverlayDataModel.OverlayWindowData.WindowVisibility = false;
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayTypeFilterCommand - ＜オーバーレイタイムラインタイプフィルタ設定コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイタイムラインタイプフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayTypeFilterExecute(TimelineType? para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイタイムラインタイプフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayTypeFilterExecute(TimelineType? para)
        {
            if (!para.HasValue) return;
            this.OverlayControlModule.SetTimelineTypeFilter(this.OverlayDataModel, para.Value);
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ OverlayJobFilterCommand - ＜オーバーレイジョブフィルタ設定コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイジョブフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayJobFilterExecute(Job? para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイジョブフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayJobFilterExecute(Job? para)
        {
            if (!para.HasValue) return;
            this.OverlayControlModule.SetJobFilter(this.OverlayDataModel, para.Value);
        }
        #endregion

        #region #- [Method] CanExecute,Execute @ OverlayTankModeFilterCommand - ＜オーバーレイタンクモードフィルタ設定コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイタンクモードフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayTankModeFilterExecute(TankMode? para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイタンクモードフィルタ設定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayTankModeFilterExecute(TankMode? para)
        {
            if (!para.HasValue) return;
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ WidthValueUpCommand - ＜横幅プラスコマンド＞ -----
        /// <summary> コマンド実行＜横幅プラスコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _WidthValueUpExecute(string para)
        {
            if (string.IsNullOrWhiteSpace(para)) return;
            
            double d = 1;

            switch(para)
            {
                case "TimeNoWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TimeNoWidth += d;
                    break;
                case "ActionTimeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActionTimeWidth += d;
                    break;
                case "TypeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TypeWidth += d;
                    break;
                case "JobWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.JobWidth += d;
                    break;
                case "TankModeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TankModeWidth += d;
                    break;
                case "ActionWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActionWidth += d;
                    break;
                case "ActiveWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActiveWidth += d;
                    break;
                case "AlertWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.AlertWidth += d;
                    break;
                case "JumpWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.JumpWidth += d;
                    break;
            }

        }
        #endregion
        #region #- [Method] CanExecute,Execute @ WidthValueDownCommand - ＜横幅マイナスコマンド＞ -----
        /// <summary> コマンド実行＜横幅マイナスコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _WidthValueDownExecute(string para)
        {
            if (string.IsNullOrWhiteSpace(para)) return;
            
            double d = -1;

            switch (para)
            {
                case "TimeNoWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TimeNoWidth += d;
                    break;
                case "ActionTimeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActionTimeWidth += d;
                    break;
                case "TypeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TypeWidth += d;
                    break;
                case "JobWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.JobWidth += d;
                    break;
                case "TankModeWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.TankModeWidth += d;
                    break;
                case "ActionWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActionWidth += d;
                    break;
                case "ActiveWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.ActiveWidth += d;
                    break;
                case "AlertWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.AlertWidth += d;
                    break;
                case "JumpWidth":
                    this.OverlayDataModel.OverlayContentSettingsData.JumpWidth += d;
                    break;
            }

        }
        #endregion 
    }
}
