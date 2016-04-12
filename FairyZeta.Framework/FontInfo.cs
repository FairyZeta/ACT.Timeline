using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

using FairyZeta.Framework.Controls;

namespace FairyZeta.Framework
{
    [Serializable]
    public class FontInfo
    {
        [XmlIgnore]
        private static FontStyleConverter styleConverter = new FontStyleConverter();

        [XmlIgnore]
        private static FontStretchConverter stretchConverter = new FontStretchConverter();

        [XmlIgnore]
        private static FontWeightConverter weightConverter = new FontWeightConverter();

        [XmlIgnore]
        private static Dictionary<string, FontFamily> fontFamilyDictionary = new Dictionary<string, FontFamily>();

        public FontInfo()
        {
            this.Family = GetFontFamily(string.Empty);
            this.Size = 11.25;
        }

        public FontInfo(
            string family,
            double size,
            string style,
            string weight,
            string stretch)
        {
            this.Family = GetFontFamily(family);
            this.Size = size;
            this.StyleString = style;
            this.WeightString = weight;
            this.StretchString = stretch;
        }

        public FontInfo(
            FontFamily family,
            double size,
            FontStyle style,
            FontWeight weight,
            FontStretch stretch)
        {
            this.Family = family;
            this.Size = size;
            this.Style = style;
            this.Weight = weight;
            this.Stretch = stretch;
        }

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
            }
        }

        [XmlAttribute("Size")]
        public double Size { get; set; }

        [XmlIgnore]
        public FontStyle Style { get; set; }

        [XmlIgnore]
        public FontStretch Stretch { get; set; }

        [XmlIgnore]
        public FontWeight Weight { get; set; }

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
            }
        }

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
            }
        }

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
            }
        }

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

        private static FontFamily GetFontFamily(
            string source)
        {
            if (!fontFamilyDictionary.ContainsKey(source))
            {
                fontFamilyDictionary[source] = new FontFamily(source);
            }

            return fontFamilyDictionary[source];
        }
    }

    public static class ControlExtension
    {
        public static void SetFontInfo(
            this Control control,
            FontInfo fontInfo)
        {
            if (control.GetFontInfo().ToString() != fontInfo.ToString())
            {
                control.FontFamily = fontInfo.Family;
                control.FontSize = fontInfo.Size;
                control.FontStyle = fontInfo.Style;
                control.FontWeight = fontInfo.Weight;
                control.FontStretch = fontInfo.Stretch;
            }
        }

        public static void SetFontInfo(
            this OutlineTextBlock control,
            FontInfo fontInfo)
        {
            if (control.GetFontInfo().ToString() != fontInfo.ToString())
            {
                control.FontFamily = fontInfo.Family;
                control.FontSize = fontInfo.Size;
                control.FontStyle = fontInfo.Style;
                control.FontWeight = fontInfo.Weight;
                control.FontStretch = fontInfo.Stretch;
            }
        }

        public static void SetFontInfo(
            this TextBlock control,
            FontInfo fontInfo)
        {
            if (control.GetFontInfo().ToString() != fontInfo.ToString())
            {
                control.FontFamily = fontInfo.Family;
                control.FontSize = fontInfo.Size;
                control.FontStyle = fontInfo.Style;
                control.FontWeight = fontInfo.Weight;
                control.FontStretch = fontInfo.Stretch;
            }
        }

        public static FontInfo GetFontInfo(
            this Control control)
        {
            return new FontInfo(
                control.FontFamily,
                control.FontSize,
                control.FontStyle,
                control.FontWeight,
                control.FontStretch);
        }

        public static FontInfo GetFontInfo(
            this OutlineTextBlock control)
        {
            return new FontInfo(
                control.FontFamily,
                control.FontSize,
                control.FontStyle,
                control.FontWeight,
                control.FontStretch);
        }

        public static FontInfo GetFontInfo(
            this TextBlock control)
        {
            return new FontInfo(
                control.FontFamily,
                control.FontSize,
                control.FontStyle,
                control.FontWeight,
                control.FontStretch);
        }
    }
}
