using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TryToAvoid.Classes
{
    class Background
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;
        private int speed;

        public int Speed
        {
            set
            {
                if (value >= 0 && value <= 20)
                {
                    speed = value;
                }
                else
                {
                    speed = 3;
                }
            }
        }

        public Background()
        {
            texture = null;
            position1 = new Vector2(0, 0);
            position2 = new Vector2(0, -950);
            speed = 3;
        }

       
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("space");
        }

      
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }

        
        public void Update(GameTime gameTime)
        {
            position1.Y = position1.Y + speed;
            position2.Y = position2.Y + speed;

            if (position1.Y >= 950)
            {
                position1.Y = 0;
                position2.Y = -950;
            }
        }
    }
}
