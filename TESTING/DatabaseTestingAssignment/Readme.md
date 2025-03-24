Name: Aryan Raj Singh Rathore
Batch: 01

Assignment:  ProductManagement - Database Testing 

1. Project Setup Steps
Step 1: Create Solution and Projects
1.	Create a new solution:
o	The solution is named ProductManagement.
2.	Add two projects to the solution:
o	ProductManagement.Data: A Class Library project for the Data Access layer.
o	ProductManagement.Tests: An NUnit Test Project for writing and running unit tests.
3.	Set up project references:
o	Added a reference to ProductManagement.Data in the ProductManagement.Tests project to enable testing of the data access layer.

Step 2: Configure Data Project
1.	Install required NuGet packages in ProductManagement.Data:
o	Microsoft.EntityFrameworkCore: For Entity Framework Core support.
o	Microsoft.EntityFrameworkCore.SqlServer: For SQL Server database provider.
In Visual Studio, you can install these packages via the NuGet Package Manager:
o	Right-click on ProductManagement.Data project -> Manage NuGet Packages -> Browse and search for each package (e.g., Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer) and click Install.
2.	Create the following folder structure in ProductManagement.Data:
o	Models/: To store the model classes.
o	Data/: To store database-related configurations, such as the DbContext.
o	Services/: To store service interfaces and implementations.
3.	Create Product Entity with the following properties:
o	The Product class is created in the Models/ folder and contains the following properties: 
o	public class Product
o	{
o	    public int Id { get; set; }
o	    public string Name { get; set; }
o	    public string Description { get; set; }
o	    public decimal Price { get; set; }
o	    public int StockQuantity { get; set; }
o	    public bool IsActive { get; set; }
o	    public DateTime CreatedDate { get; set; }
o	    public DateTime? LastModifiedDate { get; set; }
o	}
4.	Implement the required classes:
o	ProductDbContext: This class is responsible for configuring the database context and interacting with the database.
o	IProductService: This interface is created in the Services/ folder and defines the operations for managing Product entities.
o	ProductService: The implementation of the IProductService interface. It handles business logic and interacts with the database using ProductDbContext.

Step 3: Configure Test Project
1.	Install required NuGet packages in ProductManagement.Tests:
o	NUnit: The testing framework used for writing and executing tests.
o	NUnit3TestAdapter: To enable integration with Visual Studio Test Explorer.
o	Microsoft.EntityFrameworkCore.InMemory: For using an in-memory database during tests (provides isolation and avoids modifying a real database).
o	Microsoft.NET.Test.Sdk: Required for running tests using the .NET Core Test SDK.
In Visual Studio, you can install these packages via the NuGet Package Manager:
o	Right-click on ProductManagement.Tests project -> Manage NuGet Packages -> Browse and search for each package (e.g., NUnit, Microsoft.EntityFrameworkCore.InMemory, Microsoft.NET.Test.Sdk) and click Install.
2.	Create the following folder structure in ProductManagement.Tests:
o	TestFixtures/: To store the test fixtures, which are responsible for setting up the test environment (e.g., initializing the in-memory database).
o	Tests/: To store the test classes that contain the actual test cases.
3.	Implement the required test classes:
o	ProductTestFixture: This class sets up the in-memory database for testing and initializes the ProductService.
o	ProductServiceTests: This class contains the actual test cases for validating the functionality of the ProductService.

2. Detailed Explanation of Key Components
Product Entity
The Product class is the central model used in this application. It has properties like:
•	Id: The unique identifier for the product.
•	Name: The name of the product.
•	Description: A description of the product.
•	Price: The price of the product.
•	StockQuantity: The number of products in stock.
•	IsActive: A flag indicating whether the product is active.
•	CreatedDate: The date and time the product was created.
•	LastModifiedDate: The date and time the product was last modified.
ProductDbContext
ProductDbContext is the class responsible for configuring the connection to the database and mapping the Product entity to the appropriate table in the database.
IProductService Interface & ProductService
•	IProductService: This interface defines methods like CreateProduct, GetProductById, UpdateProduct, DeleteProduct, etc., that manage products.
•	ProductService: This class implements the IProductService interface and provides the business logic for managing products.
ProductTestFixture & ProductServiceTests
•	ProductTestFixture: This is used to set up the in-memory database for unit tests. It ensures that each test starts with a clean state.
•	ProductServiceTests: This is where the unit tests for the ProductService are written. Tests include adding, updating, deleting, and retrieving products.

3. Test Cases
Here are the core test cases implemented in the ProductServiceTests class:
1.	CreateProduct_ShouldAddProductToDatabase
o	This test case checks if a product is successfully added to the database.
2.	GetProductById_ShouldReturnCorrectProduct
o	This test case ensures that when a product is fetched by its ID, the correct product is returned.
3.	UpdateProduct_ShouldModifyExistingProduct
o	This test verifies that updates to a product are correctly saved in the database.
4.	DeleteProduct_ShouldRemoveProductFromDatabase
o	This test ensures that a product can be deleted successfully from the database.
5.	CreateProduct_ShouldRejectNegativePrice
o	This test case ensures that the system rejects products with a negative price.
6.	BulkCreateProduct_ShouldAddProducts
o	This test checks if multiple products can be added at once.
7.	CreateProduct_ShouldRejectDuplicateProductName
o	This test checks if Multiple Products are not added with same name

4. Running the Tests in Visual Studio
Running Tests via Visual Studio Test Explorer:
1.	Open your solution in Visual Studio.
2.	Build the solution by clicking Build -> Build Solution or pressing Ctrl + Shift + B.
3.	Open the Test Explorer by navigating to Test -> Windows -> Test Explorer.
4.	In Test Explorer, you should see a list of all the available tests.
5.	Click Run All or select specific tests and click Run to execute them.






Here I have Attached Screenshot of TestCases Passed:
 

