namespace MgtvPlayerTestCs
{
    class DiagonalMovement : EnemyMovement
    {

        public override bool CanMove(Vector2i position)
        {
            bool canMoveUp = position.y - 1 > bl.upLimit;
            bool canMoveDown = position.y + 1 < bl.downLimit;
            bool canMoveLeft = position.x - 1 > bl.leftLimit;
            bool canMoveRight = position.x + 1 < bl.rightLimit;


            direction = rand.Next(0, 4);

            switch (direction)
            {
                case 0: // Esquina superior izquierda.
                    return canMoveUp && canMoveLeft;

                case 1: // Esquina superior derecha.
                    return canMoveUp && canMoveRight;

                case 2: // Esquina inferior izquierda.
                    return canMoveDown && canMoveLeft;

                case 3: // Esquina inferior derecha.
                    return canMoveDown && canMoveRight;

                default: // Para ningún lado.
                    return false;
            }
        }

        public override void Move(ref Vector2i position)
        {
            switch (direction)
            {
                case 0: // Esquina superior izquierda.
                    position.x--;
                    position.y--;
                    break;

                case 1: // Esquina superior derecha.
                    position.x++;
                    position.y--;
                    break;

                case 2: // Esquina inferior izquierda.
                    position.x--;
                    position.y++;
                    break;

                case 3: // Esquina inferior derecha.
                    position.x++;
                    position.y++;
                    break;
            }
        }
    }
}
