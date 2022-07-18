using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PcKonfigurator.API.Entities
{
    public class InventoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Sku { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Stock { get; set; }

        public InventoryEntity(string sku, double price, double stock)
        {
            Sku = sku;
            Price = price;
            Stock = stock;
        }
    }
}
