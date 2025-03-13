using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// </summary>
    public class Player : Entity
    {
        private readonly List<Item> _inventory = new List<Item>();

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        public Player(string name) : base(name, 100, 15)
        { }

        public int GoblinsDefeated { get; private set; }

        /// <summary>
        /// </summary>
        public void IncreaseGoblinsDefeated()
        {
            GoblinsDefeated++;
        }

        /// <summary>
        /// </summary>
        /// <param name="item"></param>
        public void PickUpItem(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("No Item was found");
                return;
            }

            _inventory.Add(item);
            Console.WriteLine($"{item} was picked up");
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        public void RemoveItem(string name)
        {
            foreach (var item in _inventory.Where(item => item.Name == name))
            {
                _inventory.Remove(item);
                Console.WriteLine($"{item} was used up");
                return;
            }
        }

        public bool HasItem(string name)
        {
            return _inventory.Any(item => item.Name == name);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetItemAmount(string name)
        {
            return _inventory.Count(item => item.Name == name);
        }

        /// <summary>
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public int GetHealth()
        {
            return Health;
        }
    }
}