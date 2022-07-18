using AutoMapper;
using PcKonfigurator.API.Repositories;
using PcKonfigurator.Shared.DTOs;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.Services
{
    public class PcBuildService : IPcBuildService
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        public PcBuildService(IComponentRepository componentRepository, IMapper mapper)
        {
            _componentRepository = componentRepository ?? throw new ArgumentNullException(nameof(componentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PcBuildBase> CreatePcBuildBaseFromDto(PcBuildBaseDto pcBuildBaseDto)
{
            var pcBuildBase = new PcBuildBase();

            if (pcBuildBaseDto.CaseId is not null)
                pcBuildBase.Case = _mapper.Map<Case>(await _componentRepository.GetCaseAsync((int)pcBuildBaseDto.CaseId));

            if (pcBuildBaseDto.CpuId is not null)
                pcBuildBase.Cpu = _mapper.Map<Cpu>(await _componentRepository.GetCpuAsync((int)pcBuildBaseDto.CpuId));

            if (pcBuildBaseDto.CpuCoolerId is not null)
                pcBuildBase.CpuCooler = _mapper.Map<CpuCooler>(await _componentRepository.GetCpuCoolerAsync((int)pcBuildBaseDto.CpuCoolerId));

            if (pcBuildBaseDto.GpuId is not null)
                pcBuildBase.Gpu = _mapper.Map<Gpu>(await _componentRepository.GetGpuAsync((int)pcBuildBaseDto.GpuId));

            if (pcBuildBaseDto.MotherboardId is not null)
                pcBuildBase.Motherboard = _mapper.Map<Motherboard>(await _componentRepository.GetMotherboardAsync((int)pcBuildBaseDto.MotherboardId));

            if (pcBuildBaseDto.PsuId is not null)
                pcBuildBase.Psu = _mapper.Map<Psu>(await _componentRepository.GetPsuAsync((int)pcBuildBaseDto.PsuId));

            if (pcBuildBaseDto.RamId is not null)
                pcBuildBase.Ram = _mapper.Map<Ram>(await _componentRepository.GetRamAsync((int)pcBuildBaseDto.RamId));

            if (pcBuildBaseDto.StorageId is not null)
                pcBuildBase.Storage = _mapper.Map<Storage>(await _componentRepository.GetStorageAsync((int)pcBuildBaseDto.StorageId));

            return pcBuildBase;
        }
    }
}
