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
    public class Tower : GameObject
    {
        protected Student target;

        public Student Target
        {
            get { return target; }
        }

        public Tower(Texture2D towerSprite)
        {
            radius = 600;
            this.position.X = 145;
            this.position.Y = 185;
            velocity = Vector2.Zero;
            this.sprite = towerSprite;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Tower_aim");
        }

        public override void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + sprite.Width / 2,
            position.Y + sprite.Height / 2);


            if (target != null)
            {
                FaceTarget();

                if (!IsInRange(target.Center))
                {
                    target = null;
                }
            }
        }
        public bool IsInRange(Vector2 position)
        {
            return Vector2.Distance(center, position) <= radius;
        }
        public void GetClosestStudent(List<Student> students)
        {
            target = null;
            float smallestRange = radius;

            foreach (Student student in students)
            {
                if (Vector2.Distance(center, student.Center) < smallestRange)
                {
                    smallestRange = Vector2.Distance(center, student.Center);
                    target = student;
                }
            }
        }
        protected void FaceTarget()
        {
            Vector2 direction = center - target.Center;
            direction.Normalize();

            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }
    }
}
