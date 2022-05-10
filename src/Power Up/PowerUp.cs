using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class PowerUp : Entity
    {
        string renderer;


        public PowerUp(int x, int y, string renderer = "S") : base(x, y)
        {
            position.x = x;
            position.y = y;

            this.renderer = renderer;
        }


        public void Draw()
        {
            if (active)
            {
                C.GoToCoordinates(position.x, position.y);

                C.WriteInColor(renderer, ConsoleColor.Yellow);
            }
        }
    }
}
