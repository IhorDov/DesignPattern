using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

enum FIRERTYPE { PLAYER, ENEMY }

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
        }

        public override GameObject Create(Enum type)
        {
            return (GameObject)prototype.Clone();
        }
    }
}
