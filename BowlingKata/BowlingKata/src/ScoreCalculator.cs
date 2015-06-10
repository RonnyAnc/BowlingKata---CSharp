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
            // TODO refactor
            if (id == 8)
                return PinsForNextRollInLine(id, line) + line.Frames[id + 1].PinsForSecondRoll();
            if (id == 9)
                return line.Frames[id].PinsForSecondRoll() + ((EspecialFrame) line.Frames[id]).PinsForThirdRoll();
            return PinsForNextRollInLine(id, line) + PinsForNextToNextRollInLine(id, line);
        }

        private static int PinsForNextToNextRollInLine(int id, Line line)
        {
            // TODO change of line method
            return line.PinsForNextToNextRoll(id);
        }

        private static int PinsForNextRollInLine(int id, Line line)
        {
            // TODO change of line method
            if (id == 9) return line.PinsForThirdRollInFrame(id);
            return line.PinsForFirsRollInFrame(id + 1);
        }
    }
}