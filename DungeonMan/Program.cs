using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Raylib.InitWindow(1920, 1080, "DUNGEONMAN!");

            Slime s = new Slime();
            DungeonMan d = new DungeonMan(450, 450);
            Cutscene c1 = new Cutscene();

            Raylib.SetTargetFPS(60);


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                c1.IntroCutscene();

                // Raylib.ClearBackground(Color.WHITE);
                // s.Update();
                // s.Draw();
                // d.Draw();
                Raylib.EndDrawing();

            }





        }
    }
}
