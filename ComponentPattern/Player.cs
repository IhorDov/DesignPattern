using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Player : Component
    {
        private float speed;

        private bool canShoot = true;

        private float shootTime = 0;

        private Animator animator;

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Position += (velocity * GameWorld.DeltaTime);

            if (velocity.X > 0)
            {
                animator.PlayAnimation("Right");
            }
            else if (velocity.X < 0)
            {
                animator.PlayAnimation("Left");
            }
            else if(velocity.Y < 0)
            {
                animator.PlayAnimation("Back");
            }
            else if (velocity.Y > 0)
            {
                animator.PlayAnimation("Forward");
            }
        }

        public override void Awake()
        {
            speed = 150;
        }

        public override void Start()
        {
            SpriteRenderer sr = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;

            sr.SetSprite("PlayerF_2");
            
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2,
               GameWorld.Instance.Graphics.PreferredBackBufferHeight / 2 - sr.Sprite.Height / 3);

            animator = (Animator)GameObject.GetComponent<Animator>();
        }

        public void Shoot()
        {
            if (canShoot)
            {
                GameObject go = LaserFactory.Instance.Create(FIRERTYPE.PLAYER);
                go.Transform.Position = GameObject.Transform.Position;
                GameWorld.Instance.Instantiate(go);

            }

            canShoot = false;
        }

        public override void Update()
        {
            InputHandler.Instance.Execute(this);

            if (canShoot == false)
            {
                shootTime += GameWorld.DeltaTime;

                if (shootTime > 1)
                {
                    canShoot = true;
                    shootTime = 0;
                }
            }
        }
    }
}
