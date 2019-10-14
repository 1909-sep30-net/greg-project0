using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dom = Domains.Library;
using Microsoft.EntityFrameworkCore;

namespace DbLibrary.Library.Repositories
{
    public class OrderRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public OrderRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<dom.Order> GetOrders()
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                .Include(r => r.Customer).AsNoTracking()
                .Include(r => r.Location).AsNoTracking()
                .Include(r => r.Basket).AsNoTracking();

            return items.Select(Mapper.MapOrder);
        }
    }
}
