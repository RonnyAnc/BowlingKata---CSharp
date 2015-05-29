using System;
using System.Linq;

namespace Ronny.BowlingKata
{
    public class Frame
    {
        private readonly Roll[] rolls;

        public Frame(params char[] rolls)
        {
            this.rolls = new Roll[rolls.Length];
            for (var i = 0; i < rolls.Length; i++)
                this.rolls[i] = new Roll(rolls[i], PinsForRollWithIndex(rolls, i));
        }

        private static int PinsForRollWithIndex(char[] rolls, int i)
        {
            if (char.IsDigit(rolls[i])) return ParseToInt(rolls[i]);
            if (rolls[i] == '/') return 10 - ParseToInt(rolls[i - 1]);
            return 0;
        }

        public int Pins()
        {
            return rolls.Sum(roll => roll.Pins);
        }

        private static int ParseToInt(char symbol)
        {
            if (symbol == '-') return 0;
            return Int32.Parse(symbol.ToString());
        }
    }
}