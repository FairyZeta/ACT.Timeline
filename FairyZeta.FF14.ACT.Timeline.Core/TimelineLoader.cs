﻿using System.Collections.Generic;
using System.Globalization;
using Sprache;
using System;
using System.IO;
using FairyZeta.FF14.ACT.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    public class AlertAll
    {
        public string ActivityName;
        public double ReminderTime;
        public AlertSoundData AlertSound;
    }

    public class TimelineConfig
    {
        public List<TimelineActivityData> Items;
        public List<TimelineAnchorData> Anchors;
        public List<AlertAll> AlertAlls;
        public List<string> HideAlls;
        public List<TimelineAlertObjectModel> Alerts;
        public AlertSoundAssets AlertSoundAssets;

        public TimelineConfig()
        {
            Items = new List<TimelineActivityData>();
            Anchors = new List<TimelineAnchorData>();
            AlertAlls = new List<AlertAll>();
            HideAlls = new List<string>();
            Alerts = new List<TimelineAlertObjectModel>();
            AlertSoundAssets = new AlertSoundAssets();
        }
    }

    public class TimelineConfigParser
    {
        const int TRASH = 0;

        public delegate void ConfigOp(TimelineConfig config);

        static readonly Parser<Double> DecimalDouble = Parse.Decimal.Select(str => Double.Parse(str, CultureInfo.InvariantCulture));

        static readonly Parser<int> Comment = Parse.Regex(@"^#.*").Return(TRASH);

        static readonly Parser<string> QuotedString =
            from quoteStart in Parse.Char('"')
            from quotedString in Parse.CharExcept('"').Many().Text()
            from quoteEnd in Parse.Char('"')
            select quotedString;
        static readonly Parser<string> Spaces = Parse.Regex(@"^[ 　]+");
        static readonly Parser<string> NonWhiteSpaces = Parse.Char(c => !char.IsWhiteSpace(c), "non whitespace char").Many().Text();
        static readonly Parser<string> MaybeQuotedString = QuotedString.XOr(NonWhiteSpaces);

        static readonly Parser<char> RegexEscapedSlash =
            from escape in Parse.Char('\\')
            from slash in Parse.Char('/')
            select '/';
        static readonly Parser<char> RegexChar = RegexEscapedSlash.Or(Parse.CharExcept('/'));
        static readonly Parser<string> Regex =
            from slash in Parse.Char('/')
            from regex in RegexChar.Many().Text()
            from slash2 in Parse.Char('/')
            select regex;

        static readonly Parser<double> Duration =
            from spaces in Spaces
            from durationPrefix in Parse.String("duration").Or(Parse.String("効果時間"))
            from spaces2 in Parse.Optional(Spaces)
            from value in DecimalDouble
            select value;

        public struct SyncWindowSettings
        {
            public double WindowBefore;
            public double WindowAfter;
        };
        static readonly SyncWindowSettings DefaultWindow = new SyncWindowSettings
        {
            WindowBefore = TimelineAnchorData.DefaultWindow / 2,
            WindowAfter = TimelineAnchorData.DefaultWindow / 2
        };
        static readonly Parser<SyncWindowSettings> SingleWindow =
            from value in DecimalDouble
            select new SyncWindowSettings { WindowBefore = value / 2, WindowAfter = value / 2 };
        static readonly Parser<SyncWindowSettings> BeforeAfterWindow =
            from beforeWindow in DecimalDouble
            from sep in Parse.Regex(@"[, 　]+")
            from afterWindow in DecimalDouble
            select new SyncWindowSettings { WindowBefore = beforeWindow, WindowAfter = afterWindow };
        static readonly Parser<SyncWindowSettings> SyncWindow =
            from spaces in Spaces
            from window in Parse.String("window")
            from spaces2 in Spaces
            from value in BeforeAfterWindow.Or(SingleWindow)
            select value;
        static readonly Parser<double> Jump =
            from spaces in Spaces
            from gotoPrefix in Parse.String("jump")
            from spaces2 in Parse.Optional(Spaces)
            from value in DecimalDouble
            select value;

        static readonly Parser<Tuple<string, SyncWindowSettings>> Sync =
            from spaces in Spaces
            from sync in Parse.String("sync")
            from spaces2 in Parse.Optional(Spaces)
            from regex in Regex
            from window in Parse.Optional(SyncWindow)
            select new Tuple<string, SyncWindowSettings>(regex, window.GetOrElse(DefaultWindow));
        static readonly Parser<Tuple<TimelineActivityData, Tuple<string, SyncWindowSettings>>> TimelineActivity =
            from timeFromStart in Parse.Decimal
            from spaces in Spaces
            from name in MaybeQuotedString
            from duration in Parse.Optional(Duration)
            from sync in Parse.Optional(Sync)
            from jump in Parse.Optional(Jump)
            select new Tuple<TimelineActivityData, Tuple<string, SyncWindowSettings>>(new TimelineActivityData
            {
                Jump = jump.GetOrElse(-1),
                TimeFromStart = double.Parse(timeFromStart, CultureInfo.InvariantCulture),
                Name = name,
                Duration = duration.GetOrElse(0)
            }, sync.GetOrElse(null));

        static readonly Parser<ConfigOp> TimelineActivityStatement =
            TimelineActivity.Select<Tuple<TimelineActivityData, Tuple<string, SyncWindowSettings>>, ConfigOp>(t => ((TimelineConfig config) =>
            {
                config.Items.Add(t.Item1);
                if (t.Item2 != null)
                {
                    var windowSettings = t.Item2.Item2;
                    config.Anchors.Add(new TimelineAnchorData
                    {
                        Jump = t.Item1.Jump,
                        TimeFromStart = t.Item1.TimeFromStart,
                        Regex = new System.Text.RegularExpressions.Regex(t.Item2.Item1),
                        WindowBefore = windowSettings.WindowBefore,
                        WindowAfter = windowSettings.WindowAfter
                    });
                }
            })).Named("TimelineActivityStatement");

        static readonly Parser<Tuple<string, string>> AlertSoundAlias =
            from define_alertsound in Parse.Regex(@"^define\s+alertsound\s+")
            from alias in MaybeQuotedString
            from spaces in Spaces
            from target in MaybeQuotedString
            select new Tuple<string, string>(alias, target);

        static readonly Parser<ConfigOp> AlertSoundAliasStatement =
            AlertSoundAlias.Select<Tuple<string, string>, ConfigOp>((Tuple<string, string> t) => ((TimelineConfig config) =>
            {
                AlertSoundData alertSound = config.AlertSoundAssets.Get(t.Item2);
                config.AlertSoundAssets.RegisterAlias(alertSound, t.Item1);
            }));

        static readonly Parser<Tuple<string, string, string>> AlertAll =
            from alertall in Parse.String("alertall")
            from spaces in Spaces
            from activityName in MaybeQuotedString
            from spaces2 in Spaces
            from before in Parse.String("before")
            from spaces3 in Spaces
            from reminderTime in Parse.Decimal
            from spaces4 in Spaces
            from sound_keyword in Parse.String("sound")
            from spaces5 in Spaces
            from soundName in MaybeQuotedString
            select new Tuple<string, string, string>(activityName, reminderTime, soundName);

        static readonly Parser<ConfigOp> AlertAllStatement =
            AlertAll.Select<Tuple<string, string, string>, ConfigOp>((Tuple<string, string, string> t) => ((TimelineConfig config) =>
            {
                var alertSound = config.AlertSoundAssets.Get(t.Item3);
                config.AlertAlls.Add(new AlertAll { ActivityName = t.Item1, ReminderTime = Double.Parse(t.Item2), AlertSound = alertSound });
            }));

        static readonly Parser<string> HideAll =
            from hideall in Parse.String("hideall")
            from spaces in Spaces
            from activityName in MaybeQuotedString
            select activityName;

        static readonly Parser<ConfigOp> HideAllStatement =
            HideAll.Select<string, ConfigOp>((string targetActivityName) => ((TimelineConfig config) =>
            {
                config.HideAlls.Add(targetActivityName);
            }));

        static readonly Parser<ConfigOp> EmptyStatement = Parse.Return<ConfigOp>((TimelineConfig config) => { });

        static readonly Parser<ConfigOp> TimelineStatement =
            AlertSoundAliasStatement.Or(AlertAllStatement).Or(HideAllStatement).Or(TimelineActivityStatement).Or(EmptyStatement);

        static readonly Parser<int> LineBreak = Parse.Or(Parse.Char('\n'), Parse.Char('\r')).AtLeastOnce().Return(TRASH);
        static readonly Parser<int> StatementSeparator =
            from beforeSpaces in Parse.Optional(Spaces)
            from comment in Parse.Optional(Comment)
            from lb in LineBreak
            from afterSpaces in Parse.Optional(Spaces)
            select TRASH;

        static readonly Parser<IEnumerable<ConfigOp>> TimelineStatements =
            from stmts in TimelineStatement.DelimitedBy(StatementSeparator.Many())
            select stmts;

        public static readonly Parser<TimelineConfig> TimelineConfig = TimelineStatements.Select(stmts =>
        {
            TimelineConfig config = new TimelineConfig();
            foreach (ConfigOp op in stmts)
                op(config);
            return config;
        }).End();
    }

    public class TimelineLoader
    {
        static public void LoadFromFile(TimelineObjectModel pTimelineOM, string path)
        {
            string text = File.ReadAllText(path, System.Text.Encoding.UTF8);
            LoadFromText(pTimelineOM, Path.GetFileName(path), text);
        }

        static public void LoadFromText(TimelineObjectModel pTimelineOM, string name, string text)
        {
            TimelineConfig config = TimelineConfigParser.TimelineConfig.Parse(text);
            foreach (AlertAll alertAll in config.AlertAlls)
            {
                foreach (TimelineActivityData matchingActivity in config.Items.FindAll(activity => activity.Name == alertAll.ActivityName))
                {
                    var alert = new TimelineAlertObjectModel { Activity = matchingActivity, ReminderTimeOffset = alertAll.ReminderTime, AlertSoundData = alertAll.AlertSound };
                    config.Alerts.Add(alert);
                }
            }
            foreach (string activityName in config.HideAlls)
            {
                //foreach (TimelineActivityData matchingActivity in config.Items.FindAll(activity => activity.Name == activityName))
                //{
                //    matchingActivity.Hidden = true;
                //}
            }
            pTimelineOM.SetTimelineData(name, config.Items, config.Anchors, config.Alerts, config.AlertSoundAssets);

        }
    }
}
