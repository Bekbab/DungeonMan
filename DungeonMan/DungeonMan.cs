using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class DungeonMan : Character
    {
        private Texture2D dungeonManTexture = Raylib.LoadTexture(@"DungeonMan.png");
        Slime s1;

        public DungeonMan(int x, int y, Slime s)
        {
            s1 = s;

            position.X = x;
            position.Y = y;

            frames = 6;
            delay = 0.15f;
        }

        public void WalkAnimation()
        {

            t1.StartSpriteTimer(delay, frames);
            walking = true;
            if (walking)
            {
                t1.timerActive = true;
            }
            else if (!walking)
            {
                t1.timerActive = false;
            }
        }

        public void Update()
        {
            WalkAnimation();

            
        }
        public void Draw()
        {

            Raylib.DrawTexturePro(
            dungeonManTexture,
            new Rectangle(32 * t1.frame, 0, 32, 32), // Source
            destRec = new Rectangle(position.X, position.Y, 128, 128), // Destination
            origin = new Vector2(64, 64), // Origin
            rotation,
            Color.WHITE);

            hitbox = new Rectangle(position.X - origin.X, position.Y - origin.X, destRec.width, destRec.height);
            Raylib.DrawRectangleLinesEx(hitbox, 5, Color.BLACK);




        }

    }
}