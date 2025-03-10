using System.Diagnostics;

namespace DungeonExplorer{
    public static class GameTesting{
        public static void CheckPlayerHealth(Player player){
            Debug.Assert(player.Health >= 0 && player.Health <= 50, "Player health is out of range");
        }
    }
}