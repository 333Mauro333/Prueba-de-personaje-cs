using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Gameplay : Level
    {
        BorderLimits borderLimits;

        Random generar;

        Player player;
        Enemy enemy;
        PowerUp powerUp;
        UIManager ui;

        bool inPause;


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

            player = new Player(centerX, centerY, 100, "P", ConsoleColor.Yellow, 5);
            player.SetBorderLimits(borderLimits);

            enemy = new Enemy(centerX + 20, centerY + 5, 100, "E");
            enemy.SetBorderLimits(borderLimits);

            powerUp = new PowerUp(centerX - (int)(distCentX / 1.5), centerY - 10);

            ui = new UIManager(player);
            ui.SetUILivesPosition(centerX - (distCentX / 2) - 10, borderLimits.upLimit - 1);
            ui.SetUIPointsPosition(centerX + (distCentX / 2), borderLimits.upLimit - 1);
            ui.WriteUI();

            C.SetForegroundColor(ConsoleColor.White);
            C.DrawFrame(borderLimits.leftLimit, borderLimits.upLimit, borderLimits.rightLimit, borderLimits.downLimit);
            C.SetForegroundColor(ConsoleColor.Gray);

            inPause = false;
        }


        public override void Update(ConsoleKey key)
        {
            if (key == ConsoleKey.P)
            {
                PauseGame();
            }
            if (key == ConsoleKey.Escape && inPause)
            {
                Console.Clear();
                SceneManager.LoadScene(new MainMenu(1));
            }

            if (!inPause)
            {
                player.Update(key);
                enemy.Update();

                CheckCollisions();
            }
        }
        public override void Draw()
        {
            powerUp.Draw();
            player.Draw();
            enemy.Draw();
        }

        protected override void CheckCollisions()
        {
            if (CollisionManager.IsColliding(player, enemy))
            {
                if (player.IsInvincible())
                {
                    int x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                    int y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);


                    while (x == player.GetPosition().x && y == player.GetPosition().y)
                    {
                        x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                        y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);
                    }
                    enemy.SetPosition(x, y);

                    x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                    y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);

                    while ((x == player.GetPosition().x && y == player.GetPosition().y) || (x == enemy.GetPosition().x && y == enemy.GetPosition().y))
                    {
                        x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                        y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);
                    }
                    powerUp.Activate();
                    powerUp.SetPosition(x, y);

                    player.EndPowerUpEfect();
                    player.AddPoints(1);
                    ui.UpdatePoints();

                    C.GoToCoordinates(C.GetScreenWidth() / 2 - 3, 0);
                    Console.Write("      ");
                }
                else
                {
                    int x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                    int y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);


                    player.Lose();
                    ui.UpdateLives();

                    while (x == enemy.GetPosition().x && y == enemy.GetPosition().y)
                    {
                        x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                        y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);
                    }

                    player.SetPosition(x, y);
                }
            }

            if (CollisionManager.IsColliding(player, powerUp))
            {
                if (powerUp.IsActive())
                {
                    player.BecomeInvincible();
                    powerUp.Deactivate();

                    C.GoToCoordinates(C.GetScreenWidth() / 2 - 3, 0);
                    C.WriteInColor("ATTACK", ConsoleColor.White, ConsoleColor.Red);
                }
            }
        }
        void WriteOptions()
        {
            C.GoToCoordinates(C.GetScreenWidth() / 2 - 30, C.GetScreenHeight() / 2 - 1);
            Console.Write("PAUSE. PRESS \"P\" TO CONTINUE (OR ESC TO RETURN TO MAIN MENU)");
        }
        void EraseOptions()
        {
            C.GoToCoordinates(C.GetScreenWidth() / 2 - 30, C.GetScreenHeight() / 2 - 1);
            Console.Write("                                                              ");
        }

        void PauseGame()
        {
            inPause = !inPause;

            if (inPause)
            {
                player.MakeInvisible();
                enemy.MakeInvisible();
                powerUp.MakeInvisible();
                WriteOptions();
            }
            else
            {
                player.MakeVisible();
                enemy.MakeVisible();
                powerUp.MakeVisible();
                EraseOptions();
            }
        }
    }
}
