using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Enemy : Character
    {
        Random generar;

        int counter;
        int framesToMove;


        public Enemy(int x, int y, int health, string renderer, ConsoleColor color = ConsoleColor.Red) : base(x, y, health, renderer, color)
        {
            generar = new Random();

            counter = 0;
            framesToMove = 10;
        }


        public override void Update(ConsoleKey key = 0)
        {
            Movement();
        }
        public override void Draw()
        {
            if (active && visible)
            {
                C.GoToCoordinates(position.x, position.y);

                C.WriteInColor(renderer, color);
            }
        }


        protected override void Erase()
        {
            C.GoToCoordinates(position.x, position.y);

            Console.Write(" ");
        }
        protected override void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.CornerUpLeft:
                    position.y--;
                    position.x--;
                    break;

                case Direction.SideUp:
                    position.y--;
                    break;

                case Direction.CornerUpRight:
                    position.y--;
                    position.x++;
                    break;

                case Direction.SideLeft:
                    position.x--;
                    break;

                case Direction.SideRight:
                    position.x++;
                    break;

                case Direction.CornerDownLeft:
                    position.y++;
                    position.x--;
                    break;

                case Direction.SideDown:
                    position.y++;
                    break;

                case Direction.CornerDownRight:
                    position.y++;
                    position.x++;
                    break;
            }
        }
        protected override bool CanMove(Direction direction)
        {
            bool canMoveUp = position.y - 1 > borderLimits.upLimit;
            bool canMoveDown = position.y + 1 < borderLimits.downLimit;
            bool canMoveLeft = position.x - 1 > borderLimits.leftLimit;
            bool canMoveRight = position.x + 1 < borderLimits.rightLimit;


            switch (direction)
            {
                case Direction.Center:
                    return false;

                case Direction.CornerUpLeft:
                    return canMoveUp && canMoveLeft;

                case Direction.SideUp:
                    return canMoveUp;

                case Direction.CornerUpRight:
                    return canMoveUp && canMoveRight;

                case Direction.SideLeft:
                    return canMoveLeft;

                case Direction.SideRight:
                    return canMoveRight;

                case Direction.CornerDownLeft:
                    return canMoveDown && canMoveLeft;

                case Direction.SideDown:
                    return canMoveDown;

                case Direction.CornerDownRight:
                    return canMoveDown && canMoveRight;
            }

            return false;
        }

        bool TimeToMove()
        {
            counter = (counter < framesToMove) ? counter + 1 : 0;

            return counter == framesToMove;
        }
        void Movement()
        {
            if (TimeToMove())
            {
                Direction direction = (Direction)generar.Next(0, 9);

                if (CanMove(direction))
                {
                    Erase();

                    Move(direction);
                }
            }
        }
    }
}
