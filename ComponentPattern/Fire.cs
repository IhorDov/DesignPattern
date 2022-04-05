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

        public Vector2 Velocity { get; set; }

        public Fire()
        {
            this.speed = 500;
            
            this.Velocity = velocity; // new Vector2(0, -1);
        }
        public override void Update()
        {
            if (velocity.X > 0)
            {
                this.velocity = new Vector2(0, -1);
                Move();
            }
            else if (velocity.X < 0)
            {
                this.velocity = new Vector2(0, 1);
                Move();
            }
            else if (velocity.Y < 0)
            {
                this.velocity = new Vector2(0, -1);
                Move();
            }
            else if (velocity.Y > 0)
            {
                this.velocity = new Vector2(0, -1);
                Move();
            }

            //Move();
        }

        private void Move()
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);

            if (GameObject.Transform.Position.Y < 0)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }
        }
    }
}
