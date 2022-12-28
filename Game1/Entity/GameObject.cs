using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Entity
{
    public abstract class GameObject
    {

        public enum CollisionStatus
        {
           Enter,
           Stay,
           Exit,
           None
        }

        public Texture2D objTexture;
        public Vector2 position;
        public int width;
        public int height; 
        public Vector2 velocity;
        private string name;
        public Rectangle destRect;
        private CollisionStatus collisionStatus;

        public string Name { get => name; set => name = value; }
        public CollisionStatus CollisionStatus1 { get => collisionStatus; set => collisionStatus = value; }

        public abstract void loadContent(ContentManager cmngr);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch _spriteBatch);

       
    }

  
}
