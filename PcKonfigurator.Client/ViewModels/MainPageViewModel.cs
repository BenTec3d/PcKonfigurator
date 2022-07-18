using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PcKonfigurator.Client.Services;
using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.ViewModels
{
    [QueryProperty(nameof(Employee), nameof(Employee))]
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IPdfService _pdfService;
        private CancellationTokenSource _cancellationTokenSource = new();

        [ObservableProperty]
        Employee _employee;

        [ObservableProperty]
        PcBuildBase _pcBuild;

        [ObservableProperty]
        bool _buildComplete;

        [ObservableProperty]
        ComponentBase _selectedComponent;

        public ObservableCollection<ComponentBase> Components { get; } = new();

        public MainPageViewModel(IComponentRepository componentRepository, IPdfService pdfService)
        {
            _componentRepository = componentRepository ?? throw new ArgumentNullException(nameof(componentRepository));
            _pdfService = pdfService ?? throw new ArgumentNullException(nameof(pdfService));
            Title = "Medium Markt PC Konfigurator";

            PcBuild = new();
        }

        [ICommand]
        private void AddComponentToPcBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            if (_selectedComponent is Case)
                newPcBuild.Case = (Case)_selectedComponent;

            if (_selectedComponent is Cpu)
            {
                if (newPcBuild.CpuCooler is not null && newPcBuild.CpuCooler.InventoryItem.Sku.StartsWith("oem"))
                    newPcBuild.CpuCooler = null;

                if (newPcBuild.CpuCooler is null && ((Cpu)_selectedComponent).IncludedCooler is not null)
                    newPcBuild.CpuCooler = ((Cpu)_selectedComponent).IncludedCooler;

                newPcBuild.Cpu = (Cpu)_selectedComponent;
            }

            if (_selectedComponent is CpuCooler)
                newPcBuild.CpuCooler = (CpuCooler)_selectedComponent;

            if (_selectedComponent is Gpu)
                newPcBuild.Gpu = (Gpu)_selectedComponent;

            if (_selectedComponent is Motherboard)
                newPcBuild.Motherboard = (Motherboard)_selectedComponent;

            if (_selectedComponent is Psu)
                newPcBuild.Psu = (Psu)_selectedComponent;

            if (_selectedComponent is Ram)
                newPcBuild.Ram = (Ram)_selectedComponent;

            if (_selectedComponent is Storage)
                newPcBuild.Storage = (Storage)_selectedComponent;

            PcBuild = newPcBuild;

            VerifyBuildCompletion();
        }

        [ICommand]
        private async Task GetCompatibleCasesAsync()
        {
            IEnumerable<Case> ComponentList = await _componentRepository.GetCompatibleCasesAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleCpusAsync()
        {
            IEnumerable<Cpu> ComponentList = await _componentRepository.GetCompatibleCpusAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleCpuCoolerssAsync()
        {
            IEnumerable<CpuCooler> ComponentList = await _componentRepository.GetCompatibleCpuCoolersAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleGpusAsync()
        {
            IEnumerable<Gpu> ComponentList = await _componentRepository.GetCompatibleGpusAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleMotherboardsAsync()
        {
            IEnumerable<Motherboard> ComponentList = await _componentRepository.GetCompatibleMotherboardsAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatiblePsusAsync()
        {
            IEnumerable<Psu> ComponentList = await _componentRepository.GetCompatiblePsusAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleRamsAsync()
        {
            IEnumerable<Ram> ComponentList = await _componentRepository.GetCompatibleRamsAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private async Task GetCompatibleStoragesAsync()
        {
            IEnumerable<Storage> ComponentList = await _componentRepository.GetCompatibleStoragesAsync(PcBuild, Employee.Jwt, _cancellationTokenSource.Token);
            Components.Clear();
            foreach (var component in ComponentList)
            {
                Components.Add(component);
            }
        }

        [ICommand]
        private void RemoveCaseFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Case = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveCpuFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            if (newPcBuild.CpuCooler is not null && newPcBuild.Cpu.IncludedCooler is not null)
                if (newPcBuild.CpuCooler.Id == newPcBuild.Cpu.IncludedCooler.Id)
                    newPcBuild.CpuCooler = null;

            newPcBuild.Cpu = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveCpuCoolerFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.CpuCooler = null;

            if (newPcBuild.Cpu is not null && newPcBuild.Cpu.IncludedCooler is not null)
                newPcBuild.CpuCooler = newPcBuild.Cpu.IncludedCooler;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveGpuFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Gpu = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveMotherboardFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Motherboard = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemovePsuFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Psu = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveRamFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Ram = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void RemoveStorageFromBuild()
        {
            PcBuildBase newPcBuild = new(PcBuild.Case, PcBuild.Cpu, PcBuild.CpuCooler, PcBuild.Gpu, PcBuild.Motherboard, PcBuild.Psu, PcBuild.Ram, PcBuild.Storage);

            newPcBuild.Storage = null;

            PcBuild = newPcBuild;
            VerifyBuildCompletion();
        }

        [ICommand]
        private void SaveAsPdf()
        {
            _pdfService.PcBuildAsPdf(PcBuild, Employee);
        }

        private void VerifyBuildCompletion()
        {
            bool buildComplete = true;

            if (PcBuild.Case is null)
                buildComplete = false;

            if (PcBuild.Cpu is null)
                buildComplete = false;

            if (PcBuild.CpuCooler is null)
                buildComplete = false;

            if (PcBuild.Gpu is null)
                buildComplete = false;

            if (PcBuild.Motherboard is null)
                buildComplete = false;

            if (PcBuild.Ram is null)
                buildComplete = false;

            if (PcBuild.Psu is null)
                buildComplete = false;

            if (PcBuild.Storage is null)
                buildComplete = false;

            BuildComplete = buildComplete;
        }
    }
}
