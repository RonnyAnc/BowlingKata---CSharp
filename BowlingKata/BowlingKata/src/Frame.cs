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
            Type = ExtractTypeFromSymbols(rolls);
            Rolls = new Roll[rolls.Length];
            for (var i = 0; i < rolls.Length; i++)
                Rolls[i] = new Roll(rolls[i], ParsePinsForRollWithIndex(rolls, i));
        }

        private static FrameType ExtractTypeFromSymbols(IEnumerable<char> rolls)
        {
            if (rolls.Contains('X')) return FrameType.Strike;
            if (rolls.Contains('/')) return FrameType.Spare;
            return FrameType.Regular;
        }

        private static int ParsePinsForRollWithIndex(IReadOnlyList<char> rolls, int i)
        {
            var symbol = rolls[i];
            const int totalPins = 10;
            if (symbol == '/') return totalPins - ParseToInt(rolls[i - 1]);
            if (char.IsDigit(symbol)) return ParseToInt(symbol);
            return symbol == 'X' ? totalPins : 0;
        }

        private static int ParseToInt(char symbol)
        {
            return int.Parse(symbol.ToString());
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
                throw new IndexOutOfRangeException();
            }
        }

        public int PinsForFirstRoll()
        {
            return Rolls[0].Pins;
        }

        public int PinsForSecondRoll()
        {
            if (Type == FrameType.Strike)
                throw new Exception("Strike Frames only have one roll");
            return Rolls[1].Pins;
        }
    }
}