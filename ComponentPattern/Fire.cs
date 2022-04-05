using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Fire : Component
    {
        private float speed;

        private Vector2 velocity;

        //public Vector2 Velocity { get; set; }

        public Fire()
        {
            this.speed = 500;

            //this.velocity = velocity; // new Vector2(0, -1);

            if (velocity.X > 0)
            {
                velocity = new Vector2(1, 0);
            }
            else if (velocity.X < 0)
            {
                velocity = new Vector2(-1, 0);
            }
            else if (velocity.Y < 0)
            {
                velocity = new Vector2(0, -1);
            }
            else if (velocity.Y > 0)
            {
                velocity = new Vector2(0, 1);
            }
        }
        public override void Update()
        { 
            Move(velocity);
        }

        private void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);

            //if (velocity.X > 0)
            //{
            //    velocity = new Vector2(1, 0);
            //}
            //else if (velocity.X < 0)
            //{
            //    velocity = new Vector2(-1, 0);
            //}
            //else if (velocity.Y < 0)
            //{
            //    velocity = new Vector2(0, -1);
            //}
            //else if (velocity.Y > 0)
            //{
            //    velocity = new Vector2(0, 1);
            //}
            

            if (GameObject.Transform.Position.Y < 0)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }

            if (GameObject.Transform.Position.X < 0)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }

            if (GameObject.Transform.Position.Y > GameWorld.Instance.GraphicsDevice.Viewport.Height)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }

            if (GameObject.Transform.Position.X > GameWorld.Instance.GraphicsDevice.Viewport.Width)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }
        }
    }
}
