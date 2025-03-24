using System;

namespace SeleniumAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Selenium Assignments Menu");
                Console.WriteLine("========================");
                Console.WriteLine("1. Basic Navigation and Verification");
                Console.WriteLine("2. Working with Checkboxes");
                Console.WriteLine("3. Handling Dropdowns");
                Console.WriteLine("4. Basic Authentication");
                Console.WriteLine("5. Dynamic Loading");
                Console.WriteLine("6. Form Validation");
                Console.WriteLine("7. Handling Alerts");
                Console.WriteLine("8. Working with Frames");
                Console.WriteLine("9. Drag and Drop");
                Console.WriteLine("10. File Upload");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice (0-10): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": new Assignment1().Run(); break;
                    case "2": new Assignment2().Run(); break;
                    case "3": new Assignment3().Run(); break;
                    case "4": new Assignment4().Run(); break;
                    case "5": new Assignment5().Run(); break;
                    case "6": new Assignment6().Run(); break;
                    case "7": new Assignment7().Run(); break;
                    case "8": new Assignment8().Run(); break;
                    case "9": new Assignment9().Run(); break;
                    case "10": new Assignment10().Run(); break;
                    case "0": exit = true; break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
