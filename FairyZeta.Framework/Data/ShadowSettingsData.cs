using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Media;
using System.Xml.Serialization;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／シャドウ設定データ
    /// </summary>
    public class ShadowSettingsData : BrushData, IShadowSettingsData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] int.BaseSchemeNo - ＜ベースカラーの配色リスト番号＞ -----
        /// <summary> ベースカラーの配色リスト番号 </summary>
        private int _BaseSchemeNo;
        /// <summary> ベースカラーの配色リスト番号 </summary>    
        public int BaseSchemeNo
        {
            get { return _BaseSchemeNo; }
            set
            {
                this.SetProperty(ref this._BaseSchemeNo, value);
                base.OnPropertyChanged("BaseColor");
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        /// <summary> ベースカラー
        /// </summary>
        [XmlIgnore]
        public Color BaseColor
        {
            get
            {
                return base.GetColorCollection(this.BaseSchemeNo);
            }
            set
            {
                if (base.SetColorCollection(value, this.BaseSchemeNo))
                {
                    base.OnPropertyChanged("BaseColor");
                    base.OnPropertyChanged("BaseBrush");
                    this.PropertyChangedFLG = true;
                }
            }
        }

        /// <summary> ベースブラシタイプ
        /// </summary>
        public BrushType BaseBrushType { get; set; }

        /// <summary> ベースブラシ 
        /// </summary>    
        public Brush BaseBrush
        {
            get { return base.GetBrush(this.BaseBrushType, new int[] { this.BaseSchemeNo }); }
        }

        #region #- [Property] int.ShadowSchemeNo - ＜シャドウカラーの配色リスト番号＞ -----
        /// <summary> シャドウカラーの配色リスト番号 </summary>
        private int _ShadowSchemeNo;
        /// <summary> シャドウカラーの配色リスト番号 </summary>    
        public int ShadowSchemeNo
        {
            get { return _ShadowSchemeNo; }
            set
            {
                this.SetProperty(ref this._ShadowSchemeNo, value);
                base.OnPropertyChanged("ShadowColor");
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        /// <summary> シャドウカラー
        /// </summary>
        [XmlIgnore]
        public Color ShadowColor
        {
            get
            {
                return base.GetColorCollection(this.ShadowSchemeNo);
            }
            set
            {
                if (base.SetColorCollection(value, this.ShadowSchemeNo))
                {
                    base.OnPropertyChanged("ShadowColor");
                    base.OnPropertyChanged("ShadowOpacity");
                    this.PropertyChangedFLG = true;
                }
            }
        }

        #region #- [Property] bool.ShadowEnabled - ＜シャドウの有効状態＞ -----
        /// <summary> シャドウの有効状態 </summary>
        private bool _ShadowEnabled;
        /// <summary> シャドウの有効状態 </summary>    
        public bool ShadowEnabled
        {
            get { return _ShadowEnabled; }
            set
            {
                this.SetProperty(ref this._ShadowEnabled, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        #region #- [Property] double.ShadowLevel - ＜シャドウの強さ＞ -----
        /// <summary> シャドウの強さ </summary>
        private double _ShadowLevel;
        /// <summary> シャドウの強さ </summary>    
        public double ShadowLevel
        {
            get { return _ShadowLevel; }
            set
            {
                this.SetProperty(ref this._ShadowLevel, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        #region #- [Property] double.ShadowDepth - ＜シャドウの深さ＞ -----
        /// <summary> シャドウの深さ </summary>
        private double _ShadowDepth;
        /// <summary> シャドウの深さ </summary>    
        public double ShadowDepth
        {
            get { return _ShadowDepth; }
            set
            {
                this.SetProperty(ref this._ShadowDepth, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        #region #- [Property] double.ShadowDirection - ＜シャドウの方向＞ -----
        /// <summary> シャドウの強さ </summary>
        private double _ShadowDirection;
        /// <summary> シャドウの強さ </summary>    
        public double ShadowDirection
        {
            get { return _ShadowDirection; }
            set
            {
                this.SetProperty(ref this._ShadowDirection, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion

        /// <summary> シャドウの透過率 
        /// </summary>    
        public double ShadowOpacity
        {
            get 
            { 
                return Convert.ToDouble(this.ShadowColor.ScA); 
            }
        }

        #region #- [Property] bool.PropertyChangedFLG - ＜プロパティ変更フラグ＞ -----
        /// <summary> プロパティ変更フラグ </summary>
        private bool _PropertyChangedFLG;
        /// <summary> プロパティ変更フラグ </summary>    
        public bool PropertyChangedFLG
        {
            get { return _PropertyChangedFLG; }
            set { this.SetProperty(ref this._PropertyChangedFLG, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／シャドウ設定データ／コンストラクタ
        /// </summary>
        public ShadowSettingsData(Color pBaseColor, Color pShadowColor)
            :this()
        {
            this.SetDefaultColor(pBaseColor, pShadowColor);
        }

        /// <summary> FZ／シャドウ設定データ／コンストラクタ
        /// </summary>
        public ShadowSettingsData()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.BaseSchemeNo = 0;
            this.ShadowSchemeNo = 1;

            this.ShadowEnabled = false;
            this.ShadowLevel = 3d;
            this.ShadowDirection = 315d;
            this.ShadowDepth = 0d;

            this.PropertyChangedFLG = false;
            
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デフォルトカラー設定を実行します。
        /// </summary>
        /// <param name="pBaseColor"> デフォルト・ベースカラー </param>
        /// <param name="pShadowColor"> デフォルト・シャドウカラー </param>
        public void SetDefaultColor(Color pBaseColor, Color pShadowColor)
        {
            base.ColorCollection.Clear();
            this.BaseSchemeNo = base.AddColorCollection(pBaseColor);
            this.ShadowSchemeNo = base.AddColorCollection(pShadowColor);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
