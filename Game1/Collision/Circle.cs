
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1.Collision
{
    public class Circle
    {
        private static readonly Random _r = new Random();
        private readonly Texture2D _texture;
        public Vector2 origin { get; }
        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
        public int speed { get; set; }
        public Color Color { get; set; }

        private static Vector2 RandomPosition()
        {
            return new Vector2();
        }

        private static Vector2 RandomDirection()
        {
            var angle = _r.NextDouble() * 2 * Math.PI;
            return new Vector2((float)Math.Sin(angle), -(float)Math.Cos(angle));
        }

        public Circle(Texture2D tex) 
        { 
            _texture = tex;
            this.origin = new(tex.Width/2,tex.Height/2);
            this.position = RandomPosition();
            this.direction = RandomDirection();
            this.speed = 200;
            this.Color = Color.White;
        }

        public void Update()
        {
            //position += direction * speed * 
        }
    }
}
