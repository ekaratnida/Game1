using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Entity
{
    public enum FruitType
    {
        Apple,
        Toxic
    }

    public class Fruit : GameObject
    {

        //Texture2D playerTexture;
        Vector2 speed;
        FruitType type;

        public Fruit(Vector2 pos, Vector2 speed, FruitType type)
        {
            position = pos;
            this.speed = speed;
            this.type = type;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            //throw new NotImplementedException();

            Rectangle? rect = null;
            if (this.type == FruitType.Apple)//Good apple
            {
                rect = new Rectangle(0, 0, objTexture.Width, objTexture.Height/2);
            }
            else
            {
                rect = new Rectangle(0, objTexture.Height/2, objTexture.Width, objTexture.Height/2);
            }

            _spriteBatch.Draw(
              objTexture,
              new Rectangle(
                  (int)position.X,
                  (int)position.Y,
                  objTexture.Width, 
                  objTexture.Height/2),
              rect,
              Color.White
            );
        }

        public override void loadContent(ContentManager cmngr)
        {
            //throw new NotImplementedException();

            objTexture = cmngr.Load<Texture2D>("Fruit");
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
            float totalSecond = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += this.speed.Y * totalSecond;
        }
    }
}
