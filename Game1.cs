using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TryToAvoid.Classes;
using System.Collections.Generic;
using System;
public enum GameState
{
    Menu, Playing, Info, Exit, GameOver, ChooseDifficulty, EasyDifficulty, MediumDifficulty, HardDifficulty, Pause
}
namespace TryToAvoid
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background = new Background();
        Player player = new Player();
        public static GameState gameState = GameState.Menu;

        Random random = new Random();
        List<Asteroid> asteroidList = new List<Asteroid>();

        Pause pause = new Pause();
        Menu mainMenu = new Menu();
        Info info = new Info();
        GameOver gameOver = new GameOver();
        HUD hud = new HUD();
        ChooseDifficulty chooseDifficulty = new ChooseDifficulty();
        int asteroidCount = 5;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

        }

       
        protected override void Initialize()
        {
            

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pause.LoadContent(Content);
            chooseDifficulty.LoadContent(Content);
            hud.LoadContent(Content);
            gameOver.LoadContent(Content);
            info.LoadContent(Content);
            mainMenu.LoadContent(Content);
            background.LoadContent(Content);
            player.LoadContent(Content);
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.Menu:
                    mainMenu.Update(gameTime);
                    background.Speed = 1;
                    background.Update(gameTime);
                    break;

                case GameState.MediumDifficulty:
                    pause.PrevGameState = "Medium";
                    foreach (var asteroid in asteroidList)
                    {
                        if (player.BoundingBox.Bottom < asteroid.Position.Y)
                        {
                            asteroid.IsVisible = false;
                            player.IncreaseScore(10);
                        }
                    }
                    hud.Update(player.Score);
                    background.Speed = 3;
                    background.Update(gameTime);
                    player.Update(gameTime);
                    LoadAsteroids();
                    UpdateAsteroids();

                    KeyboardState keyboard = Keyboard.GetState();
                    if (keyboard.IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Pause;
                    }
                    break;

                case GameState.EasyDifficulty:
                    pause.PrevGameState = "Easy";
                    asteroidCount = 3;
                    foreach (var asteroid in asteroidList)
                    {
                        if (player.BoundingBox.Bottom < asteroid.Position.Y)
                        {
                            asteroid.IsVisible = false;
                            player.IncreaseScore(10);
                        }
                    }
                    hud.Update(player.Score);
                    background.Speed = 3;
                    background.Update(gameTime);
                    player.Update(gameTime);
                    LoadAsteroids();
                    UpdateAsteroids();

                    KeyboardState keyboardED = Keyboard.GetState();
                    if (keyboardED.IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Pause;
                    }
                    break;

                case GameState.HardDifficulty:
                    pause.PrevGameState = "Hard";
                    asteroidCount = 7;
                    foreach (var asteroid in asteroidList)
                    {
                        if (player.BoundingBox.Bottom < asteroid.Position.Y)
                        {
                            asteroid.IsVisible = false;
                            player.IncreaseScore(10);
                        }
                    }
                    hud.Update(player.Score);
                    background.Speed = 3;
                    background.Update(gameTime);
                    player.Update(gameTime);
                    LoadAsteroids();
                    UpdateAsteroids();

                    KeyboardState keyboardHD = Keyboard.GetState();
                    if (keyboardHD.IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Pause;
                    }
                    break;

                case GameState.Info:
                    KeyboardState keyboardInf = Keyboard.GetState();
                    if (keyboardInf.IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Menu;
                    }
                    background.Speed = 0;
                    break;

                case GameState.Exit:
                    Exit();
                    break;

                case GameState.GameOver:
                    gameOver.Score = player.Score.ToString();
                    keyboard = Keyboard.GetState();
                    if (keyboard.IsKeyDown(Keys.Escape))
                    {
                        Reset();
                        gameState = GameState.Menu;
                    }
                    break;

                case GameState.ChooseDifficulty:
                    chooseDifficulty.Update(gameTime);
                    background.Speed = 1;
                    background.Update(gameTime);
                    break;
                case GameState.Pause:
                    pause.Update(gameTime);
                    background.Speed = 1;
                    background.Update(gameTime);
                    break;
            }
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            {
                switch (gameState)
                {
                    case GameState.Menu:
                        {
                            background.Draw(spriteBatch);
                            mainMenu.Draw(spriteBatch);
                        }
                        break;
                    case GameState.MediumDifficulty:
                        {
                            background.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            DrawAsteroids();
                            hud.Draw(spriteBatch);
                        }
                        break;

                    case GameState.EasyDifficulty:
                        {
                            background.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            DrawAsteroids();
                            hud.Draw(spriteBatch);
                        }
                        break;

                    case GameState.HardDifficulty:
                        {
                            background.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            DrawAsteroids();
                            hud.Draw(spriteBatch);
                        }
                        break;

                    case GameState.GameOver:
                        {
                            background.Draw(spriteBatch);
                            gameOver.Draw(spriteBatch);
                        }
                        break;
                    case GameState.Info:
                        background.Draw(spriteBatch);
                        info.Draw(spriteBatch);
                        break;
                    case GameState.ChooseDifficulty:
                        background.Draw(spriteBatch);
                        chooseDifficulty.Draw(spriteBatch);
                        break;
                    case GameState.Pause:
                        background.Draw(spriteBatch);
                        pause.Draw(spriteBatch);
                        break;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void UpdateAsteroids()
        {
            foreach (Asteroid asteroid in asteroidList)
            {
                asteroid.Update();
               
                
               if (asteroid.BoundingBox.Intersects(player.BoundingBox))
               {

                    Game1.gameState = GameState.GameOver;
               }
                
            }
        }

        private void DrawAsteroids()
        {
            foreach (Asteroid asteroid in asteroidList)
            {
                asteroid.Draw(spriteBatch);
            }
        }
        
        private void LoadAsteroids()
        {
            int randY = random.Next(-600, -50);
            int randX = random.Next(0, 750);

            Asteroid asteroid =
                new Asteroid(new Vector2(randX, randY),
                    Content.Load<Texture2D>("asteroid4"));

            if (asteroidList.Count < asteroidCount)
            {
                asteroidList.Add(asteroid);
            }

            

            
            for (int i = 0; i < asteroidList.Count; i++)
            {
                
                if (!asteroidList[i].IsVisible)
                {
                    asteroidList.RemoveAt(i);
                    i--;
                   
                }
            }

        }

        private void Reset()
        {
            foreach (var asteroid in asteroidList)
            {
                asteroid.IsVisible = false;
            }
            player.Reset();
           
        }

       
    }
}
