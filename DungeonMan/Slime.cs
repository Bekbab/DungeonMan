using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
namespace DungeonMan
{
    public class Slime : Character
    {

        private Texture2D slimeTexture = Raylib.LoadTexture(@"Slime.png");


        public void WalkAnimation()
        {
            t1.StartSpriteTimer(0.15f, 3, false);

            if (walking)
            {
                timerActive = true;
            }
            else if (walking == false)
            {
                timerActive = false;
            }


        }

        public void Update()
        {
            WalkAnimation();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.Y -= speed * Raylib.GetFrameTime();
                walking = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= speed * Raylib.GetFrameTime();
                walking = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.Y += speed * Raylib.GetFrameTime();
                walking = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += speed * Raylib.GetFrameTime();
                walking = true;
            }
            else if (!Raylib.IsKeyDown(KeyboardKey.KEY_D)
                && !Raylib.IsKeyDown(KeyboardKey.KEY_S)
                && !Raylib.IsKeyDown(KeyboardKey.KEY_A)
                && !Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                walking = false;
            }






        }

        public void Draw()
        {
            Raylib.DrawTexturePro(
            slimeTexture,
            new Rectangle(16 * frame, 0, 16, 16), // Source
            destRec = new Rectangle(position.X, position.Y, 64, 64), // Destination
            new Vector2(32, 32), // Origin
            rotation,
            Color.WHITE);

            hitbox = destRec;


        }


    }
}