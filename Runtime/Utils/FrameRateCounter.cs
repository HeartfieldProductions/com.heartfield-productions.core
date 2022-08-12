using System;

namespace Heartfield
{
    public static class FrameRateCounter
    {
        static DateTime lastTime;
        static int framesRendered; // an increasing count
        static int fps; // the FPS calculated from the last measurement

        public static float CalculateFrames()
        {
            framesRendered++;

            if ((DateTime.Now - lastTime).TotalSeconds >= 1)
            {
                fps = framesRendered;
                framesRendered = 0;
                lastTime = DateTime.Now;
            }

            return fps;
        }
    }
}