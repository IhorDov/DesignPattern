using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public interface IGameListner
    {
        void Notify(GameEvent gameEvent);
    }
}
