using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DaniaTowerDefence
{
    public class Student : GameObject
    {
        Grid grid = new Grid();
        protected bool alive = true;
        public Student(Texture2D studentSprite)
        {
            this.position.X = 300;
            this.position.Y = 300;




            this.sprite = studentSprite;
        }
        public override void LoadContent(ContentManager content)
        {
            //sprite = content.Load<Texture2D>("student");
        }

        public override void Update(GameTime gameTime)
        {
            Gravity(gameTime);
      
            Move(gameTime);
        }
        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        private void Gravity(GameTime gameTime)
        {
            velocity += new Vector2(0, 1);

            Move(gameTime);
        }
    }
}
