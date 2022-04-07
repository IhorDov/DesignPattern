using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public enum ENEMYTYPE
    {
        SLOW,
        FAST 
    }
    class EnemyFactory : Factory
    {
        private static EnemyFactory instance;

        private Random rnd = new Random();

        private Animator animator;

        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }

                return instance;
            }
        }

        private EnemyFactory()
        { }

        public override GameObject Create(Enum type)
        {
            GameObject go = new GameObject();

            SpriteRenderer sr = (SpriteRenderer)go.AddComponent(new SpriteRenderer());

            go.AddComponent(new Collider());

            //animator = (Animator)go.GetComponent<Animator>();

            //animator.AddAnimation(BuildEnemyAnimation("MoveEnemyForward",
            //    new string[] { "EnemyF_11", "EnemyF_21", "EnemyF_31", "EnemyF_41" }));

            //go.AddComponent(new Animator());

            switch (type)
            {
                case ENEMYTYPE.SLOW:
                    sr.SetSprite("EnemyF_11");
                    go.AddComponent(new Enemy(50));
                    break;

                case ENEMYTYPE.FAST:
                    sr.SetSprite("EnemyF_31");
                    go.AddComponent(new Enemy(100));
                    break;
            }

            return go;
        }

        //private Animation BuildEnemyAnimation(string animationName, string[] spriteNames)
        //{
        //    Texture2D[] sprites = new Texture2D[spriteNames.Length];

        //    for (int i = 0; i < sprites.Length; i++)
        //    {
        //        sprites[i] = GameWorld.Instance.Content.Load<Texture2D>(spriteNames[i]);
        //    }

        //    Animation animation = new Animation(animationName, sprites, 5);

        //    return animation;
        //}
    }
}
