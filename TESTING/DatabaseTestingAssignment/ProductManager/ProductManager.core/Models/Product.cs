

using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Data.Models
{
    public class Product
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0.01 ,int.MaxValue, ErrorMessage = "Negative Price is not allowed")]
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
