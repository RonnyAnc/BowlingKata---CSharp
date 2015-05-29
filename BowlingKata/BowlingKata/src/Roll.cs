namespace Ronny.BowlingKata
{
    public class Roll
    {
        public int Pins { get; private set; }

        public Roll(char symbol)
        {
            Pins = ParseToInt(symbol);
        }

        private static int ParseToInt(char symbol)
        {
            if (symbol == '-') return 0;
            return int.Parse(symbol.ToString());
        }
    }
}