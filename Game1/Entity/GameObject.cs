

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Entity
{
    public abstract class GameObject
    {
        public Texture2D objTexture;
        public Vector2 position;

        public abstract void loadContent(ContentManager cmngr);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch _spriteBatch);

       
    }

  
}
