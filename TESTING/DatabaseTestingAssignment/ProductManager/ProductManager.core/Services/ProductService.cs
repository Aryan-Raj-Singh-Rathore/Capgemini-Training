using ProductManagement.Data.Data;
using ProductManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product GetProductByName(string name)
        {
            return _context.Products
                .Where(c => c.Name == name)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            return _context.Products
                .Where(c => c.IsActive)
                .ToList();
        }

        public Product CreateProduct(Product product)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

            if (!isValid)
            {
                return null;
            }
            product.IsActive = true;
            product.CreatedDate = DateTime.Now;
            if( product.Price>0)
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
                return false;

            existingProduct.Id = product.Id;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.LastModifiedDate = DateTime.Now;

            _context.SaveChanges();
            return true;
        }


        public bool DeleteProduct(Product product)
        {
            var product1 = _context.Products.Find(product.Id);
            if (product1 == null)
                return false;

            _context.Products.Remove(product1);
            _context.SaveChanges();
            return true;
        }

        public int GetProductCount()
        {
            return _context.Products.Count();
        }

        public bool BulkCreateProducts(List<Product> products)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var product in products)

                {
                    product.CreatedDate = DateTime.Now;
                    _context.Products.Add(product);
                }
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
        public bool DeactivateProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return false;
            product.IsActive = false;
            product.LastModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
    }
}
