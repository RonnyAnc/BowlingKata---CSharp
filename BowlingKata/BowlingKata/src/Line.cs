namespace Ronny.BowlingKata
{
    using System;
    using static FrameType;

    public class Line
    {
        public Frame[] Frames { get; } = new Frame[10];
        private int currentIndex = 0;

        public Line(string inputLine)
        {
            FillFramesWith(inputLine);
        }

        private void FillFramesWith(string inputLine)
        {
            for (int i = 0, j = 0; j < Frames.Length; i += 2, j++)
            {
                if (i == 18 && inputLine.Length == 21)
                {
                    Frames[j] = new Frame(inputLine[i], inputLine[i + 1], inputLine[i + 2]);
                    break;
                }
                Frames[j] = new Frame(inputLine[i], inputLine[i + 1]);
            }
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

        public int PinsForSecondRollInFrame(int id)
        {
            if (Frames[id].Type == Strike)
                return Frames[id + 1].PinsForFirstRoll();
            return Frames[id].PinsForSecondRoll();
        }

        public int PinsForThirdRollInFrame(int id)
        {
            return Frames[id].PinsForThirdRoll();
        }
    }
}