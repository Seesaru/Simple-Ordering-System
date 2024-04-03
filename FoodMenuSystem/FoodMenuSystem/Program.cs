using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuSystem
{
    class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static List<MenuItem> menuItems = new List<MenuItem>()
    {
        new MenuItem { Name = "Chicken Karage", Price = 90 },
        new MenuItem { Name = "Sushi (4pcs)", Price = 160 },
        new MenuItem { Name = "Tempura (4pcs)", Price = 90 },
        new MenuItem { Name = "Sashimi", Price = 110},
        new MenuItem { Name = "Miso Soup", Price = 80},
        new MenuItem { Name = "Kaiseki", Price = 120},
        new MenuItem { Name = "Coke 8oz", Price = 15 },
        new MenuItem { Name = "Sprite 8oz", Price = 15 },
        new MenuItem { Name = "Coke 1 liter", Price = 45},
        new MenuItem { Name = "Sprite 1 liter", Price =45},
    };

        static List<MenuItem> orderItems = new List<MenuItem>();

        static void Main()
        {
            bool exit = false;

            while (!exit)   
            {
                Console.Clear();
                Console.WriteLine("**Welcome to Gyoza's Restaurant**");
                Console.WriteLine("=================================");
                Console.WriteLine("");
                Console.WriteLine("1. :: Add Item to Order");
                Console.WriteLine("2. :: Remove Item from Order");
                Console.WriteLine("3. :: View Order Summary");
                Console.WriteLine("4. :: Enter Payment");
                Console.WriteLine("5. :: Exit");
                Console.WriteLine("");
                Console.Write("Enter your choice:: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        DisplayMenu();
                        AddItemToOrder();
                        break;
                    case "2":
                        Console.Clear();
                        ViewOrderSummary();
                        RemoveItemFromOrder();
                        break;
                    case "3":
                        Console.Clear();
                        ViewOrderSummary();
                        break;
                    case "4":
                        Console.Clear();
                        EnterPayment();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Thank you for using the Food Menu System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Here's our Menu!");
            Console.WriteLine("");
            Console.WriteLine("Menu::");
            for (int i = 0; i < menuItems.Count-4; i++)
            {   
                Console.WriteLine($"{i + 1}.   :: {menuItems[i].Name} - PHP{menuItems[i].Price}");
            }
            Console.WriteLine("");
            Console.WriteLine("Drinks::");
            for (int i = 6; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}.   :: {menuItems[i].Name} - PHP{menuItems[i].Price}");
            }
        }

        static void AddItemToOrder()
        {
            bool ContinueOrder = true;

            while (ContinueOrder)
            {
                Console.WriteLine("");
                Console.Write("Enter the number of the item you want to add: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= menuItems.Count)
                {
                    MenuItem selectedItem = menuItems[itemNumber - 1];
                    orderItems.Add(selectedItem);
                    Console.WriteLine("Item added to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid item number. Item not added to the order.");
                }
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue ordering or press 'x' to stop ordering");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x")
                {
                    ContinueOrder = false;
                }
            }
        }
        static void RemoveItemFromOrder()
        {
            bool RemovingItem = true;

            while (RemovingItem)
            {


                Console.Write("Enter the number of the item you want to remove: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= orderItems.Count)
                {
                    MenuItem removedItem = orderItems[itemNumber - 1];
                    orderItems.RemoveAt(itemNumber - 1);
                    Console.WriteLine($"Item \"{removedItem.Name}\" removed from the order.");
                }
                else
                {
                    Console.WriteLine("Invalid item number. No item removed from the order.");
                }
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue removing order or press 'x' to stop ordering");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x")
                {
                    RemovingItem = false;
                }
            }
        }
        static void ViewOrderSummary()
        {
            Console.WriteLine("Order Summary::");
            Console.WriteLine("");
            if (orderItems.Count > 0)
            {
                double totalCost = 0;
                for (int i = 0; i < orderItems.Count; i++)
                {
                    MenuItem item = orderItems[i];
                    Console.WriteLine($"{i + 1}. :: {item.Name} - PHP{item.Price}");
                    totalCost += item.Price;
                }
                Console.WriteLine("");
                Console.WriteLine($"Total Cost: PHP{totalCost}");
            }
            else
            {
                Console.WriteLine("No items in the order.");
            }
        }

        static void EnterPayment()
        {
            bool EnteringPayment = true;

            while (EnteringPayment)
            {

                if (orderItems.Count == 0)
                {
                    Console.WriteLine("No items in the order. Please add items before entering payment.");
                    return;
                }

                double totalCost = 0;
                foreach (MenuItem item in orderItems)
                {
                    totalCost += item.Price;
                }

                ViewOrderSummary();
                Console.WriteLine("");
                Console.Write("Enter the payment amount: PHP");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double paymentAmount))
                {
                    if (paymentAmount >= totalCost)
                    {
                        double change = paymentAmount - totalCost;
                        Console.WriteLine("");
                        Console.WriteLine($"Payment successful! Change: PHP{change}");
                        Console.WriteLine("========================================");  
                        Console.WriteLine("Thank you for ordering!");
                        orderItems.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Insufficient payment amount.");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to pay again or Press 'x' to stop payment");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "x")
                    {
                        EnteringPayment = false;
                    }
                    else
                    {
                        Console.Clear();
                        EnterPayment();
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid payment amount.");
                }
            }
        }
    }
} 
