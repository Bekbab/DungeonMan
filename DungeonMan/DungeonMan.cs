using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class DungeonMan : Character
    {
        private Texture2D dungeonManTexture = Raylib.LoadTexture(@"DungeonMan.png");

        public DungeonMan(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void WalkAnimation()
        {
            if (walking)
            {
                timerActive = true;
            }
            else if (walking == false)
            {
                timerActive = false;
            }

            if (timerActive == true)
            {
                timer += Raylib.GetFrameTime();
            }

            if (timer >= 0.15f)
            {
                timer = 0.0f;

                frame += 1;
            }

            if (frame > 2)
            {
                frame = 0;
            }
        }


        public void Draw()
        {

            Raylib.DrawTexturePro(
            dungeonManTexture,
            new Rectangle(16 * frame, 0, 16, 16), // Source
            destRec = new Rectangle(position.X, position.Y, 64, 64), // Destination
            new Vector2(32, 32), // Origin
            rotation,
            Color.WHITE);

            hitbox = destRec;


        }

    }
}