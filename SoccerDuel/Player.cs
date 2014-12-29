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
        private float jumpVelocity = 400f;

        private KeyboardState keyState;
        private KeyboardState oldKeyState;
        private bool isJumping = false;
        private bool moveDown = false;
        private int playerNo = 1;

        public Player(float groundFlatY, int player)
        {
            this.groundFlatY = groundFlatY;
            this.playerNo = player;
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
                if (playerNo == 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                        position.X -= deltaTime * velocity; 
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        position.X -= deltaTime * velocity; 
                }
            }
            
            if (position.X < Game1.SCREEN_WIDTH - texture.Width)
            {
                if (playerNo == 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        position.X += deltaTime * velocity;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        position.X += deltaTime * velocity;
                }
            }

            if (!isJumping && !moveDown)
            {
                if (playerNo == 1)
                {
                    if (keyState.IsKeyDown(Keys.W) && !oldKeyState.IsKeyDown(Keys.W))
                    {
                        isJumping = true;
                    }
                }
                else
                {
                    if (keyState.IsKeyDown(Keys.Up) && !oldKeyState.IsKeyDown(Keys.Up))
                    {
                        isJumping = true;
                    }
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
                    position.Y -= deltaTime * jumpVelocity;
                }
            }

            if (moveDown)
            {
                if (groundFlatY - (position.Y + texture.Height) > 0)
                {
                    position.Y += deltaTime * jumpVelocity;
                }
                else
                {
                    moveDown = false;
                    position.Y = groundFlatY - texture.Height;
                }
            }

            oldKeyState = keyState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerNo == 1)
            {
                spriteBatch.Draw(texture, position, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, Color.Blue);
            }
        }

        public void MoveToStartPosition()
        {
            if (playerNo == 1)
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
