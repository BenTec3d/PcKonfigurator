namespace PcKonfigurator.Shared.Models
{
    public class Motherboard : ComponentBase
    {
        public string Socket { get; set; }

        public string Chipset { get; set; }

        public string Size { get; set; }

        public string CompatibleRamTypes { get; set; }

        public int RamSlots { get; set; }

        public int M2Slots { get; set; }

        public int SataConnectors { get; set; }

        public Motherboard(string socket, string chipset, string size, string compatibleRamTypes, int ramSlots, int m2Slots, int sataConnectors, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Socket = socket;
            Chipset = chipset;
            Size = size;
            CompatibleRamTypes = compatibleRamTypes;
            RamSlots = ramSlots;
            M2Slots = m2Slots;
            SataConnectors = sataConnectors;
        }
    }
}