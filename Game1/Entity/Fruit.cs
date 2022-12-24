using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;

namespace Game1.Entity
{
    public enum FruitType
    {
        Apple,
        Toxic
    }

    public class Fruit : GameObject
    {

        public FruitType type;
        public bool isVisible;

        public Fruit(String n, Vector2 pos, Vector2 speed, FruitType type)
        {
            Name = n;
            position = pos;
            velocity = speed;
            this.type = type;
            this.isVisible = true;
        }

        public override void loadContent(ContentManager cmngr)
        {
            //throw new NotImplementedException();

            objTexture = cmngr.Load<Texture2D>("Fruit");
            width = objTexture.Width;
            height = objTexture.Height / 2;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            //throw new NotImplementedException();

            if (objTexture != null)
            {
                Rectangle? srcRect = null;
                if (this.type == FruitType.Apple)//Good apple
                {
                    srcRect = new Rectangle(0, 0, objTexture.Width, objTexture.Height / 2);
                }
                else
                {
                    srcRect = new Rectangle(0, objTexture.Height / 2, objTexture.Width, objTexture.Height / 2);
                }

                destRect = new Rectangle(
                      (int)position.X,
                      (int)position.Y,
                      objTexture.Width,
                      objTexture.Height / 2);

                _spriteBatch.Draw(
                  objTexture,
                  destRect,
                  srcRect, //sourceRect
                  Color.White
                );
            }
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
            float totalSecond = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += this.velocity.Y * totalSecond;
            
            if (position.Y > MainGame.screenHeight)
            {
                position.Y = 0;
            }
        }
    }
}
