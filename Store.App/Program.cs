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
            var startupInventory = new List<Product>
            {
                new Product("taco","mexican food item",14),
                new Product("burger","american food item",1)
            };
            

            var store = new Location("Walmart", "123 Main St", startupInventory);
            Console.WriteLine(store.StoreName);
            Console.WriteLine(store.Address);
            Console.WriteLine(store.StoreID);

            Console.WriteLine(store.InventoryToString());

            Product coke = new Product("coke", "tasty drink", 15);
            Product pepsi = new Product("pepsi", "nasty drink", 8);

            store.AddNewItem(coke);
            store.AddNewItem(pepsi, 100);

            Console.WriteLine(store.InventoryToString());

            store.AdjustQuantity(coke, 4);
            store.AdjustQuantity(pepsi, -2);

            Console.WriteLine(store.InventoryToString());



        }
    }
}
