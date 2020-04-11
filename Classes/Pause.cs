using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TryToAvoid.Classes
{
    class Pause
    {
        private KeyboardState keyboard;
        private KeyboardState prevKeyboard;
        private SpriteFont spriteFont;
        private List<string> buttonList;
        private int selected;
        private string prevGameState;

        public string  PrevGameState { set { prevGameState = value; } }

        public Pause()
        {
            buttonList = new List<string>();
            selected = 0;

            buttonList.Add("Continue");
            buttonList.Add("Choose Difficulty");
            buttonList.Add("Exit");
        }

        public void LoadContent(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("GameFont");
        }

        public void Update(GameTime gameTime)
        {

            keyboard = Keyboard.GetState();


            if (keyboard.IsKeyDown(Keys.S))
            {
                if (keyboard != prevKeyboard)
                {
                    if (selected < buttonList.Count - 1)
                    {
                        selected++;
                    }
                }
            }


            if (keyboard.IsKeyDown(Keys.W))
            {
                if (keyboard != prevKeyboard)
                {
                    if (selected > 0)
                    {
                        selected--;
                    }
                }
            }


            if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (selected)
                {
                    case 0:
                        if (prevGameState == "Easy")
                        {
                            Game1.gameState = GameState.EasyDifficulty;
                        }
                        else if (prevGameState == "Medium")
                        {
                            Game1.gameState = GameState.MediumDifficulty;
                        }
                        else if (prevGameState == "Hard")
                        {
                            Game1.gameState = GameState.HardDifficulty;
                        }


                        break;
                    case 1:
                        Game1.gameState = GameState.ChooseDifficulty;
                        break;
                    case 2:
                        Game1.gameState = GameState.GameOver;
                        break;
                }
            }

            prevKeyboard = keyboard;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color;

            for (int i = 0; i < buttonList.Count; i++)
            {

                if (i == selected)
                {
                    color = Color.Yellow;
                }
                else
                {
                    color = Color.White;
                }

                Vector2 pausePosition = new Vector2(
                    800 / 2 - (spriteFont.MeasureString(buttonList[i]).X / 2),
                    600 / 2 - (spriteFont.LineSpacing * buttonList.Count / 2) +
                            ((spriteFont.LineSpacing + 5) * i)
                );


               

                spriteBatch.DrawString(spriteFont, buttonList[i],
                      pausePosition, color);

                spriteBatch.DrawString(spriteFont, "Game paused", new Vector2(355,500) , Color.White);

            }

        }
    }
}
