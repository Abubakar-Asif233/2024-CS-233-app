using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantManagementSystem
{
    class FoodItem
    {
        public string ItemID;
        public string ItemName;
        public double Price;
    }

    class Admin
    {
        private List<FoodItem> menu;
        private string menuFilePath = "menu.txt";

        public Admin()
        {
            menu = new List<FoodItem>();
            LoadMenuFromFile();
        }

        private void LoadMenuFromFile()
        {
            if (File.Exists(menuFilePath))
            {
                string[] lines = File.ReadAllLines(menuFilePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    FoodItem item = new FoodItem
                    {
                        ItemID = data[0],
                        ItemName = data[1],
                        Price = double.Parse(data[2])
                    };
                    menu.Add(item);
                }
            }
        }

        private void SaveMenuToFile()
        {
            List<string> lines = new List<string>();
            foreach (var item in menu)
            {
                lines.Add($"{item.ItemID},{item.ItemName},{item.Price}");
            }
            File.WriteAllLines(menuFilePath, lines);
        }

        public void AddFoodItem()
        {
            Console.WriteLine("Enter Food Item ID:");
            string itemID = Console.ReadLine();
            Console.WriteLine("Enter Food Item Name:");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            double price = double.Parse(Console.ReadLine());

            FoodItem item = new FoodItem { ItemID = itemID, ItemName = itemName, Price = price };
            menu.Add(item);
            SaveMenuToFile();
            Console.WriteLine("Food item added successfully!");
        }

        public void DeleteFoodItem()
        {
            Console.WriteLine("Enter Food Item ID to Delete:");
            string itemID = Console.ReadLine();
            FoodItem itemToRemove = null;

            foreach (var item in menu)
            {
                if (item.ItemID == itemID)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                menu.Remove(itemToRemove);
                SaveMenuToFile();
                Console.WriteLine("Food item deleted successfully!");
            }
            else
            {
                Console.WriteLine("Food item not found!");
            }
        }

        public void UpdateFoodItem()
        {
            Console.WriteLine("Enter Food Item ID to Update:");
            string itemID = Console.ReadLine();
            foreach (var item in menu)
            {
                if (item.ItemID == itemID)
                {
                    Console.WriteLine("Enter New Food Item Name:");
                    item.ItemName = Console.ReadLine();
                    Console.WriteLine("Enter New Price:");
                    item.Price = double.Parse(Console.ReadLine());
                    SaveMenuToFile();
                    Console.WriteLine("Food item updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Food item not found!");
        }

        public void ViewMenu()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("No food items found!");
                return;
            }

            Console.WriteLine("Menu Items:");
            foreach (var item in menu)
            {
                Console.WriteLine($"ID: {item.ItemID}, Name: {item.ItemName}, Price: {item.Price}");
            }
        }
    }
}