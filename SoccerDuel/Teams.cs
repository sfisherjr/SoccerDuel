using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoccerDuel
{
    public class Teams
    {
        private Player aPlayer;
        private float groundFlatY;

        public Teams(float groundFlatY)
        {
            this.groundFlatY = groundFlatY;
        }

        public void LoadContent(ContentManager content)
        {
            aPlayer = new Player(groundFlatY);
            aPlayer.LoadContent(content);

            aPlayer.MoveToStartPosition(1);
        }

        public void Update(GameTime gameTime)
        {
            aPlayer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aPlayer.Draw(spriteBatch);
        }        
    }
}