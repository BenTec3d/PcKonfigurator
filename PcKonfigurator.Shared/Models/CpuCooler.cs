namespace PcKonfigurator.Shared.Models
{
    public class CpuCooler : ComponentBase
    {
        public string CompatibleSockets { get; set; }

        public double Height { get; set; }

        public CpuCooler(string compatibleSockets, double height, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            CompatibleSockets = compatibleSockets;
            Height = height;
        }
    }
}