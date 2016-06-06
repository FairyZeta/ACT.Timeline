namespace FairyZeta.Framework
{
    /// <summary> ファイルの保存タイプを指定します。
    /// </summary>
    public enum SaveType
    {
        /// <summary> 新しいファイルとして保存します。既にファイルが存在した場合は、異常として返します。 </summary>
        NewFile,
        /// <summary> 上書きとしてファイルを保存します。 </summary>
        OverRide
    }

    /// <summary> グラデーションタイプ定義
    /// </summary>
    public enum GradientType
    {
        /// <summary> 線状グラデーション </summary>
        Linear,
        /// <summary> 放射状グラデーション </summary>
        Radial
    }
}
