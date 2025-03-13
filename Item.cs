namespace DungeonExplorer
{
    /// <summary>
    ///     Item class that can be added to the players inventory
    /// </summary>
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}