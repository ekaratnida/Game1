﻿using Game1.Entity;
using Game1.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        GameOver,
        ClearGame
    }

    public class MainGame : Game
    {
       //Game state
        public static GameState currentState;

        //Scene
        MainScene mainScene;
        GameOverScene gameOverScene;
        ClearGameScene clearGameScene;

        //Game entities
        Player player;
        List<Fruit> fruits = new List<Fruit>(10);

        //Game window elements
        SpriteFont font1;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static readonly int screenWidth = 1024;
        public static readonly int screenHeight = 768;
        FruitType[] fruitTypes;
        int numFruits;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            MainGame.currentState = GameState.MainMenu;

            //Scene
            mainScene = new MainScene("MainMenuScene");
            gameOverScene = new GameOverScene("GameOverScene");
            clearGameScene = new ClearGameScene("ClearGameScene");

            player = new Player(
                    "Arthur",
                    new Vector2(screenWidth/2, screenHeight-100),
                    new Vector2(200,0),
                    3
                );

            numFruits = 10;
            
            fruitTypes = new FruitType[]{ FruitType.Apple, FruitType.Toxic };
            
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

            mainScene.init(Window,this);
            gameOverScene.init(Window, this);
            clearGameScene.init(Window, this);
          
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mainScene.loadContent(Content);
            gameOverScene.loadContent(Content);
            clearGameScene.loadContent(Content);

            font1 = Content.Load<SpriteFont>("tileFont");
            
            player.loadContent(Content);

            for (int i = 0; i < fruits.Count - 1; ++i)
            {
                fruits[i].loadContent(Content);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (currentState == GameState.MainMenu)
            {
                mainScene.Update(gameTime);
            }
            else if (currentState == GameState.Playing)
            {

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


                        if (fruits[i].type == FruitType.Apple)
                        {
                            //fruits[i].velocity = Vector2.Zero;
                            fruits[i] = null;
                            fruits.RemoveAt(i);
                            Scores.Score += 1;

                            if ( Scores.Score >= 3)
                            {
                                Scores.Score = 0;
                                player.Hp = 3;
                                player.position = new(screenWidth / 2, screenHeight - 100);
                                player.velocity = new(200, 0);

                                for(int fc = 0; fc < fruits.Count; fc++)
                                {
                                    fruits[fc] = null;
                                }

                                fruits.Clear();

                                for (int f = 0; f < numFruits; ++f)
                                {
                                    Fruit fruit = new Fruit(
                                      "fr_" + f,
                                      new Vector2(new Random().Next(screenWidth), 0),
                                      new Vector2(0, new Random().Next(100) + 100),
                                      fruitTypes[new Random().Next(0, fruitTypes.Length)]
                                    );

                                    fruit.loadContent(Content);

                                    //Debug.WriteLine(fruit.position);
                                    fruits.Add(fruit);
                                }


                                currentState = GameState.ClearGame;
                            }
                        }
                        else
                        {
                            if (fruits[i].CollisionStatus1 == GameObject.CollisionStatus.Enter)
                            {
                                if (player.Hp > 0)
                                {
                                    player.Hp--;
                                }

                                //player die, reset
                                if (player.Hp == 0)
                                {
                                    Scores.Score = 0;
                                    player.Hp = 3;
                                    player.position = new(screenWidth / 2, screenHeight - 100);
                                    player.velocity = new(200, 0);

                                    for (int fc = 0; fc < fruits.Count; fc++)
                                    {
                                        fruits[fc] = null;
                                    }

                                    fruits.Clear();

                                    for (int f = 0; f < numFruits; ++f)
                                    {
                                        Fruit fruit = new Fruit(
                                          "fr_" + f,
                                          new Vector2(new Random().Next(screenWidth), 0),
                                          new Vector2(0, new Random().Next(100) + 100),
                                          fruitTypes[new Random().Next(0, fruitTypes.Length)]
                                        );

                                        fruit.loadContent(Content);

                                        //Debug.WriteLine(fruit.position);
                                        fruits.Add(fruit);
                                    }

                                    currentState = GameState.GameOver;
                                }
                            }
                            //Debug.WriteLine(fruits[i].Name);

                        }
                    }
                    else
                    {
                        fruits[i].CollisionStatus1 = GameObject.CollisionStatus.None;
                    }
                }

            }
            else if ( currentState == GameState.GameOver )
            {
                gameOverScene.Update(gameTime);
            }
            else if ( currentState == GameState.ClearGame )
            {
                clearGameScene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (currentState == GameState.MainMenu)
            {
                mainScene.Draw(_spriteBatch);
            }
            else if (currentState == GameState.Playing)
            {

                //if (System.Diagnostics.Debugger.IsAttached)
                //Draw score
                _spriteBatch.DrawString(font1, "Score = " + Scores.Score, new Vector2(10, 10),
                    Color.Blue, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

                //Draw life
                _spriteBatch.DrawString(font1, "Life = " + player.Hp, new Vector2(10, 50),
                   Color.Red, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

                player.Draw(_spriteBatch);

                for (int i = 0; i < fruits.Count - 1; ++i)
                {
                    if (fruits[i] != null)
                    {
                        fruits[i].Draw(_spriteBatch);
                    }
                }

            }
            else if ( currentState == GameState.GameOver )
            {
                gameOverScene.Draw(_spriteBatch);
            }
            else if ( currentState == GameState.ClearGame )
            {
                clearGameScene.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}