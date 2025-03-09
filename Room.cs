using System;

namespace DungeonExplorer{
    public class Room{
        private static readonly string[] RoomDescriptions ={
            "Skibidi",
            "Ohio"
        };

        private string description;
        private Item item;
        public bool ItemPicked = false;
        public bool HasEnemy = false;
        public bool Explored = false;
        
        public Room(){
            this.description = RoomDescriptions[new Random().Next(RoomDescriptions.Length)];
            item = CreateItem();
        }

        public string GetDescription(){
            return description;
        }

        private Item CreateItem(){
            int random = new Random().Next(100);
            if (random < 40){ // 40% Chance no item is found 
                return null;
            }
            if (random < 90){ // 50% of Health Potion 
                return new Item("Health Potion", "A potion that seems to rejuvenate your health by 20hp");
            }
            // 10% For Key
            return new Item("Key", "A mysterious key that may open some doors deeper in the dungeon");
        }

        public Item GetItem(){
            return item;
        }

        public bool CanOpenDoor(){
            return false;
        }
    }
}