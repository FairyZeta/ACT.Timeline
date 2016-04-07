namespace FairyZeta.FF14.ACT.Timeline.Core
{
    public enum TimelineType
    {
        UNKNOWN,
        ENEMY,
        TANK,
        DPS,
        HEALER,
        PET,
        GIMMICK
    }

    public enum Job
    {
        UNKNOWN,
        NON,

        PLD,
        WAR,
        DKN,

        MNK,
        DRG,
        BRD,
        NIN,
        BLM,
        SMN,
        MCN,

        WHM,
        SCH,
        AST,

        EGI,
        FAIRY,
        TURRET

        //ナ / ナイト　：PLD / Paladin
        //モ / モンク　：MNK / Monk
        //戦 / 戦士　　：WAR / Warrior
        //竜 / 竜騎士　：DRG / Dragoon
        //詩 / 吟遊詩人：BRD / Bard
        //忍 / 忍者　　：NIN / Ninja
        //白 / 白魔道士：WHM / WhiteMage
        //黒 / 黒魔道士：BLM / BlackMage
        //召 / 召喚士　：SMN / Summoner
        //学 / 学者　　：SCH / Scholar
        //暗 / 暗黒騎士：DKN / DarkKnight*
        //占 / 占星術師：AST / Astrologian*
        //機 / 機工士　：MCN / Machinist*
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
        StandardTimeline
    }

}
