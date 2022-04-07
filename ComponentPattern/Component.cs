using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public abstract class Component
    {
        //protected float myScale = 0.6f;
        protected float speed;
        public GameObject GameObject { get; set; }

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
