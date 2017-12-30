﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Scoring;
using osu.Game.Screens.Ranking;
using osu.Game.Users;
using static osu.Game.Rulesets.Scoring.Score;

namespace osu.Game.Tests.Visual
{
    public class TestCaseResults : OsuTestCase
    {
        private BeatmapManager beatmaps;

        [BackgroundDependencyLoader]
        private void load(BeatmapManager beatmaps)
        {
            this.beatmaps = beatmaps;
        }

        private WorkingBeatmap beatmap;

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (beatmap == null)
            {
                var beatmapInfo = beatmaps.QueryBeatmap(b => b.RulesetID == 0);
                if (beatmapInfo != null)
                    beatmap = beatmaps.GetWorkingBeatmap(beatmapInfo);
            }

            Add(new Results(new Score
            {
                TotalScore = 2845370,
                Accuracy = 0.98,
                MaxCombo = 123,
                Rank = ScoreRank.A,
                Date = DateTimeOffset.Now,
                Statistics = new Dictionary<HitCount, dynamic>
                {
                    { HitCount.Great, 50 },
                    { HitCount.Good, 20 },
                    { HitCount.Meh, 50 },
                    { HitCount.Miss, 1 }
                },
                User = new User
                {
                    Username = "peppy",
                }
            })
            {
                InitialBeatmap = beatmap
            });
        }
    }
}
