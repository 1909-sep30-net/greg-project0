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
            //Establish dbContext, our connection to the b=database
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Hidden.ConnectionString);
            var dbContext = new Project0Context(optionsBuilder.Options);

            //Establish contexts to the four domains
            var custContext = new DbRepo.CustomerRepo(dbContext);
            var prodContext = new DbRepo.ProductRepo(dbContext);
            var locContext = new DbRepo.LocationRepo(dbContext);
            var ordContext = new DbRepo.OrderRepo(dbContext);

            //Add a domain customer to the database
            var domTestCustomer = new dom.Customer(firstName:"Bill", lastName:"Hernandez");
            custContext.AddCustomer(domTestCustomer);
            custContext.Save();

            //Get all of our Domain Data into usable List<>'s
            var customers = custContext.GetCustomers().ToList();
            int numberOfCustomers = customers.Count;
            Console.WriteLine(numberOfCustomers);

            /*
            var products = prodContext.GetProducts().ToList();
            int numberOfProducts = products.Count;
            Console.WriteLine(numberOfProducts);

            var locations = locContext.GetLocations().ToList();
            int numberOfLocations = locations.Count;
            Console.WriteLine(numberOfLocations);

            var orders = ordContext.GetOrders().ToList();
            int numberOfOrders = orders.Count;
            Console.WriteLine(numberOfOrders);
            */
            


        }
    }
}
