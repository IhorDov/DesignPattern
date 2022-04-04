using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public abstract class Factory
    {
        public abstract GameObject Create(Enum type);
    }
}
