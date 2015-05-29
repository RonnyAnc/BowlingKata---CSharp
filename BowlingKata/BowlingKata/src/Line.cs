using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;

namespace Ronny.BowlingKata
{
    public class Line
    {
        private readonly Frame[] frames;

        public Line(string inputLine)
        {
            frames = new Frame[10];
            for (int i = 0, j = 0; j < frames.Length; i += 2, j++)
                frames[j] = new Frame(inputLine[i], inputLine[i + 1]);
        }

        public Frame[] Frames()
        {
            return frames;
        }
    }
}