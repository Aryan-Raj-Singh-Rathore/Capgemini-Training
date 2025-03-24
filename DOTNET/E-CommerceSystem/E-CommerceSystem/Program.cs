using System;
using System.Collections.Generic;

public interface IDiscountable
{
    decimal ApplyDiscount(decimal percentage);
    bool IsDiscountable { get; }
}

public abstract class Product : IDiscountable
{
    private string productId;
    private string name;
    private string description;
    private decimal price;
    private int inventoryCount;
    public double Weight { get; set; }

    public string ProductId { get => productId; }
    public string Name { get => name; }
    public string Description { get => description; }
    public decimal Price { get => price; }
    public int InventoryCount { get => inventoryCount; }

    public Product(string productId, string name, string description, decimal price, int inventoryCount)
    {
        if (string.IsNullOrEmpty(productId)) throw new ArgumentException("Product ID cannot be null or empty.");
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Product name cannot be null or empty.");
        if (price <= 0) throw new ArgumentException("Price must be positive.");
        if (inventoryCount < 0) throw new ArgumentException("Inventory count cannot be negative.");

        this.productId = productId;
        this.name = name;
        this.description = description;
        this.price = price;
        this.inventoryCount = inventoryCount;
    }

    public abstract decimal CalculateTax();
    public virtual string GetDetails()
    {
        return $"Product ID: {productId}, Name: {name}, Description: {description}, Price: {price:C}, Inventory: {inventoryCount}";
    }

    public bool IsDiscountable => inventoryCount > 0;

    public decimal ApplyDiscount(decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentException("Discount percentage must be between 0 and 100.");
        return price - (price * percentage / 100);
    }
}

public class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; }

    public ElectronicProduct(string productId, string name, decimal price, int inventoryCount)
        : base(productId, name, "Electronic Product", price, inventoryCount) { }

    public override decimal CalculateTax() => Price * 0.08m;

    public override string GetDetails()
    {
        return base.GetDetails() + $", Warranty: {WarrantyPeriod} months, Weight: {Weight} kg";
    }
}

public class BookProduct : Product
{
    public string Author { get; set; }
    public string ISBN { get; set; }

    public BookProduct(string productId, string name, decimal price, int inventoryCount)
        : base(productId, name, "Book", price, inventoryCount) { }

    public override decimal CalculateTax() => Price * 0.06m;

    public override string GetDetails()
    {
        return base.GetDetails() + $", Author: {Author}, ISBN: {ISBN}, Weight: {Weight} kg";
    }
}

public class ClothingProduct : Product
{
    public string Size { get; set; }
    public string Color { get; set; }

    public ClothingProduct(string productId, string name, decimal price, int inventoryCount)
        : base(productId, name, "Clothing", price, inventoryCount) { }

    public override decimal CalculateTax() => Price * 0.075m;

    public override string GetDetails()
    {
        return base.GetDetails() + $", Size: {Size}, Color: {Color}, Weight: {Weight} kg";
    }
}

public enum MembershipLevel
{
    Regular,
    Premium,
    VIP
}

public class ShoppingCart
{
    public List<(Product product, int quantity)> Products { get; set; }

    public ShoppingCart()
    {
        Products = new List<(Product product, int quantity)>();
    }

    public void AddProduct(Product product, int quantity)
    {
        if (product.InventoryCount < quantity)
            throw new InvalidOperationException($"Product {product.Name} is out of stock.");
        Products.Add((product, quantity));
    }

    public decimal CalculateSubtotal()
    {
        decimal subtotal = 0;
        foreach (var item in Products)
        {
            subtotal += item.product.Price * item.quantity;
        }
        return subtotal;
    }

    public decimal CalculateTotalTax()
    {
        decimal totalTax = 0;
        foreach (var item in Products)
        {
            totalTax += item.product.CalculateTax() * item.quantity;
        }
        return totalTax;
    }

    public decimal ApplyDiscounts()
    {
        decimal totalDiscount = 0;
        foreach (var item in Products)
        {
            if (item.product.IsDiscountable)
            {
                totalDiscount += item.product.ApplyDiscount(10);
            }
        }
        return totalDiscount;
    }
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public MembershipLevel MembershipLevel { get; set; }
    public ShoppingCart ShoppingCart { get; set; }

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
        ShoppingCart = new ShoppingCart();
    }

    public decimal CalculateLoyaltyDiscount()
    {
        switch (MembershipLevel)
        {
            case MembershipLevel.Premium:
                return 0.05m;
            case MembershipLevel.VIP:
                return 0.1m;
            default:
                return 0m;
        }
    }
}

public enum ShippingMethod
{
    Standard,
    Express,
    NextDay
}

