using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    abstract class Entity
    {
        protected Vector2i position;
        protected bool active;
        protected bool visible;


        public Entity(int x, int y, bool active = true)
        {
            position.x = x;
            position.y = y;

            this.active = active;
            visible = true;
        }


        public bool IsActive()
        {
            return active;
        }
        public bool IsVisible()
        {
            return visible;
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
        public void MakeVisible()
        {
            visible = true;
        }
        public void MakeInvisible()
        {
            visible = false;

            C.GoToCoordinates(position.x, position.y);
            C.WriteInColor(" ", System.ConsoleColor.Gray);
        }
    }
}
