﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Player : Component, IGameListner
    {
        //private float speed;

        private bool canShoot = true;

        private float shootTime = 0;

        private Animator animator;

        private Dictionary<Keys, BUTTONSTATE> movementKeys = new Dictionary<Keys, BUTTONSTATE>();

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
            else if (velocity.X == 0 && velocity.Y == 0)
            {
                animator.PlayAnimation("Stay");
            }
        }

        public override void Awake()
        {
            this.speed = 150;
            //this.myScale = 0.5f;
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
            //if (velocity.X > 0)
            //{
            //    fire.Velocity = new Vector2(1, 0);
            //}
            //else if (velocity.X < 0)
            //{
            //    fire.Velocity = new Vector2(-1, 0);
            //}
            //else if (velocity.Y < 0)
            //{
            //    fire.Velocity = new Vector2(0, -1);
            //}
            //else if (velocity.Y > 0)
            //{
            //    fire.Velocity = new Vector2(0, 1);
            //}

            if (canShoot)
            {
            GameObject go = FireFactory.Instance.Create(FIRERTYPE.PLAYER);
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

        public void Notify(GameEvent gameEvent)
        {
            if (gameEvent is CollisionEvent)
            {
                GameWorld.Instance.Destroy((gameEvent as CollisionEvent).Other);
            }
            else if (gameEvent is ButtonEvent)
            {
                ButtonEvent be = (gameEvent as ButtonEvent);

                movementKeys[be.Key] = be.State;
            }
        }
    }
}
