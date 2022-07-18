using PcKonfigurator.API.Entities;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.Repositories
{
    public interface IComponentRepository
    {
        Task<CaseEntity?> GetCaseAsync(int caseId);
        Task<CpuEntity?> GetCpuAsync(int cpuId);
        Task<CpuCoolerEntity?> GetCpuCoolerAsync(int cpuCoolerId);
        Task<GpuEntity?> GetGpuAsync(int gpuId);
        Task<MotherboardEntity?> GetMotherboardAsync(int motherboardId);
        Task<PsuEntity?> GetPsuAsync(int psuId);
        Task<RamEntity?> GetRamAsync(int ramId);
        Task<StorageEntity?> GetStorageAsync(int storageId);

        Task<IEnumerable<CaseEntity>> GetCompatibleCasesAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<CpuEntity>> GetCompatibleCpusAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<CpuCoolerEntity>> GetCompatibleCpuCoolersAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<GpuEntity>> GetCompatibleGpusAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<MotherboardEntity>> GetCompatibleMotherboardsAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<PsuEntity>> GetCompatiblePsusAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<RamEntity>> GetCompatibleRamsAsync(PcBuildBase pcBuildBase);
        Task<IEnumerable<StorageEntity>> GetCompatibleStoragesAsync(PcBuildBase pcBuildBase);
    }
}
