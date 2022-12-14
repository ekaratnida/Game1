using Game1.Control;
using Game1.Entity;
using Game1.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Game1
{
    public class MainGame : Game
    {
        SpriteFont font1;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        //Fruit fruit;
        List<Fruit> fruits = new List<Fruit>(10);

        public static readonly int screenWidth = 1024;
        public static readonly int screenHeight = 768;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            player = new Player(
                    "Arthur",
                    new Vector2(screenWidth/2, screenHeight-100),
                    new Vector2(200,0),
                    3
                );

            int numFruits = 10;
            FruitType[] fruitTypes = { FruitType.Apple, FruitType.Toxic};
            for(int i=0; i < numFruits; ++i)
            {
                Fruit fruit = new Fruit(
                  "fr_"+i,
                  new Vector2(new Random().Next(screenWidth), 0),
                  new Vector2(0, new Random().Next(100)+100),
                  fruitTypes[new Random().Next(0,fruitTypes.Length)]
                );
                //Debug.WriteLine(fruit.position);
                fruits.Add( fruit );
            }
          
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
            for(int i=0; i < fruits.Count-1; ++i)
                fruits[i].loadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            for (int i = 0; i < fruits.Count - 1; ++i)
            {
                fruits[i].Update(gameTime);

                Rectangle playerRect = new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height);
                Rectangle fruitRect = new Rectangle((int)fruits[i].position.X, (int)fruits[i].position.Y, fruits[i].width, fruits[i].height);

                if (playerRect.Intersects(fruitRect))
                {
                    if (fruits[i].CollisionStatus1 == GameObject.CollisionStatus.None)
                        fruits[i].CollisionStatus1 = GameObject.CollisionStatus.Enter;
                    else if (fruits[i].CollisionStatus1 == GameObject.CollisionStatus.Enter)
                        fruits[i].CollisionStatus1 = GameObject.CollisionStatus.Stay;
                    //else if (fruits[i].CollisionStatus1 == GameObject.CollisionStatus.Stay)
                    //    fruits[i].CollisionStatus1 = GameObject.CollisionStatus.Enter;


                    if (fruits[i].type == FruitType.Apple) {
                        //fruits[i].velocity = Vector2.Zero;
                        fruits[i] = null;
                        fruits.RemoveAt(i);
                        Scores.Score += 1;
                    }
                    else
                    {
                        if (fruits[i].CollisionStatus1 == GameObject.CollisionStatus.Enter)
                        {
                            if (player.Hp > 0)
                                player.Hp--;
                        }
                        //Debug.WriteLine(fruits[i].Name);
                       
                    }
                }
                else
                {
                    fruits[i].CollisionStatus1 = GameObject.CollisionStatus.None;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //if (System.Diagnostics.Debugger.IsAttached)
            //Draw score
            _spriteBatch.DrawString(font1, "Score = "+Scores.Score, new Vector2(10, 10), 
                Color.Blue,0,Vector2.Zero,1.5f,SpriteEffects.None,0);

            //Draw life
            _spriteBatch.DrawString(font1, "Life = " + player.Hp, new Vector2(10, 50),
               Color.Red, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

            player.Draw(_spriteBatch);

            for (int i = 0; i < fruits.Count - 1; ++i)
                fruits[i].Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}