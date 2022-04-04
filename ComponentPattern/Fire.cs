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

        public Fire()
        {
            this.speed = 500;

            velocity = new Vector2(0, -1);
        }
        public override void Update()
        {
            Move();
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
