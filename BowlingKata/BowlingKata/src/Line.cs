namespace Ronny.BowlingKata
{
    using System;
    using static FrameType;

    public class Line
    {
        public Frame[] Frames { get; } = new Frame[10];

        public Line(string inputLine)
        {
            FillFramesWith(inputLine);
        }

        private void FillFramesWith(string inputLine)
        {
            for (int i = 0, j = 0; j < Frames.Length; i += 2, j++)
            {
                if (AreThereExtraRollsIn(inputLine) && IsLastFrame(i))
                {
                    Frames[j] = new EspecialFrame(inputLine[i], inputLine[i + 1], inputLine[i + 2]);
                    return;
                }
                Frames[j] = new Frame(inputLine[i], inputLine[i + 1]);
            }
        }

        private static bool IsLastFrame(int i)
        {
            return i == 18;
        }

        private static bool AreThereExtraRollsIn(string inputLine)
        {
            return inputLine.Length == 21;
        }

        public int FramesAmount()
        {
            return Frames.Length;
        }

        public int PinsForNextRollAfterFrame(int id)
        {
            if (id == 9) return Frames[id].PinsForSecondRoll();
            return Frames[id + 1].PinsForFirstRoll();
        }

        public int PinsForNextToNextRollAfterFrame(int id)
        {
            if (id == 8) return Frames[id + 1].PinsForSecondRoll();
            if (id == 9) return ((EspecialFrame)Frames[id]).PinsForThirdRoll();
            if (IsStrike(Frames[id + 1])) return Frames[id + 2].PinsForFirstRoll();
            return Frames[id + 1].PinsForSecondRoll();
        }

        public int PinsForThirdRollInFrame(int id)
        {
            return ((EspecialFrame) Frames[id]).PinsForThirdRoll();
        }

        private bool IsStrike(Frame frame)
        {
            return frame.Type == Strike;
        }
    }
}