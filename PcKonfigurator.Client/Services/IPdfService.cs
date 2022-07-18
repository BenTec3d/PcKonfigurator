using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Services
{
    public interface IPdfService
    {
        void PcBuildAsPdf(PcBuildBase pcBuild, Employee employee);
    }
}
