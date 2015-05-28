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
    }
}