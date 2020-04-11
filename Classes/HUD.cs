using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TryToAvoid.Classes
{
    class HUD
    {
        private int playerScore;
        private Vector2 playerScorePosition;
        private SpriteFont playerScoreFont;
        private bool showHUD;

        public int PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }

        public HUD()
        {
            
            playerScore = 0;
            showHUD = true;
            playerScoreFont = null;
            playerScorePosition = new Vector2(800 / 2, 50);
        }

        public void LoadContent(ContentManager content)
        {
            playerScoreFont = content.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (showHUD)
            {
                spriteBatch.DrawString(playerScoreFont,
                    "Score: " + playerScore, playerScorePosition, Color.White);
            }
        }

        public void Update(int playerScore)
        {
            this.playerScore = playerScore;
        }


    }
}
