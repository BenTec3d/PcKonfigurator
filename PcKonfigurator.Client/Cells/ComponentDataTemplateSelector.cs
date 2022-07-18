using PcKonfigurator.Shared.Models;

namespace PcKonfigurator.Client.Cells
{
    public class ComponentDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ComponentBaseTemplate { get; set; }
        public DataTemplate CpuTemplate { get; set; }
        public DataTemplate CpuCoolerTemplate { get; set; }
        public DataTemplate GpuTemplate { get; set; }
        public DataTemplate CaseTemplate { get; set; }
        public DataTemplate MotherboardTemplate { get; set; }
        public DataTemplate PsuTemplate { get; set; }
        public DataTemplate RamTemplate { get; set; }
        public DataTemplate StorageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Cpu)
                return CpuTemplate;
            if (item is CpuCooler)
                return CpuCoolerTemplate;
            if (item is Gpu)
                return GpuTemplate;
            if (item is Case)
                return CaseTemplate;
            if (item is Motherboard)
                return MotherboardTemplate;
            if (item is Psu)
                return PsuTemplate;
            if (item is Ram)
                return RamTemplate;
            if (item is Storage)
                return StorageTemplate;

            return ComponentBaseTemplate;
        }
    }
}
