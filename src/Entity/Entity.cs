namespace MgtvPlayerTestCs
{
    abstract class Entity
    {
        protected Vector2i position;
        protected bool active;


        public Entity(int x, int y, bool active = true)
        {
            position.x = x;
            position.y = y;

            this.active = active;
        }


        public bool IsActive()
        {
            return active;
        }
        public Vector2i GetPosition()
        {
            return position;
        }
        
        public void SetPosition(int x, int y)
        {
            position.x = x;
            position.y = y;
        }

        public void Activate()
        {
            active = true;
        }
        public void Deactivate()
        {
            active = false;
        }
    }
}
