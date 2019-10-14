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

        public IEnumerable<dom.Order> GetOrders(int custId = -1)
        {
            IQueryable<Entities.Receipt> items = null;
            if (custId == -1)
            {
                items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                        .ThenInclude(basket => basket.Product);
            }
            else
            {
                items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                     .ThenInclude(basket => basket.Product)
                    .Where(r => r.CustomerId == custId);
            }
            return items.Select(Mapper.MapOrder);
        }


    }
}
