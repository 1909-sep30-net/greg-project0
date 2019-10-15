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

            //Establish contexts to the four domains
            var custContext = new DbRepo.CustomerRepo(dbContext);
            var prodContext = new DbRepo.ProductRepo(dbContext);
            var locContext = new DbRepo.LocationRepo(dbContext);
            var ordContext = new DbRepo.OrderRepo(dbContext);

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
        }
    }
}
