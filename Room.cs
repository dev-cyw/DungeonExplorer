using System;
using System.Runtime;

namespace DungeonExplorer{
    public class Room{
        private static readonly string[] RoomDescriptions ={
            "Something about a chest",
            "Ohio",
            ""
        };

        private string description;
        private Item item;
        private int X, Y;
        public  Goblin enemy{ get; private set; }
        public bool itemPicked { get; private set; }
        public bool HasChest { get; private set; }
        
        public Room(int x, int y){
            this.description = RoomDescriptions[new Random().Next(RoomDescriptions.Length)];
            if (description == RoomDescriptions[0]) { HasChest = true; }
            item = CreateItem();
            X = x; Y = y;
            CreateGoblin();
        }

        public string GetDescription(){
            return description;
        }

        private void CreateGoblin(){
            int random = new Random().Next(100);
            enemy = new Goblin();
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
        
        public void ItemPicked(){
            itemPicked = true;
        }
        
        public Item GetItem(){
            return item;
        }

        public int GetXCoordinate(){
            return X;
        }

        public int GetYCoordinate(){
            return Y;
        }
    }
}