using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scenes
{
    public class MainScene : BaseScene
    {
        
        public MainScene(String name) {
            Name = name;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                objTexture,
                Vector2.Zero,
                Color.White
           );

        }

        public override void loadContent(ContentManager cmngr)
        {
            objTexture = cmngr.Load<Texture2D>("MainBackground");
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
