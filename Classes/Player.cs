using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TryToAvoid.Classes
{
    class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private int score;

        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }

        public int Score { get { return score; } set { score = value; } }

        public Vector2 Position {  get { return position; } }

        public Player()
        {
            position = new Vector2(800 / 2 - 30, 600);
            texture = null;
            speed = 6;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ship2");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        
        public void Update(GameTime gameTime)
        {
      
            KeyboardState keyState = Keyboard.GetState();

            
            
            if (keyState.IsKeyDown(Keys.A))
            {
                position.X = position.X - speed;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                position.X = position.X + speed;
            }

            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= 800 - texture.Width)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y >= 600 - texture.Height)
            {
                position.Y = 600 - texture.Height;
            }

            
            boundingBox = new Rectangle((int)position.X,
                (int)position.Y, texture.Width, texture.Height);
        }

        public void Reset()
        {
            score = 0;
            position = new Vector2(800 / 2 - 30, 600);
            
        }

        public void IncreaseScore(int value)
        {
            score += value;

            if (score >= 2000)
            {
                score = 2000;
            }
        }

    }
}
