namespace FairyZeta.FF14.ACT
{
    /// <summary> ダウンロードステータス
    /// </summary>
    public enum DownloadStatus
    {
        /// <summary> 未開始 </summary>
        NonStarted,
        /// <summary> ダウンロード中 </summary>
        NowDownloading,
        /// <summary> 成功 </summary>
        Success,
        /// <summary> 失敗 </summary>
        Failure
    }

    /// <summary> アップデートダイアログ応答結果
    /// </summary>
    public enum UpdateDialogResult
    {
        /// <summary> 不明 </summary>
        Unknown,
        /// <summary>  </summary>
        ZipDownload,
        /// <summary> Webサイトオープン </summary>
        WebOpen,

        DirectoryOpen,

        Close
        
    }

    public enum TimerOperation
    {
        Start,
        Stop,
        Pause,
        ReStart,
        ReBoot
    }
}
