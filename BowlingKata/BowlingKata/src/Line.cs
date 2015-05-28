namespace Ronny.BowlingKata
{
    public class Line
    {
        private readonly string stringLine;

        public Line(string inputLine)
        {
            stringLine = inputLine;
        }

        public override string ToString()
        {
            return stringLine;
        }
    }
}