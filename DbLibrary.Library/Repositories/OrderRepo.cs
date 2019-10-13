using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DbLibrary.Library.Repositories
{
    public class OrderRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public OrderRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Domains.Library.Order> GetOrders()
        {
            IQueryable<Entities.Reciept> items = _dbContext.Reciept;

            return items.Select(Mapper.MapOrder);
        }
    }
}
