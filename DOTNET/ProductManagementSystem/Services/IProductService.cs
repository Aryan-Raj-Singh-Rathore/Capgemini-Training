using System.Collections.Generic;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void SaveToFile();
        void LoadFromFile();
    }
}
