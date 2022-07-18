namespace PcKonfigurator.Shared.Models
{
    public class Gpu : ComponentBase
    {
        public double VramCapacity { get; set; }

        public double BaseFreq { get; set; }

        public double TurboFreq { get; set; }

        public int HeightInSlots { get; set; }

        public int PowerConnectors { get; set; }

        public bool RtRtCapable { get; set; }

        public Gpu(double vramCapacity, double baseFreq, double turboFreq, int heightInSlots, int powerConnectors, bool rtRtCapable, string name, string picture, string manufacturer, int power) : base(name, picture, manufacturer, power)
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