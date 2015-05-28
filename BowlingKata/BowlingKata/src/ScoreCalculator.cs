namespace Ronny.BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateFor(Line line)
        {
            var score = 0;
            foreach (var character in line.ToString())
                if (char.IsDigit(character)) score += ParseToInt(character);
            return score;
        }

        private static int ParseToInt(char character)
        {
            return int.Parse(character.ToString());
        }
    }
}