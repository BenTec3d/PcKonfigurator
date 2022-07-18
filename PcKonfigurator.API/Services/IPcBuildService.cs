using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.Services
{
public interface IPcBuildService
{
        Task<PcBuildBase> CreatePcBuildBaseFromDto(PcBuildBaseDto pcBuildBaseDto);
    }
}
