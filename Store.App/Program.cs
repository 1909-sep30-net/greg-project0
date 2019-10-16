using System;
using dom = Domains.Library;
using System.Collections.Generic;
using DbLibrary.Library;
using DbRepo = DbLibrary.Library.Repositories;
using DbLibrary.Library.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Store.App
{
    public static class Program
    {
        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            //Establish dbContext, our connection to the database
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Hidden.ConnectionString);
            using var dbContext = new Project0Context(optionsBuilder.Options);

            RunUI(dbContext);
        }

        public static void RunUI(Project0Context dbContext)
        {
            //Establish contexts to the four domains
            var custContext = new DbRepo.CustomerRepo(dbContext);
            var prodContext = new DbRepo.ProductRepo(dbContext);
            var locContext = new DbRepo.LocationRepo(dbContext);
            var ordContext = new DbRepo.OrderRepo(dbContext);

            string storeName =  " ____  ____  __  ____  ____  _  _   __   __ _   __    ___  ____  ____ \n" +
                                "/ ___)(_  _)/  \\(  _ \\(  __)( \\/ ) / _\\ (  ( \\ / _\\  / __)(  __)(  _ \\\n" +
                                "\\___ \\  )( (  O ))   / ) _) / \\/ \\/    \\/    //    \\( (_ \\ ) _)  )   /\n" +
                                "(____/ (__) \\__/(__\\_)(____)\\_)(_/\\_/\\_/\\_)__)\\_/\\_/ \\___/(____)(__\\_)\n";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(storeName);
                Console.WriteLine();

                Console.WriteLine("1:\tAdd a customer");
                Console.WriteLine("2:\tPerform Searches and Displays");
                Console.WriteLine("3:\tPlace an order");
                Console.WriteLine("4:\tQuit");
                Console.WriteLine();
                Console.Write("Enter a valid menu option: ");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    string firstName = null;
                    string lastName = null;
                    string address = null;

                    Console.Clear();
                    Console.WriteLine("Add a customer menu\n");

                    while (firstName == null)
                    {
                        Console.Write("Enter a first name: ");
                        firstName = Console.ReadLine();
                        if (firstName == "")
                        {
                            firstName = null;
                        }
                    }
                    while (lastName == null)
                    {
                        Console.Write("Enter a last name: ");
                        lastName = Console.ReadLine();
                        if (lastName == "")
                        {
                            lastName = null;
                        }
                    }
                    while (address == null)
                    {
                        Console.Write("Enter an address: ");
                        address = Console.ReadLine();
                        if (address == "")
                        {
                            address = null;
                        }
                    }
                    Console.WriteLine($"\nCreating a new customer with:\nFirst Name:  {firstName}\nLast Name:  {lastName}\nAddress:  {address}");

                    try
                    {
                        var newCustomer = new dom.Customer(firstName, lastName, address);
                        custContext.AddCustomer(newCustomer);
                        custContext.Save();
                        var dbCustomerId = custContext.GetCustomers(firstName, lastName).Last().CustID;
                        Console.WriteLine($"The customer has been successfully added.\nID:\t{dbCustomerId}\n");

                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                        s_logger.Info(ex);
                    }
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search and Display Menu\n");

                        Console.WriteLine("1:\tSearch and Display Customers by Name");
                        Console.WriteLine("2:\tDisplay Locations");
                        Console.WriteLine("3:\tDisplay all Orders for a Customer");
                        Console.WriteLine("4:\tDisplay all Orders for a Location");
                        Console.WriteLine("5:\tDisplay Details of an Order");
                        Console.WriteLine("6:\tLeave Menu");
                        Console.WriteLine();

                        Console.Write("Enter a valid menu option: ");
                        var inputMenu2 = Console.ReadLine();
                        if (inputMenu2 == "1")
                        {
                            string firstNameSearch = null;
                            string lastNameSearch = null;

                            Console.Clear();
                            Console.WriteLine("Search and Display Customers by Name\n");

                            Console.WriteLine("Enter a First Name to search:");
                            Console.Write("\t(or leave empty): ");
                            firstNameSearch = Console.ReadLine();
                            if (firstNameSearch == "")
                                firstNameSearch = null;

                            Console.WriteLine("Enter a Last Name to search:");
                            Console.Write("\t(or leave empty): ");
                            lastNameSearch = Console.ReadLine();
                            if (lastNameSearch == "")
                                lastNameSearch = null;

                            Console.WriteLine($"\nSearching for Customers with\n\tFirst Name: {firstNameSearch}\n\tLast Name: {lastNameSearch}\n\nResults:");
                            Console.WriteLine();
                            var customersSearched = custContext.GetCustomers(firstNameSearch, lastNameSearch).ToList();
                            foreach (dom.Customer cust in customersSearched)
                            {
                                Console.WriteLine(cust.ToString() + "\n");
                            }

                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                        }
                        else if (inputMenu2 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Locations:\n");

                            var locations = locContext.GetLocations().ToList();
                            foreach (dom.Location item in locations)
                            {
                                Console.WriteLine(item.ToString() + "\n");
                            }
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                        }
                        else if (inputMenu2 == "3")
                        {
                            string inputMenu2Entry;
                            int custId = 0;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display All Orders for a Customer\n");

                                Console.Write("Enter a Customer ID: ");
                                inputMenu2Entry = Console.ReadLine();
                                isInt = Int32.TryParse(inputMenu2Entry, out custId);
                            }
                            while (!isInt);

                            var results = ordContext.GetOrdersByCustomer(custId: custId).ToList();
                            if (results.Count > 0)
                            {
                                foreach (dom.Order ord in results)
                                {
                                    Console.WriteLine(ord.ToString() + "\n");
                                }
                            }
                            else
                                Console.WriteLine($"No results matching CustomerID {custId}");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        else if (inputMenu2 == "4")
                        {
                            string inputMenu3Entry;
                            int locId = 0;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display All Orders for a Location\n");

                                Console.Write("Enter a Location ID: ");
                                inputMenu3Entry = Console.ReadLine();
                                isInt = Int32.TryParse(inputMenu3Entry, out locId);
                            }
                            while (!isInt);

                            var results = ordContext.GetOrdersByLocation(locId).ToList();
                            if (results.Count > 0)
                            {
                                foreach (dom.Order ord in results)
                                {
                                    Console.WriteLine(ord.ToString() + "\n");
                                }
                            }
                            else
                                Console.WriteLine($"No results matching LocationID {locId}");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();

                        }
                        else if (inputMenu2 == "5")
                        {
                            string inputMenu4Entry;
                            int ordId = 0;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display Details of an Order:\n");

                                Console.Write("Enter a Order ID: ");
                                inputMenu4Entry = Console.ReadLine();
                                isInt = Int32.TryParse(inputMenu4Entry, out ordId);
                            }
                            while (!isInt);

                            var result = ordContext.GetOrderById(ordId).ToList().FirstOrDefault();
                            if (result == null)
                            {
                                Console.WriteLine($"No results matching OrderID {ordId}");
                            }
                            else
                            {
                                Console.WriteLine(result.ToString());
                                Console.WriteLine(result.BasketToString());
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();

                        }
                        else if (inputMenu2 == "6")
                        {
                            break;
                        }

                    }
                }
                else if (input == "3")
                {
                    string inputStr;
                    int custId = 0;
                    int locId = 0;
                    bool isInt = false;


                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Place an Order Menu\n");

                        Console.Write("Enter a Customer ID: ");
                        inputStr = Console.ReadLine();
                        isInt = Int32.TryParse(inputStr, out custId);
                    }
                    while (!isInt);

                    var cust = custContext.GetCustomers(custId: custId).FirstOrDefault();
                    if (cust == null)
                    {
                        Console.WriteLine($"Customer {custId} does not exist.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Customer found:\n");
                        Console.WriteLine(cust.ToString());
                    }

                    isInt = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Place an Order Menu\n");

                        Console.WriteLine($"Enter a Customer ID: {custId}");
                        Console.WriteLine("Customer found:\n");
                        Console.WriteLine(cust.ToString());

                        Console.Write("Enter a Location ID: ");
                        inputStr = Console.ReadLine();
                        isInt = Int32.TryParse(inputStr, out locId);
                    }
                    while (!isInt);

                    var loc = locContext.GetLocations(locId).FirstOrDefault();
                    if (loc == null)
                    {
                        Console.WriteLine($"Location {locId} does not exist.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Location found:\n");
                        Console.WriteLine(loc.ToString());
                    }
                    bool abort = false;
                    do
                    {
                        Console.Write("Would you like to continue? (YES/NO): ");
                        string answer = Console.ReadLine();
                        if (answer.ToUpper() == "YES")
                        {
                            break;
                        }
                        else if (answer.ToUpper() == "NO")
                        {
                            abort = true;
                        }
                    }
                    while (!abort);

                    if (!abort)
                    {

                        try
                        {
                            var ord = new dom.Order(cust, loc, 0);
                            ordContext.AddOrder(ord);
                            ordContext.Save();
                            ord = ordContext.GetOrdersByCustomer(cust.CustID).Last();


                            int prodId = 0;

                            bool done = false;
                            do
                            {
                                do
                                {
                                    prodId = 0;

                                    Console.Clear();
                                    Console.WriteLine("Place an Order Menu\n");
                                    Console.WriteLine($"Customer:\n{cust.ToString()}");
                                    Console.WriteLine($"Location:\n{loc.ToString()}");
                                    Console.WriteLine();
                                    Console.WriteLine("Location inventory:");
                                    Console.WriteLine(loc.InventoryToString());
                                    Console.WriteLine();
                                    Console.WriteLine("Your basket:");
                                    Console.WriteLine(ord.BasketToString());

                                    Console.Write("Enter a Product Id, or DONE if finished: ");
                                    inputStr = Console.ReadLine();
                                    if (inputStr.ToUpper() == "DONE")
                                    {
                                        done = true;
                                        isInt = true;
                                    }
                                    else
                                    {
                                        isInt = Int32.TryParse(inputStr, out prodId);
                                    }
                                }
                                while (!isInt);
                                if (!done)
                                {
                                    var prod = prodContext.GetProducts(prodId).FirstOrDefault();
                                    if (prod == null)
                                    {
                                        Console.WriteLine($"Product {prodId} does not exist");
                                        Console.WriteLine("\nPress any key to continue.");
                                        Console.ReadKey();
                                    }
                                    else if (!loc.FindItemById(prodId))
                                    {
                                        Console.WriteLine($"Product {prodId} is not in this location's inventory");
                                        Console.WriteLine("\nPress any key to continue.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        bool isIntQuantity = false;
                                        int quantity = 0;
                                        do
                                        {
                                            Console.Write("Enter a quanity: ");
                                            inputStr = Console.ReadLine();
                                            isIntQuantity = Int32.TryParse(inputStr, out quantity);

                                        }
                                        while (!isIntQuantity);
                                        if (loc.AdjustQuantity(prod, -1 * quantity))
                                        {
                                            ord.basket.Add(prod, quantity);
                                            Console.WriteLine($"Added {quantity} {prod.ProductName}s to basket.");
                                            Console.WriteLine("\nPress any key to continue.");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                            while (!done);
                            ordContext.AddBasket(ord);
                            ordContext.Save();

                            Console.Clear();
                            Console.WriteLine($"Order Complete.\n");
                            Console.WriteLine(ord.ToString());
                            Console.WriteLine(ord.BasketToString());
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                            s_logger.Info(ex);
                        }
                    }
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Closing application...");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                }
            }
        }

        private static void Notes()
        {
            //Add a domain customer to the database
            /*
            var domTestCustomer = new dom.Customer(firstName:"Bill", lastName:"Hernandez");
            custContext.AddCustomer(domTestCustomer);
            custContext.Save();
            */



            //Get all of our Domain Data into usable List<>'s
            /*
            var customers = custContext.GetCustomers(firstName:"Jim").ToList();
            int numberOfCustomers = customers.Count;
            //Console.WriteLine(numberOfCustomers);
            

            
            var products = prodContext.GetProducts().ToList();
            int numberOfProducts = products.Count;
            //Console.WriteLine(numberOfProducts);

            var locations = locContext.GetLocations().ToList();
            int numberOfLocations = locations.Count;
            //Console.WriteLine(numberOfLocations);
            
            var orders = ordContext.GetOrders().ToList();
            int numberOfOrders = orders.Count;
            Console.WriteLine(numberOfOrders);
            */

            //Get all orders over all, for a customer (by customerId), and from a location (by locationid)
            /*
            var AllOrders = ordContext.GetOrders().ToList();
            foreach (dom.Order item in AllOrders)
            {
                Console.WriteLine(item.OrderId);
            };

            Console.WriteLine();

            var EllieOrders = ordContext.GetOrdersByCustomer(1001).ToList();
            foreach (dom.Order item in EllieOrders)
            {
                Console.WriteLine(item.OrderId);
            };

            Console.WriteLine();

            var TexasOrders = ordContext.GetOrdersByLocation(1000).ToList();
            foreach (dom.Order item in TexasOrders)
            {
                Console.WriteLine(item.OrderId);
            };
            */


            //Add an order to the database
            /*
            var cust = custContext.GetCustomers(firstName: "Greg").First();
            var prod = prodContext.GetProducts(3).First();
            var loc = locContext.GetLocations(2).First();

            var ord = new dom.Order(cust, loc, 4);
            ord.basket.Add(prod, 1);
            //ordContext.AddOrder(ord);
            //ordContext.Save();

            var newOrd = ordContext.GetOrdersByCustomer(1).Last();
            var dbId = newOrd.OrderId;
            Console.WriteLine(dbId);
            ordContext.AddBasket(ord, dbId);
            ordContext.Save();
            */
        }
    }
}
