using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private static readonly string[] SRoomDescriptions =
        {
            "A Dark dingy room with a single chest in the middle",
            "A room with stale air and a strange symbol on the wall",
            "Walls with moss covering them and water dripping from the ceiling",
            "A Skeleton lies on the wall from a previous adventurer",
            "A blood stained streak on the wall warning about dangerous enemies"
        };

        private readonly string _description;
        private readonly Item _item;
        private readonly int _x;
        private readonly int _y;

        /// <summary>
        ///     Sets the random room description from the static array
        ///     Sets what item will be in the room
        ///     Makes the enemy Spawn
        /// </summary>
        /// <param name="x">The X coordinate in the map array</param>
        /// <param name="y">The Y coordinate in the map array</param>
        public Room(int x, int y)
        {
            _description = SRoomDescriptions[new Random().Next(SRoomDescriptions.Length)];
            if (_description == SRoomDescriptions[0]) HasChest = true;

            _item = CreateItem();
            _x = x;
            _y = y;
            Enemies.Add(new Goblin());
            if (_description == SRoomDescriptions[4]) Enemies.Add(new Goblin());
        }

        public List<Goblin> Enemies { get; } = new List<Goblin>();
        public bool ItemSearched { get; private set; }
        public bool HasChest { get; private set; }

        // Getters
        public string GetDescription()
        {
            return _description;
        }

        public Item GetItem()
        {
            return _item;
        }

        public int GetXCoordinate()
        {
            return _x;
        }

        public int GetYCoordinate()
        {
            return _y;
        }

        public void ItemPickedUp()
        {
            ItemSearched = true;
        }
        
        /// <summary>
        ///     In the constructor to generate a random item
        /// </summary>
        /// <returns>Either a Key or Health Potion Item or no item</returns>
        private Item CreateItem()
        {
            var random = new Random().Next(100);
            if (random < 40)
                // 40% Chance no item is found 
                return null;

            if (random < 90)
                // 50% of Health Potion 
                return new Item("Health Potion");

            // 10% For Key
            return new Item("Key");
        }
    }
}