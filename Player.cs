using System;
using System.Collections.Generic;

namespace DungeonExplorer{
    public class Player{
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventory = new List<Item>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(Item item){
            if (item == null){
                Console.WriteLine("There was no item in the room");
            }
            else{
                Console.WriteLine("You Got a {0}!", item);
                inventory.Add(item);
            }
        }
        public string InventoryContents(){
            return string.Join(", ", inventory);
        }

        public bool InventoryHasItem(string name){
            foreach (var item in inventory){
                if (item.GetName() == name){
                    return true;
                }
            }
            return false;
        }

        public void RemoveItem(string name){
            foreach (var item in inventory){
                if (item.GetName() == name){
                    inventory.Remove(item);
                    return;
                }
            }
            Console.WriteLine("Item was not found in the inventory");
        }

        public int GetItemAmount(string name){
            int amount = 0;
            foreach (var item in inventory){
                if (item.GetName() == name){
                    amount++;
                }
            }
            return amount;
        }

        public int GetInventoryCount(){
            return inventory.Count;
        }
    }
}