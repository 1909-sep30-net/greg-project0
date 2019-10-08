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
            string custFirst = "Greg";
            string custLast = "Favrot";

            //base products
            Product taco = new Product("taco", "mexican food item");
            Product burger = new Product("burger", "american food item");
            Product coke = new Product("coke", "tasty drink");
            Product pepsi = new Product("pepsi", "nasty drink");

            var store = new Location(storeName, address);
                                    
            store.AddNewItem(taco, 14);
            store.AddNewItem(burger, 0);
            store.AddNewItem(coke, 100);

            var greg = new Customer(custFirst, custLast);

            var order = new Order(greg, store);

            order.AddItemToBasket(taco, 17);

            order.ReturnProduct(taco);

            Console.WriteLine(order.ToString());

        }
    }
}
