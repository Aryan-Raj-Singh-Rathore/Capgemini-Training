using System;
using System.Collections.Generic;
using ProductManagementSystem.Data;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly string filePath = "products.json";

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            if (product.ProductId <= 0 || product.Price <= 0 || product.QuantityInStock < 0)
            {
                Console.WriteLine("Error: Invalid product data.");
                return;
            }
            _repository.AddProduct(product);
        }

        public List<Product> GetAllProducts() => _repository.GetAllProducts();

        public Product GetProductById(int id) => _repository.GetProductById(id);

        public void UpdateProduct(Product product) => _repository.UpdateProduct(product);

        public void DeleteProduct(int id) => _repository.DeleteProduct(id);

        public void SaveToFile() => _repository.SaveToFile(filePath);

        public void LoadFromFile() => _repository.LoadFromFile(filePath);
    }
}
