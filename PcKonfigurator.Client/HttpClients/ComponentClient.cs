using Marvin.StreamExtensions;
using Microsoft.Extensions.Options;
using PcKonfigurator.Shared.Models;
using System.Net.Http.Headers;

namespace PcKonfigurator.Client.HttpClients
{
    public class ComponentClient
    {
        private readonly HttpClient _client;
        const string _baseUrl = "https://localhost:7187/api/v:1.0/components/";

        public ComponentClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        }

        public async Task<IEnumerable<Case>> GetCompatibleCasesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "case/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Case>>();
            }
        }

        public async Task<IEnumerable<Cpu>> GetCompatibleCpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "cpu/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Cpu>>();
            }
        }

        public async Task<IEnumerable<CpuCooler>> GetCompatibleCpuCoolersAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "cpucooler/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<CpuCooler>>();
            }
        }

        public async Task<IEnumerable<Gpu>> GetCompatibleGpusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "gpu/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Gpu>>();
            }
        }

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "motherboard/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Motherboard>>();
            }
        }

        public async Task<IEnumerable<Psu>> GetCompatiblePsusAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "psu/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Psu>>();
            }
        }

        public async Task<IEnumerable<Ram>> GetCompatibleRamsAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "ram/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Ram>>();
            }
        }

        public async Task<IEnumerable<Storage>> GetCompatibleStoragesAsync(PcBuildBase pcBuild, string jwt, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "storage/compatible?" + PcBuildBaseToQueryString(pcBuild);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<IEnumerable<Storage>>();
            }
        }

        private static string PcBuildBaseToQueryString(PcBuildBase pcBuild)
        {
            string query = "";

            if (pcBuild is null)
                return query;

            if (pcBuild.Case is not null)
                query += $"CaseId={pcBuild.Case.Id}&";

            if (pcBuild.Cpu is not null)
                query += $"CpuId={pcBuild.Cpu.Id}&";

            if (pcBuild.CpuCooler is not null)
                query += $"CpuCoolerId={pcBuild.CpuCooler.Id}&";

            if (pcBuild.Gpu is not null)
                query += $"GpuId={pcBuild.Gpu.Id}&";

            if (pcBuild.Motherboard is not null)
                query += $"MotherboardId={pcBuild.Motherboard.Id}&";

            if (pcBuild.Psu is not null)
                query += $"PsuId={pcBuild.Psu.Id}&";

            if (pcBuild.Ram is not null)
                query += $"RamId={pcBuild.Ram.Id}&";

            if (pcBuild.Storage is not null)
                query += $"StorageId={pcBuild.Storage.Id}&";

            return query;
        }
    }
}
