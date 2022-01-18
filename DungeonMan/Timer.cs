using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class Timer
    {

        public float timer = 0.0f;
        bool timerActive = false;
        int frame;
        public bool timerEnd;
        public void StartTimer(float delay) //continous timer which resets after a delay of x seconds
        {
            timerActive = true;

            if (timerActive)
            {
                timer += Raylib.GetFrameTime();
            }

            if (timer >= delay)
            {
                timer = 0.0f;
                timerEnd = true;
            }
            else
            {
                timerEnd = false;
            }
        }

        public void Wait(float delay) //allows for delays in for example loops, waits x seconds
        {

            while (delay > 0)
            {
                delay -= Raylib.GetFrameTime();
            }
        }

        public void StartSpriteTimer(float delay, int frames, bool active) //timer for drawing sprites, define delay between frames in seconds, amount of frames, and whether the timer enters active or not
        {
            timerActive = active;

            if (timerActive == true)
            {
                timer += Raylib.GetFrameTime();
            }

            if (timer >= 0.15f)
            {
                timer = 0.0f;

                frame += 1;
            }

            if (frame > (frames - 1))
            {
                frame = 0;
            }
        }
    }
}