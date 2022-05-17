using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class UIManager
    {
        Player player;

        Vector2i healthDisplayPosition;
        Vector2i pointsDisplayPosition;

        string livesText;
        string pointsText;


        public UIManager(Player player)
        {
            this.player = player;

            healthDisplayPosition.x = 0;
            healthDisplayPosition.y = 0;

            pointsDisplayPosition.x = 0;
            pointsDisplayPosition.y = 1;

            livesText = "Lives: ";
            pointsText = "Points: ";
        }


        public void SetUILivesPosition(int x, int y)
        {
            healthDisplayPosition.x = x;
            healthDisplayPosition.y = y;
        }
        public void SetUIPointsPosition(int x, int y)
        {
            pointsDisplayPosition.x = x;
            pointsDisplayPosition.y = y;
        }

        public void WriteUI()
        {
            WriteLives();
            WritePoints();
        }
        public void UpdatePoints()
        {
            WritePoints();
        }
        public void UpdateLives()
        {
            WriteLives();
        }

        void WriteLives()
        {
            ConsoleColor c = ConsoleColor.Gray;

            C.GoToCoordinates(healthDisplayPosition.x, healthDisplayPosition.y);
            Console.Write(livesText);

            if (player.GetLives() < 1)
            {
                c = ConsoleColor.Red;
            }

            if (player.IsAlive())
            {
                C.WriteInColor(player.GetLives().ToString(), c);
            }
            else
            {
                C.WriteInColor("DEAD", c);
            }
        }
        void WritePoints()
        {
            C.GoToCoordinates(pointsDisplayPosition.x, pointsDisplayPosition.y);
            Console.Write(pointsText);

            if (player.GetPoints() < 10)
            {
                Console.Write("0" + player.GetPoints().ToString() + " ");
            }
            else
            {
                Console.Write(player.GetPoints().ToString() + " ");
            }
        }
    }
}
