using static Ronny.BowlingKata.FrameType;

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
            if (Frame(id).Type == Spare)
                return 10 + PinsForNextRoll(id);
            return Frame(id).Pins();
        }

        private Frame Frame(int id)
        {
            return Line.Frames[id];
        }

        private int PinsForNextRoll(int id)
        {
            return Line.PinsForFirsRollInFrame(id + 1);
        }
    }
}