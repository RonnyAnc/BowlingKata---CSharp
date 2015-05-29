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
            {
                this.rolls[i] = new Roll(rolls[i]);
            }
        }

        public int Pins()
        {
            return rolls.Sum(roll => roll.Pins);
        }
    }
}