using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgtvPlayerTestCs
{
    abstract class Scene
    {
        public abstract void Update(ConsoleKey key);
        public abstract void Draw();
    }
}
