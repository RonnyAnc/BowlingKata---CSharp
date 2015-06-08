namespace Ronny.BowlingKata
{
    public class EspecialFrame : Frame
    {
        public EspecialFrame(params char[] rolls): base(rolls) {}

        public override int PinsForSecondRoll()
        {
            return Rolls[1].Pins;
        }

        public int PinsForThirdRoll()
        {
            return Rolls[2].Pins;
        }
    }
}