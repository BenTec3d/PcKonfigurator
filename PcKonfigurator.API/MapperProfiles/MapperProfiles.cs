using AutoMapper;
using PcKonfigurator.API.Entities;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.API.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<CaseEntity, Case>();
            CreateMap<CpuEntity, Cpu>();
            CreateMap<CpuCoolerEntity, CpuCooler>();
            CreateMap<GpuEntity, Gpu>();
            CreateMap<MotherboardEntity, Motherboard>();
            CreateMap<PsuEntity, Psu>();
            CreateMap<RamEntity, Ram>();
            CreateMap<StorageEntity, Storage>();

            CreateMap<InventoryEntity, Inventory>();

            CreateMap<EmployeeEntity, Employee>();
        }
    }
}
