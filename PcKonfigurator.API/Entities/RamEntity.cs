using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class RamEntity : ComponentBaseEntity
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public int TotalCapacity { get; set; }

        [Required]
        public double Frequency { get; set; }

        [Required]
        public int NumberOfSticks { get; set; }

        public RamEntity(string type, int totalCapacity, double frequency, int numberOfSticks, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Type = type;
            TotalCapacity = totalCapacity;
            Frequency = frequency;
            NumberOfSticks = numberOfSticks;
        }
    }
}
