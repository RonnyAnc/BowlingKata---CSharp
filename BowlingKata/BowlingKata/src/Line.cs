using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;

namespace Ronny.BowlingKata
{
    public class Line
    {
        public Frame[] Frames { get; }

        public Line(string inputLine)
        {
            Frames = new Frame[10];
            for (int i = 0, j = 0; j < Frames.Length; i += 2, j++)
                Frames[j] = new Frame(inputLine[i], inputLine[i + 1]);
        }

        public int FramesAmount()
        {
            return Frames.Length;
        }
    }
}