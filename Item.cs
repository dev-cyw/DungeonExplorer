namespace DungeonExplorer{
    /// <summary>
    /// Item class that can be added to the players inventory
    /// </summary>
    public class Item {
        private string Name;
        private string Description;
        

        /// <param name="name">Make an item with name</param>
        /// <param name="description">Make item with description</param>
        public Item(string name, string description){
            Name = name;
            Description = description;
        }

        public string GetName(){
            return Name;
        }

        public string GetDescription(){
            return Description;
        }

        public override string ToString(){
            return Name;
        }
    }
}