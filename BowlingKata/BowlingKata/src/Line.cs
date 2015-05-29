namespace Ronny.BowlingKata
{
    public class Line
    {
        public Frame[] Frames { get; }
        private int currentIndex = 0;

        public Line(string inputLine)
        {
            Frames = new Frame[10];
            for (int i = 0, j = 0; j < Frames.Length; i += 2, j++)
                Frames[j] = new Frame(inputLine[i], inputLine[i + 1]);
        }

        public Frame CurrentFrame()
        {
            return Frames[currentIndex];
        }

        public int FramesAmount()
        {
            return Frames.Length;
        }

        public int PinsForFirsRollInFrame(int id)
        {
            return Frames[id].PinsForFirstRoll();
        }
    }
}