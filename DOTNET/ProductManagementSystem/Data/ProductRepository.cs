using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Data
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.ProductId == id);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var product = GetProductById(updatedProduct.ProductId);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Category = updatedProduct.Category;
                product.Price = updatedProduct.Price;
                product.QuantityInStock = updatedProduct.QuantityInStock;
                product.IsDiscontinued = updatedProduct.IsDiscontinued;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}
