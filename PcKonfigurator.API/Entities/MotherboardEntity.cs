using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class MotherboardEntity : ComponentBaseEntity
    {
        [Required]
        public string Socket { get; set; }

        [Required]
        public string Chipset { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string CompatibleRamTypes { get; set; }

        [Required]
        public int RamSlots { get; set; }

        [Required]
        public int M2Slots { get; set; }

        [Required]
        public int SataConnectors { get; set; }

        public MotherboardEntity(string socket, string chipset, string size, string compatibleRamTypes, int ramSlots, int m2Slots, int sataConnectors, string name, string picture, string manufacturer, int power)
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
