using System;

namespace MgtvPlayerTestCs
{
    static class CollisionManager
    {
        public static bool IsColliding(Character c1, Character c2)
        {
            return c1.GetPosition().x == c2.GetPosition().x && c1.GetPosition().y == c2.GetPosition().y;
        }
    }
}
