using System;
using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    abstract class Character : Entity
    {
        protected int maxHealth;
        protected int health;
        protected string renderer;
        protected ConsoleColor color;

        protected BorderLimits borderLimits;


        public Character(int x, int y, int health, string renderer, ConsoleColor color) : base(x, y)
        {
            maxHealth = 100;
            this.health = (health >= maxHealth) ? maxHealth : health;
            this.renderer = renderer;
            this.color = color;

            borderLimits.upLimit = 0;
            borderLimits.downLimit = C.GetScreenHeight();
            borderLimits.leftLimit = 0;
            borderLimits.rightLimit = C.GetScreenWidth();
        }


        public abstract void Update(ConsoleKey key);
        public abstract void Draw();

        public int GetHealth()
        {
            return health;
        }

        public void ReceiveDamage(int damage)
        {
            health = (damage >= health) ? 0 : health - damage;
        }
        public void Kill()
        {
            health = 0;
        }
        public void Heal(int health)
        {
            this.health = (this.health + health >= maxHealth) ? maxHealth : this.health + health;
        }
        public void FullRegenerate()
        {
            health = maxHealth;
        }

        public void SetBorderLimits(BorderLimits borderLimits)
        {
            this.borderLimits = borderLimits;
        }


        protected abstract void Erase();
        protected abstract void Move(Direction direction);
        protected abstract bool CanMove(Direction direction);
    }
}
