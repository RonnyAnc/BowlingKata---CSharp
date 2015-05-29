using System;
using System.Collections.Generic;
using System.Linq;

namespace Ronny.BowlingKata
{
    public class Frame
    {
        public Roll[] Rolls { get; }

        public FrameType Type { get; private set; }

        public Frame(params char[] rolls)
        {
            Type = rolls.Contains('/') ? FrameType.Spare : FrameType.Regular;
            Rolls = new Roll[rolls.Length];
            for (var i = 0; i < rolls.Length; i++)
                Rolls[i] = new Roll(rolls[i], PinsForRollWithIndex(rolls, i));
        }

        private static int PinsForRollWithIndex(IReadOnlyList<char> rolls, int i)
        {
            var symbol = rolls[i];
            if (symbol == '/') return 10 - ParseToInt(rolls[i - 1]);
            return ParseToInt(symbol);
        }

        private static int ParseToInt(char symbol)
        {
            return char.IsDigit(symbol) ? int.Parse(symbol.ToString()) : 0;
        }

        public int Pins()
        {
            return Rolls.Sum(roll => roll.Pins);
        }

        public Roll this [int index]
        {
            get
            {
                if (index >= 0 && index < Rolls.Length) return Rolls[index];
                throw new System.IndexOutOfRangeException();
            }
        }
    }
}