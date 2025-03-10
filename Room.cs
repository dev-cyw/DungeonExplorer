using System;
using System.Runtime;

namespace DungeonExplorer{
    public class Room {
        private static readonly string[] s_roomDescriptions ={
            "Something about a chest",
            "Ohio",
            ""
        };

        private string _description;
        private Item _item;
        private int _x, _y;
        public Goblin Enemy{ get; private set; }
        public bool ItemSearched { get; private set; }
        public bool HasChest { get; private set; }
        
        // Room Constructor
        // Parameters X and Y To know the current Location of the room
        // Sets the random room description from the static array
        // Sets what item will be in the room
        // Makes the enemy Spawn
        public Room(int X, int Y){
            _description = s_roomDescriptions[new Random().Next(s_roomDescriptions.Length)];
            if (_description == s_roomDescriptions[0]) { HasChest = true; }
            _item = CreateItem();
            _x = X; _y = Y;
            Enemy = new Goblin();
        }

        public string GetDescription(){
            return _description;
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
        
        public void ItemPickedUp(){
            ItemSearched = true;
        }
        
        public Item GetItem(){
            return _item;
        }

        public int GetXCoordinate(){
            return _x;
        }

        public int GetYCoordinate(){
            return _y;
        }
    }
}