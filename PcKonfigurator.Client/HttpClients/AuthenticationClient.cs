using Marvin.StreamExtensions;
using Newtonsoft.Json;
using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;
using System.Net.Http.Headers;
using System.Text;

namespace PcKonfigurator.Client.HttpClients
{
    public class AuthenticationClient
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _client;
        const string _baseUrl = "https://localhost:7187/api/v:1.0/authentication/";

        public AuthenticationClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        }

        public async Task<Employee> AuthenticateAsync(LoginDto login, CancellationToken cancellationToken)
        {
            var url = _baseUrl + "authenticate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            string json = JsonConvert.SerializeObject(login);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<Employee>();
            }
        }
    }
}
