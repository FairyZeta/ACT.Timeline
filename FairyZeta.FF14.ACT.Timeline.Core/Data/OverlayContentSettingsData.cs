using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイコンテンツ設定データ
    /// </summary>
    public class OverlayContentSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] double.TimeNoWidth - ＜タイム番号の幅＞ -----
        /// <summary> タイム番号の幅 </summary>
        private double _TimeNoWidth;
        /// <summary> タイム番号の幅 </summary>
        public double TimeNoWidth
        {
            get { return this._TimeNoWidth; }
            set
            {
                if (this._TimeNoWidth == value) return;

                this._TimeNoWidth = value;
                base.OnPropertyChanged("TimeNoWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.ActionTimeWidth - ＜アクション時間の幅＞ -----
        /// <summary> アクション時間の幅 </summary>
        private double _ActionTimeWidth;
        /// <summary> アクション時間の幅 </summary>
        public double ActionTimeWidth
        {
            get { return this._ActionTimeWidth; }
            set
            {
                if (this._ActionTimeWidth == value) return;

                this._ActionTimeWidth = value;
                base.OnPropertyChanged("ActionTimeWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.TypeWidth - ＜タイプの幅＞ -----
        /// <summary> タイプの幅 </summary>
        private double _TypeWidth;
        /// <summary> タイプの幅 </summary>
        public double TypeWidth
        {
            get { return this._TypeWidth; }
            set
            {
                if (this._TypeWidth == value) return;

                this._TypeWidth = value;
                base.OnPropertyChanged("TypeWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.JobWidth - ＜ジョブの幅＞ -----
        /// <summary> ジョブの幅 </summary>
        private double _JobWidth;
        /// <summary> ジョブの幅 </summary>
        public double JobWidth
        {
            get { return this._JobWidth; }
            set
            {
                if (this._JobWidth == value) return;

                this._JobWidth = value;
                base.OnPropertyChanged("JobWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.TankModeWidth - ＜タンクモードの幅＞ -----
        /// <summary> タンクモードの幅 </summary>
        private double _TankModeWidth;
        /// <summary> タンクモードの幅 </summary>
        public double TankModeWidth
        {
            get { return this._TankModeWidth; }
            set
            {
                if (this._TankModeWidth == value) return;

                this._TankModeWidth = value;
                base.OnPropertyChanged("TankModeWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.ActionWidth - ＜アクションの幅＞ -----
        /// <summary> アクションの幅 </summary>
        private double _ActionWidth;
        /// <summary> アクションの幅 </summary>
        public double ActionWidth
        {
            get { return this._ActionWidth; }
            set
            {
                if (this._ActionWidth == value) return;

                this._ActionWidth = value;
                base.OnPropertyChanged("ActionWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.ActiveWidth - ＜アクティブの幅＞ -----
        /// <summary> アクティブの幅 </summary>
        private double _ActiveWidth;
        /// <summary> アクティブの幅 </summary>
        public double ActiveWidth
        {
            get { return this._ActiveWidth; }
            set
            {
                if (this._ActiveWidth == value) return;

                this._ActiveWidth = value;
                base.OnPropertyChanged("ActiveWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.AlertWidth - ＜アラートの幅＞ -----
        /// <summary> アラートの幅 </summary>
        private double _AlertWidth;
        /// <summary> アラートの幅 </summary>
        public double AlertWidth
        {
            get { return this._AlertWidth; }
            set
            {
                if (this._AlertWidth == value) return;

                this._AlertWidth = value;
                base.OnPropertyChanged("AlertWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.JumpWidth - ＜ジャンプの幅＞ -----
        /// <summary> ジャンプの幅 </summary>
        private double _JumpWidth;
        /// <summary> ジャンプの幅 </summary>
        public double JumpWidth
        {
            get { return this._JumpWidth; }
            set
            {
                if (this._JumpWidth == value) return;

                this._JumpWidth = value;
                base.OnPropertyChanged("JumpWidth");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイコンテンツ設定データ／コンストラクタ
        /// </summary>
        public OverlayContentSettingsData()
            : base()
        {
            this.initData();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.TimeNoWidth = 50;
            this.ActionTimeWidth = 50;
            this.TypeWidth = 70;
            this.JobWidth = 70;
            this.TankModeWidth = 50;
            this.ActionWidth = 150;
            this.ActiveWidth = 120;
            this.AlertWidth = 30;
            this.JumpWidth = 30;

            return true;
        }
    }
}
