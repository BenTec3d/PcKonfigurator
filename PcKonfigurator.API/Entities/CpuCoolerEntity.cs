using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class CpuCoolerEntity : ComponentBaseEntity
    {
        [Required]
        public string CompatibleSockets { get; set; }

        [Required]
        public double Height { get; set; }

        public CpuCoolerEntity(string compatibleSockets, double height, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            CompatibleSockets = compatibleSockets;
            Height = height;
        }
    }
}
