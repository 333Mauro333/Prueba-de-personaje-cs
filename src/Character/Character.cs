using System;


namespace MgtvPlayerTestCs
{
    abstract class Character : Entity
    {
        protected int maxHealth;
        protected int health;
        protected string renderer;
        protected ConsoleColor color;


        public Character(int x, int y, int health, string renderer, ConsoleColor color) : base(x, y)
        {
            maxHealth = 100;
            this.health = (health >= maxHealth) ? maxHealth : health;
            this.renderer = renderer;
            this.color = color;
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


        protected abstract void Erase();
        protected abstract void Move(Direction direction);
    }
}
