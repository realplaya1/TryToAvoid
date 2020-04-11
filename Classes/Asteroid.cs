using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TryToAvoid.Classes
{
    class Asteroid
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private bool isVisible;

        public int Speed { get { return speed; }
            set { speed = value; } }
        
        private Rectangle boundingBox;

        
        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Asteroid()
        {
            texture = null;
            position = new Vector2(100, 100);
            speed = 5;
            isVisible = true;
        }

        public Asteroid(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
            speed = 5;
            isVisible = true;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid4");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public void Update()
        {
            position.Y = position.Y + speed;

            if (position.Y >= 700)
            {
                IsVisible = false;
            }

            
            boundingBox = new Rectangle(
                (int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }
    }
}

