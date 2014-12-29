using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

// NOTE: 
//  Team A = Left Side
//  Team B = Right Side

namespace SoccerDuel
{
    public class SoccerNets
    {
        public Vector2 aPosition { get; private set; }
        public Vector2 bPosition { get; private set; }

        private Texture2D texture;
        private float groundFlatY;

        public SoccerNets(float groundFlatY)
        {
            this.groundFlatY = groundFlatY;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("soccer_net");

            // Initialize team A net position
            aPosition = new Vector2(
                0,
                groundFlatY - texture.Height);

            // Initialize team B net position
            bPosition = new Vector2(
                Game1.SCREEN_WIDTH - texture.Width,
                groundFlatY - texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw team A net
            spriteBatch.Draw(
                texture,
                aPosition,
                Color.White);

            // Draw team B net
            spriteBatch.Draw(
                texture,
                bPosition,
                Color.White);
        }
    }
}
