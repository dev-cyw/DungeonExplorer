using System;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Room _currentRoom;
        private readonly Room[,] _map;
        private readonly Player _player;

        /// <summary>
        ///     Game Constructor with the player name
        ///     Initialize the game with a map and a player and sets the spawn room
        /// </summary>
        /// <param name="playerName">set the name in the player object</param>
        public Game(string playerName)
        {
            _player = new Player(playerName);
            _map = CreateMap();
            GameTesting.CheckMapIsPopulated(_map);
            _currentRoom = _map[2, 0];
        }

        /// <summary>
        ///     The Main game loop
        ///     Gets the input and then does the task
        ///     Also has a win condition of defeat 5 Goblins
        /// </summary>
        public void Start()
        {
            Console.WriteLine("You Enter the Dungeon\n");
            var playing = true;
            do
            {
                ShowOptions();
                var option = 0;
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Only Input numbers");
                    continue;
                }

                switch (option)
                {
                    case 1: // ViewCurrentRoom
                        Console.WriteLine(_currentRoom.GetDescription());
                        Console.WriteLine("Current Coordinates: {0},{1}\n", _currentRoom.GetXCoordinate(),
                            _currentRoom.GetYCoordinate());
                        break;
                    case 2: // Display Status
                        CurrentStatus();
                        break;
                    case 3: // Pickup Item
                        if (_currentRoom.ItemSearched) Console.WriteLine("Cannot pickup another item");

                        _player.PickUpItem(_currentRoom.GetItem());
                        _currentRoom.ItemPickedUp();
                        break;
                    case 4: // Move Room
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

                if (_player.GoblinsDefeated >= 5)
                {
                    Console.WriteLine("Well Done you have defeated all the Goblins!");
                    PlayerWin();
                }
            } while (playing);
        }

        /// <summary>
        ///     Shows the user what inputs they can choose
        /// </summary>
        private static void ShowOptions()
        {
            Console.WriteLine("Choose an option:\n" +
                              "(1) Show Current Room\n" +
                              "(2) Display Status\n" +
                              "(3) Pickup Item\n" +
                              "(4) Move To a different Room\n" +
                              "(5) Use Item\n" +
                              "(6) Exit");
        }

        /// <summary>
        ///     Shows the amount of each item there is
        ///     Asks the user for input on which item they would like to use
        ///     if key and treasure chest exists the player wins!
        /// </summary>
        private void ItemUsage()
        {
            if (_player.InventoryContents() == string.Empty)
            {
                Console.WriteLine("There is nothing in your inventory");
                return;
            }

            if (_player.HasItem("Key"))
            {
                var amount = _player.GetItemAmount("Key");
                Console.WriteLine("Key, ({0})", amount);
            }

            if (_player.HasItem("Health Potion"))
            {
                var amount = _player.GetItemAmount("Health Potion");
                Console.WriteLine("Health Potion, ({0})", amount);
            }

            var validInput = false;
            do
            {
                Console.WriteLine("Which Item would you like to use?");
                var option = Console.ReadLine()?.ToLower();
                switch (option)
                {
                    case "key":
                        if (_currentRoom.HasChest && _player.HasItem("Key"))
                        {
                            _player.RemoveItem("key");
                            Console.WriteLine("A Chest full of treasure opened");
                            PlayerWin();
                        }

                        validInput = true;
                        break;
                    case "health":
                    case "potion":
                    case "health potion":
                        if (!_player.HasItem("Health Potion")) break;

                        _player.RemoveItem("Health Potion");
                        _player.Heal(20);
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!validInput);
        }

        /// <summary>
        ///     Tells the player that they have won and then exits the program
        /// </summary>
        private void PlayerWin()
        {
            Console.WriteLine("You have won!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        ///     Show the current status of the player
        /// </summary>
        private void CurrentStatus()
        {
            Console.WriteLine("{0}'s Status", _player.Name);
            Console.WriteLine("Health: {0}", _player.GetHealth());
            Console.WriteLine("Current Items: {0}", _player.InventoryContents());
            Console.WriteLine("Goblins Killed {0}", _player.GoblinsDefeated);
        }

        /// <summary>
        ///     Used in the Constructor to generate the map
        /// </summary>
        /// <returns>A 2-dimensional array of room objects</returns>
        private Room[,] CreateMap()
        {
            var Map = new Room[5, 5];
            for (var i = 0; i < Map.GetLength(0); i++)
            for (var j = 0; j < Map.GetLength(1); j++)
                Map[i, j] = new Room(i, j);

            return Map;
        }

        /// <summary>
        ///     Receives input from the user for a direction checks
        ///     if it is valid and then moves the player to that room
        ///     then Starts the battle
        /// </summary>
        private void MoveRoom()
        {
            var invalidAction = true;
            do
            {
                Console.WriteLine("Enter Direction, (up, down, left, right): ");
                var option = Console.ReadLine()?.ToLower();
                var currentY = _currentRoom.GetYCoordinate();
                var currentX = _currentRoom.GetXCoordinate();
                switch (option)
                {
                    case "up":
                        if (currentY - 1 < 0)
                        {
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }

                        _currentRoom = _map[currentX, currentY + 1];
                        invalidAction = false;
                        break;
                    case "down":
                        if (currentY + 1 > 5)
                        {
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }

                        _currentRoom = _map[currentX, currentY + 1];
                        invalidAction = false;
                        break;
                    case "left":
                        if (_currentRoom.GetXCoordinate() - 1 < 0)
                        {
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }

                        _currentRoom = _map[currentX - 1, currentY];
                        invalidAction = false;
                        break;
                    case "right":
                        if (currentX + 1 > 5)
                        {
                            Console.WriteLine("Room Doesnt Exist");
                            break;
                        }

                        _currentRoom = _map[currentX + 1, currentY];
                        invalidAction = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (invalidAction);

            // Simulate Fight
            if (_currentRoom.Enemies == null) return;
            while (_currentRoom.Enemies.Count != 0 && _player.Alive)
            {
                _player.Attack(_currentRoom.Enemies.First());
                _currentRoom.Enemies.First().Attack(_player);
                if (_currentRoom.Enemies.First().Alive == false)
                    _currentRoom.Enemies.Remove(_currentRoom.Enemies.First());
            }

            if (_player.Alive)
            {
                _player.IncreaseGoblinsDefeated();
            }
            else
            {
                Console.WriteLine("You are dead!");
                Environment.Exit(0);
            }
        }
    }
}