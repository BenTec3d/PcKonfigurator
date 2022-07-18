using PcKonfigurator.Client.HttpClients;
using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationClient _client;

        public AuthenticationRepository(AuthenticationClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public Task<Employee> AuthenticateAsync(LoginDto login, CancellationToken cancellationToken)
        {
            return _client.AuthenticateAsync(login, cancellationToken);
        }
    }
}
