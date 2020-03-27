using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniaTowerDefence
{
    public abstract class GameObject
    {
        protected Texture2D sprite;

        protected Texture2D[] sprites;

        protected Vector2 position;

        protected Vector2 origin;

        protected Vector2 center;

        protected Vector2 velocity;

        protected float rotation;

        protected float radius;

        protected Texture2D texture;

        protected Vector2 speed;

        public Vector2 Center
        {
            get { return center; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, center, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }
        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);
    }
}
