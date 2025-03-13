using System;

namespace DungeonExplorer
{
    /// <summary>
    ///     A
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="baseDamage"></param>
        protected Entity(string name, int health, int baseDamage)
        {
            Name = name;
            Health = health;
            BaseDamage = baseDamage;
        }

        public string Name { get; protected set; }
        public bool Alive { get; private set; } = true;
        protected int Health { get; set; }
        private int BaseDamage { get; }

        /// <summary>
        /// </summary>
        /// <param name="damage"></param>
        private void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Alive = false;
            }
        }

        /// <summary>
        ///     Attacks other
        /// </summary>
        /// <param name="target"></param>
        public void Attack(Entity target)
        {
            if (target is Player player) GameTesting.CheckPlayerHealth(player);

            var damage = BaseDamage + new Random().Next(2);
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} attacked {target.Name} and did {damage} damage");
        }
    }
}