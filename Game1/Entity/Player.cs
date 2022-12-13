using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Collisions;
using System;
using System.Diagnostics;

namespace Game1.Entity
{
    public class Player : GameObject
    {

        CollisionComponent collision;

        //Texture2D playerTexture;
        
        public Player(String n, Vector2 pos, Vector2 vel)
        {
            name = n;
            position = pos;
            velocity = vel;
          

        }

        public override void loadContent(ContentManager cmngr)
        {
            objTexture = cmngr.Load<Texture2D>("player1");
            width = objTexture.Width;
            height = objTexture.Height;
        }

        public override void Update(GameTime gameTime)
        {
            //frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;
            float totalSecond = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Debug.WriteLine(totalSecond);


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
                        position.X -= this.velocity.X * totalSecond; //This will move X pixels in one second.
                        //Debug.WriteLine(position.X);
                        break;
                    case 'd':
                    case 'D':
                    case 'r': //Left arrow
                    case 'R':
                        position.X += this.velocity.X * totalSecond;
                        break;
                    default:
                        break;
                }
            }

            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            destRect = new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    objTexture.Width, objTexture.Height);

            _spriteBatch.Draw(
                objTexture,
                destRect,
                Color.White
              );
        }

       

      
    }
}
