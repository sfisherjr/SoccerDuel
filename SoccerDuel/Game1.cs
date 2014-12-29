using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Diagnostics;

namespace SoccerDuel
{
    public class Game1 : Game
    {
        public static int SCREEN_WIDTH;
        public static int SCREEN_HEIGHT;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Ground ground;
        private SoccerNets teamNets;
        private Teams teams;
        private Ball ball;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsFixedTimeStep = true;
            this.IsMouseVisible = true;

            var screen = System.Windows.Forms.Screen.AllScreens.First(e => e.Primary);
            Window.IsBorderless = true;
            Window.Position = new Point(screen.Bounds.X, screen.Bounds.Y);

            SCREEN_WIDTH = screen.Bounds.Width;
            SCREEN_HEIGHT = screen.Bounds.Height;

            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            Debug.WriteLine("Screen Resolution->W:" + SCREEN_WIDTH + " " + "H:" + SCREEN_HEIGHT);
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ground = new Ground(GraphicsDevice);
            teamNets = new SoccerNets(ground.bounds.Y);
            teamNets.LoadContent(Content);
            teams = new Teams(ground.bounds.Y);
            teams.LoadContent(Content);
            ball = new Ball(ground.bounds.Y);
            ball.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            teams.Update(gameTime);
            ball.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ground.Draw(spriteBatch);
            teams.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            teamNets.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
