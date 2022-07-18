namespace PcKonfigurator.Shared.Models
{
    public class ComponentBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Manufacturer { get; set; }

        public int Power { get; set; }

        public Inventory? InventoryItem { get; set; }
        public int InventoryId { get; set; }

        public ComponentBase(string name, string picture, string manufacturer, int power)
        {
            Name = name;
            Picture = picture;
            Manufacturer = manufacturer;
            Power = power;
        }
    }
}
