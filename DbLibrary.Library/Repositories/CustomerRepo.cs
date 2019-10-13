using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dom = Domains.Library;


namespace DbLibrary.Library.Repositories
{
    public class CustomerRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public CustomerRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<dom.Customer> GetCustomers(string firstName = null, string lastName = null)
        {
            IQueryable<Entities.Customer> items = _dbContext.Customer;
            
            if(firstName != null)
            {
                items = items.Where(c => c.FirstName.Contains(firstName));
            }

            if (lastName != null)
            {
                items = items.Where(c => c.LastName.Contains(lastName));
            }

            return items.Select(Mapper.MapCustomer);
        }

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

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
