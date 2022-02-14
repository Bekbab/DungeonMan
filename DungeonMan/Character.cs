using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace DungeonMan
{
    public class Character
    {
        // protected Vector2 position = new Vector2();
        protected float speed = 150;
        protected float rotation = 360;

        public bool walking;

        protected Rectangle destRec;
        public Vector2 position;

        public Rectangle hitbox;
        protected Timer t1 = new Timer();

        protected float delay; //how often the sprite should update

        protected Vector2 origin;

        protected int frames; //how many frames it's sprite has
    }
}