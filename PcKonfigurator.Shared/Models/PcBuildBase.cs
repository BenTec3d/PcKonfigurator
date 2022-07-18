namespace PcKonfigurator.Shared.Models
{
    public class PcBuildBase
    {
        public Case? Case { get; set; }
        public Cpu? Cpu { get; set; }
        public CpuCooler? CpuCooler { get; set; }
        public Gpu? Gpu { get; set; }
        public Motherboard? Motherboard { get; set; }
        public Psu? Psu { get; set; }
        public Ram? Ram { get; set; }
        public Storage? Storage { get; set; }
        public int TotalPowerConsumption
        {
            get
            {
                int totalPowerConsumption = 0;

                if (Case is not null)
                    totalPowerConsumption += Case.Power;

                if (Cpu is not null)
                    totalPowerConsumption += Cpu.Power;

                if (CpuCooler is not null)
                    totalPowerConsumption += CpuCooler.Power;

                if (Gpu is not null)
                    totalPowerConsumption += Gpu.Power;

                if (Motherboard is not null)
                    totalPowerConsumption += Motherboard.Power;

                if (Ram is not null)
                    totalPowerConsumption += Ram.Power;

                if (Storage is not null)
                    totalPowerConsumption += Storage.Power;

                return totalPowerConsumption;
            }
        }

        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;

                if (Case is not null && Case.InventoryItem is not null)
                    totalPrice += Case.InventoryItem.Price;

                if (Cpu is not null && Cpu.InventoryItem is not null)
                    totalPrice += Cpu.InventoryItem.Price;

                if (CpuCooler is not null && CpuCooler.InventoryItem is not null)
                    totalPrice += CpuCooler.InventoryItem.Price;

                if (Gpu is not null && Gpu.InventoryItem is not null)
                    totalPrice += Gpu.InventoryItem.Price;

                if (Motherboard is not null && Motherboard.InventoryItem is not null)
                    totalPrice += Motherboard.InventoryItem.Price;

                if (Ram is not null && Ram.InventoryItem is not null)
                    totalPrice += Ram.InventoryItem.Price;

                if (Storage is not null && Storage.InventoryItem is not null)
                    totalPrice += Storage.InventoryItem.Price;

                return totalPrice;
            }
        }

        public PcBuildBase()
        {

        }

        public PcBuildBase(Case? @case, Cpu? cpu, CpuCooler? cpuCooler, Gpu? gpu, Motherboard? motherboard, Psu? psu, Ram? ram, Storage? storage)
        {
            Case = @case;
            Cpu = cpu;
            CpuCooler = cpuCooler;
            Gpu = gpu;
            Motherboard = motherboard;
            Psu = psu;
            Ram = ram;
            Storage = storage;
        }
    }
}
