using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class PsuEntity : ComponentBaseEntity
    {
        [Required]
        public string Size { get; set; }

        [Required]
        public int GpuPowerConnectors { get; set; }

        [Required]
        public bool Modular { get; set; }

        public PsuEntity(string size, int gpuPowerConnectors, bool modular, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Size = size;
            GpuPowerConnectors = gpuPowerConnectors;
            Modular = modular;
        }
    }
}
