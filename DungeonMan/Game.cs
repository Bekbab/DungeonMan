using System;

namespace DungeonMan
{
    public class Game
    {
        public bool gameOver = false;
        public bool youreFucked = false;
        Timer t1 = new Timer();
        Slime s1;
        DungeonMan d1;

        public Game()
        {
            s1 = new Slime(200, 200);
            d1 = new DungeonMan(500, 500, s1);
        }

        public void Play()
        {
            if (!gameOver)
            {
                Update();
                Draw();
            }
            Program.window = 2;

        }

        public void Update()
        {
            if (youreFucked)
            {
                d1.Update();
            }
            s1.Update();
        }

        public void Draw()
        {
            if (youreFucked)
            {
                d1.Draw();
            }
            s1.Draw();
        }


    }
}