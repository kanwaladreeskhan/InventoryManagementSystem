using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Program
    { 
       static string[] name = new string[5];
        static int[] id = new int[5];
        static int[] quantity = new int[5];
         static double[] price = new double[5];
        static int count = 0; const int max = 5; static int nextid = 1;
        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine("\n--- Inventory Menu ---");
                Console.WriteLine("What operation do you want to perform? Press: \n1 for Add item \n2 for Remove Item" +
                    "\n3 for Search Item\n4 for  Display Inventory\n5 for Exit Program.");
                int choice=Convert.ToInt32(Console.ReadLine()); 
                switch(choice) 
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        RemoveItem();
                        break;
                    case 3:
                        SearchItem();
                        break;
                    case 4:
                        Display();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                
            }
                    }
        public static void AddItem()
        {
            if (count >= max)
            {
                Console.WriteLine("Inventory full!");
                return;
            }
            else
            {
                Console.Write("Enter name: ");
                name[count] = Console.ReadLine();
                Console.Write("Enter quantity: ");
                quantity[count] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter price: ");
                price[count] = Convert.ToDouble(Console.ReadLine());
                id[count] = nextid++;
                count++;
                Console.WriteLine("Item added successfully!");
            }
        }
        public static void RemoveItem()
        {
            Console.Write("Enter Name to remove: ");
            string removeName = Console.ReadLine();
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (name[i] != null && name[i].Equals(removeName, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Item not found!");
                return;
            }
            for (int i = index; i < count - 1; i++)
            {
                id[i] = id[i + 1];
                name[i] = name[i + 1];
                quantity[i] = quantity[i + 1];
                price[i] = price[i + 1];
            }
            id[count - 1] = 0;
            name[count - 1] = null;
            quantity[count - 1] = 0;
            price[count - 1] = 0;
            count--;
            Console.WriteLine("Item removed successfully!");
        }
        public static void SearchItem()
        {
            Console.Write("Enter name to search: ");
            string term = Console.ReadLine().ToLower();
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (name[i].ToLower().Contains(term))
                {
                    Console.WriteLine("Id = {0}\tName = {1}\tQuantity = {2}\tPrice = {3}", id[i], name[i], quantity[i], price[i]);
                    found = true;
                }
            }
                if (!found)
                Console.WriteLine("No items found.");
        }
        public static void Display()
        {
            Console.WriteLine("\nID\tName\t\tQuantity\tPrice\t\tTotal");
            for (int i = 0; i < count; i++)
            {
                double total = quantity[i] * price[i];
                Console.WriteLine("Id = {0}\tName = {1}\tQuantity = {2}\tPrice = {3}\tTotal = {4}", id[i], name[i], quantity[i], price[i], total);
            }
        }
        public static void Exit()
        {
            Console.WriteLine("Program is Exiting......");
            Environment.Exit(0);
        }
    }
}
