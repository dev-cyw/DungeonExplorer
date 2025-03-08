namespace DungeonExplorer{
    public class Item {
        private string Name;
        private string Description;
        
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