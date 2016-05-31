using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／アウトラインテキストデータ
    /// </summary>
    public class OutlineTextData : BrushData, IShadowSettingsData, IOutlineColorSettingsData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Property] int.InnerTextSchemeNo - ＜内部カラーの配色リスト番号＞ -----
        /// <summary> 内部カラーの配色リスト番号 </summary>
        private int _InnerTextSchemeNo;
        /// <summary> 内部カラーの配色リスト番号 </summary>    
        public int InnerTextSchemeNo
        {
            get { return _InnerTextSchemeNo; }
            set
            {
                this.SetProperty(ref this._InnerTextSchemeNo, value);
                base.OnPropertyChanged("InnerTextColor");
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        /// <summary> 内部カラー
        /// </summary>
        [XmlIgnore]
        public Color InnerTextColor 
        {
            get 
            {
                return base.GetColorCollection(this.InnerTextSchemeNo);
            }
            set 
            {
                if(base.SetColorCollection(value, this.InnerTextSchemeNo))
                {
                    base.OnPropertyChanged("InnerTextColor");
                    this.PropertyChangedFLG = true;
                }
            }
        }

        #region #- [Property] int.OutlineTextSchemeNo - ＜縁取りカラーの配色リスト番号＞ -----
        /// <summary> 縁取りカラーの配色リスト番号 </summary>
        private int _OutlineTextSchemeNo;
        /// <summary> 縁取りカラーの配色リスト番号 </summary>    
        public int OutlineTextSchemeNo
        {
            get { return _OutlineTextSchemeNo; }
            set
            {
                this.SetProperty(ref this._OutlineTextSchemeNo, value);
                base.OnPropertyChanged("OutlineTextColor");
                this.PropertyChangedFLG = true;
            }
        }
        #endregion
        /// <summary> 縁取りカラー
        /// </summary>
        [XmlIgnore]
        public Color OutlineTextColor
        {
            get 
            {
                return base.GetColorCollection(this.OutlineTextSchemeNo);
            }
            set
            {
                if(base.SetColorCollection(value, this.OutlineTextSchemeNo))
                {
                    base.OnPropertyChanged("OutlineTextColor");
                    this.PropertyChangedFLG = true;
                }
            }
        }

        #region #- [Property] double.OutlineThickness - ＜縁取りの太さ＞ -----
        /// <summary> 縁取りの太さ </summary>
        private double _OutlineThickness;
        /// <summary> 縁取りの太さ </summary>    
        public double OutlineThickness
        {
            get { return _OutlineThickness; }
            set
            {
                this.SetProperty(ref this._OutlineThickness, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion

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

        /// <summary> [get] シャドウの透過率 
        /// </summary>    
        public double ShadowOpacity
        {
            get 
            { 
                return Convert.ToDouble(this.ShadowColor.ScA); 
            }
        }

        #region #- [Property] bool.DrawingReverseMode - ＜描画逆順モード＞ -----
        /// <summary> 描画逆順モード </summary>
        private bool _DrawingReverseMode;
        /// <summary> 描画逆順モード 
        /// <para> True: アウトライン=>テキスト の順番で描画する </para>
        /// <para> False: テキスト=>アウトライン の順番で描画する(デフォルト) </para>
        /// </summary> 
        public bool DrawingReverseMode
        {
            get { return _DrawingReverseMode; }
            set
            {
                this.SetProperty(ref this._DrawingReverseMode, value);
                this.PropertyChangedFLG = true;
            }
        }
        #endregion

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

        /// <summary> FZ／アウトラインテキストデータ／コンストラクタ
        /// </summary>
        public OutlineTextData(Color pInnerColor, Color pOutlineColor, Color pShadowColor)
            : this()
        {
            this.SetDefaultColor(pInnerColor, pOutlineColor, pShadowColor);
        }

        /// <summary> FZ／アウトラインテキストデータ／コンストラクタ
        /// </summary>
        public OutlineTextData()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.InnerTextSchemeNo = 0;
            this.OutlineTextSchemeNo = 1;
            this.ShadowSchemeNo = 2;

            this.OutlineThickness = 0d;

            this.ShadowEnabled = false;
            this.ShadowLevel = 3d;
            this.ShadowDirection = 315d;
            this.ShadowDepth = 0d;

            this.DrawingReverseMode = false;

            this.PropertyChangedFLG = false;
            
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void SetDefaultColor(Color pInnerColor, Color pOutlineColor, Color pShadowColor)
        {
            base.ColorCollection.Clear();
            this.InnerTextSchemeNo = base.AddColorCollection(pInnerColor);
            this.OutlineTextSchemeNo = base.AddColorCollection(pOutlineColor);
            this.ShadowSchemeNo = base.AddColorCollection(pShadowColor);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
