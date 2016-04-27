using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイ／フォントデータ
    /// </summary>
    public class OverlayFontData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイトルバーフォント情報
        /// </summary>
        public FontInfo TitleBar_BaseFontInfo { get; set; }

        /// <summary> ヘッダーフォント情報
        /// </summary>
        public FontInfo Header_BaseFontInfo { get; set; }

        /// <summary> コンテンツフォント情報
        /// </summary>
        public FontInfo Content_BaseFontInfo { get; set; }

        /// <summary> コンテンツ／アクティブフォント情報
        /// </summary>
        public FontInfo Content_ActiveFontInfo { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイ／フォントデータ／コンストラクタ
        /// </summary>
        public OverlayFontData()
        {
            this.initData();
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.TitleBar_BaseFontInfo = new FontInfo();

            this.Header_BaseFontInfo = new FontInfo();

            this.Content_BaseFontInfo = new FontInfo();
            this.Content_ActiveFontInfo = new FontInfo();

            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デフォルトフォントセッティングを実行します。
        /// </summary>
        public void SetupDefaultFontSetting()
        {
            this.meiryoSetting(this.TitleBar_BaseFontInfo);
            this.meiryoSetting(this.Header_BaseFontInfo);
            this.meiryoSetting(this.Content_BaseFontInfo);
            this.tahomaSetting(this.Content_ActiveFontInfo);
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private void meiryoSetting(FontInfo pFontInfo)
        {
            pFontInfo.FamilyName = "Meiryo";
            pFontInfo.Size = 14.0;
            pFontInfo.StretchString = "Normal";
            pFontInfo.WeightString = "Normal";
            pFontInfo.StyleString = "Normal";
            
        }

        private void tahomaSetting(FontInfo pFontInfo)
        {
            pFontInfo.FamilyName = "Tahoma";
            pFontInfo.Size = 14.0;
            pFontInfo.StretchString = "Normal";
            pFontInfo.WeightString = "Normal";
            pFontInfo.StyleString = "Normal";

        }

    }
}
