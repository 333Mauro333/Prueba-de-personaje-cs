using System;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class Enemy : Character
    {
        Random generar;

        int counter;
        int framesToMove;

        EnemyMovement movement;


        public Enemy(int x, int y, int health, string renderer, EnemyMovement movement, ConsoleColor color = ConsoleColor.Red) : base(x, y, health, renderer, color)
        {
            this.movement = movement;

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
            movement.Move(ref position);
        }

        public void SetBorderLimits(BorderLimits borderLimits)
        {
            movement.SetBorderLimits(borderLimits);
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

                if (movement.CanMove(position))
                {
                    Erase();

                    Move(direction);
                }
            }
        }
    }
}
