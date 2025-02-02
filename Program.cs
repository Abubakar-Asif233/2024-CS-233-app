using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem;

namespace App_development
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            int choice;

            do
            {
                Console.WriteLine("\nRestaurant Management System - Admin Menu");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Update Food Item");
                Console.WriteLine("4. View Menu");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    admin.AddFoodItem();
                }
                else if (choice == 2)
                {
                    admin.DeleteFoodItem();
                }
                else if (choice == 3)
                {
                    admin.UpdateFoodItem();
                }
                else if (choice == 4)
                {
                    admin.ViewMenu();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                }
            } while (choice != 5);
        }
    }
}
