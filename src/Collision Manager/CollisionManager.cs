namespace MgtvPlayerTestCs
{
    static class CollisionManager
    {
        public static bool IsColliding(Entity e1, Entity e2)
        {
            return e1.GetPosition().x == e2.GetPosition().x && e1.GetPosition().y == e2.GetPosition().y;
        }
        public static bool IsColliding(Entity e, int x2, int y2)
        {
            return e.GetPosition().x == x2 && e.GetPosition().y == y2;
        }
    }
}
