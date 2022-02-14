using System;
using Raylib_cs;
namespace DungeonMan
{
    public class Game
    {
        public static bool gameOver = false;
        public static bool youreFucked = false;
        Timer t3 = new Timer();
        Slime s1;
        DungeonMan d1;

        Sound fucked = Raylib.LoadSound("yourefucked.ogg");

        bool soundplayed = false;

        public Game()
        {
            s1 = new Slime(200, 200);
            d1 = new DungeonMan(-30, -30, s1, true);
        }

        public void Play()
        {

            t3.StartTimer(10);

            if (!gameOver)
            {
                Raylib.ClearBackground(Color.WHITE);
                if (t3.timerEnd)
                {
                    youreFucked = true;
                }
                Update();
                Draw();
            }
            else if (gameOver)
            {
                Program.window = 2;
            }
        }

        public void Update()
        {

            s1.Update();

            if (youreFucked)
            {
                d1.Update();
            }
        }

        public void Draw()
        {
            Raylib.DrawText($"{t3.timer}", 50, 50, 20, Color.RED);
            s1.Draw();
            if (youreFucked)
            {
                if (!soundplayed)
                {
                    if (!Raylib.IsSoundPlaying(fucked))
                    {
                        Raylib.PlaySound(fucked);
                        soundplayed = true;
                    }
                }
                d1.Draw();
            }
        }
    }
}