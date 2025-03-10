using System;
using System.Collections.Generic;

namespace DungeonExplorer{
    /// <summary>
    /// The Player class is used to keep track of what the player does
    /// Keeps track of the health and inventory which are vital to winning
    /// or losing the game 
    /// </summary>
    public class Player{
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int GoblinsDefeated { get; private set; }
        private List<Item> _inventory = new List<Item>();

        /// <summary>
        /// Constructor of the player class
        /// </summary>
        /// <param name="name">Sets the name of the player</param>
        /// <param name="health">Sets the starting health of the player</param>
        public Player(string name, int health) {
            Name = name;
            Health = health;
        }
        
        public void SetHealth(int health){
            Health = health;
        }
        
        public int GetInventoryCount(){
            return _inventory.Count;
        }

        public void IncreaseGoblinsDefeated(){
            GoblinsDefeated++;
        }
        
        public string InventoryContents(){
            return string.Join(", ", _inventory);
        }
        
        /// <summary>
        /// Pickups the item and puts it in the inventory and
        /// notifies the user of which item it is  
        /// </summary>
        /// <param name="item">The item from the room you are currently in</param>
        public void PickUpItem(Item item){
            if (item == null){
                Console.WriteLine("There was no item in the room");
            }
            else{
                Console.WriteLine("You Got a {0}!", item);
                _inventory.Add(item);
            }
        }
        
        /// <summary>
        /// Loops Through the inventory to see if an item exists 
        /// </summary>
        /// <param name="name">The name of the item to find</param>
        /// <returns>If exists return true</returns>
        public bool InventoryHasItem(string name){ 
            foreach (var item in _inventory){
                if (item.GetName() == name){
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Loops Through the inventory to remove it from the inventory
        /// </summary>
        /// <param name="name">the name of the item to remove</param>
        public void RemoveItem(string name){
            foreach (var item in _inventory){
                if (item.GetName() == name){
                    _inventory.Remove(item);
                    return;
                }
            }
            Console.WriteLine("Item was not found in the inventory");
        }
        
        /// <summary>
        /// Loops Through the inventory to count how many of each item is there
        /// </summary>
        /// <param name="name">the name of the item to count</param>
        /// <returns></returns>
        public int GetItemAmount(string name){
            int amount = 0;
            foreach (var item in _inventory){
                if (item.GetName() == name){
                    amount++;
                }
            }
            return amount;
        }
    }
}