public class Order
{
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public List<(Product product, int quantity)> Products { get; set; }

    public Order(Customer customer, string orderId)
    {
        OrderId = orderId;
        Customer = customer;
        OrderDate = DateTime.Now;
        Products = new List<(Product product, int quantity)>();
    }

    public void ProcessOrder()
    {
        foreach (var item in Customer.ShoppingCart.Products)
        {
            Products.Add(item);
        }
    }

    public string GenerateReceipt()
    {
        decimal subtotal = Customer.ShoppingCart.CalculateSubtotal();
        decimal tax = Customer.ShoppingCart.CalculateTotalTax();
        decimal loyaltyDiscount = Customer.CalculateLoyaltyDiscount();
        decimal discountTotal = Customer.ShoppingCart.ApplyDiscounts();
        decimal shippingCost = ShippingMethod == ShippingMethod.Express ? 15 : 10;
        decimal total = subtotal + tax - discountTotal - loyaltyDiscount + shippingCost;

        string receipt = $"====== ORDER RECEIPT ======\n";
        receipt += $"Order ID: {OrderId}\n";
        receipt += $"Date: {OrderDate}\n";
        receipt += $"Customer: {Customer.Name}\n";
        receipt += $"Email: {Customer.Email}\n";
        receipt += $"Address: {Customer.Address}\n";
        receipt += $"Membership: {Customer.MembershipLevel}\n";
        receipt += $"Items:\n";

        foreach (var item in Products)
        {
            decimal discount = item.product.ApplyDiscount(10);
            decimal subtotalItem = item.product.Price * item.quantity;
            decimal taxItem = item.product.CalculateTax() * item.quantity;

            receipt += $"{item.product.Name} ({item.product.ProductId})\n";
            receipt += $"Original Price: {item.product.Price:C}\n";
            receipt += $"Discount: {discount:C} (10%)\n";
            receipt += $"Quantity: {item.quantity}\n";
            receipt += $"Subtotal: {subtotalItem:C}\n";
            receipt += $"Tax ({item.product.CalculateTax() * 100}%): {taxItem:C}\n";
            receipt += $"Details: {item.product.GetDetails()}\n";
        }

        receipt += $"Order Summary:\n";
        receipt += $"Subtotal: {subtotal:C}\n";
        receipt += $"Tax: {tax:C}\n";
        receipt += $"Loyalty Discount: {loyaltyDiscount:C}\n";
        receipt += $"Shipping: {shippingCost:C}\n";
        receipt += $"Total: {total:C}\n";
        receipt += $"Thank you for shopping with us!\n";
        receipt += "============================";

        return receipt;
    }
}

public class ECommerceSystem
{
    private List<Product> Inventory;
    private List<Customer> Customers;
    private List<Order> Orders;

    public ECommerceSystem()
    {
        Inventory = new List<Product>();
        Customers = new List<Customer>();
        Orders = new List<Order>();
    }

    public void AddProductToInventory(Product product) => Inventory.Add(product);

    public void ProcessOrder(Order order)
    {
        Orders.Add(order);
    }

    public void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report:");
        foreach (var order in Orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Total: {order.GenerateReceipt()}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var laptop = new ElectronicProduct("E001", "Gaming Laptop", 1200.00m, 10) { WarrantyPeriod = 24, Weight = 2.5 };
        var book = new BookProduct("B001", "C# Programming Guide", 45.99m, 50) { Author = "John Smith", ISBN = "978-3-16-148410-0", Weight = 0.8 };
        var shirt = new ClothingProduct("C001", "Casual Shirt", 29.99m, 100) { Size = "L", Color = "Blue", Weight = 0.3 };

        var customer = new Customer("Alice Johnson", "alice@example.com")
        {
            Address = "123 Main St, Anytown, USA",
            MembershipLevel = MembershipLevel.Premium
        };

        customer.ShoppingCart.AddProduct(laptop, 1);
        customer.ShoppingCart.AddProduct(book, 2);
        customer.ShoppingCart.AddProduct(shirt, 3);

        laptop.ApplyDiscount(10.0m);
        book.ApplyDiscount(5.0m);

        decimal loyaltyDiscount = customer.CalculateLoyaltyDiscount();

        var order = new Order(customer, "ORD-2023-001")
        {
            ShippingMethod = ShippingMethod.Express
        };
        order.ProcessOrder();

        string receipt = order.GenerateReceipt();
        Console.WriteLine(receipt);

        try
        {
            var smartphone = new ElectronicProduct("E002", "Smartphone", 800.00m, 0);
            customer.ShoppingCart.AddProduct(smartphone, 1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
