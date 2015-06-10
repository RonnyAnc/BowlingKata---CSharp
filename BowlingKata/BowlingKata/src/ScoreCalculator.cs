using static Ronny.BowlingKata.FrameType;

namespace Ronny.BowlingKata
{

    public class ScoreCalculator
    {
        public static int CalculateScoreForLine(Line line)
        {
            return ScoreForFirstNineFramesIn(line) + ScoreForLastFrameIn(line);
        }

        private static int ScoreForLastFrameIn(Line line)
        {
            return line.Frames[9].Pins();
        }

        private static int ScoreForFirstNineFramesIn(Line line)
        {
            var score = 0;
            for (var i = 0; i < line.FramesAmount() - 1; i++)
                score += CalculateScoreForFrameInLine(i, line);
            return score;
        }

        private static int CalculateScoreForFrameInLine(int id, Line line)
        {
            if (IsSpare(line.Frames[id]))
                return 10 + PinsForNextRollInLine(id, line);
            if (IsStrike(line.Frames[id]))
                return 10 + PinsForTwoNextRollsInLine(id, line);
            return line.Frames[id].Pins();
        }

        private static bool IsStrike(Frame frame)
        {
            return frame.Type == Strike;
        }

        private static bool IsSpare(Frame frame)
        {
            return frame.Type == Spare;
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