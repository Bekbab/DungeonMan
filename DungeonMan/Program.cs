using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    class Program
    {
        public static int window = 0;
        static void Main(string[] args)
        {
            Raylib.InitWindow(1920, 1080, "DUNGEONMAN!");
            Raylib.SetTargetFPS(60);

            Cutscene c1 = new Cutscene();
            Game g = new Game();




            while (!Raylib.WindowShouldClose() && window == 0)
            {
                Raylib.BeginDrawing();
                c1.IntroCutscene();
                Raylib.EndDrawing();
            }

            while (!Raylib.WindowShouldClose() && window == 1)
            {
                Raylib.BeginDrawing();
                g.Play();
                Raylib.EndDrawing();
            }

            while (!Raylib.WindowShouldClose() && window == 2)
            {
                
            }





        }
    }
}
