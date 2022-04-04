namespace desafioLanches
{
    public class Lanches
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int ID { get; set; }

        public Lanches()
        {
        }

        public Lanches(string name, double price, string type, int amount, int id)
        {
            Name = name;
            Price = price;
            Type = type;
            Amount = amount;
            ID = id;
        }
    }
}



