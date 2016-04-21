using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／オーバーレイカスタムウィンドウビューモデル
    /// </summary>
    public class OverlayCustomWindowViewModel : _ViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] OverlayViewComponent.OverlayViewComponent - ＜オーバーレイ表示コンポーネント＞ -----
        /// <summary> オーバーレイ表示コンポーネント </summary>
        private OverlayViewComponent _OverlayViewComponent;
        /// <summary> オーバーレイ表示コンポーネント </summary>
        public OverlayViewComponent OverlayViewComponent
        {
            get { return this._OverlayViewComponent; }
            set
            {
                if (this._OverlayViewComponent == value) return;

                this._OverlayViewComponent = value;
                base.OnPropertyChanged("OverlayViewComponent");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイカスタムウィンドウビューモデル／コンストラクタ
        /// </summary>
        public OverlayCustomWindowViewModel()
            : base()
        {
            this.initViewModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] PredefinedColor[].PredefinedColors - ＜カラーリスト一覧＞ -----

        /// <summary> カラーリスト一覧 </summary>
        private PredefinedColor[] _PredefinedColors;
        /// <summary> カラーリスト一覧 </summary>    
        public PredefinedColor[] PredefinedColors
        {
            get { return this._PredefinedColors ?? (this._PredefinedColors = this.EnumlatePredefinedColors()); }
            set { this.SetProperty(ref this._PredefinedColors, value); }
        }
        #endregion

        private PredefinedColor[] EnumlatePredefinedColors()
        {
            var colors = typeof(Colors).GetProperties();

            var list = new List<PredefinedColor>();
            foreach (var color in colors)
            {
                try
                {
                    list.Add(new PredefinedColor()
                    {
                        Name = color.Name,
                        Color = (Color)ColorConverter.ConvertFromString(color.Name)
                    });
                }
                catch
                {
                }
            }

            return list.OrderBy(x => x.Color.ToString()).ToArray();
        }
    }

    public class PredefinedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
