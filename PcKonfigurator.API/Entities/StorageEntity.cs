using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class StorageEntity : ComponentBaseEntity
    {
        [Required]
        public string Size { get; set; }

        [Required]
        public string Connection { get; set; }

        [Required]
        public double Capacity { get; set; }

        [Required]
        public string Type { get; set; }

        public StorageEntity(string size, string connection, double capacity, string type, string name, string picture, string manufacturer, int power)
            : base(name, picture, manufacturer, power)
        {
            Size = size;
            Connection = connection;
            Capacity = capacity;
            Type = type;
        }
    }
}
