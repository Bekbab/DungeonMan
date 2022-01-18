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

        Timer t2 = new Timer();

        public bool running = true;

        public int part = 1;
        public void Print()
        {
            if (printing)
            {

                foreach (string print in prints)
                {
                    sizes.Add(Raylib.MeasureTextEx(f1, print, 150, 0));
                }

                t2.StartTimer(prints.Count);

                if (t2.timerEnd == true)
                {
                    part = 2;
                    printing = false;
                }
                else
                {
                    for (int i = 0; i * 2 < t2.timer && i < prints.Count; i++)
                    {
                        Raylib.DrawTextEx(f1, prints[i], new Vector2(960 - sizes[i].X / 2, i * 200 + 100), 150, 0, Color.RED);
                    }
                }





            }

        }

        public void IntroCutscene()
        {

            Raylib.ClearBackground(Color.WHITE);

            if (part == 1)
            {
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
            }


            if (part == 2 && printing == false)
            {
                DungeonMan c1 = new DungeonMan(250, 250);
                prints.Clear();
                sizes.Clear();

                prints.AddRange(new List<string>
                {
                    "You are",
                    "NOT",
                    "Dungeonman",
                });

                printing = true;
            }

        }
    }
}