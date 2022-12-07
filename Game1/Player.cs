using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Player
    {

        Texture2D playerTexture;
        Vector2 position;
        public Player(int posX, int posY) 
        {
            position.X = posX;
            position.Y = posY;
        }

        public void loadContent(ContentManager cmngr)
        {
           playerTexture = cmngr.Load<Texture2D>("player1");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(
                playerTexture,
                new Rectangle(
                    (int)position.X-(playerTexture.Width / 8 / 2),
                    (int)position.Y+200,
                    playerTexture.Width/8,playerTexture.Height/8),
                    Color.White
              );
        }
    }
}
