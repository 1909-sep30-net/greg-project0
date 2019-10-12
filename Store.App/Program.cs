using System;
using Domains.Library;
using Serilog;
using System.Collections.Generic;
using DbLibrary.Library;
using DbLibrary.Library.Repositories;
using DbLibrary.Library.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Hidden.ConnectionString);

            var dbContext = new Project0Context(optionsBuilder.Options);




            var custContext = new DbLibrary.Library.Repositories.CustomerRepo
                (dbContext);

            var customers = custContext.GetCustomers().ToList();

            int numberOfCustomers = customers.Count;

            Console.WriteLine(numberOfCustomers);


        }
    }
}
