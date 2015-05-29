namespace Ronny.BowlingKata
{
    public class Roll
    {
        public char Symbol { get; private set; }
        public int Pins { get; private set; }

        public Roll(char symbol, int pins)
        {
            Symbol = symbol;
            Pins = pins;
        }
    }
}