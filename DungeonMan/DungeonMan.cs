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
        bool chasing;


        public DungeonMan(int x, int y, Slime s, bool chase)
        {
            s1 = s;

            speed = 400;

            position.X = x;
            position.Y = y;

            frames = 6;
            delay = 0.15f;

            chasing = chase;
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

            if (Raylib.CheckCollisionRecs(hitbox, s1.hitbox))
            {
                Game.gameOver = true;
            }

            if (chasing)
            {
                Chase();
            }



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
            // Raylib.DrawRectangleLinesEx(hitbox, 5, Color.BLACK);
        }

        public void Chase()
        {

            WalkAnimation();
            Vector2 slimePos = new Vector2(s1.position.X, s1.position.Y);
            Vector2 delta = slimePos - position;
            delta = Vector2.Normalize(delta);
            position += delta * speed * Raylib.GetFrameTime();

        }

    }
}