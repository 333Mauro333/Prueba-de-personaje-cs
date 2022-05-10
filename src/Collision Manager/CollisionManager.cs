using System;

namespace MgtvPlayerTestCs
{
    static class CollisionManager
    {
        public static bool IsColliding(Entity e1, Entity e2)
        {
            return e1.GetPosition().x == e2.GetPosition().x && e1.GetPosition().y == e2.GetPosition().y;
        }
    }
}
