using System;
using System.Media;
using System.Runtime;

namespace DungeonExplorer{
    internal class Game{
        private Player player;
        private Room currentRoom;
        private Room[,] map;
        public Game(string playerName){
            // Initialize the game with one room and one player
            player = new Player(playerName, 50);
            map = CreateMap();
            currentRoom = map[2,0];
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
                        Console.WriteLine("Current Coordinates: {0},{1}\n", currentRoom.GetXCoordinate(), currentRoom.GetYCoordinate());
                        break;
                    case 2: // Display Status
                        CurrentStatus();
                        break;
                    case 3: // Pickup Item
                        if (currentRoom.itemPicked == true){
                            Console.WriteLine("Cannot pickup another item");
                        }
                        player.PickUpItem(currentRoom.GetItem());
                        currentRoom.ItemPicked();
                        break;
                    case 4 : // Move Room
                        MoveRoom();
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
                              "(5) Use Item\n" +
                              "(6) Exit");
        }

        private void ItemUsage(){
            if (player.GetInventoryCount() == 0){
                Console.WriteLine("There is nothing in your inventory");
                return;
            }
            if (player.InventoryHasItem("Key")){
                int amount = player.GetItemAmount("Key");
                Console.WriteLine("Key, ({0})", 0);
            }

            if (player.InventoryHasItem("Health Potion")){
                int amount = player.GetItemAmount("Health Potion");
                Console.WriteLine("Health Potion, ({0})", amount);
            }
            bool ValidInput = false;
            do{
                Console.WriteLine("Which Item would you like to use?");
                string option = Console.ReadLine()?.ToLower();
                switch (option){
                    case "key":
                        if (currentRoom.HasChest && player.InventoryHasItem("Key")){
                            player.RemoveItem("key");
                            Console.WriteLine("A Chest full of treasure opened");
                        }
                        ValidInput = true;
                        break;
                    case "health":
                    case "potion":
                    case "health potion":
                        int health = player.Health + 20;
                        if (health > 50){
                            health = 50;
                        }
                        player.SetHealth(health);
                        ValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!ValidInput);

        }

        private void CurrentStatus(){
            Console.WriteLine($"{player.Name}'s Status");
            Console.WriteLine("Health: {0}", player.Health);
            Console.WriteLine("Current Items: {0}", player.InventoryContents());
        }

        private Room[,] CreateMap(){
            Room[,] Map = new Room[5,5];
            for (int i = 0; i < Map.GetLength(0); i++){
                for (int j = 0; j < Map.GetLength(1); j++){
                    Map[i,j] = new Room(i, j);
                }
            }
            return Map;
        }

        private void MoveRoom(){
            
            bool invalidAction = true;
            do{
                Console.WriteLine("Enter Direction, (up, down, left, right): ");
                string option = Console.ReadLine()?.ToLower();
                int currentY = currentRoom.GetYCoordinate();
                int currentX = currentRoom.GetXCoordinate();
                switch (option){
                    case "up":
                        if (currentY - 1 < 0){
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }
                        currentRoom = map[currentX,currentY + 1];
                        invalidAction = false;
                        break;
                    case "down":
                        if (currentY + 1 > 5){
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }
                        currentRoom = map[currentX,currentY + 1];
                        invalidAction = false;
                        break;
                    case "left":
                        if (currentRoom.GetXCoordinate() - 1 < 0){
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }
                        currentRoom = map[currentX - 1, currentY];
                        invalidAction = false;
                        break;
                    case "right":
                        if (currentX + 1 > 5){
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }
                        currentRoom = map[currentX + 1, currentY];
                        invalidAction = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (invalidAction);

            if (currentRoom.enemy != null){
                currentRoom.enemy.TakeDamage(player);
            }
        }
    }
}