using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class ShootCommand : ICommand
    {
        //private Vector2 velocity;

        //public ShootCommand(Vector2 velocity)
        //{
        //    this.velocity = velocity;
        //}
        public void Execute(Player player)
        {
            player.Shoot();

        }
    }
}
