using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class PlayerBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();

            Animator animator = (Animator)gameObject.GetComponent<Animator>();

            animator.AddAnimation(BuildAnimation("Forward", new string[] { "PlayerF_1", "PlayerF_2", "PlayerF_3", "PlayerF_4" }));
            animator.AddAnimation(BuildAnimation("Back", new string[] { "PlayerB_1", "PlayerB_2", "PlayerB_3", "PlayerB_4" }));
            animator.AddAnimation(BuildAnimation("Right", new string[] { "PlayerR_1", "PlayerR_2", "PlayerR_3", "PlayerR_4" }));
            animator.AddAnimation(BuildAnimation("Left", new string[] { "PlayerL_1", "PlayerL_2", "PlayerL_3", "PlayerL_4" }));
            animator.AddAnimation(BuildAnimation("Stay", new string[] { "PlayerF_2", "PlayerF_2", "PlayerF_2", "PlayerF_2" }));
        }

        private void BuildComponents()
        {
            Player p = (Player)gameObject.AddComponent(new Player());

            gameObject.AddComponent(new Player());
            gameObject.AddComponent(new SpriteRenderer());
            gameObject.AddComponent(new Animator());

            Collider c = (Collider)gameObject.AddComponent(new Collider());
            c.CollisionEvent.Attach(p);
        }

        private Animation BuildAnimation(string animationName, string[] spriteNames)
        {
            Texture2D[] sprites = new Texture2D[spriteNames.Length];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = GameWorld.Instance.Content.Load<Texture2D>(spriteNames[i]);
            }

            Animation animation = new Animation(animationName, sprites, 5);

            return animation;
        }

            public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
