using PcKonfigurator.Client.HttpClients;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Services
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ComponentClient _client;

        public ComponentRepository(ComponentClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Case>> GetCompatibleCasesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleCasesAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<CpuCooler>> GetCompatibleCpuCoolersAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleCpuCoolersAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Cpu>> GetCompatibleCpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleCpusAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Gpu>> GetCompatibleGpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleGpusAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleMotherboardsAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Psu>> GetCompatiblePsusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatiblePsusAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Ram>> GetCompatibleRamsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleRamsAsync(pcBuild, jwt, cancellationToken);
        }

        public async Task<IEnumerable<Storage>> GetCompatibleStoragesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            return await _client.GetCompatibleStoragesAsync(pcBuild, jwt, cancellationToken);
        }
    }
}
