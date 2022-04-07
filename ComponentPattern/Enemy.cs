using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Enemy : Component
    {
        private Vector2 velocity;

        private Animator animator;
      
        public Enemy(float speed)
        {
            this.speed = speed;

            velocity = new Vector2(0, 1);

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

            //if (velocity.Y > 0)
            //{
            //    animator.PlayAnimation("MoveEnemyForward");
            //}

            if (GameObject.Transform.Position.Y > GameWorld.Instance.GraphicsDevice.Viewport.Height)
            {
                EnemyPool.Instance.ReleaseObject(GameObject);
            }
        }
    }
}
