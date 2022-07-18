namespace PcKonfigurator.Shared.Models
{
    public class Case : ComponentBase
    {
        public double VolumeInLiters { get; set; }

        public string CompatibleMotherboardSizes { get; set; }

        public string CompatiblePsuSizes { get; set; }

        public double MaxCpuCoolerHeight { get; set; }

        public int StorageBayLarge { get; set; }

        public int StorageBaySmall { get; set; }

        public int StorageBayFlex { get; set; }

        public int ExpansionSlots { get; set; }

        public Case(double volumeInLiters, string compatibleMotherboardSizes, string compatiblePsuSizes, double maxCpuCoolerHeight, int storageBayLarge, int storageBaySmall, int storageBayFlex, int expansionSlots
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