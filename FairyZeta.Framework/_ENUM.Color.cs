namespace FairyZeta.Framework
{
    /// <summary> パレットタイプ
    /// </summary>
    public enum PaletteType
    {
        NonType,
        Real,
        Complementary,
        Analogous,
        Shades,
        SplitComplementary,
        Monochromatic,
        Triad,
        Tetrad,
    }

    /// <summary> ブラシタイプ
    /// </summary>
    public enum BrushType
    {
        NonType,
        /// <summary> カラーブラシ </summary>
        SolidColorBrush,
        /// <summary> イメージブラシ </summary>
        ImageBrush
    }

    public enum AseBlockType
    {
        Color = 0x0001,

        GroupStart = 0xc001,

        GroupEnd = 0xc002
    }

    public enum AseColorType
    {
        Global,

        Spot,

        Normal
    }
}
