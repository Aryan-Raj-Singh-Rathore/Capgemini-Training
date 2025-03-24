using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Models;

namespace ProductManagement.Data.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        Product GetProductByName(string name);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetActiveProducts();
        Product CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        public bool DeactivateProduct(int id);
        public bool BulkCreateProducts(List<Product> products);
        int GetProductCount();
    }
}