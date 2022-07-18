using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class CaseEntity : ComponentBaseEntity
    {
        [Required]
        public double VolumeInLiters { get; set; }

        [Required]
        public string CompatibleMotherboardSizes { get; set; }

        [Required]
        public string CompatiblePsuSizes { get; set; }

        [Required]
        public double MaxCpuCoolerHeight { get; set; }

        [Required]
        public int StorageBayLarge { get; set; }

        [Required]
        public int StorageBaySmall { get; set; }

        [Required]
        public int StorageBayFlex { get; set; }

        [Required]
        public int ExpansionSlots { get; set; }

        public CaseEntity(double volumeInLiters, string compatibleMotherboardSizes, string compatiblePsuSizes, double maxCpuCoolerHeight, int storageBayLarge, int storageBaySmall, int storageBayFlex, int expansionSlots
            , string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            VolumeInLiters = volumeInLiters;
            CompatibleMotherboardSizes = compatibleMotherboardSizes;
            CompatiblePsuSizes = compatiblePsuSizes;
            MaxCpuCoolerHeight = maxCpuCoolerHeight;
            StorageBayLarge = storageBayLarge;
            StorageBaySmall = storageBaySmall;
            StorageBayFlex = storageBayFlex;
            ExpansionSlots = expansionSlots;
        }
    }
}
