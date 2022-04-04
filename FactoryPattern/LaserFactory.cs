using System;
using System.Collections.Generic;
using System.Text;

enum FIRERTYPE { PLAYER, ENEMY }

namespace DesignPattern
{
    class LaserFactory : Factory
    {
        private static LaserFactory instance;

        private GameObject prototype;

        public static LaserFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LaserFactory();

                }

                return instance;
            }
        }

        private LaserFactory()
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
