using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcKonfigurator.API.Entities
{
    public class CpuEntity : ComponentBaseEntity
    {
        [Required]
        public string CompatibleSocket { get; set; }

        [Required]
        public string CompatibleChipsets { get; set; }

        [Required]
        public string Cores { get; set; }

        [Required]
        public string CompatibleRamTypes { get; set; }

        [Required]
        public double BaseFreq { get; set; }

        [Required]
        public double TurboFreq { get; set; }

        [ForeignKey("CoolerId")]
        public CpuCoolerEntity? IncludedCooler { get; set; }
        public int? CoolerId { get; set; }

        public CpuEntity(string compatibleSocket, string compatibleChipsets, string cores, string compatibleRamTypes, double baseFreq, double turboFreq, string name, string picture, string manufacturer, int power) 
            : base(name, picture, manufacturer, power)
        {
            CompatibleSocket = compatibleSocket;
            CompatibleChipsets = compatibleChipsets;
            Cores = cores;
            CompatibleRamTypes = compatibleRamTypes;
            BaseFreq = baseFreq;
            TurboFreq = turboFreq;
        }
    }
}
