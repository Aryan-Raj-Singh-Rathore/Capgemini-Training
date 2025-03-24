using System;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.UI
{
    public class Menu
    {
        private readonly IProductService _service;

        public Menu(IProductService service)
        {
            _service = service;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nPRODUCT MANAGEMENT SYSTEM");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Add New Product");
                Console.WriteLine("3. Save Data to File");
                Console.WriteLine("4. Load Data from File");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var products = _service.GetAllProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine(product);
                        }
                        break;
                    case "2":
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        _service.AddProduct(new Product { ProductId = new Random().Next(1, 1000), Name = name, Price = price });
                        Console.WriteLine("Product added successfully!");
                        break;
                    case "3":
                        _service.SaveToFile();
                        Console.WriteLine("Data saved.");
                        break;
                    case "4":
                        _service.LoadFromFile();
                        Console.WriteLine("Data loaded.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
