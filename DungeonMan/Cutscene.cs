using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class Cutscene
    {
        Font f1 = Raylib.LoadFont(@"Olondona.otf");

        bool printing;

        List<Vector2> sizes = new List<Vector2>();
        List<string> prints = new List<string>();
        public void Print()
        {
            if (printing == true)
            {

                foreach (string print in prints)
                {
                    sizes.Add(Raylib.MeasureTextEx(f1, print, 150, 0));
                }


                foreach (Vector2 size in sizes)
                {
                    Raylib.DrawTextEx(f1, prints[sizes.IndexOf(size)], new Vector2(960 - size.X / 2, sizes.IndexOf(size) * 200 + 100), 150, 0, Color.RED);
                }


                printing = false;
            }
        }
        public void IntroCutscene()
        {

            Raylib.ClearBackground(Color.WHITE);

            prints.AddRange(new List<string>
            {
                "This is",
                "Dungeonman",
                "Hero of Kremoria",
                "Saviour of Time",
                "Slayer of Gargoroth"
            });
            printing = true;
            Print();

            DungeonMan c1 = new DungeonMan(250, 250);




        }
    }
}