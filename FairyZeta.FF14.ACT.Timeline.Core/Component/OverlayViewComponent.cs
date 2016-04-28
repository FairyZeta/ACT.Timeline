using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using FairyZeta.Framework;
using FairyZeta.Framework.ObjectModel;

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
        /// <summary> オーバーレイ管理モジュール
        /// </summary>
        public OverlayManageModule OverlayManageModule { get; set; }

        /// <summary> プレビューオブジェクトモデル
        /// </summary>
        public OverlayPreviewObjectModel OverlayPreviewObjectModel { get; set; }

        /// <summary> ダイアログ管理モデル
        /// </summary>
        public DialogManageObjectModel DialogManage { get; private set; }

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

        #region #- [Command] DelegateCommand.OverlayCustomOpenCommand - ＜オーバーレイカスタムオープンコマンド＞ -----
        /// <summary> オーバーレイカスタムオープンコマンド＜コマンド＞ </summary>
        private DelegateCommand _OverlayCustomOpenCommand;
        /// <summary> オーバーレイカスタムオープンコマンド＜コマンド＞ </summary>
        public DelegateCommand OverlayCustomOpenCommand
        {
            get { return _OverlayCustomOpenCommand = _OverlayCustomOpenCommand ?? new DelegateCommand(this._OverlayCustomOpenExecute, this._CanOverlayCustomOpenExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.OverlayCustomClosedCommand - ＜オーバーレイカスタム終了コマンド＞ -----
        /// <summary> オーバーレイカスタム終了コマンド＜コマンド＞ </summary>
        private DelegateCommand _OverlayCustomClosedCommand;
        /// <summary> オーバーレイカスタム終了コマンド＜コマンド＞ </summary>
        public DelegateCommand OverlayCustomClosedCommand
        {
            get { return _OverlayCustomClosedCommand = _OverlayCustomClosedCommand ?? new DelegateCommand(this._OverlayCustomClosedExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<string>.FontEditCommand - ＜フォント変更コマンド＞ -----
        /// <summary> フォント変更コマンド＜コマンド＞ </summary>
        private DelegateCommand<FontEditTarget?> _FontEditCommand;
        /// <summary> フォント変更コマンド＜コマンド＞ </summary>
        public DelegateCommand<FontEditTarget?> FontEditCommand
        {
            get { return _FontEditCommand = _FontEditCommand ?? new DelegateCommand<FontEditTarget?>(this._FontEditExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.FontEditEndCommand - ＜フォント変更終了コマンド＞ -----
        /// <summary> フォント変更終了コマンド＜コマンド＞ </summary>
        private DelegateCommand _FontEditEndCommand;
        /// <summary> フォント変更終了コマンド＜コマンド＞ </summary>
        public DelegateCommand FontEditEndCommand
        {
            get { return _FontEditEndCommand = _FontEditEndCommand ?? new DelegateCommand(this._FontEditEndExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.FontEditCancelCommand - ＜フォント変更キャンセルコマンド＞ -----
        /// <summary> フォント変更キャンセルコマンド＜コマンド＞ </summary>
        private DelegateCommand _FontEditCancelCommand;
        /// <summary> フォント変更キャンセルコマンド＜コマンド＞ </summary>
        public DelegateCommand FontEditCancelCommand
        {
            get { return _FontEditCancelCommand = _FontEditCancelCommand ?? new DelegateCommand(this._FontEditCancelExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<string>.ColorEditCommand - ＜カラー変更コマンド＞ -----
        /// <summary> カラー変更コマンド＜コマンド＞ </summary>
        private DelegateCommand<ColorEditTarget?> _ColorEditCommand;
        /// <summary> カラー変更コマンド＜コマンド＞ </summary>
        public DelegateCommand<ColorEditTarget?> ColorEditCommand
        {
            get { return _ColorEditCommand = _ColorEditCommand ?? new DelegateCommand<ColorEditTarget?>(this._ColorEditExecute); }
        }
        #endregion
        #region #- [Command] DelegateCommand<string>.EditCloseCommand - ＜変更終了コマンド＞ -----
        /// <summary> 変更終了コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _EditCloseCommand;
        /// <summary> 変更終了コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> EditCloseCommand
        {
            get { return _EditCloseCommand = _EditCloseCommand ?? new DelegateCommand<string>(this._EditCloseExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.StringColorEditCancelCommand - ＜文字カラー変更キャンセルコマンド＞ -----
        /// <summary> 文字カラー変更キャンセルコマンド＜コマンド＞ </summary>
        private DelegateCommand _StringColorEditCancelCommand;
        /// <summary> 文字カラー変更キャンセルコマンド＜コマンド＞ </summary>
        public DelegateCommand StringColorEditCancelCommand
        {
            get { return _StringColorEditCancelCommand = _StringColorEditCancelCommand ?? new DelegateCommand(this._StringColorEditCancelExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<ColorEditTarget?>.ActiveColorEditCommand - ＜アクティブカラー変更コマンド＞ -----
        /// <summary> アクティブカラー変更コマンド＜コマンド＞ </summary>
        private DelegateCommand<ColorEditTarget?> _ActiveColorEditCommand;
        /// <summary> アクティブカラー変更コマンド＜コマンド＞ </summary>
        public DelegateCommand<ColorEditTarget?> ActiveColorEditCommand
        {
            get { return _ActiveColorEditCommand = _ActiveColorEditCommand ?? new DelegateCommand<ColorEditTarget?>(this._ActiveColorEditExecute); }
        }
        #endregion
        #region #- [Command] DelegateCommand<ColorEditTarget?>.CastColorEditCommand - ＜キャストカラー変更コマンド＞ -----
        /// <summary> キャストカラー変更コマンド＜コマンド＞ </summary>
        private DelegateCommand<ColorEditTarget?> _CastColorEditCommand;
        /// <summary> キャストカラー変更コマンド＜コマンド＞ </summary>
        public DelegateCommand<ColorEditTarget?> CastColorEditCommand
        {
            get { return _CastColorEditCommand = _CastColorEditCommand ?? new DelegateCommand<ColorEditTarget?>(this._CastColorEditExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<ColorEditTarget?>.ActiveColorEditEndCommand - ＜アクティブカラー変更終了コマンド＞ -----
        /// <summary> アクティブカラー変更終了コマンド＜コマンド＞ </summary>
        private DelegateCommand<ColorEditTarget?> _ActiveColorEditEndCommand;
        /// <summary> アクティブカラー変更終了コマンド＜コマンド＞ </summary>
        public DelegateCommand<ColorEditTarget?> ActiveColorEditEndCommand
        {
            get { return _ActiveColorEditEndCommand = _ActiveColorEditEndCommand ?? new DelegateCommand<ColorEditTarget?>(this._ActiveColorEditEndExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand<ColorEditTarget?>.CastColorEditEndCommand - ＜キャストカラー変更終了コマンド＞ -----
        /// <summary> キャストカラー変更終了コマンド＜コマンド＞ </summary>
        private DelegateCommand<ColorEditTarget?> _CastColorEditEndCommand;
        /// <summary> キャストカラー変更終了コマンド＜コマンド＞ </summary>
        public DelegateCommand<ColorEditTarget?> CastColorEditEndCommand
        {
            get { return _CastColorEditEndCommand = _CastColorEditEndCommand ?? new DelegateCommand<ColorEditTarget?>(this._CastColorEditEndExecute); }
        }
        #endregion

        #region #- [Command] DelegateCommand.ActiveColorEditCancelCommand - ＜アクティブカラー変更キャンセルコマンド＞ -----
        /// <summary> アクティブカラー変更キャンセルコマンド＜コマンド＞ </summary>
        private DelegateCommand _ActiveColorEditCancelCommand;
        /// <summary> アクティブカラー変更キャンセルコマンド＜コマンド＞ </summary>
        public DelegateCommand ActiveColorEditCancelCommand
        {
            get { return _ActiveColorEditCancelCommand = _ActiveColorEditCancelCommand ?? new DelegateCommand(this._ActiveColorEditCancelExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.CastColorEditCancelCommand - ＜キャストカラー変更キャンセルコマンド＞ -----
        /// <summary> キャストカラー変更キャンセルコマンド＜コマンド＞ </summary>
        private DelegateCommand _CastColorEditCancelCommand;
        /// <summary> キャストカラー変更キャンセルコマンド＜コマンド＞ </summary>
        public DelegateCommand CastColorEditCancelCommand
        {
            get { return _CastColorEditCancelCommand = _CastColorEditCancelCommand ?? new DelegateCommand(this._CastColorEditCancelExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayViewLockCommand - ＜オーバーレイロック切替コマンド＞ -----
        /// <summary> オーバーレイロック切替コマンド＜コマンド＞ </summary>
        private DelegateCommand _OverlayViewLockCommand;
        /// <summary> オーバーレイロック切替コマンド＜コマンド＞ </summary>
        public DelegateCommand OverlayViewLockCommand
        {
            get { return _OverlayViewLockCommand = _OverlayViewLockCommand ?? new DelegateCommand(this._OverlayViewLockExecute); }
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
            this.OverlayManageModule = new OverlayManageModule();
            this.DialogManage = new DialogManageObjectModel();
            this.OverlayPreviewObjectModel = new OverlayPreviewObjectModel();
            return true;
        }

        /// <summary> コンポーネントのセットアップを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public bool ComponenSetupt()
        {
            this.OverlayControlModule.SetAllFilter(this.OverlayDataModel);
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
            WindowsServices.WindowCloseSendMessage(this.OverlayDataModel.OverlayWindowData.WindowIntPtr);
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

        #region #- [Method] CanExecute,Execute @ OverlayCustomOpenCommand - ＜オーバーレイカスタムオープンコマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイカスタムオープンコマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayCustomOpenExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイカスタムオープンコマンド＞ </summary>
        private void _OverlayCustomOpenExecute()
        {
            this.OverlayManageModule.ShowCustomWindow(base.CommonDataModel, this);
        }
        #endregion 

        #region #- [Method] Execute @ OverlayCustomClosedCommand - ＜オーバーレイカスタム終了コマンド＞ -----

        /// <summary> コマンド実行＜オーバーレイカスタム終了コマンド＞ </summary>
        private void _OverlayCustomClosedExecute()
        {
            this.OverlayDataModel.OverlayViewData.OverlayCustomClosed = true;
        }

        #endregion 

        #region #- [Method] Execute @ FontEditCommand - ＜フォント変更コマンド＞ -----

        /// <summary> コマンド実行＜フォント変更コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _FontEditExecute(FontEditTarget? para)
        {
            if (!para.HasValue)
                return;

            switch (para.Value)
            {
                case FontEditTarget.TitleBar:
                    this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo
                        = this.OverlayDataModel.FontData.TitleBar_BaseFontInfo;
                    break;

                case FontEditTarget.Header:
                    this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo
                        = this.OverlayDataModel.FontData.Header_BaseFontInfo;
                    break;

                case FontEditTarget.Content:
                    this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo
                        = this.OverlayDataModel.FontData.Content_BaseFontInfo;
                    break;

                case FontEditTarget.Active:
                    this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo
                        = this.OverlayDataModel.FontData.Content_ActiveFontInfo;
                    break;

                default:
                    return;
            }
            this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo.CreateBeforeFontInfo();
            this.OverlayDataModel.OverlayCustomTempData.BaseFontCustomVisibility = true;
        }
        #endregion
        #region #- [Method] Execute @ FontEditEndCommand - ＜フォント変更終了コマンド＞ -----

        /// <summary> コマンド実行＜フォント変更終了コマンド＞ </summary>
        private void _FontEditEndExecute()
        {
            this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo = null;
            this.OverlayDataModel.OverlayCustomTempData.BaseFontCustomVisibility = false;
            this.OverlayDataModel.FontData.SaveChangedTarget = true;
        }
        #endregion
        #region #- [Method] CanExecute,Execute @ FontEditCancelCommand - ＜フォント変更キャンセルコマンド＞ -----

        /// <summary> コマンド実行＜フォント変更キャンセルコマンド＞ </summary>
        private void _FontEditCancelExecute()
        {
            this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo.SetBeforeFontInfo();
            this.OverlayDataModel.OverlayCustomTempData.ChangeTargetFontInfo = null;
            this.OverlayDataModel.OverlayCustomTempData.BaseFontCustomVisibility = false;
            this.OverlayDataModel.FontData.SaveChangedTarget = true;
        }

        #endregion 


        #region #- [Method] Execute @ ColorEditCommand - ＜カラー変更コマンド＞ -----

        /// <summary> コマンド実行＜カラー変更コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _ColorEditExecute(ColorEditTarget? para)
        {
            if (!para.HasValue) return;

            this.OverlayDataModel.OverlayColorSettingsData.ColorEditTarget = para.Value;
            this.OverlayDataModel.OverlayColorSettingsData.SetBeforeColor();
            this.OverlayDataModel.OverlayCustomTempData.StringColorCustomVisibility = true;

        }
        #endregion 
        #region #- [Method] Execute @ EditCloseCommand - ＜変更終了コマンド＞ -----

        /// <summary> コマンド実行＜変更終了コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _EditCloseExecute(string para)
        {
            this.OverlayDataModel.OverlayCustomTempData.StringColorCustomVisibility = false;
            this.OverlayDataModel.OverlayColorSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }
        #endregion 
        #region #- [Method] Execute @ StringColorEditCancelCommand - ＜文字カラー変更キャンセルコマンド＞ -----

        /// <summary> コマンド実行＜文字カラー変更キャンセルコマンド＞ </summary>
        private void _StringColorEditCancelExecute()
        {
            this.OverlayDataModel.OverlayColorSettingsData.EditBindColor
                = this.OverlayDataModel.OverlayColorSettingsData.BeforeColor;
            this.OverlayDataModel.OverlayCustomTempData.StringColorCustomVisibility = false;
            this.OverlayDataModel.OverlayColorSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }

        #endregion 

        #region #- [Method] Execute @ ActiveColorEditCommand - ＜アクティブカラー変更コマンド＞ -----

        /// <summary> コマンド実行＜アクティブカラー変更コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _ActiveColorEditExecute(ColorEditTarget? para)
        {
            if (!para.HasValue) return;

            this.OverlayDataModel.ActiveBarSettingsData.ColorEditTarget = para.Value;
            this.OverlayDataModel.ActiveBarSettingsData.SetBeforeColor();
            this.OverlayDataModel.OverlayCustomTempData.ActiveColorCustomVisibility = true;
        }

        #endregion
        #region #- [Method] Execute @ CastColorEditCommand - ＜キャストカラー変更コマンド＞ -----

        /// <summary> コマンド実行＜キャストカラー変更コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _CastColorEditExecute(ColorEditTarget? para)
        {
            if (!para.HasValue) return;

            this.OverlayDataModel.CastBarSettingsData.ColorEditTarget = para.Value;
            this.OverlayDataModel.CastBarSettingsData.SetBeforeColor();
            this.OverlayDataModel.OverlayCustomTempData.CastColorCustomVisibility = true;
        }
        #endregion 
        #region #- [Method] Execute @ ActiveColorEditEndCommand - ＜アクティブカラー変更終了コマンド＞ -----

        /// <summary> コマンド実行＜アクティブカラー変更終了コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _ActiveColorEditEndExecute(ColorEditTarget? para)
        {
            this.OverlayDataModel.OverlayCustomTempData.ActiveColorCustomVisibility = false;
            this.OverlayDataModel.ActiveBarSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }
        #endregion 
        #region #- [Method] Execute @ CastColorEditEndCommand - ＜キャストカラー変更終了コマンド＞ -----

        /// <summary> コマンド実行＜キャストカラー変更終了コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _CastColorEditEndExecute(ColorEditTarget? para)
        {
            this.OverlayDataModel.OverlayCustomTempData.CastColorCustomVisibility = false;
            this.OverlayDataModel.CastBarSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }
        #endregion

        #region #- [Method] Execute @ ActiveColorEditCancelCommand - ＜アクティブカラー変更キャンセルコマンド＞ -----

        /// <summary> コマンド実行＜アクティブカラー変更キャンセルコマンド＞ </summary>
        private void _ActiveColorEditCancelExecute()
        {
            this.OverlayDataModel.ActiveBarSettingsData.EditBindColor
                = this.OverlayDataModel.ActiveBarSettingsData.BeforeColor;
            this.OverlayDataModel.OverlayCustomTempData.ActiveColorCustomVisibility = false;
            this.OverlayDataModel.ActiveBarSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }

        #endregion
        #region #- [Method] Execute @ CastColorEditCancelCommand - ＜キャストカラー変更キャンセルコマンド＞ -----

        /// <summary> コマンド実行＜キャストカラー変更キャンセルコマンド＞ </summary>
        private void _CastColorEditCancelExecute()
        {
            this.OverlayDataModel.CastBarSettingsData.EditBindColor
                = this.OverlayDataModel.CastBarSettingsData.BeforeColor;
            this.OverlayDataModel.OverlayCustomTempData.CastColorCustomVisibility = false;
            this.OverlayDataModel.CastBarSettingsData.ColorEditTarget = ColorEditTarget.Non;
        }

        #endregion 

        #region #- [Method] CanExecute,Execute @ OverlayViewLockCommand - ＜オーバーレイロック切替コマンド＞ -----

        /// <summary> コマンド実行＜オーバーレイロック切替コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayViewLockExecute()
        {
            if (this.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(this.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
            else
            {
                WindowsServices.InitWindowExTransparent(this.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }

        #endregion 
    }
}
