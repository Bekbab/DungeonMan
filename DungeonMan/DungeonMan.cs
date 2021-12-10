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

            timer += Raylib.GetFrameTime();


            if (timer >= 0.15f)
            {
                timer = 0.0f;

                frame += 1;
            }

            if (frame > 5)
            {
                frame = 0;
            }
        }


        public void Draw()
        {

            Raylib.DrawTexturePro(
            dungeonManTexture,
            new Rectangle(32 * frame, 0, 32, 32), // Source
            destRec = new Rectangle(position.X, position.Y, 128, 128), // Destination
            new Vector2(64, 64), // Origin
            rotation,
            Color.WHITE);

            hitbox = destRec;


        }

    }
}