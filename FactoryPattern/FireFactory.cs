using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

enum FIRERTYPE
{
    PLAYER,
    ENEMY 
}
public enum SIDEOFSHOOT
{ 
    UP,
    DOWN, 
    LEFT,
    RIGHT
}

namespace DesignPattern
{
    class FireFactory : Factory
    {
        private static FireFactory instance;

        private GameObject prototype;

        public static FireFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireFactory();

                }

                return instance;
            }
        }

        private FireFactory()
        {
            prototype = new GameObject();

            SpriteRenderer sr = (SpriteRenderer)prototype.AddComponent(new SpriteRenderer());

            sr.SetSprite("Fireball1");

            prototype.AddComponent(new Fire());

            prototype.AddComponent(new Collider());
        }

        public override GameObject Create(Enum type)
        {
            GameObject go = new GameObject();

            SpriteRenderer sr = (SpriteRenderer)go.AddComponent(new SpriteRenderer());

            go.AddComponent(new Collider());

            //switch (type)
            //{
            //    case SIDEOFSHOOT.UP:
                    
            //        go.AddComponent(new Fire(new Vector2(0, -1)));
            //        break;
            //    case SIDEOFSHOOT.DOWN:
                    
            //        go.AddComponent(new Fire(new Vector2(0, 1)));
            //        break;
            //    case SIDEOFSHOOT.LEFT:

            //        go.AddComponent(new Fire(new Vector2(-1, 0)));
            //        break;
            //    case SIDEOFSHOOT.RIGHT:

            //        go.AddComponent(new Fire(new Vector2(1, 0)));
            //        break;
            //}

            return (GameObject)prototype.Clone();
        }
    }
}
