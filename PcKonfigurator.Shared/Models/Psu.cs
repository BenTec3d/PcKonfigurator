namespace PcKonfigurator.Shared.Models
{
    public class Psu : ComponentBase
    {
        public string Size { get; set; }

        public int GpuPowerConnectors { get; set; }

        public bool Modular { get; set; }

        public Psu(string size, int gpuPowerConnectors, bool modular, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Size = size;
            GpuPowerConnectors = gpuPowerConnectors;
            Modular = modular;
        }
    }
}