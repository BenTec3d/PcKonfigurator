using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class ComponentBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        [ForeignKey("InventoryId")]
        public InventoryEntity? InventoryItem { get; set; }
        public int InventoryId { get; set; }

        public ComponentBaseEntity(string name, string picture, string manufacturer, int power)
        {
            Name = name;
            Picture = picture;
            Manufacturer = manufacturer;
            Power = power;
        }
    }
}
