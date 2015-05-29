using System;
using System.Linq;

namespace Ronny.BowlingKata
{
    public class ScoreCalculator
    {
        private Line Line { get; set; }

        public ScoreCalculator(Line line)
        {
            Line = line;
        }

        public int CalculateScore()
        {
            var score = 0;
            for (var i = 0; i < Line.FramesAmount(); i++)
                score += CalculateScoreForFrame(i);
            return score;
        }

        private int CalculateScoreForFrame(int id)
        {
            if (Line.Frames[id].Type == FrameType.Spare)
                return 10 + PinsForNextRoll(id);
            return Line.Frames[id].Pins();
        }

        private int PinsForNextRoll(int id)
        {
            return Line.Frames[id + 1].Rolls[0].Pins;
        }
    }
}