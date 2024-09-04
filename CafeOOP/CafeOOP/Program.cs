using System;
using System.Collections.Generic;
using System.Xml;
/* This updated program is for my OOP Quiz 3
 * to turn my program into a more object oriented program, I made every method into their respective class.
 * these classes were then called into the cases of my switch at the main program. I will also try to make an interface, sana gumana huhu
 * - brave
*/
namespace OsioCofee
{
    interface IShopItem
    {
        string Item { get; }
        double Price { get; }
    }
    class ShopItem : IShopItem
    {
        public string Item { get; }
        public double Price { get; }

        public ShopItem(string item, double price)
        {
            Item = item;
            Price = price;
        }
    }

    class Program
    {
        static List<ShopItem> menu = new List<ShopItem>();
        static List<ShopItem> order = new List<ShopItem>();
        static void Main(string[] args)
        {

            bool run = true;

            while (run)
            {

                Console.WriteLine("Welcome to the Coffee Shop!");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. View Menu");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Order");
                Console.WriteLine("5. Calculate Total");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageMenu.additem(menu);
                        break;
                    case "2":
                        ManageMenu.viewmenu(menu);
                        break;
                    case "3":
                        ManageOrder.placeorder(menu, order);
                        break;
                    case "4":
                        ManageOrder.vieworder(order);
                        break;
                    case "5":
                        ManageOrder.total(order);
                        break;
                    case "6":
                        Console.WriteLine("Thank you for visiting! Please come again.");
                        Console.Beep(); //:) -Brave
                        Console.ReadKey();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }
    }
    class ManageMenu
    {
        public static void additem(List<ShopItem> menu)
        {
            Console.Write("Enter item name: ");
            string newItem = Console.ReadLine();
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out double Price))
            {
                menu.Add(new ShopItem(newItem, Price));
                Console.WriteLine("Item added successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid price. Item not added.");
                Console.WriteLine();
            }

        }

        public static void viewmenu(List<ShopItem> menu)
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("There are no items in the menu.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Menu: ");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Item} - ${menu[i].Price:F2}");
                }
                Console.WriteLine();
            }
        }
    }
    class ManageOrder
    {
        public static void placeorder(List<ShopItem> menu, List<ShopItem> order)
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("There are no items in the menu.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Menu: ");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Item} - ${menu[i].Price:F2}");
                    
                }
                Console.WriteLine();
            }
            Console.Write("Enter the item number to order: ");
            if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber >= 1 && itemNumber <= menu.Count)
            {
                order.Add(menu[itemNumber - 1]);
                Console.WriteLine("Item added to order!");
                
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
            Console.WriteLine();

        }
        public static void vieworder(List<ShopItem> order)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("You do not have any orders.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Your Order: ");
                for (int i = 0; i < order.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {order[i].Item} - ${order[i].Price:F2}");
                    
                }
                Console.WriteLine();
            }
        }
        public static void total(List<ShopItem> order)
        {
            double total = 0;
            foreach (var item in order)
            {
                total += item.Price;
            }
            Console.WriteLine($"Total Amount Payable by admin: ${total:F2}");
            Console.WriteLine();
        }
    }
}
// link of original code: https://github.com/Osio-BraveJohn-BSCS21A1/Coffee-OOP_A2_BraveJohn_Osio.git


