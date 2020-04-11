using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TryToAvoid.Classes
{
    class GameOver
    {
        private SpriteFont spriteFont;
        private string score = "0";
        
        public string Score { get { return score; } set { score = value; } }

        public void LoadContent(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string info = "Game Over";
            string info2 = "Press Esc to continue";


            spriteBatch.DrawString(spriteFont, info, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(spriteFont, score, new Vector2(100, 150), Color.White);
            spriteBatch.DrawString(spriteFont, info2, new Vector2(100, 200), Color.White);
        }
    }
}
