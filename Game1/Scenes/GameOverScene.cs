﻿using Game1.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1.Scenes
{
    public class GameOverScene : BaseScene
    {
        Button button;
       
        public GameOverScene(String name)
        {
            Name = name;
            button = new Button(2,
                new string[] { "main_menu", "exit" },
                new MyDelegate[] {
                        (Game game) => {
                             MainGame.currentState = GameState.MainMenu;
                        },
                        (Game game) =>  {
                            Console.WriteLine("Exit");
                            game.Exit();
                        }

                    }
                );
        }

        public override void init(GameWindow window, Game game)
        {
            button.init(window, game);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                objTexture,
                Vector2.Zero,
                Color.White
           );

           button.draw(_spriteBatch);

        }

        public override void loadContent(ContentManager cmngr)
        {
            objTexture = cmngr.Load<Texture2D>("GameOverBG");
            button.loadContent(cmngr);
        }

        public override void Update(GameTime gameTime)
        {
            button.update(gameTime);
        }
    }
}
