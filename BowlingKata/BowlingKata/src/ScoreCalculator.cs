using static Ronny.BowlingKata.FrameType;

namespace Ronny.BowlingKata
{
    using System;

    public class ScoreCalculator
    {
        public static int CalculateScoreForLine(Line line)
        {
            var score = 0;
            for (var i = 0; i < line.FramesAmount(); i++)
                score += CalculateScoreForFrameInLine(i, line);
            return score;
        }

        private static int CalculateScoreForFrameInLine(int id, Line line)
        {
            // TODO refactor
            if (line.Frames[id].Type == Spare)
                return 10 + PinsForNextRollInLine(id, line);
            if (line.Frames[id].Type == Strike)
                return 10 + PinsForTwoNextRollsInLine(id, line);
            return line.Frames[id].Pins();
        }

        private static int PinsForTwoNextRollsInLine(int id, Line line)
        {
            return PinsForNextRollInLine(id, line) + PinsForNextToNextRollInLine(id, line);
        }

        private static int PinsForNextToNextRollInLine(int id, Line line)
        {
            return line.PinsForNextToNextRollAfterFrame(id);
        }

        private static int PinsForNextRollInLine(int id, Line line)
        {
            return line.PinsForNextRollAfterFrame(id);
        }
    }
}