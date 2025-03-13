using System.Diagnostics;

namespace DungeonExplorer
{
    public static class GameTesting
    {
        public static void CheckPlayerHealth(Player player)
        {
            Debug.Assert(player.GetHealth() >= 0 && player.GetHealth() <= 100, "Player health is out of range");
        }

        public static void CheckMapIsPopulated(Room[,] map)
        {
            Debug.Assert(map.GetLength(0) == 5 && map.GetLength(1) == 5, "Map is empty");
        }

        public static void CheckMapIsFull()
        { }
    }
}