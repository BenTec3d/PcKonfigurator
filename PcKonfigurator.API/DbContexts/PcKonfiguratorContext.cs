using Microsoft.EntityFrameworkCore;
using PcKonfigurator.API.Entities;
using PcKonfigurator.Shared.Models;
using PcKonfigurator.Shared.Services;

namespace PcKonfigurator.API.DbContexts
{
    public class PcKonfiguratorContext : DbContext
    {
        public DbSet<InventoryEntity> Inventory { get; set; } = null!;
        public DbSet<EmployeeEntity> Employee { get; set; } = null!;
        public DbSet<CaseEntity> Case { get; set; } = null!;
        public DbSet<CpuEntity> Cpu { get; set; } = null!;
        public DbSet<CpuCoolerEntity> CpuCooler { get; set; } = null!;
        public DbSet<GpuEntity> Gpu { get; set; } = null!;
        public DbSet<MotherboardEntity> Motherboard { get; set; } = null!;
        public DbSet<PsuEntity> Psu { get; set; } = null!;
        public DbSet<RamEntity> Ram { get; set; } = null!;
        public DbSet<StorageEntity> Storage { get; set; } = null!;

        public PcKonfiguratorContext(DbContextOptions<PcKonfiguratorContext> options) : base(options)
        {

        }
    }
}
