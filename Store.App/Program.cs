using System;
using Domains.Library;
using Store.Library;
using Serilog;
using System.Collections.Generic;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string storeName = "Walmart";
            string address = "123 Main St";

            //base products
            Product taco = new Product("taco", "mexican food item");
            Product burger = new Product("burger", "american food item");
            Product coke = new Product("coke", "tasty drink");
            Product pepsi = new Product("pepsi", "nasty drink");


            var store1 = new Location(storeName, address);
            //var store2 = new Location(storeName, "456 South St");
            
            Console.WriteLine(store1.StoreName);
            Console.WriteLine(store1.Address);
            Console.WriteLine(store1.StoreID);
            Console.WriteLine();
            /*
            Console.WriteLine(store2.StoreName);
            Console.WriteLine(store2.Address);
            Console.WriteLine(store2.StoreID);
            Console.WriteLine();
            */
            store1.AddNewItem(taco, 14);
            store1.AddNewItem(burger, 0);
            store1.AddNewItem(coke, 100);
            /*
            store2.AddNewItem(taco, 10);
            store2.AddNewItem(burger, 20);
            store2.AddNewItem(pepsi, 100);
            */
            Console.WriteLine(store1.InventoryToString());
            //Console.WriteLine(store2.InventoryToString());

            store1.AdjustQuantity(coke, 4);
            //store2.AdjustQuantity(coke, 4);

            Console.WriteLine(store1.InventoryToString());
            //Console.WriteLine(store2.InventoryToString());




        }
    }
}
