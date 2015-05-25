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

        private const float MAX_JUMP_HEIGHT = 15f;
        private const float VELOCITY = 500f;

        private Texture2D texture;
        private float groundFlatY; // Ground surface position
        private float jumpVelocity = 0;
        private float startSpacer = 200f; // Offset where player starts when round begins

        private KeyboardState keyState;
        private KeyboardState oldKeyState;
        private bool isJumping = false;
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
                        position.X -= deltaTime * VELOCITY;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        position.X -= deltaTime * VELOCITY;
                }
            }

            if (position.X < Game1.SCREEN_WIDTH - texture.Width)
            {
                if (playerNo == 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        position.X += deltaTime * VELOCITY;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        position.X += deltaTime * VELOCITY;
                }
            }

            if (isJumping)
            {
                position.Y -= jumpVelocity;
                jumpVelocity -= 1;

                if (position.Y >= groundFlatY - texture.Height)
                {
                    position.Y = groundFlatY - texture.Height;
                    isJumping = false;
                    Debug.WriteLine("Resetting position to groundFlatY: " + groundFlatY.ToString());
                }
            }

            if (!isJumping)
            {
                if (playerNo == 1)
                {
                    if (keyState.IsKeyDown(Keys.W) && !oldKeyState.IsKeyDown(Keys.W))
                    {
                        isJumping = true;
                        jumpVelocity = MAX_JUMP_HEIGHT;
                    }
                }
                else
                {
                    if (keyState.IsKeyDown(Keys.Up) && !oldKeyState.IsKeyDown(Keys.Up))
                    {
                        isJumping = true;
                        jumpVelocity = MAX_JUMP_HEIGHT;
                    }
                }
            }

            oldKeyState = keyState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerNo == 1)
                spriteBatch.Draw(texture, position, Color.Red);
            else
                spriteBatch.Draw(texture, position, Color.Blue);
        }

        public void MoveToStartPosition()
        {
            if (playerNo == 1)
            {
                position = new Vector2(
                    (Game1.SCREEN_WIDTH / 2 - texture.Width / 2) - startSpacer,
                    groundFlatY - texture.Height);
            }
            else
            {
                position = new Vector2(
                    (Game1.SCREEN_WIDTH / 2 - texture.Width / 2) + startSpacer,
                    groundFlatY - texture.Height);
            }
        }
    }
}
