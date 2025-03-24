using ProductManagementSystem.Data;
using ProductManagementSystem.Services;
using ProductManagementSystem.UI;

IProductRepository repo = new ProductRepository();
IProductService service = new ProductService(repo);
Menu menu = new Menu(service);
menu.ShowMainMenu();
