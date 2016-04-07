using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイフィルタ設定データ
    /// </summary>
    public class OverlayFilterSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      #region - [REGION] - Type Filter

        #region #- [Property] bool.TypeUNKNOWN - ＜Type:不明フィルタ＞ -----
        /// <summary> Type:不明フィルタ </summary>
        private bool _TypeUNKNOWN;
        /// <summary> Type:不明フィルタ </summary>
        public bool TypeUNKNOWN
        {
            get { return this._TypeUNKNOWN; }
            set
            {
                if (this._TypeUNKNOWN == value) return;
                
                this._TypeUNKNOWN = value;
                base.OnPropertyChanged("TypeUNKNOWN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeENEMY - ＜Type:敵フィルタ＞ -----
        /// <summary> Type:敵フィルタ </summary>
        private bool _TypeENEMY;
        /// <summary> Type:敵フィルタ </summary>
        public bool TypeENEMY
        {
            get { return this._TypeENEMY; }
            set
            {
                if (this._TypeENEMY == value) return;
                
                this._TypeENEMY = value;
                base.OnPropertyChanged("TypeENEMY");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeTANK - ＜Type:タンクフィルタ＞ -----
        /// <summary> Type:タンクフィルタ </summary>
        private bool _TypeTANK;
        /// <summary> Type:タンクフィルタ </summary>
        public bool TypeTANK
        {
            get { return this._TypeTANK; }
            set
            {
                if (this._TypeTANK == value) return;
                
                this._TypeTANK = value;
                base.OnPropertyChanged("TypeTANK");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeDPS - ＜Type:DPSフィルタ＞ -----
        /// <summary> Type:DPSフィルタ </summary>
        private bool _TypeDPS;
        /// <summary> Type:DPSフィルタ </summary>
        public bool TypeDPS
        {
            get { return this._TypeDPS; }
            set
            {
                if (this._TypeDPS == value) return;
                
                this._TypeDPS = value;
                base.OnPropertyChanged("TypeDPS");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeHEALER - ＜Type:ヒーラーフィルタ＞ -----
        /// <summary> Type:ヒーラーフィルタ </summary>
        private bool _TypeHEALER;
        /// <summary> Type:ヒーラーフィルタ </summary>
        public bool TypeHEALER
        {
            get { return this._TypeHEALER; }
            set
            {
                if (this._TypeHEALER == value) return;
                
                this._TypeHEALER = value;
                base.OnPropertyChanged("TypeHEALER");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypePET - ＜Type:ペットフィルタ＞ -----
        /// <summary> Type:ペットフィルタ </summary>
        private bool _TypePET;
        /// <summary> Type:ペットフィルタ </summary>
        public bool TypePET
        {
            get { return this._TypePET; }
            set
            {
                if (this._TypePET == value) return;
                
                this._TypePET = value;
                base.OnPropertyChanged("TypePET");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.TypeGIMMICK - ＜Type:ギミックフィルタ＞ -----
        /// <summary> Type:ギミックフィルタ </summary>
        private bool _TypeGIMMICK;
        /// <summary> Type:ギミックフィルタ </summary>
        public bool TypeGIMMICK
        {
            get { return this._TypeGIMMICK; }
            set
            {
                if (this._TypeGIMMICK == value) return;
                
                this._TypeGIMMICK = value;
                base.OnPropertyChanged("TypeGIMMICK");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        
      #endregion

      #region - [REGION] - Job Filter

        #region #- [Property] bool.JobUNKNOWN - ＜Job:不明フィルタ＞ -----
        /// <summary> Job:不明フィルタ </summary>
        private bool _JobUNKNOWN;
        /// <summary> Job:不明フィルタ </summary>
        public bool JobUNKNOWN
        {
            get { return this._JobUNKNOWN; }
            set
            {
                if (this._JobUNKNOWN == value) return;

                this._JobUNKNOWN = value;
                base.OnPropertyChanged("JobUNKNOWN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobNON - ＜Job:無しフィルタ＞ -----
        /// <summary> Job:無しフィルタ </summary>
        private bool _JobNON;
        /// <summary> Job:無しフィルタ </summary>
        public bool JobNON
        {
            get { return this._JobNON; }
            set
            {
                if (this._JobNON == value) return;
                
                this._JobNON = value;
                base.OnPropertyChanged("JobNON");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobPLD - ＜Job:ナイトフィルタ＞ -----
        /// <summary> Job:ナイトフィルタ </summary>
        private bool _JobPLD;
        /// <summary> Job:ナイトフィルタ </summary>
        public bool JobPLD
        {
            get { return this._JobPLD; }
            set
            {
                if (this._JobPLD == value) return;
                
                this._JobPLD = value;
                base.OnPropertyChanged("JobPLD");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobMNK - ＜Job:モンクフィルタ＞ -----
        /// <summary> Job:モンクフィルタ </summary>
        private bool _JobMNK;
        /// <summary> Job:モンクフィルタ </summary>
        public bool JobMNK
        {
            get { return this._JobMNK; }
            set
            {
                if (this._JobMNK == value) return;
                
                this._JobMNK = value;
                base.OnPropertyChanged("JobMNK");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobWAR - ＜Job:戦士フィルタ＞ -----
        /// <summary> Job:戦士フィルタ </summary>
        private bool _JobWAR;
        /// <summary> Job:戦士フィルタ </summary>
        public bool JobWAR
        {
            get { return this._JobWAR; }
            set
            {
                if (this._JobWAR == value) return;
                
                this._JobWAR = value;
                base.OnPropertyChanged("JobWAR");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobDRG - ＜Job:竜騎士フィルタ＞ -----
        /// <summary> Job:竜騎士フィルタ </summary>
        private bool _JobDRG;
        /// <summary> Job:竜騎士フィルタ </summary>
        public bool JobDRG
        {
            get { return this._JobDRG; }
            set
            {
                if (this._JobDRG == value) return;
                
                this._JobDRG = value;
                base.OnPropertyChanged("JobDRG");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobBRD - ＜Job:吟遊詩人フィルタ＞ -----
        /// <summary> Job:吟遊詩人フィルタ </summary>
        private bool _JobBRD;
        /// <summary> Job:吟遊詩人フィルタ </summary>
        public bool JobBRD
        {
            get { return this._JobBRD; }
            set
            {
                if (this._JobBRD == value) return;
                
                this._JobBRD = value;
                base.OnPropertyChanged("JobBRD");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobNIN - ＜Job:忍者フィルタ＞ -----
        /// <summary> Job:忍者フィルタ </summary>
        private bool _JobNIN;
        /// <summary> Job:忍者フィルタ </summary>
        public bool JobNIN
        {
            get { return this._JobNIN; }
            set
            {
                if (this._JobNIN == value) return;
                
                this._JobNIN = value;
                base.OnPropertyChanged("JobNIN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobWHM - ＜Job:白魔導士フィルタ＞ -----
        /// <summary> Job:白魔導士フィルタ </summary>
        private bool _JobWHM;
        /// <summary> Job:白魔導士フィルタ </summary>
        public bool JobWHM
        {
            get { return this._JobWHM; }
            set
            {
                if (this._JobWHM == value) return;
                
                this._JobWHM = value;
                base.OnPropertyChanged("JobWHM");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobBLM - ＜Job:黒魔導士フィルタ＞ -----
        /// <summary> Job:黒魔導士フィルタ </summary>
        private bool _JobBLM;
        /// <summary> Job:黒魔導士フィルタ </summary>
        public bool JobBLM
        {
            get { return this._JobBLM; }
            set
            {
                if (this._JobBLM == value) return;
                
                this._JobBLM = value;
                base.OnPropertyChanged("JobBLM");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobSMN - ＜Job:召喚士フィルタ＞ -----
        /// <summary> Job:召喚士フィルタ </summary>
        private bool _JobSMN;
        /// <summary> Job:召喚士フィルタ </summary>
        public bool JobSMN
        {
            get { return this._JobSMN; }
            set
            {
                if (this._JobSMN == value) return;
                
                this._JobSMN = value;
                base.OnPropertyChanged("JobSMN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobSCH - ＜Job:学者フィルタ＞ -----
        /// <summary> Job:学者フィルタ </summary>
        private bool _JobSCH;
        /// <summary> Job:学者フィルタ </summary>
        public bool JobSCH
        {
            get { return this._JobSCH; }
            set
            {
                if (this._JobSCH == value) return;
                
                this._JobSCH = value;
                base.OnPropertyChanged("JobSCH");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobDKN - ＜Job:暗黒騎士フィルタ＞ -----
        /// <summary> Job:暗黒騎士フィルタ </summary>
        private bool _JobDKN;
        /// <summary> Job:暗黒騎士フィルタ </summary>
        public bool JobDKN
        {
            get { return this._JobDKN; }
            set
            {
                if (this._JobDKN == value) return;
                
                this._JobDKN = value;
                base.OnPropertyChanged("JobDKN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobAST - ＜Job:占星術士フィルタ＞ -----
        /// <summary> Job:占星術士フィルタ </summary>
        private bool _JobAST;
        /// <summary> Job:占星術士フィルタ </summary>
        public bool JobAST
        {
            get { return this._JobAST; }
            set
            {
                if (this._JobAST == value) return;
                
                this._JobAST = value;
                base.OnPropertyChanged("JobAST");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobMCN - ＜Job:機工士フィルタ＞ -----
        /// <summary> Job:機工士フィルタ </summary>
        private bool _JobMCN;
        /// <summary> Job:機工士フィルタ </summary>
        public bool JobMCN
        {
            get { return this._JobMCN; }
            set
            {
                if (this._JobMCN == value) return;
                
                this._JobMCN = value;
                base.OnPropertyChanged("JobMCN");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobEGI - ＜Job:エギフィルタ＞ -----
        /// <summary> Job:エギフィルタ </summary>
        private bool _JobEGI;
        /// <summary> Job:エギフィルタ </summary>
        public bool JobEGI
        {
            get { return this._JobEGI; }
            set
            {
                if (this._JobEGI == value) return;
                
                this._JobEGI = value;
                base.OnPropertyChanged("JobEGI");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobFAIRY - ＜Job:フェアリーフィルタ＞ -----
        /// <summary> Job:フェアリーフィルタ </summary>
        private bool _JobFAIRY;
        /// <summary> Job:フェアリーフィルタ </summary>
        public bool JobFAIRY
        {
            get { return this._JobFAIRY; }
            set
            {
                if (this._JobFAIRY == value) return;
                
                this._JobFAIRY = value;
                base.OnPropertyChanged("JobFAIRY");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.JobTURRET - ＜Job:タレットフィルタ＞ -----
        /// <summary> Job:タレットフィルタ </summary>
        private bool _JobTURRET;
        /// <summary> Job:タレットフィルタ </summary>
        public bool JobTURRET
        {
            get { return this._JobTURRET; }
            set
            {
                if (this._JobTURRET == value) return;
                
                this._JobTURRET = value;
                base.OnPropertyChanged("JobTURRET");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        
      #endregion

      #region - [REGION] - TankMode Filter

        #region #- [Property] bool.TankModeNON - ＜TankMode:指定無しフィルタ＞ -----
        /// <summary> TankMode:指定無しフィルタ </summary>
        private bool _TankModeNON;
        /// <summary> TankMode:指定無しフィルタ </summary>
        public bool TankModeNON
        {
            get { return this._TankModeNON; }
            set
            {
                if (this._TankModeNON == value) return;

                this._TankModeNON = value;
                base.OnPropertyChanged("TankModeNON");
            }
        }
        #endregion
        #region #- [Property] bool.TankModeMT - ＜TankMode:メイン＞ -----
        /// <summary> TankMode:メイン </summary>
        private bool _TankModeMT;
        /// <summary> TankMode:メイン </summary>
        public bool TankModeMT
        {
            get { return this._TankModeMT; }
            set
            {
                if (this._TankModeMT == value) return;

                this._TankModeMT = value;
                base.OnPropertyChanged("TankModeMT");
            }
        }
        #endregion
        #region #- [Property] bool.TankModeST - ＜TankMode:サブ＞ -----
        /// <summary> TankMode:サブ(オフ) </summary>
        private bool _TankModeST;
        /// <summary> TankMode:サブ(オフ) </summary>
        public bool TankModeST
        {
            get { return this._TankModeST; }
            set
            {
                if (this._TankModeST == value) return;

                this._TankModeST = value;
                base.OnPropertyChanged("TankModeST");
            }
        }
        #endregion
        #region #- [Property] bool.TankModeOT - ＜TankMode:オフ＞ -----
        /// <summary> TankMode:オフ </summary>
        private bool _TankModeOT;
        /// <summary> TankMode:オフ </summary>
        public bool TankModeOT
        {
            get { return this._TankModeOT; }
            set
            {
                if (this._TankModeOT == value) return;

                this._TankModeOT = value;
                base.OnPropertyChanged("TankModeOT");
            }
        }
        #endregion

      #endregion

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイフィルタ設定データ
        /// </summary>
        public OverlayFilterSettingsData()
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
            this.TypeUNKNOWN = true;
            this.TypeENEMY   = true;
            this.TypeTANK    = true;
            this.TypeDPS     = true;
            this.TypeHEALER  = true;
            this.TypePET     = true;
            this.TypeGIMMICK = true;

            this.JobUNKNOWN  = true;
            this.JobNON      = true;
            this.JobPLD      = true;
            this.JobMNK      = true;
            this.JobWAR      = true;
            this.JobDRG      = true;
            this.JobBRD      = true;
            this.JobNIN      = true;
            this.JobWHM      = true;
            this.JobBLM      = true;
            this.JobSMN      = true;
            this.JobSCH      = true;
            this.JobDKN      = true;
            this.JobAST      = true;
            this.JobMCN      = true;
            this.JobEGI      = true;
            this.JobFAIRY    = true;
            this.JobTURRET   = true;

            this.TankModeNON = true;
            this.TankModeMT  = true;
            this.TankModeST  = true;
            this.TankModeOT  = true;

            return true;
        }
    }
}
