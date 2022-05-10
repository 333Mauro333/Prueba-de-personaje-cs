using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Gameplay : Scene
    {
        BorderLimits borderLimits;

        Player player;
        Enemy enemy;
        UIManager ui;


        public Gameplay()
        {
            int centerX = C.GetScreenWidth() / 2;
            int centerY = C.GetScreenHeight() / 2;
            int distCentX = 45;
            int distCentY = 12;


            borderLimits.upLimit = centerY - distCentY;
            borderLimits.downLimit = centerY + distCentY;
            borderLimits.leftLimit = centerX - distCentX;
            borderLimits.rightLimit = centerX + distCentX;

            player = new Player(centerX, centerY, 100, "P", ConsoleColor.Yellow);
            player.SetBorderLimits(borderLimits);

            enemy = new Enemy(centerX + 20, centerY + 5, 100, "E");
            enemy.SetBorderLimits(borderLimits);

            ui = new UIManager(player);
            ui.SetUILivesPosition(centerX - (distCentX / 2) - 10, borderLimits.upLimit - 1);
            ui.SetUIPointsPosition(centerX + (distCentX / 2), borderLimits.upLimit - 1);
            ui.WriteUI();

            C.DrawFrame(borderLimits.leftLimit, borderLimits.upLimit, borderLimits.rightLimit, borderLimits.downLimit);
        }


        public override void Update(ConsoleKey key)
        {
            player.Update(key);
            enemy.Update();
        }
        public override void Draw()
        {
            player.Draw();
            enemy.Draw();
        }
    }
}
