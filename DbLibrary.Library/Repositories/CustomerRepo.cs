using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dom = Domains.Library;


namespace DbLibrary.Library.Repositories
{
    /// <summary>
    /// A Repository of Functions revolving around Domain Customers and Entity Customers
    /// </summary>
    public class CustomerRepo
    {
        /// <summary>
        /// The Context of the database
        /// </summary>
        private readonly Entities.Project0Context _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public CustomerRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Gets a list of Domain Customers.
        /// Can be filtered by First and/or Last name.
        /// </summary>
        /// <param name="firstName">The First name to filter by</param>
        /// <param name="lastName">The Last name to filter by</param>
        /// <returns>A list of Domain Customers</returns>
        public IEnumerable<dom.Customer> GetCustomers(string firstName = null, string lastName = null, int custId = -1)
        {
            IQueryable<Entities.Customer> items = _dbContext.Customer
                .Include(c => c.Receipt).AsNoTracking();
            

            if (firstName != null)
            {
                items = items.Where(c => c.FirstName.Contains(firstName));
            }

            if (lastName != null)
            {
                items = items.Where(c => c.LastName.Contains(lastName));
            }
            if(custId != -1)
            {
                items = items.Where(c => c.CustomerId == custId);
            }

            return items.Select(Mapper.MapCustomer);
        }

        /// <summary>
        /// Maps and adds a Domain Customer to an Entity Customer in the Database
        /// </summary>
        /// <param name="custDom">A Domain Customer</param>
        public void AddCustomer(dom.Customer custDom)
        {
            if(custDom.CustID != 0)
            {
                Console.WriteLine($"Customer ID is set to {custDom.CustID}, which will be ignored.");                              
            }
            Entities.Customer custEnt = Mapper.MapCustomer(custDom);
            custEnt.CustomerId = 0;
            _dbContext.Add(custEnt);
        }

        
        /// <summary>
        /// Commits and saves changes to the Database
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
