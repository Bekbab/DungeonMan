using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class Cutscene
    {
        // Font f1 = Raylib.LoadFont(@"Olondona.otf");
        Font f1 = Raylib.LoadFontEx("Olondona.otf", 30, null, -1);

        Sound splat = Raylib.LoadSound("splat.ogg");
        Sound music = Raylib.LoadSound("music.ogg");
        Texture2D boot = Raylib.LoadTexture("Boot.png");

        bool printing;

        List<Vector2> sizes = new List<Vector2>();
        List<string> prints = new List<string>();

        Timer t2 = new Timer();

        bool listFull;

        public bool running = true;

        public int part = 1;

        float printTime;
        bool soundplayed1 = false;
        bool soundplayed2 = false;

        Slime s1;
        DungeonMan d1;
        public Cutscene()
        {
            s1 = new Slime(1670, 250);
            d1 = new DungeonMan(250, 250, s1, false);
        }


        public void Print()
        {
            if (printing)
            {

                foreach (string print in prints)
                {
                    sizes.Add(Raylib.MeasureTextEx(f1, print, 150, 0));
                }

                printTime = prints.Count * 2;

                t2.StartTimer(printTime);

                if (t2.timerEnd == true)
                {

                    prints.Clear();
                    sizes.Clear();
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
            if (!soundplayed1)
            {
                if (!Raylib.IsSoundPlaying(music))
                {
                    Raylib.PlaySound(music);
                    soundplayed1 = true;
                }
            }

            if (prints.Count < 1 && sizes.Count < 1)
            {
                listFull = false;
            }
            else
            {
                listFull = true;
            }

            Raylib.ClearBackground(Color.WHITE);

            // Raylib.DrawText($"{t2.timer}", 100, 100, 20, Color.BLACK);
            // Raylib.DrawText($"{prints.Count}", 100, 200, 20, Color.BLACK);
            // Raylib.DrawText($"{part}", 100, 300, 20, Color.BLACK);
            // Raylib.DrawText($"{s1.walking}", 100, 400, 20, Color.BLACK);
            if (part == 1)
            {
                if (!listFull)
                {
                    prints.AddRange(new List<string>
                    {
                        "This is",
                        "Dungeonman",
                        "Hero of Kremoria",
                        "Saviour of Time",
                        "Slayer of Gargoroth"
                    });
                }
                printing = true;
                Print();
                d1.WalkAnimation();
                d1.Draw();

            }

            if (part == 2)
            {


                if (!listFull)
                {
                    prints.AddRange(new List<string>
                    {
                        "You are",
                        "NOT",
                        "Dungeonman",
                    });
                }

                printing = true;
                Print();
                d1.WalkAnimation();
                d1.Draw();

            }

            if (part == 3)
            {


                if (!listFull)
                {
                    prints.AddRange(new List<string>
                    {
                        "You are",
                        "A level 1 slime",
                        "Just another obstacle",
                        "In Dungeonmans",
                        "Quest for glory"
                    });
                }

                printing = true;
                Print();
                d1.WalkAnimation();
                s1.Update();
                d1.Draw();
                s1.Draw();
            }

            if (printing == false)
            {
                part += 1;
            }

            if (part > 3)
            {
                Raylib.StopSound(music);
                Program.window = 1;
            }
        }

        public void GameOverCutscene()
        {
            Raylib.ClearBackground(Color.DARKGRAY);
            Raylib.DrawTextureEx(boot, new Vector2((Raylib.GetScreenWidth() / 2) - boot.width, 0), 0, 2, Color.WHITE);
            Raylib.DrawTextEx(f1, "You", new Vector2(100, 150), 250, 0, Color.RED);
            Raylib.DrawTextEx(f1, "Died", new Vector2(1100, 150), 250, 0, Color.RED);

            if (!soundplayed2)
            {
                if (!Raylib.IsSoundPlaying(splat))
                {
                    Raylib.PlaySound(splat);
                    soundplayed2 = true;
                }
            }
        }
    }
}