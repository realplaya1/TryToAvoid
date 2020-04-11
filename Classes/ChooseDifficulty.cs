using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TryToAvoid.Classes
{
    class ChooseDifficulty
    {
        private KeyboardState keyboard;
        private KeyboardState prevKeyboard;
        private SpriteFont spriteFont;
        private List<string> buttonList;
        private int selected;


       

        
        public ChooseDifficulty()
        {
            buttonList = new List<string>();
            selected = 0;

            buttonList.Add("Easy");
            buttonList.Add("Normal");
            buttonList.Add("Hard");
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


            if (keyboard.IsKeyDown(Keys.Space))
            {
                switch (selected)
                {
                    case 0:
                        Game1.gameState = GameState.EasyDifficulty;

                        break;
                    case 1:
                        Game1.gameState = GameState.MediumDifficulty;
                        break;
                    case 2:
                        Game1.gameState = GameState.HardDifficulty;
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

                Vector2 vectorCtrl = new Vector2(100, 290);

                Vector2 diffPosition = new Vector2(
                    800 / 2 - (spriteFont.MeasureString(buttonList[i]).X / 2),
                    600 / 2 - (spriteFont.LineSpacing * buttonList.Count / 2) +
                            ((spriteFont.LineSpacing + 5) * i)
                );

                spriteBatch.DrawString(spriteFont, buttonList[i],
                      diffPosition, color);

                spriteBatch.DrawString(spriteFont, "Press Space to choose difficulty", vectorCtrl, Color.White);

            }

        }

        
    }
}

