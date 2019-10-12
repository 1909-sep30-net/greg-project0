using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbLibrary.Library.Repositories
{
    public class CustomerRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public CustomerRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Domains.Library.Customer> GetCustomers()
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Entities.Customer> items = _dbContext.Customer;
            
            return items.Select(Mapper.MapCustomer);
        }
    }
}
