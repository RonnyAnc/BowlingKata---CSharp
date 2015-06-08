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
            AreEqual(0, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_five_when_only_five_pins_are_knocked_down()
        {
            var line = new Line("-5------------------");
            AreEqual(5, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_fifteen_when_only_fifteen_pins_are_knocked_down_without_spare_or_strike()
        {
            var line = new Line("-5-2-3-4-1----------");
            AreEqual(15, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_teen_when_player_got_only_a_spare()
        {
            var line = new Line("3/------------------");
            AreEqual(10, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_eighteen_when_player_knock_down_four_pins_after_a_spare()
        {
            var line = new Line("6/4-----------------");
            AreEqual(18, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_ten_when_player_get_only_a_strike()
        {
            var line = new Line("Xn------------------");
            AreEqual(10, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_twentyeight_when_player_get_strike_and_then_knock_down_nine_pins_in_two_next_rolls()
        {
            var line = new Line("Xn45----------------");
            AreEqual(28, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_sixty_when_player_get_three_following_strikes()
        {
            var line = new Line("XnXnXn--------------");
            AreEqual(60, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_one_hundred_fifty_when_player_always_knock_down_five_pins()
        {
            var line = new Line("5/5/5/5/5/5/5/5/5/5/5");
            AreEqual(150, ScoreCalculator.CalculateScoreForLine(line));
        }

        [Test]
        public void returns_three_hundred_when_player_always_get_a_strike()
        {
            var line = new Line("XnXnXnXnXnXnXnXnXnXXX");
            AreEqual(300, ScoreCalculator.CalculateScoreForLine(line));
        }
    }
}