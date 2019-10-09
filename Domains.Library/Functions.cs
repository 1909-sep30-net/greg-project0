using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    public static class Functions
    {
        public static Dictionary<int, Customer> customers;
        public static Dictionary<int, Location> locations;
        public static Dictionary<int, Product> products;
        public static Dictionary<int, Order> orders;

        //place orders to store locations for customers


        //add a new customer
        public static Customer AddCustomer(string firstName, string lastName)
        {
            var cust = new Customer(firstName, lastName);
            customers.Add(cust.CustID, cust);
            return cust;
        }

        //search customers by name
        public static string CustomerSearchByName(string name)
        {
            string results = "The following customers were found:\n";
            foreach (KeyValuePair<int, Customer> item in customers)
            {
                if (item.Value.FirstName == name || item.Value.LastName == name)
                {
                    results += item.Value.ToString() + "\n";
                }
            }
            return results;
        }

        //display details of an order
        public static string DisplayOrderDetails(int orderKey)
        {
            
            if (orders.ContainsKey(orderKey))
            {
                string results = $"Details of Order:\n";
                results += $"Order ID: {orderKey}\n";
                results += $"Customer: {orders[orderKey].OrderCustomer.ToString()}\n";
                results += $"Location: {orders[orderKey].OrderLocation.ToString()}\n";
                results += $"  Items Purchased:\n";
                results += orders[orderKey].ToString();
                return results;

            }
            else
            {
                return "Invalid Order Key Entered\n";
            }
        }

        //display all order history of a store location


        //display all order history of a customer


        //input validation


        //exception handling


        //persistent data(SQL); no products, prices, customers, etc. hardcoded in C#


        //logging


    }
}
