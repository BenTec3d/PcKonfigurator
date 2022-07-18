using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PcKonfigurator.API.DbContexts;
using PcKonfigurator.API.Entities;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly PcKonfiguratorContext _context;

        public ComponentRepository(PcKonfiguratorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CaseEntity?> GetCaseAsync(int caseId)
        {
            return await _context.Case.Where(x => x.Id == caseId).FirstOrDefaultAsync();
        }
        public async Task<CpuEntity?> GetCpuAsync(int cpuId)
        {
            return await _context.Cpu.Where(x => x.Id == cpuId).FirstOrDefaultAsync();
        }
        public async Task<CpuCoolerEntity?> GetCpuCoolerAsync(int cpuCoolerId)
        {
            return await _context.CpuCooler.Where(x => x.Id == cpuCoolerId).FirstOrDefaultAsync();
        }
        public async Task<GpuEntity?> GetGpuAsync(int gpuId)
        {
            return await _context.Gpu.Where(x => x.Id == gpuId).FirstOrDefaultAsync();
        }
        public async Task<MotherboardEntity?> GetMotherboardAsync(int motherboardId)
        {
            return await _context.Motherboard.Where(x => x.Id == motherboardId).FirstOrDefaultAsync();
        }
        public async Task<PsuEntity?> GetPsuAsync(int psuId)
        {
            return await _context.Psu.Where(x => x.Id == psuId).FirstOrDefaultAsync();
        }
        public async Task<RamEntity?> GetRamAsync(int ramId)
        {
            return await _context.Ram.Where(x => x.Id == ramId).FirstOrDefaultAsync();
        }
        public async Task<StorageEntity?> GetStorageAsync(int storageId)
        {
            return await _context.Storage.Where(x => x.Id == storageId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CaseEntity>> GetCompatibleCasesAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Case as IQueryable<CaseEntity>;

            if (pcBuildBase.CpuCooler is not null)
                collection = collection.Where(x => x.MaxCpuCoolerHeight >= pcBuildBase.CpuCooler.Height);

            if (pcBuildBase.Gpu is not null)
                collection = collection.Where(x => x.ExpansionSlots >= pcBuildBase.Gpu.HeightInSlots);

            if (pcBuildBase.Motherboard is not null)
                collection = collection.Where(x => x.CompatibleMotherboardSizes.Contains(pcBuildBase.Motherboard.Size));

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => x.CompatiblePsuSizes.Contains(pcBuildBase.Psu.Size)
                && pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<CpuEntity>> GetCompatibleCpusAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Cpu as IQueryable<CpuEntity>;

            if (pcBuildBase.CpuCooler is not null)
                collection = collection.Where(x => pcBuildBase.CpuCooler.CompatibleSockets.Contains(x.CompatibleSocket));

            if (pcBuildBase.Motherboard is not null)
                collection = collection.Where(x => x.CompatibleSocket.Contains(pcBuildBase.Motherboard.Socket)
                && x.CompatibleChipsets.Contains(pcBuildBase.Motherboard.Chipset));

            if (pcBuildBase.Ram is not null)
                collection = collection.Where(x => x.CompatibleRamTypes.Contains(pcBuildBase.Ram.Type));

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            return await collection.Include(x => x.InventoryItem).Include(x => x.IncludedCooler).Include(x => ((x.IncludedCooler == null) ? null : x.IncludedCooler.InventoryItem)).ToListAsync();
        }

        public async Task<IEnumerable<CpuCoolerEntity>> GetCompatibleCpuCoolersAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.CpuCooler as IQueryable<CpuCoolerEntity>;

            if (pcBuildBase.Case is not null)
                collection = collection.Where(x => x.Height <= pcBuildBase.Case.MaxCpuCoolerHeight);

            if (pcBuildBase.Cpu is not null)
                collection = collection.Where(x => x.CompatibleSockets.Contains(pcBuildBase.Cpu.CompatibleSocket));

            if (pcBuildBase.Motherboard is not null)
                collection = collection.Where(x => x.CompatibleSockets.Contains(pcBuildBase.Motherboard.Socket));

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            collection = collection.Where(x => x.InventoryItem.Sku.StartsWith("mm"));

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<GpuEntity>> GetCompatibleGpusAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Gpu as IQueryable<GpuEntity>;

            if (pcBuildBase.Case is not null)
                collection = collection.Where(x => x.HeightInSlots <= pcBuildBase.Case.ExpansionSlots);

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => x.PowerConnectors <= pcBuildBase.Psu.GpuPowerConnectors
                && pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<MotherboardEntity>> GetCompatibleMotherboardsAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Motherboard as IQueryable<MotherboardEntity>;

            if (pcBuildBase.Case is not null)
                collection = collection.Where(x => pcBuildBase.Case.CompatibleMotherboardSizes.Contains(x.Size));

            if (pcBuildBase.Cpu is not null)
                collection = collection.Where(x => pcBuildBase.Cpu.CompatibleSocket.Contains(x.Socket)
                && pcBuildBase.Cpu.CompatibleChipsets.Contains(x.Chipset));

            if (pcBuildBase.CpuCooler is not null)
                collection = collection.Where(x => pcBuildBase.CpuCooler.CompatibleSockets.Contains(x.Socket));

            if (pcBuildBase.Ram is not null)
                collection = collection.Where(x => x.CompatibleRamTypes.Contains(pcBuildBase.Ram.Type)
                && x.RamSlots >= pcBuildBase.Ram.NumberOfSticks);

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            if (pcBuildBase.Storage is not null && pcBuildBase.Storage.Connection == "SATA")
                collection = collection.Where(x => x.SataConnectors > 0);

            if (pcBuildBase.Storage is not null && pcBuildBase.Storage.Connection == "M.2")
                collection = collection.Where(x => x.M2Slots > 0);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<PsuEntity>> GetCompatiblePsusAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Psu as IQueryable<PsuEntity>;

            if (pcBuildBase.Case is not null)
                collection = collection.Where(x => pcBuildBase.Case.CompatiblePsuSizes.Contains(x.Size));

            if (pcBuildBase.Gpu is not null)
                collection = collection.Where(x => x.GpuPowerConnectors >= pcBuildBase.Gpu.PowerConnectors);

            collection = collection.Where(x => x.Power >= pcBuildBase.TotalPowerConsumption);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<RamEntity>> GetCompatibleRamsAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Ram as IQueryable<RamEntity>;

            if (pcBuildBase.Cpu is not null)
                collection = collection.Where(x => pcBuildBase.Cpu.CompatibleRamTypes.Contains(x.Type));

            if (pcBuildBase.Motherboard is not null)
                collection = collection.Where(x => pcBuildBase.Motherboard.CompatibleRamTypes.Contains(x.Type)
                && x.NumberOfSticks <= pcBuildBase.Motherboard.RamSlots);

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }

        public async Task<IEnumerable<StorageEntity>> GetCompatibleStoragesAsync(PcBuildBase pcBuildBase)
        {
            var collection = _context.Storage as IQueryable<StorageEntity>;

            if (pcBuildBase.Motherboard is not null && pcBuildBase.Motherboard.SataConnectors == 0)
                collection = collection.Where(x => x.Connection != "SATA");

            if (pcBuildBase.Motherboard is not null && pcBuildBase.Motherboard.M2Slots == 0)
                collection = collection.Where(x => x.Connection != "M.2");

            if (pcBuildBase.Psu is not null)
                collection = collection.Where(x => pcBuildBase.TotalPowerConsumption + x.Power <= pcBuildBase.Psu.Power);

            return await collection.Include(x => x.InventoryItem).ToListAsync();
        }
    }
}
