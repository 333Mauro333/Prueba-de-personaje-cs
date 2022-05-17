using System;
using System.Collections.Generic;

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
        OptionsPanel op;

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

            op = new OptionsPanel(C.GetScreenWidth() / 2, C.GetScreenHeight() / 2 - 1);
            op.AddOption("RESUME");
            op.AddOption("RETURN TO MAIN MENU");

            C.SetForegroundColor(ConsoleColor.White);
            C.DrawFrame(borderLimits.leftLimit, borderLimits.upLimit, borderLimits.rightLimit, borderLimits.downLimit);
            C.SetForegroundColor(ConsoleColor.Gray);

            inPause = false;
        }


        public override void Update(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape && !inPause)
            {
                PauseGame();
            }
            if (key == ConsoleKey.Enter && inPause)
            {
                if (op.ActualOption == 1)
                {
                    PauseGame();
                }
                else if (op.ActualOption == 2)
                {
                    Console.Clear();
                    SceneManager.LoadScene(new MainMenu(1));
                }
            }

            if (!inPause)
            {
                player.Update(key);
                enemy.Update();

                CheckCollisions();
            }
            else
            {
                op.Update(key);
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
                    int x;
                    int y;


                    do
                    {
                        x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                        y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);

                    } while (CollisionManager.IsColliding(player, x, y) || CollisionManager.IsColliding(powerUp, x, y));

                    enemy.SetPosition(x, y);

                    do
                    {
                        x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                        y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);

                    } while (CollisionManager.IsColliding(player, x, y) || CollisionManager.IsColliding(enemy, x, y));

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
                    player.Lose();
                    ui.UpdateLives();

                    if (player.IsAlive())
                    {
                        int x;
                        int y;


                        do
                        {
                            x = generar.Next(borderLimits.leftLimit + 1, borderLimits.rightLimit);
                            y = generar.Next(borderLimits.upLimit + 1, borderLimits.downLimit);

                        } while (CollisionManager.IsColliding(player, x, y));

                        player.SetPosition(x, y);
                    }
                    else
                    {
                        Console.Clear();
                        C.GoToCoordinates(C.GetScreenWidth() / 2 - 5, C.GetScreenHeight() / 2);
                        C.WriteInColor("GAME OVER", ConsoleColor.Red);
                        C.Sleep(1000);
                        Console.Clear();
                        SceneManager.LoadScene(new MainMenu(1));
                    }
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

        void PauseGame()
        {
            inPause = !inPause;

            if (inPause)
            {
                player.MakeInvisible();
                enemy.MakeInvisible();
                powerUp.MakeInvisible();
                op.Activate();
            }
            else
            {
                player.MakeVisible();
                enemy.MakeVisible();
                powerUp.MakeVisible();
                op.Deactivate();
            }
        }
    }
}
