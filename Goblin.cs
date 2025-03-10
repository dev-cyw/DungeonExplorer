using System;
using System.Dynamic;

namespace DungeonExplorer{
    public class Goblin{
        private int health{ get; set; } = 10;

        public void DoBattle(Player player){
            bool alive = true;
            Console.WriteLine("Goblin's health: " + health);
            while (alive){
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
                Console.WriteLine("Player health: " + player.Health);
            }
        }
    }
}