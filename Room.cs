using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime;

namespace DungeonExplorer{
    public class Room{
        private static readonly string[] s_roomDescriptions ={
            "Something about a chest",
            "Ohio",
            ""
        };

        private string _description;
        private Item _item;
        private int _x, _y;
        public Goblin Enemy{ get; private set; }
        public bool ItemSearched{ get; private set; }
        public bool HasChest{ get; private set; }

        /// <summary>
        /// Sets the random room description from the static array
        /// Sets what item will be in the room
        /// Makes the enemy Spawn
        /// </summary>
        /// <param name="x">The X coordinate in the map array</param>
        /// <param name="y">The Y coordinate in the map array</param>
        public Room(int x, int y){
            _description = s_roomDescriptions[new Random().Next(s_roomDescriptions.Length)];
            if (_description == s_roomDescriptions[0]){
                HasChest = true;
            }
            _item = CreateItem();
            _x = x; _y = y;
            Enemy = new Goblin();
        }

        public string GetDescription(){
            return _description;
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
        
        public void ItemPickedUp(){
            ItemSearched = true;
        }

        /// <summary>
        /// In the constructor to generate a random item
        /// </summary>
        /// <returns>Either a Key or Health Potion Item or no item</returns>
        private Item CreateItem(){
            int random = new Random().Next(100);
            if (random < 40){
                // 40% Chance no item is found 
                return null;
            }

            if (random < 90){
                // 50% of Health Potion 
                return new Item("Health Potion", "A potion that seems to rejuvenate your health by 20hp");
            }

            // 10% For Key
            return new Item("Key", "A mysterious key that may open some doors deeper in the dungeon");
        }

        /// <summary>
        /// 80% chance to return a goblin object
        /// </summary>
        /// <returns>null or a goblin object</returns>
        public Goblin CreateGoblin(){
            if (new Random().Next(100) < 80){
                return new Goblin();
            }
            return null;
        }
    }
}