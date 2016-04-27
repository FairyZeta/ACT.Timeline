using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;
using Prism.Mvvm;
using FairyZeta.Framework.Controls;

namespace FairyZeta.Framework.Data
{
    /// <summary> フォント情報
    /// </summary>
    [Serializable]
    public class FontInfo : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        [XmlIgnore]
        public FontFamily Family { get; set; }
        [XmlAttribute("FontFamily")]
        public string FamilyName
        {
            get
            {
                return
                    this.Family != null ?
                    this.Family.Source ?? string.Empty :
                    string.Empty;
            }
            set
            {
                this.Family = GetFontFamily(value);
                base.OnPropertyChanged("Family");
                base.OnPropertyChanged("FamilyName");
            }
        }

        #region #- [Property] double.Size - ＜フォントサイズ＞ -----
        /// <summary> フォントサイズ </summary>
        private double _Size;
        /// <summary> フォントサイズ </summary>  
        [XmlAttribute("Size")]
        public double Size
        {
            get { return _Size; }
            set { base.SetProperty(ref this._Size, value); }
        }
        #endregion

        [XmlIgnore]
        public FontWeight Weight { get; set; }
        [XmlAttribute("Weight")]
        public string WeightString
        {
            get
            {
                return weightConverter.ConvertToString(this.Weight);
            }
            set
            {
                this.Weight = (FontWeight)weightConverter.ConvertFromString(value);
                base.OnPropertyChanged("Weight");
            }
        }

        [XmlIgnore]
        public FontStyle Style { get; set; }
        [XmlAttribute("Style")]
        public string StyleString
        {
            get
            {
                return styleConverter.ConvertToString(this.Style);
            }
            set
            {
                this.Style = (FontStyle)styleConverter.ConvertFromString(value);
                base.OnPropertyChanged("Style");
            }
        }

        [XmlIgnore]
        public FontStretch Stretch { get; set; }
        [XmlAttribute("Stretch")]
        public string StretchString
        {
            get
            {
                return stretchConverter.ConvertToString(this.Stretch);
            }
            set
            {
                this.Stretch = (FontStretch)stretchConverter.ConvertFromString(value);
                base.OnPropertyChanged("Stretch");
            }
        }


        [XmlIgnore]
        private static FontStyleConverter styleConverter = new FontStyleConverter();
 
        [XmlIgnore]
        private static FontStretchConverter stretchConverter = new FontStretchConverter();

        [XmlIgnore]
        private static FontWeightConverter weightConverter = new FontWeightConverter();

        [XmlIgnore]
        private static Dictionary<string, FontFamily> fontFamilyDictionary = new Dictionary<string, FontFamily>();

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public FontInfo()
        {
            this.Family = GetFontFamily(string.Empty);
            this.Size = 0;
        }

        public FontInfo(string family, double size, string style, string weight, string stretch)
        {
            this.Family = GetFontFamily(family);
            this.Size = size;
            this.StyleString = style;
            this.WeightString = weight;
            this.StretchString = stretch;
        }

        public FontInfo(FontFamily family, double size, FontStyle style, FontWeight weight, FontStretch stretch)
        {
            this.Family = family;
            this.Size = size;
            this.Style = style;
            this.Weight = weight;
            this.Stretch = stretch;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        

        [XmlIgnore]
        public FamilyTypeface Typeface
        {
            get
            {
                var ftf = new FamilyTypeface();
                ftf.Stretch = this.Stretch;
                ftf.Weight = this.Weight;
                ftf.Style = this.Style;
                return ftf;
            }
        }

        public override string ToString()
        {
            var t = string.Empty;

            t += "{ ";
            t += "\"Family\":" + "\"" + this.FamilyName + "\"" + ", ";
            t += "\"Size\":" + this.Size + ", ";
            t += "\"Style\":" + "\"" + this.StyleString + "\"" + ", ";
            t += "\"Weight\":" + "\"" + this.WeightString + "\"" + ", ";
            t += "\"Streth\":" + "\"" + this.StretchString + "\"";
            t += " }";

            return t;
        }

        private static FontFamily GetFontFamily(string source)
        {
            if (!fontFamilyDictionary.ContainsKey(source))
            {
                fontFamilyDictionary[source] = new FontFamily(source);
            }

            return fontFamilyDictionary[source];
        }
    }
}
