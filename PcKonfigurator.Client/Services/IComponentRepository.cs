using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Services
{
    public interface IComponentRepository
    {
        Task<IEnumerable<Case>> GetCompatibleCasesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Cpu>> GetCompatibleCpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<CpuCooler>> GetCompatibleCpuCoolersAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Gpu>> GetCompatibleGpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Psu>> GetCompatiblePsusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Ram>> GetCompatibleRamsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
        Task<IEnumerable<Storage>> GetCompatibleStoragesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken);
    }
}
