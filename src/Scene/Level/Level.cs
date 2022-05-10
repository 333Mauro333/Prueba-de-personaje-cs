using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgtvPlayerTestCs
{
    abstract class Level : Scene
    {
        protected abstract void CheckCollisions();
    }
}
