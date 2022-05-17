using System;


namespace MgtvPlayerTestCs
{
    abstract class EnemyMovement
    {
        protected Random rand;
        protected BorderLimits bl;

        protected int direction;


        public EnemyMovement()
        {
            rand = new Random();

            direction = 0;
        }


        public void SetBorderLimits(BorderLimits bl)
        {
            this.bl = bl;
        }
        public virtual bool CanMove(Vector2i position)
        {
            bool canMoveUp = position.y - 1 > bl.upLimit;
            bool canMoveDown = position.y + 1 < bl.downLimit;
            bool canMoveLeft = position.x - 1 > bl.leftLimit;
            bool canMoveRight = position.x + 1 < bl.rightLimit;


            direction = rand.Next(0, 8);

            switch (direction)
            {
                case 0: // Esquina superior izquierda.
                    return canMoveUp && canMoveLeft;

                case 1: // Borde superior.
                    return canMoveUp;

                case 2: // Esquina superior derecha.
                    return canMoveUp && canMoveRight;

                case 3: // Borde izquierdo.
                    return canMoveLeft;

                case 4: // Borde derecho.
                    return canMoveRight;

                case 5: // Esquina inferior izquierda.
                    return canMoveDown && canMoveLeft;

                case 6: // Borde inferior.
                    return canMoveDown;

                case 7: // Esquina inferior derecha.
                    return canMoveDown && canMoveRight;

                default: // Para nungún lado.
                    return false;
            }
        }

        public abstract void Move(ref Vector2i position);
    }
}
