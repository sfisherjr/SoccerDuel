using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SoccerDuel
{
    public class Player
    {
        public Vector2 position;

        private Texture2D texture;
        private float groundFlatY;
        private float velocity = 500f;
        private float dropSpeed = 300f;

        private KeyboardState keyState;
        private KeyboardState oldKeyState;
        private bool isJumping = false;
        private bool moveDown = false;

        public Player(float groundFlatY)
        {
            this.groundFlatY = groundFlatY;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("soccer_player");
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X > 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                    position.X -= deltaTime * velocity;   
            }
            
            if (position.X < Game1.SCREEN_WIDTH - texture.Width)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    position.X += deltaTime * velocity;
            }

            if (!isJumping && !moveDown)
            {
                if (keyState.IsKeyDown(Keys.W) && !oldKeyState.IsKeyDown(Keys.W))
                {
                    isJumping = true;
                }
            }

            if (isJumping)
            {
                if ((groundFlatY - (position.Y - (float)texture.Height)) > 230)
                {
                    moveDown = true;
                    isJumping = false;
                }
                else
                {
                    position.Y -= deltaTime * 600f;
                }
            }

            if (moveDown)
            {
                if (groundFlatY - (position.Y + texture.Height) > 0)
                {
                    position.Y += deltaTime * 600f;
                }
                else
                {
                    moveDown = false;
                }
            }

            Debug.WriteLine("Position Y: " + (groundFlatY - position.Y));

            oldKeyState = keyState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                Color.White);
        }

        public void MoveToStartPosition(int player)
        {
            if (player == 1)
            {
                position = new Vector2(
                    Game1.SCREEN_WIDTH / 2 - texture.Width * 2,
                    groundFlatY - texture.Height);
            }
            else
            {
                position = new Vector2(
                    Game1.SCREEN_WIDTH / 2 + texture.Width * 2,
                    groundFlatY - texture.Height);
            }
        }
    }
}
