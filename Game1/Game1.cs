using Game1.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Game1
{
    public class Game1 : Game
    {

       
        Texture2D tileTexture;
        Texture2D playerTexture;
        SpriteFont font1;
       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D SimpleTexture; // = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);

        Int32[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
       

        // Global variables
        Button button;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            button = new Button();
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 400;
           
            SimpleTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            SimpleTexture.SetData<Int32>(pixel, 0, SimpleTexture.Width * SimpleTexture.Height);

            //GUI
            button.init(Window, this);
            

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //ballTexture = Content.Load<Texture2D>("ball");
            tileTexture = Content.Load<Texture2D>("tile1");
            font1 = Content.Load<SpriteFont>("tileFont");
            player1Texture = Content.Load<Texture2D>("player1");
            player2Texture = Content.Load<Texture2D>("player2");

            button.loadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            button.update(gameTime);

            base.Update(gameTime);
        }

      

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            Vector2 offsetVec = new Vector2(140, 100);
            float scaleMultiply = 2.0f;
            int nCol = 8;
            int nRow = 4;

            _spriteBatch.Begin();

            button.draw(_spriteBatch);

            for (int c = 0; c < nCol; ++c)
            {
                for ( int r = 0; r < nRow; ++r )
                {
                    if ((c > 0 && c < nCol-1) && (r > 0 && r < nRow-1)) continue;

                    Vector2 tPos = new Vector2(
                            c * 33 * scaleMultiply,
                            r * 33 * scaleMultiply
                            ) + offsetVec;

                    _spriteBatch.Draw(
                        tileTexture,
                        tPos,
                        null,
                        Color.White,
                        0.0f,
                        Vector2.Zero,
                        scaleMultiply,
                        SpriteEffects.None,
                        0f
                    );

                    if (System.Diagnostics.Debugger.IsAttached)
                        _spriteBatch.DrawString(font1, "[" + c + "," + r + "]", tPos + new Vector2(10,10), Color.Black);

                }
            }

            _spriteBatch.Draw(
                    player1Texture,
                    new Vector2(20,150),
                    null,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    0.1f,
                    SpriteEffects.None,
                    0f
                );

            _spriteBatch.Draw(
                 player2Texture,
                 new Vector2(20, 280),
                 null,
                 Color.White,
                 0.0f,
                 Vector2.Zero,
                 0.1f,
                 SpriteEffects.None,
                 0f
             );

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}