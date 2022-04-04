using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    interface IBuilder
    {
        void BuildGameObject();

        GameObject GetResult();
    }
}
