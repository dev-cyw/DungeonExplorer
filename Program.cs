using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer{
    internal class Program{
        static void Main(string[] args){
            string name;
            do {
                Console.Write("Please Enter Your Name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            Console.Clear();
            Game game = new Game(name);
            game.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
