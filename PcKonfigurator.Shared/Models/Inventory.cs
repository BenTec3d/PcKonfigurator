namespace PcKonfigurator.Shared.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Sku { get; set; }

        public double Price { get; set; }

        public double Stock { get; set; }

        public Inventory(string sku, double price, double stock)
        {
            Sku = sku;
            Price = price;
            Stock = stock;
        }
    }
}