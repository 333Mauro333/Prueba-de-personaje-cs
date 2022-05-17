namespace MgtvPlayerTestCs
{
    class LinealMovement : EnemyMovement
    {
        public override bool CanMove(Vector2i position)
        {
            bool canMoveLeft = position.x - 1 > bl.leftLimit;
            bool canMoveRight = position.x + 1 < bl.rightLimit;


            direction = rand.Next(0, 2);

            switch (direction)
            {
                case 0: // Esquina superior izquierda.
                    return canMoveLeft;

                case 1: // Esquina superior derecha.
                    return canMoveRight;

                default: // Para ningún lado.
                    return false;
            }
        }

        public override void Move(ref Vector2i position)
        {
            switch (direction)
            {
                case 0: // Borde izquierdo.
                    position.x--;
                    break;

                case 1: // Borde derecho.
                    position.x++;
                    break;
            }
        }
    }
}
