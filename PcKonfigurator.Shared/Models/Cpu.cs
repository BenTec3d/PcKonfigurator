namespace PcKonfigurator.Shared.Models
{
    public class Cpu : ComponentBase
    {
        public string CompatibleSocket { get; set; }

        public string CompatibleChipsets { get; set; }

        public string Cores { get; set; }

        public string CompatibleRamTypes { get; set; }

        public double BaseFreq { get; set; }

        public double TurboFreq { get; set; }

        public CpuCooler? IncludedCooler { get; set; }
        public int? CoolerId { get; set; }

        public Cpu(string compatibleSocket, string compatibleChipsets, string cores, string compatibleRamTypes, double baseFreq, double turboFreq, string name, string picture, string manufacturer, int power)
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