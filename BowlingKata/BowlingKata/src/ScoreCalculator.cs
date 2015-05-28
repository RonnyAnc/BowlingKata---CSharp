namespace Ronny.BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateFor(Line line)
        {
            foreach (var character in line.ToString())
                if (char.IsDigit(character)) return ParseToInt(character);
            return 0;
        }

        private static int ParseToInt(char character)
        {
            return int.Parse(character.ToString());
        }
    }
}