using System;
using System.Dynamic;

namespace DungeonExplorer{
    public class Goblin{
        private int health{ get; set; } = 10;
        
        /// <summary>
        /// Plays out a battle between the Goblins and the player
        /// </summary>
        /// <param name="player">To take damage and Increase Goblins Defeated</param>
        public void DoBattle(Player player){
            bool alive = true;
            Console.WriteLine("Goblin's health: " + health);
            while (alive){
                GameTesting.CheckPlayerHealth(player);
                int damage = new Random().Next(4, 6);
                health -= damage;
                if (health <= 0){
                    Console.WriteLine("The Goblin is dead");
                    player.IncreaseGoblinsDefeated();
                    alive = false;
                }
                else{
                    Console.WriteLine("Goblin's health: " + health);
                }
                
                player.SetHealth(player.Health - 3);

                if (player.Health <= 0){
                    Console.WriteLine("You Died and lost");
                    Console.WriteLine("Press any key to exit...");
                    Environment.Exit(0);
                    return;
                }
                Console.WriteLine("Player health: " + player.Health);
            }
        }
    }
}