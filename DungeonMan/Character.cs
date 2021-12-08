using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class Character
    {
        protected Vector2 position = new Vector2(960, 540);
        protected float speed = 150;
        protected float rotation = 360;

        protected float timer = 0.0f;

        protected bool timerActive;

        protected int frame = 0;

        protected bool walking;

        protected Rectangle destRec;
        protected Rectangle hitbox;
    }
}