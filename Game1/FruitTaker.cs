using Game1.Control;
using Game1.Entity;
using Game1.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Game1
{
    public class FruitTaker : Game
    {
        SpriteFont font1;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        Fruit fruit;

        int screenWidth = 1024;
        int screenHeight = 768;

        public FruitTaker()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player(
                    new Vector2(screenWidth/2, screenHeight/2),
                    new Vector2(200,0)
                );
            fruit = new Fruit(
                    new Vector2(0, screenHeight / 3),
                    new Vector2(0, 100),
                    FruitType.good
                );
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
          
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font1 = Content.Load<SpriteFont>("tileFont");

            player.loadContent(Content);
            fruit.loadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            fruit.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (System.Diagnostics.Debugger.IsAttached)
                _spriteBatch.DrawString(font1, "Test Font", new Vector2(10, 10), Color.DarkRed);

            player.Draw(_spriteBatch);

            fruit.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}