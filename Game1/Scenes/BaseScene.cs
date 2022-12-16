using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Scenes
{
    public abstract class BaseScene
    {
        public Texture2D objTexture;
        public Vector2 position;
        public int width;
        public int height;
        public Vector2 velocity;
        private string name;
        
        public string Name { get => name; set => name = value; }

        public abstract void init(GameWindow window, Game game);

        public abstract void loadContent(ContentManager cmngr);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch _spriteBatch);
    }
}
