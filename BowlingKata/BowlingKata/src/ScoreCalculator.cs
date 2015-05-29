namespace Ronny.BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateFor(Line line)
        {
            var score = 0;
            foreach (var frame in line.Frames())
                score += frame.Pins();
            return score;
        }
    }
}