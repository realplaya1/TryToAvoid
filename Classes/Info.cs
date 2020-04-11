using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TryToAvoid.Classes
{
    class Info
    {
        SpriteFont spriteFont;


        public void LoadContent(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            

            string controlsA = "A - Left";
            Vector2 vectorA = new Vector2(100, 130);

            string controlsD = "D - Right";
            Vector2 vectorD = new Vector2(100, 190);

            string controlsExit = "Press Esc to quit";
            Vector2 vectorExit = new Vector2(100,290);

            spriteBatch.DrawString(spriteFont, controlsA, vectorA, Color.White);
            spriteBatch.DrawString(spriteFont, controlsD, vectorD, Color.White);
            spriteBatch.DrawString(spriteFont, controlsExit, vectorExit, Color.White);





        }
    }
}
