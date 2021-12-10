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