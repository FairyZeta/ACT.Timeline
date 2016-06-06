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
        /// <summary> メニューメイン／アウトライン </summary>
        MenuMain_Outline,
        /// <summary> メニューメイン／シャドウ </summary>
        MenuMain_Shadow,

        /// <summary> メニューサブ／ベース </summary>
        MenuSub_Base,
        /// <summary> メニューサブ／アウトライン </summary>
        MenuSub_Outline,
        /// <summary> メニューサブ／シャドウ </summary>
        MenuSub_Shadow,

        /// <summary> 背景／ベース </summary>
        Background_Base,
        /// <summary> 背景／シャドウ </summary>
        Background_Shadow,

        /// <summary> タイムライン／ヘッダーテキスト／ベース </summary>
        HeaderText_Base,
        /// <summary> タイムライン／ヘッダーテキスト／アウトライン </summary>
        HeaderText_Outline,
        /// <summary> タイムライン／ヘッダーテキスト／シャドウ </summary>
        HeaderText_Shadow,

        /// <summary> タイムライン／ヘッダーバー／ベース </summary>
        HeaderBar_Base,
        /// <summary> タイムライン／ヘッダーバー／シャドウ </summary>
        HeaderBar_Shadow,

        /// <summary> タイムライン／不明／ベース </summary>
        TypeColorUNKNOWN_Base,
        /// <summary> タイムライン／不明／アウトライン </summary>
        TypeColorUNKNOWN_Outline,
        /// <summary> タイムライン／不明／シャドウ </summary>
        TypeColorUNKNOWN_Shadow,

        /// <summary> タイムライン／敵／ベース </summary>
        TypeColorENEMY_Base,
        /// <summary> タイムライン／敵／アウトライン </summary>
        TypeColorENEMY_Outline,
        /// <summary> タイムライン／敵／シャドウ </summary>
        TypeColorENEMY_Shadow,

        /// <summary> タイムライン／タンク／ベース </summary>
        TypeColorTANK_Base,
        /// <summary> タイムライン／タンク／アウトライン </summary>
        TypeColorTANK_Outline,
        /// <summary> タイムライン／タンク／シャドウ </summary>
        TypeColorTANK_Shadow,

        /// <summary> タイムライン／DPS／ベース </summary>
        TypeColorDPS_Base,
        /// <summary> タイムライン／DPS／アウトライン </summary>
        TypeColorDPS_Outline,
        /// <summary> タイムライン／DPS／シャドウ </summary>
        TypeColorDPS_Shadow,

        /// <summary> タイムライン／ヒーラー／ベース </summary>
        TypeColorHEALER_Base,
        /// <summary> タイムライン／ヒーラー／アウトライン </summary>
        TypeColorHEALER_Outline,
        /// <summary> タイムライン／ヒーラー／シャドウ </summary>
        TypeColorHEALER_Shadow,

        /// <summary> タイムライン／ペット／ベース </summary>
        TypeColorPET_Base,
        /// <summary> タイムライン／ペット／アウトライン </summary>
        TypeColorPET_Outline,
        /// <summary> タイムライン／ペット／シャドウ </summary>
        TypeColorPET_Shadow,

        /// <summary> タイムライン／ギミック／ベース </summary>
        TypeColorGIMMICK_Base,
        /// <summary> タイムライン／ギミック／アウトライン </summary>
        TypeColorGIMMICK_Outline,
        /// <summary> タイムライン／敵／シャドウ </summary>
        TypeColorGIMMICK_Shadow,

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
        SimpleType,
        /// <summary> ウィンドウズ標準型 </summary>
        WindowsType,
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
