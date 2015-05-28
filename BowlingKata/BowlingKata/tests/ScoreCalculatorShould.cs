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
    }
}