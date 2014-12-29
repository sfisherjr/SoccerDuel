using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SoccerDuel
{
    public class Ball
    {
        public Vector2 position;
        private Texture2D texture;
        private float groundFlatY;

        public Ball(float groundFlatY)
        {
            this.groundFlatY = groundFlatY;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("soccer_ball");
            MoveToStartPosition();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void MoveToStartPosition()
        {
            position = new Vector2(
                Game1.SCREEN_WIDTH / 2 - texture.Width / 2,
                Game1.SCREEN_HEIGHT / 2 - texture.Height / 2);
        }
    }
}
