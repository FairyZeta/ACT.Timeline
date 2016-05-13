namespace FairyZeta.FF14.ACT.Timeline.Core
{
    /// <summary> ENUM: アプリケーションモード
    /// </summary>
    public enum AppMode
    {
        /// <summary> 初期セットアップ未済 </summary>
        NotInitSetup,
        /// <summary> 通常モード </summary>
        Normal,
        /// <summary> デザインモード </summary>
        Desing,
        /// <summary> デバッグモード </summary>
        Debug
    }

    /// <summary> ENUM:アプリケーションステータス
    /// </summary>
    public enum AppStatus
    {
        /// <summary> 初期セットアップ未済 </summary>
        NotInitSetup,
        /// <summary> 通常モード </summary>
        NormalMode,
        /// <summary> セーフモード </summary>
        SafeMode,
        /// <summary> エラー発生中 </summary>
        ErrorRun,
        /// <summary> 終了処理中 </summary>
        ExitedRun
    }

    /// <summary> ENUM:タイマー状態
    /// </summary>
    public enum TimerStatus
    {
        /// <summary> 初期状態 </summary>
        Init,
        /// <summary> 停止中 </summary>
        Stop,
        /// <summary> 稼働中 </summary>
        Run,
        /// <summary> 一時停止中 </summary>
        Pause
    }

    /// <summary> ディレクトリステータス
    /// </summary>
    public enum DirectoryStatus
    {
        /// <summary> 初期状態 </summary>
        Init,
        /// <summary> 見つからなかった </summary>
        NotFound,
        /// <summary> 見つけたが0ファイル </summary>
        ZeroFile,
        /// <summary> ディレクトリとファイルを見つけた </summary>
        FoundFile
    }

    /// <summary> タイムラインロードステータス
    /// </summary>
    public enum TimelineLoadStatus
    {
        /// <summary> 初期状態 </summary>
        Init,
        /// <summary> 未読込 </summary>
        NonLoad,
        /// <summary> 読込中 </summary>
        NowLoading,
        /// <summary> 成功 </summary>
        Success,
        /// <summary> 失敗 </summary>
        Failure,
        /// <summary> ロードファイル無し(AutoLoad) </summary>
        NotFoundTimeline
    }

    /// <summary> ENUM: タイムラインタイプ
    /// </summary>
    public enum TimelineType
    {
        /// <summary> 不明 </summary>
        UNKNOWN,
        /// <summary> 敵 </summary>
        ENEMY,
        /// <summary> タンク </summary>
        TANK,
        /// <summary> DPS </summary>
        DPS,
        /// <summary> ヒーラー </summary>
        HEALER,
        /// <summary> ペット </summary>
        PET,
        /// <summary> ギミック </summary>
        GIMMICK
    }

    /// <summary> ENUM: ジョブ
    /// </summary>
    public enum Job
    {
        /// <summary> 不明 </summary>
        UNKNOWN,
        /// <summary> 無し </summary>
        NON,

        ///<summary> ナ / ナイト　：PLD / Paladin </summary>
        PLD,
        ///<summary> 戦 / 戦士　　：WAR / Warrior </summary>
        WAR,
        ///<summary> 暗 / 暗黒騎士：DKN / DarkKnight  </summary>
        DKN,

        ///<summary> モ / モンク　：MNK / Monk </summary>
        MNK,
        ///<summary> 竜 / 竜騎士　：DRG / Dragoon </summary>
        DRG,
        ///<summary> 詩 / 吟遊詩人：BRD / Bard </summary>
        BRD,
        ///<summary> 忍 / 忍者　　：NIN / Ninja </summary>
        NIN,
        ///<summary> 黒 / 黒魔道士：BLM / BlackMage </summary>
        BLM,
        ///<summary> 召 / 召喚士　：SMN / Summoner </summary>
        SMN,
        ///<summary> 機 / 機工士　：MCN / Machinist </summary>
        MCN,

        ///<summary> 白 / 白魔道士：WHM / WhiteMage </summary>
        WHM,
        ///<summary> 学 / 学者　　：SCH / Scholar </summary>
        SCH,
        ///<summary> 占 / 占星術師：AST / Astrologian  </summary>
        AST,

        /// <summary> ｘｘ・エギ </summary>
        EGI,
        /// <summary> フェアリー・ｘｘ </summary>
        FAIRY,
        /// <summary> オートタレット・ｘｘ </summary>
        TURRET

    }

    /// <summary> カラー変更ターゲット
    /// </summary>
    public enum ColorEditTarget
    {
        /// <summary> 編集無し </summary>
        Non,

        /// <summary> メニューメイン／ベース </summary>
        MenuMain_Base,
        /// <summary> メニューサブ／ベース </summary>
        MenuSub_Base,
        /// <summary> 背景／ベース </summary>
        Background_Base,

        /// <summary> タイムライン／ヘッダーテキスト／ベース </summary>
        HeaderText_Base,
        /// <summary> タイムライン／ヘッダーバー／ベース </summary>
        HeaderBar_Base,
        /// <summary> タイムライン／不明／ベース </summary>
        TypeColorUNKNOWN_Base,
        /// <summary> タイムライン／敵／ベース </summary>
        TypeColorENEMY_Base,
        /// <summary> タイムライン／タンク／ベース </summary>
        TypeColorTANK_Base,
        /// <summary> タイムライン／DPS／ベース </summary>
        TypeColorDPS_Base,
        /// <summary> タイムライン／ヒーラー／ベース </summary>
        TypeColorHEALER_Base,
        /// <summary> タイムライン／ペット／ベース </summary>
        TypeColorPET_Base,
        /// <summary> タイムライン／ギミック／ベース </summary>
        TypeColorGIMMICK_Base,

        BarBorder_Base,
        BarBackgroung_Base,
        BarColor1_Base,
        BarColor2_Base,
        BarColor3_Base,
    }

    /// <summary> バータイプ
    /// </summary>
    public enum BarFormType
    {
        /// <summary> シンプル型 </summary>
        SimpleType
    }

    /// <summary> Doubleの小数点
    /// </summary>
    public enum DoubleVisibilityStyle
    {
        /// <summary> 0 </summary>
        N0,
        /// <summary> 0.0 </summary>
        N1,
        /// <summary> 0.00 </summary>
        N2
    }

    /// <summary> フォント編集対象
    /// </summary>
    public enum FontEditTarget
    {
        TitleBar,
        Header,
        Content,
        Active
    }

    /// <summary> エフェクトタイプ
    /// </summary>
    public enum EffectType
    {
        /// <summary> ぼかし </summary>
        Blur,
        /// <summary> ドロップシャドウ </summary>
        DropShadow,
    }

    /// <summary> インポートタイプ
    /// </summary>
    public enum ImportType
    {
        /// <summary> ファイルからインポート </summary>
        File,
        /// <summary> Webからダウンロードしてインポート </summary>
        Web
    }

    /// <summary> インポート結果
    /// </summary>
    public enum ImportResult
    {
        /// <summary> 成功 </summary>
        Success,
        /// <summary> 失敗 </summary>
        Failure,
        /// <summary> キャンセル </summary>
        Cancel
    }

    public enum TankMode
    {
        NON,
        MT,
        ST,
        OT
    }

    public enum WindowLock
    {
        Lock,
        Unlock
    }

    public enum OverlayType
    {
        StandardTimeline,
        TimelineControl
    }

}
