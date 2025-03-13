using System.Diagnostics;

namespace DungeonExplorer
{
    public static class GameTesting
    {
        /// <summary>
        ///  Checks the player class to see if its health is above or below any ranges it shouldnt
        /// </summary>
        /// <param name="player">the player class that health gets checked</param>
        public static void CheckPlayerHealth(Player player)
        {
            Debug.Assert(player.GetHealth() >= 0 && player.GetHealth() <= 100, "Player health is out of range");
        }
        
        /// <summary>
        ///  Checks the map to make sure it is fully instantiated 
        /// </summary>
        /// <param name="map">The main map of the program</param>
        public static void CheckMapIsPopulated(Room[,] map)
        {
            Debug.Assert(map.GetLength(0) == 5 && map.GetLength(1) == 5, "Map is empty");
        }
    }
}