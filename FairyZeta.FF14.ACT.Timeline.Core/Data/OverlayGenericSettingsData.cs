using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ一般設定データ
    /// </summary>
    public class OverlayGenericSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] double.TitleBarFontSize - ＜タイトルバーフォントサイズ＞ -----
        /// <summary> タイトルバーフォントサイズ </summary>
        private double _TitleBarFontSize;
        /// <summary> タイトルバーフォントサイズ </summary>
        public double TitleBarFontSize
        {
            get { return this._TitleBarFontSize; }
            set
            {
                if (this._TitleBarFontSize == value) return;

                this._TitleBarFontSize = value;
                base.OnPropertyChanged("TitleBarFontSize");
            }
        }
        #endregion
        #region #- [Property] double.HeaderFontSize - ＜ヘッダーフォントサイズ＞ -----
        /// <summary> ヘッダーフォントサイズ </summary>
        private double _HeaderFontSize;
        /// <summary> ヘッダーフォントサイズ </summary>
        public double HeaderFontSize
        {
            get { return this._HeaderFontSize; }
            set
            {
                if (this._HeaderFontSize == value) return;

                this._HeaderFontSize = value;
                base.OnPropertyChanged("HeaderFontSize");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.ContentFontSize - ＜コンテンツフォントサイズ＞ -----
        /// <summary> コンテンツフォントサイズ </summary>
        private double _ContentFontSize;
        /// <summary> コンテンツフォントサイズ </summary>
        public double ContentFontSize
        {
            get { return this._ContentFontSize; }
            set
            {
                if (this._ContentFontSize == value) return;

                this._ContentFontSize = value;
                base.OnPropertyChanged("ContentFontSize");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] int.ContentOpacity - ＜コンテンツの透過率＞ -----
        /// <summary> コンテンツの透過率 </summary>
        private int _ContentOpacity;
        /// <summary> コンテンツの透過率 </summary>
        public int ContentOpacity
        {
            get { return this._ContentOpacity; }
            set
            {
                if (this._ContentOpacity == value) return;

                this._ContentOpacity = value;
                base.OnPropertyChanged("ContentOpacity");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] int.BackgroundOpacity - ＜背景の透過率＞ -----
        /// <summary> 背景の透過率 </summary>
        private int _BackgroundOpacity;
        /// <summary> 背景の透過率 </summary>
        public int BackgroundOpacity
        {
            get { return this._BackgroundOpacity; }
            set
            {
                if (this._BackgroundOpacity == value) return;

                this._BackgroundOpacity = value;
                base.OnPropertyChanged("BackgroundOpacity");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] EffectType.BackgroundEffectType - ＜背景エフェクトタイプ＞ -----
        /// <summary> 背景エフェクトタイプ </summary>
        private EffectType _BackgroundEffectType;
        /// <summary> 背景エフェクトタイプ </summary>    
        public EffectType BackgroundEffectType
        {
            get { return _BackgroundEffectType; }
            set
            {
                this.SetProperty(ref this._BackgroundEffectType, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.BackgroundBlurRadius - ＜背景のぼかし強さ＞ -----
        /// <summary> 背景のぼかし強さ </summary>
        private double _BackgroundBlurRadius;
        /// <summary> 背景のぼかし強さ </summary>    
        public double BackgroundBlurRadius
        {
            get { return _BackgroundBlurRadius; }
            set
            {
                this.SetProperty(ref this._BackgroundBlurRadius, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] KernelType.BackgroundEffectKernelType - ＜背景のエフェクトカーネルタイプ＞ -----
        /// <summary> 背景のエフェクトカーネルタイプ </summary>
        private KernelType _BackgroundEffectKernelType;
        /// <summary> 背景のエフェクトカーネルタイプ </summary>    
        public KernelType BackgroundEffectKernelType
        {
            get { return _BackgroundEffectKernelType; }
            set
            {
                this.SetProperty(ref this._BackgroundEffectKernelType, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Thickness.BackgroundCornerRadius - ＜背景の丸さ＞ -----
        /// <summary> 背景の丸さ </summary>
        private CornerRadius _BackgroundCornerRadius;
        /// <summary> 背景の丸さ </summary>    
        public CornerRadius BackgroundCornerRadius
        {
            get { return _BackgroundCornerRadius; }
            set
            {
                this.SetProperty(ref this._BackgroundCornerRadius, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Thickness.BackgroundMargin - ＜背景の余白＞ -----
        /// <summary> 背景の余白 </summary>
        private Thickness _BackgroundMargin;
        /// <summary> 背景の余白 </summary>    
        public Thickness BackgroundMargin
        {
            get { return _BackgroundMargin; }
            set
            {
                this.SetProperty(ref this._BackgroundMargin, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.TitleBarVisibility - ＜タイトルバーの表示状態＞ -----
        /// <summary> タイトルバーの表示状態 </summary>
        private bool _TitleBarVisibility;
        /// <summary> タイトルバーの表示状態 </summary>
        public bool TitleBarVisibility
        {
            get { return this._TitleBarVisibility; }
            set
            {
                if (this._TitleBarVisibility == value) return;

                this._TitleBarVisibility = value;
                base.OnPropertyChanged("TitleBarVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.ContentHeaderVisibility - ＜コンテンツヘッダーの表示状態＞ -----
        /// <summary> コンテンツヘッダーの表示状態 </summary>
        private bool _ContentHeaderVisibility;
        /// <summary> コンテンツヘッダーの表示状態 </summary>
        public bool ContentHeaderVisibility
        {
            get { return this._ContentHeaderVisibility; }
            set
            {
                if (this._ContentHeaderVisibility == value) return;

                this._ContentHeaderVisibility = value;
                base.OnPropertyChanged("ContentHeaderVisibility");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.ContentScrollBarVisibility - ＜コンテンツスクロールバーの表示状態＞ -----
        /// <summary> コンテンツスクロールバーの表示状態 </summary>
        private bool _ContentScrollBarVisibility;
        /// <summary> コンテンツスクロールバーの表示状態 </summary>
        public bool ContentScrollBarVisibility
        {
            get { return this._ContentScrollBarVisibility; }
            set
            {
                if (this._ContentScrollBarVisibility == value) return;

                this._ContentScrollBarVisibility = value;
                base.OnPropertyChanged("ContentScrollBarVisibility");
            }
        }
        #endregion

        /// <summary> エフェクトタイプコレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<EffectType> EffectTypeCollection { get; private set; }

        /// <summary> カーネルタイプコレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<KernelType> KernelTypeCollection { get; private set; }

        #region -- Thickness 変更用 -----

        /// <summary> 背景余白 </summary> 
        [XmlIgnore]
        public double BackgroundMargin_Left
        {
            get { return this.BackgroundMargin.Left; }
            set
            {
                this.BackgroundMargin = new Thickness(value, BackgroundMargin.Top, BackgroundMargin.Right, BackgroundMargin.Bottom);
            }
        }
        /// <summary> 背景余白 </summary> 
        [XmlIgnore]
        public double BackgroundMargin_Top
        {
            get { return this.BackgroundMargin.Top; }
            set
            {
                this.BackgroundMargin = new Thickness(BackgroundMargin.Left, value, BackgroundMargin.Right, BackgroundMargin.Bottom);
            }
        }
        /// <summary> 背景余白 </summary> 
        [XmlIgnore]
        public double BackgroundMargin_Right
        {
            get { return this.BackgroundMargin.Right; }
            set
            {
                this.BackgroundMargin = new Thickness(BackgroundMargin.Left, BackgroundMargin.Top, value, BackgroundMargin.Bottom);
            }
        }
        /// <summary> 背景余白 </summary> 
        [XmlIgnore]
        public double BackgroundMargin_Bottom
        {
            get { return this.BackgroundMargin.Bottom; }
            set
            {
                this.BackgroundMargin = new Thickness(BackgroundMargin.Left, BackgroundMargin.Top, BackgroundMargin.Right, value);
            }
        }

        /// <summary> 背景の丸さ </summary> 
        [XmlIgnore]
        public double BackgroundCornerRadius_TopLeft
        {
            get { return this.BackgroundCornerRadius.TopLeft; }
            set
            {
                this.BackgroundCornerRadius = new CornerRadius(value, BackgroundCornerRadius.TopRight, BackgroundCornerRadius.BottomRight, BackgroundCornerRadius.BottomLeft);
            }
        }
        /// <summary> 背景の丸さ </summary> 
        [XmlIgnore]
        public double BackgroundCornerRadius_TopRight
        {
            get { return this.BackgroundCornerRadius.TopRight; }
            set
            {
                this.BackgroundCornerRadius = new CornerRadius(BackgroundCornerRadius.TopLeft, value, BackgroundCornerRadius.BottomRight, BackgroundCornerRadius.BottomLeft);
            }
        }
        /// <summary> 背景の丸さ </summary> 
        [XmlIgnore]
        public double BackgroundCornerRadius_BottomRight
        {
            get { return this.BackgroundCornerRadius.BottomRight; }
            set
            {
                this.BackgroundCornerRadius = new CornerRadius(BackgroundCornerRadius.TopLeft, BackgroundCornerRadius.TopRight, value, BackgroundCornerRadius.BottomLeft);
            }
        }
        /// <summary> 背景の丸さ </summary> 
        [XmlIgnore]
        public double BackgroundCornerRadius_BottomLeft
        {
            get { return this.BackgroundCornerRadius.BottomLeft; }
            set
            {
                this.BackgroundCornerRadius = new CornerRadius(BackgroundCornerRadius.TopLeft, BackgroundCornerRadius.TopRight, BackgroundCornerRadius.BottomRight, value);
            }
        }

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ一般設定データ／コンストラクタ
        /// </summary>
        public OverlayGenericSettingsData()
            : base()
        {
            this.initData();
            this.clear();

            this.SetupCollection();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.EffectTypeCollection = new ObservableCollection<EffectType>();
            this.KernelTypeCollection = new ObservableCollection<KernelType>();
     
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コレクションの内容をセットアップします。
        /// </summary>
        public void SetupCollection()
        {
            this.EffectTypeCollection.Clear();
            this.KernelTypeCollection.Clear();

            this.EffectTypeCollection.Add(EffectType.Blur);
            this.EffectTypeCollection.Add(EffectType.DropShadow);
            this.KernelTypeCollection.Add(KernelType.Box);
            this.KernelTypeCollection.Add(KernelType.Gaussian);
        }


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
            this.TitleBarFontSize = 14.0;
            this.HeaderFontSize = 14.0;
            this.ContentFontSize = 14.0;
            this.ContentOpacity = 0;
            this.BackgroundOpacity = 60;

            this.BackgroundEffectType = EffectType.Blur;
            this.BackgroundBlurRadius = 10;
            this.BackgroundEffectKernelType = KernelType.Box;
            this.BackgroundCornerRadius = new CornerRadius(10, 10, 10, 10);
            this.BackgroundMargin = new Thickness(10, 10, 10, 10);

            this.TitleBarVisibility = true;
            this.ContentHeaderVisibility = true;
            this.ContentScrollBarVisibility = true;

            return true;
        }

    }
}
