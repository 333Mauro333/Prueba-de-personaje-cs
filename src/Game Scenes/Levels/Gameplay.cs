using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Gameplay : Scene
    {
        BorderLimits borderLimits;

        Player player;


        public Gameplay()
        {
            int centerX = C.GetScreenWidth() / 2;
            int centerY = C.GetScreenHeight() / 2;
            int distCentX = 45;
            int distCentY = 10;


            borderLimits.upLimit = centerY - distCentY;
            borderLimits.downLimit = centerY + distCentY;
            borderLimits.leftLimit = centerX - distCentX;
            borderLimits.rightLimit = centerX + distCentX;

            player = new Player(centerX, centerY, 100, "P", ConsoleColor.Yellow);
            player.SetBorderLimits(borderLimits.upLimit, borderLimits.downLimit, borderLimits.leftLimit, borderLimits.rightLimit);

            C.DrawFrame(borderLimits.leftLimit, borderLimits.upLimit, borderLimits.rightLimit, borderLimits.downLimit);
        }


        public override void Update(ConsoleKey key)
        {
            player.Update(key);
        }
        public override void Draw()
        {
            player.Draw();
        }
    }
}
