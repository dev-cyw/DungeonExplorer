using System;
using System.Media;
using System.Runtime;

namespace DungeonExplorer{
    internal class Game{
        private Player player;
        private Room currentRoom;
        
        public Game(string playerName){
            // Initialize the game with one room and one player
            player = new Player(playerName, 50);
            currentRoom = new Room();
        }

        public void Start(){
            Console.WriteLine("You Enter the Dungeon\n");
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            do {
                ShowOptions();
                int option = 0;
                try {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex){
                    Console.WriteLine("Only Input numbers");
                    continue;
                }
                
                switch (option){
                    case 1: // ViewCurrentRoom
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case 2: // Display Status
                        CurrentStatus();
                        break;
                    case 3: // Pickup Item
                        if (currentRoom.ItemPicked == true){
                            Console.WriteLine("Cannot pickup another item");
                        }
                        player.PickUpItem(currentRoom.GetItem());
                        currentRoom.ItemPicked = true;
                        break;
                    case 4 : // Move Room
                        break;
                    case 5:
                        ItemUsage();
                        break;
                    case 6: // Quit
                        Console.WriteLine("You've Quit!");
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while(playing);
        }
        
        private void ShowOptions(){
            Console.WriteLine("Choose an option:\n" +
                              "(1) Show Current Room\n" +
                              "(2) Display Status\n" +
                              "(3) Pickup Item\n" +
                              "(4) Move To a different Room\n" +
                              "(5) Use Item" +
                              "(6) Exit");
        }

        private void ItemUsage(){
            if (player.GetInventoryCount() == 0){
                Console.WriteLine("There is nothing in your inventory");
                return;
            }
            Console.WriteLine("Which Item would you like to use?");
            if (player.InventoryHasItem("Key")){
                int amount = player.GetItemAmount("Key");
                Console.WriteLine("Key, ({0})", 0);
            }

            if (player.InventoryHasItem("Health Potion")){
                int amount = player.GetItemAmount("Health Potion");
                Console.WriteLine("Health Potion, ({0})", amount);
            }
        }

        private void UseKey(){
            if (currentRoom.CanOpenDoor() == true && player.InventoryHasItem("Key")){
                player.RemoveItem("Key");
            }
            // Do something with a room
        }

        private void CurrentStatus(){
            Console.WriteLine($"{player.Name}'s Status");
            Console.WriteLine("Health: {0}", player.Health);
            Console.WriteLine("Current Items: {0}", player.InventoryContents());
        }
    }
}