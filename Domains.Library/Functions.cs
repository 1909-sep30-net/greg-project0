using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    public static class Functions
    {
        /*
        public static Dictionary<int, Customer> customers = new Dictionary<int, Customer> { };
        public static Dictionary<int, Location> locations = new Dictionary<int, Location> { };
        public static Dictionary<int, Product> products = new Dictionary<int, Product> { };
        public static Dictionary<int, Order> orders = new Dictionary<int, Order> { };

        //place orders to store locations for customers
        public static string placeOrder(int customerId, int locationId)
        {
            if(customers.ContainsKey(customerId))
            {
                if(locations.ContainsKey(locationId))
                {
                    var order = new Order(customers[customerId], locations[locationId]);
                    orders.Add(order.OrderId, order);
                    return $"Order Creation Successful. You may now add items to the order.\nThe OrderID is {order.OrderId}.";
                }
                else
                {
                    return "Invalid Location Id entered. Please try again.";
                }

            }
            else
            {
                return "Invalid Customer Id entered. Please try again.";
            }
        }


        //add a new location
        public static void AddLocation(string name, string address)
        {
            var loc = new Location(name, address);
            locations.Add(loc.StoreID, loc);
            
        }
        //add a new product
        public static void AddProduct(string name, string description)
        {
            var prod = new Product(name, description);
            products.Add(prod.ProductID, prod);

        }
        //add a new customer
        public static void AddCustomer(string firstName, string lastName)
        {
            var cust = new Customer(firstName, lastName);
            customers.Add(cust.CustID, cust);
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
        public static string DisplayLocationOrderHistory(int locationKey)
        {
            if(locations.ContainsKey(locationKey))
            {
                string results = $"{locations[locationKey].ToString()}\n  Orders:\n";
                foreach(KeyValuePair<int, Order> order in orders)
                {
                    if(order.Value.OrderLocation == locations[locationKey])
                    {
                        results += $"    Order {order.Key}\n";
                    }
                }

                return results;
            }
            else
            {
                return "Invalid Location Key Entered\n";
            }
        }

        //display all order history of a customer
        public static string DisplayCustomerOrderHistory(int customerKey)
        {
            if (customers.ContainsKey(customerKey))
            {
                string results = $"{customers[customerKey].ToString()}\n  Orders:\n";
                foreach (KeyValuePair<int, Order> order in orders)
                {
                    if (order.Value.OrderCustomer == customers[customerKey])
                    {
                        results += $"    Order {order.Key}\n";
                    }
                }

                return results;
            }
            else
            {
                return "Invalid Customer Key Entered\n";
            }
        }*/

        //input validation


        //exception handling


        //persistent data(SQL); no products, prices, customers, etc. hardcoded in C#


        //logging


    }
}
