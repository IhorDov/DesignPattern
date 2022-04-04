using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class ShootCommand : ICommand
    {
        public void Execute(Player player)
        {
            player.Shoot();
        }
    }
}
