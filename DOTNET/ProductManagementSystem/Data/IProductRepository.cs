using System.Collections.Generic;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Data
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void SaveToFile(string filePath);
        void LoadFromFile(string filePath);
    }
}
