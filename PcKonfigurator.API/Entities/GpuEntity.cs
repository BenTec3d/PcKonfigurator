using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class GpuEntity : ComponentBaseEntity
    {
        [Required]
        public double VramCapacity { get; set; }

        [Required]
        public double BaseFreq { get; set; }

        [Required]
        public double TurboFreq { get; set; }

        [Required]
        public int HeightInSlots { get; set; }

        [Required]
        public int PowerConnectors { get; set; }

        [Required]
        public bool RtRtCapable { get; set; }

        public GpuEntity(double vramCapacity, double baseFreq, double turboFreq, int heightInSlots, int powerConnectors, bool rtRtCapable, string name, string picture, string manufacturer, int power) : base(name, picture, manufacturer, power)
        {
            VramCapacity = vramCapacity;
            BaseFreq = baseFreq;
            TurboFreq = turboFreq;
            HeightInSlots = heightInSlots;
            PowerConnectors = powerConnectors;
            RtRtCapable = rtRtCapable;
        }
    }
}
