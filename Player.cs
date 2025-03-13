using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    ///     Player Class that controls all the parts of
    ///     the player and is a child class of Entity class
    /// </summary>
    public class Player : Entity
    {
        private readonly List<Item> _inventory = new List<Item>();

        /// <summary>
        ///     The Player Constructor that makes the inputted player name the player name
        /// </summary>
        /// <param name="name"></param>
        public Player(string name) : base(name, 100, 15)
        { }

        public int GoblinsDefeated { get; private set; }

        /// <summary>
        /// Increase the amount of Goblins defeated
        /// </summary>
        public void IncreaseGoblinsDefeated()
        {
            GoblinsDefeated++;
        }

        /// <summary>
        /// Pickups the item and puts it in the inventory and
        /// notifies the user of which item it is  
        /// </summary>
        /// <param name="item">The item from the room you are currently in</param>
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
        /// Loops Through the inventory to remove it from the inventory
        /// </summary>
        /// <param name="name">the name of the item to remove</param>
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
        ///     Gets all the inventory contents 
        /// </summary>
        /// <returns>returns the string of the inventory contents</returns>
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }

        /// <summary>
        /// Checks inventory to count how many of each item is there
        /// </summary>
        /// <param name="name">the name of the item to count</param>
        /// <returns>the count of item</returns>
        public int GetItemAmount(string name)
        {
            return _inventory.Count(item => item.Name == name);
        }

        /// <summary>
        ///     Heals the player
        /// </summary>
        /// <param name="amount">amount to increase health by</param>
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }

        /// <summary>
        /// returns health
        /// </summary>
        /// <returns></returns>
        public int GetHealth()
        {
            return Health;
        }
    }
}