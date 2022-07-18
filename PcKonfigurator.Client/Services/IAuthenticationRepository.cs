using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Services
{
    public interface IAuthenticationRepository
    {
        Task<Employee> AuthenticateAsync(LoginDto login, CancellationToken cancellationToken);
    }
}
