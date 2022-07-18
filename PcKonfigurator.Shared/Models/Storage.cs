namespace PcKonfigurator.Shared.Models
{
    public class Storage : ComponentBase
    {
        public string Size { get; set; }

        public string Connection { get; set; }

        public double Capacity { get; set; }

        public string Type { get; set; }

        public Storage(string size, string connection, double capacity, string type, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Size = size;
            Connection = connection;
            Capacity = capacity;
            Type = type;
        }
    }
}