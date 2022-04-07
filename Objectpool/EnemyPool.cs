using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class EnemyPool : Objectpool
    {
        private static EnemyPool instance;

        public static EnemyPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyPool();
                }

                return instance;
            }
        }

        private static Random rnd = new Random();

        protected override void CleanUp(GameObject gameObject)
        {

        }

        protected override GameObject CreateObject()
        {
            return EnemyFactory.Instance.Create((ENEMYTYPE)rnd.Next(0, 2));
        }
    }
}
