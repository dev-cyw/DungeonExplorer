using System;

namespace DungeonExplorer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string name;
            do
            {
                Console.Write("Please Enter Your Name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name) || name.Length >= 10);

            Console.Clear();
            var game = new Game(name);
            game.Start();
        }
    }
}