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
        private Vector2 _motwPosition;


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
            //objTexture = cmngr.Load<Texture2D>("player1");
            //width = objTexture.Width;
            //height = objTexture.Height;

            //var spriteSheet = cmngr.Load<SpriteSheetAnimation>("motw.sf", new JsonContentLoader());
            //var sprite = new AnimatedSprite(spriteSheet);
            var spriteSheet = cmngr.Load<SpriteSheet>("motw.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("idle");
            _motwPosition = new Vector2(100, 100);
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
                _motwPosition.Y -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                animation = "walkSouth";
                _motwPosition.Y += walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "walkWest";
                _motwPosition.X -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                _motwPosition.X += walkSpeed;
            }

            position= _motwPosition;

            _motwSprite.Play(animation);

            _motwSprite.Update(deltaSeconds);


            //base.Update(gameTime);
            ////frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;
            //float totalSecond = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ////Debug.WriteLine(totalSecond);

            //KeyboardState keyboard_state = Keyboard.GetState();
            //Keys[] keymap = (Keys[])keyboard_state.GetPressedKeys();
            //foreach (Keys k in keymap)
            //{
            //    char key = k.ToString()[0];
            //    Debug.WriteLine(key);
            //    switch (key)
            //    {
            //        case 'a':
            //        case 'A':
            //        case 'l': //Left arrow
            //        case 'L':
            //            position.X -= this.velocity.X * totalSecond; //This will move X pixels in one second.
            //            //Debug.WriteLine(position.X);
            //            break;
            //        case 'd':
            //        case 'D':
            //        case 'r': //Left arrow
            //        case 'R':
            //            position.X += this.velocity.X * totalSecond;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            /* destRect = new Rectangle(
                     (int)position.X,
                     (int)position.Y,
                     objTexture.Width, objTexture.Height);

             _spriteBatch.Draw(
                 objTexture,
                 destRect,
                 Color.White
               ); */
            _spriteBatch.Draw(_motwSprite, _motwPosition);
        }
    }
}
