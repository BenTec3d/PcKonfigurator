namespace PcKonfigurator.Shared.Models
{
    public class Ram : ComponentBase
    {
        public string Type { get; set; }

        public int TotalCapacity { get; set; }

        public double Frequency { get; set; }

        public int NumberOfSticks { get; set; }

        public Ram(string type, int totalCapacity, double frequency, int numberOfSticks, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Type = type;
            TotalCapacity = totalCapacity;
            Frequency = frequency;
            NumberOfSticks = numberOfSticks;
        }
    }
}