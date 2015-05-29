using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Ronny.BowlingKata.tests
{
    [TestFixture]
    public class ScoreCalculatorShould
    {
        [Test]
        public void returns_zero_when_no_pins_are_knocked_down()
        {
            var line = new Line("--------------------");
            AreEqual(0, ScoreCalculator.CalculateFor(line));
        }

        [Test]
        public void returns_five_when_only_five_pins_are_knocked_down()
        {
            var line = new Line("-5------------------");
            AreEqual(5, ScoreCalculator.CalculateFor(line));
        }

        [Test]
        public void returns_fifteen_when_only_fifteen_pins_are_knocked_down_without_spare_or_strike()
        {
            var line = new Line("-5-2-3-4-1----------");
            AreEqual(15, ScoreCalculator.CalculateFor(line));
        }

        [Test]
        public void returns_teen_when_player_got_only_a_spare()
        {
            var line = new Line("3/------------------");
            AreEqual(10, ScoreCalculator.CalculateFor(line));
        }
    }
}