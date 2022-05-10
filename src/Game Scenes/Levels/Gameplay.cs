using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Gameplay : Scene
    {
        BorderLimits borderLimits;

        Random generar;

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

            generar = new Random();

            player = new Player(centerX, centerY, 100, "P", ConsoleColor.Yellow, 1);
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

            CheckCollisions();
        }
        public override void Draw()
        {
            player.Draw();
            enemy.Draw();
        }

        void CheckCollisions()
        {
            if (CollisionManager.IsColliding(player, enemy))
            {
                player.Lose();
                ui.UpdateLives();

                int x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                int y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);

                while (x == enemy.GetPosition().x && y == enemy.GetPosition().y)
                {
                    x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                    y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);
                }

                player.SetPosition(x, y);
            }
        }
    }
}
