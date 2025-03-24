using System;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return $"{ProductId} | {Name} | {Category} | ${Price} | Stock: {QuantityInStock}";
        }
    }
}
