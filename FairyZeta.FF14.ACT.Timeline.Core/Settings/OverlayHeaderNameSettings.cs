using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FairyZeta.FF14.ACT.Timeline.Core.Settings
{
    /// <summary> オーバーレイ／ヘッダー名設定
    /// </summary>
    public class OverlayHeaderNameSettings : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.TimeNo - ＜項目：番号＞ -----
        /// <summary> 項目：番号 </summary>
        private string _TimeNo;
        /// <summary> 項目：番号 </summary>    
        public string TimeNo
        {
            get { return _TimeNo; }
            set
            {
                this.SetProperty(ref this._TimeNo, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.ActionTime - ＜項目：アクション時間＞ -----
        /// <summary> 項目：アクション時間 </summary>
        private string _ActionTime;
        /// <summary> 項目：アクション時間 </summary>    
        public string ActionTime
        {
            get { return _ActionTime; }
            set
            {
                this.SetProperty(ref this._ActionTime, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Alert - ＜項目：アラート＞ -----
        /// <summary> 項目：アラート </summary>
        private string _Alert;
        /// <summary> 項目：アラート </summary>    
        public string Alert
        {
            get { return _Alert; }
            set
            {
                this.SetProperty(ref this._Alert, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Action - ＜項目：アクション＞ -----
        /// <summary> 項目：アクション </summary>
        private string _Action;
        /// <summary> 項目：アクション </summary>    
        public string Action
        {
            get { return _Action; }
            set
            {
                this.SetProperty(ref this._Action, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Active - ＜項目：アクティブ＞ -----
        /// <summary> 項目：アクティブ </summary>
        private string _Active;
        /// <summary> 項目：アクティブ </summary>    
        public string Active
        {
            get { return _Active; }
            set
            {
                this.SetProperty(ref this._Active, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Type - ＜項目：タイプ＞ -----
        /// <summary> 項目：タイプ </summary>
        private string _Type;
        /// <summary> 項目：タイプ </summary>    
        public string Type
        {
            get { return _Type; }
            set
            {
                this.SetProperty(ref this._Type, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Job - ＜項目：ジョブ＞ -----
        /// <summary> 項目：ジョブ </summary>
        private string _Job;
        /// <summary> 項目：ジョブ </summary>    
        public string Job
        {
            get { return _Job; }
            set
            {
                this.SetProperty(ref this._Job, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.Anc - ＜項目：アンカー＞ -----
        /// <summary> 項目：アンカー </summary>
        private string _Anc;
        /// <summary> 項目：アンカー </summary>    
        public string Anc
        {
            get { return _Anc; }
            set
            {
                this.SetProperty(ref this._Anc, value);
                this.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.SaveChangedTarget - ＜保存対象であるか＞ -----
        /// <summary> 保存対象であるか </summary>
        private bool _SaveChangedTarget;
        /// <summary> 保存対象であるか </summary>    
        public bool SaveChangedTarget
        {
            get { return _SaveChangedTarget; }
            set { this.SetProperty(ref this._SaveChangedTarget, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> オーバーレイ／ヘッダー名設定／コンストラクタ
        /// </summary>
        public OverlayHeaderNameSettings()
        {
            this.initSettings();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> 設定の初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initSettings()
        {
            this.TimeNo = "T-No";
            this.ActionTime = "Time";
            this.Alert = "Alt";
            this.Action = "Action";
            this.Active = "Active";
            this.Type = "Type";
            this.Job = "Job";
            this.Anc = "Anc";

            this.SaveChangedTarget = false;

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
