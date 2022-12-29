using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using MonoGame.Extended.Sprites;
using System;

namespace Game1.Entity
{
    public class Player : GameObject
    {
        private AnimatedSprite _motwSprite;
        //private Vector2 _motwPosition;


        //Texture2D playerTexture;
        private int hp = 0;

        public int Hp { get => hp; set => hp = value; }

        public Player(String n, Vector2 pos, Vector2 vel, int hp)
        {
            Name = n;
            position = pos;
            velocity = vel;
            Hp = hp;
        }


        public override void loadContent(ContentManager cmngr)
        {
            var spriteSheet = cmngr.Load<SpriteSheet>("motw.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("idle");
            _motwSprite = sprite;
        }

        public override void Update(GameTime gameTime)
        {

            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var walkSpeed = deltaSeconds * 128;
            var keyboardState = Keyboard.GetState();
            var animation = "idle";

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                animation = "walkNorth";
                position.Y -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                animation = "walkSouth";
                position.Y += walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "walkWest";
                position.X -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                position.X += walkSpeed;
            }

            _motwSprite.Play(animation);

            _motwSprite.Update(deltaSeconds);


        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_motwSprite, position);
        }
    }
}
