using System;
using dom = Domains.Library;
using Serilog;
using System.Collections.Generic;
using DbLibrary.Library;
using DbRepo = DbLibrary.Library.Repositories;
using DbLibrary.Library.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Establish dbContext, our connection to the database
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Hidden.ConnectionString);
            var dbContext = new Project0Context(optionsBuilder.Options);

            RunUI(dbContext);
        }

        public static void RunUI(Project0Context dbContext)
        {
            //Establish contexts to the four domains
            var custContext = new DbRepo.CustomerRepo(dbContext);
            var prodContext = new DbRepo.ProductRepo(dbContext);
            var locContext = new DbRepo.LocationRepo(dbContext);
            var ordContext = new DbRepo.OrderRepo(dbContext);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("StoreManager\n");
                Console.WriteLine();

                Console.WriteLine("1:\tAdd a customer");
                Console.WriteLine("2:\tPerform Searches");
                Console.WriteLine("3:\tPlace an order");
                Console.WriteLine("4:\tQuit");
                Console.WriteLine();
                Console.Write("Enter a valid menu option: ");
                var input = Console.ReadLine();
                if(input == "1")
                {
                    string firstName = null;
                    string lastName = null;
                    string address = null;

                    Console.Clear();
                    Console.WriteLine("Add a customer menu\n");
                    
                    while(firstName == null)
                    {
                        Console.Write("Enter a first name: ");
                        firstName = Console.ReadLine();
                        if(firstName == "")
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
                    Console.WriteLine($"Creating a new customer with:\nFirst Name:  {firstName}\nLast Name:  {lastName}\nAddress:  {address}");

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
                        Console.WriteLine(ex); 
                    }
                }
                else if (input == "2")
                {

                }
                else if (input == "3")
                {

                }
                else if (input == "4")
                {

                }
            }
        }

        private void Notes()
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
