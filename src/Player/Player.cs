using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Player : Character
    {
        PlayerControls controls;

        int lives;

        const int maxLimitPoints = 999999;
        int points;


        public Player(int x, int y, int health, string renderer, ConsoleColor color = ConsoleColor.White, int lives = 5) : base(x, y, health, renderer, color)
        {
            controls.up = ConsoleKey.UpArrow;
            controls.down = ConsoleKey.DownArrow;
            controls.left = ConsoleKey.LeftArrow;
            controls.right = ConsoleKey.RightArrow;

            this.lives = lives;
            points = 0;
        }


        public override void Update(ConsoleKey key)
        {
            Movement(key);
        }
        public override void Draw()
        {
            C.GoToCoordinates(position.x, position.y);

            C.WriteInColor(renderer, color);
        }

        public void AddPoints(int points)
        {
            if (points > 0)
            {
                this.points = (this.points + points < maxLimitPoints) ? this.points + points : maxLimitPoints;
            }
        }
        public void Lose()
        {
            lives = (lives >= 0) ? lives - 1 : 0;
        }

        public int GetLives()
        {
            return lives;
        }
        public int GetPoints()
        {
            return points;
        }


        protected override void Erase()
        {
            C.GoToCoordinates(position.x, position.y);

            Console.Write(" ");
        }
        protected override void Move(Direction direction)
        {
            Erase();

            if (CanMove(direction))
            {
                switch (direction)
                {
                    case Direction.SideUp:
                        position.y--;
                        break;

                    case Direction.SideDown:
                        position.y++;
                        break;

                    case Direction.SideLeft:
                        position.x--;
                        break;

                    case Direction.SideRight:
                        position.x++;
                        break;

                }
            }
        }
        protected override bool CanMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.SideUp:
                    return position.y - 1 > borderLimits.upLimit;

                case Direction.SideLeft:
                    return position.x - 1 > borderLimits.leftLimit;

                case Direction.SideRight:
                    return position.x + 1 < borderLimits.rightLimit;

                case Direction.SideDown:
                    return position.y + 1 < borderLimits.downLimit;
            }

            return false;
        }

        void Movement(ConsoleKey key)
        {
            if (key == controls.up)
            {
                Move(Direction.SideUp);
            }
            else if (key == controls.down)
            {
                Move(Direction.SideDown);
            }
            else if (key == controls.left)
            {
                Move(Direction.SideLeft);
            }
            else if (key == controls.right)
            {
                Move(Direction.SideRight);
            }
        }
    }
}
