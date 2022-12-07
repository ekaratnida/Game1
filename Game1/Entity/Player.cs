using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Game1.Entity
{
    public class Player : GameObject
    {

        //Texture2D playerTexture;
        Vector2 speed;

        public Player(Vector2 pos, Vector2 speed)
        {
            position = pos;
            this.speed = speed;
            
        }

        public override void loadContent(ContentManager cmngr)
        {
            objTexture = cmngr.Load<Texture2D>("player1");
        }

        public override void Update(GameTime gameTime)
        {
            //frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;
            float totalSecond = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Debug.WriteLine(totalSecond);


            KeyboardState keyboard_state = Keyboard.GetState();
            Keys[] keymap = (Keys[])keyboard_state.GetPressedKeys();
            foreach (Keys k in keymap)
            {

                char key = k.ToString()[0];
                Debug.WriteLine(key);
                switch (key)
                {
                    case 'a':
                    case 'A':
                    case 'l': //Left arrow
                    case 'L':
                        position.X -= this.speed.X * totalSecond; //This will move X pixels in one second.
                        //Debug.WriteLine(position.X);
                        break;
                    case 'd':
                    case 'D':
                    case 'r': //Left arrow
                    case 'R':
                        position.X += this.speed.X * totalSecond;
                        break;
                    default:
                        break;
                }

            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(
                objTexture,
                new Rectangle(
                    (int)position.X - objTexture.Width / 8 / 2,
                    (int)position.Y + 200,
                    objTexture.Width / 8, objTexture.Height / 8),
                    Color.White
              );
        }

      
    }
}
