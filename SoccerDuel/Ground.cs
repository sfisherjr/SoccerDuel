using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoccerDuel
{
    public class Ground
    {
        public Rectangle bounds { get; private set; }

        private Texture2D texture;
        private GraphicsDevice graphics;

        public Ground(GraphicsDevice graphics)
        {
            this.graphics = graphics;

            init();
        }

        private void init()
        {
            // Initialize bounds
            bounds = new Rectangle(
                0, Game1.SCREEN_HEIGHT - 100,
                Game1.SCREEN_WIDTH, 100);

            // Initialize texture
            texture = new Texture2D(graphics, 1, 1);
            texture.SetData<Color>(new Color[] { Color.SandyBrown });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, bounds, Color.White);
        }
    }
}
