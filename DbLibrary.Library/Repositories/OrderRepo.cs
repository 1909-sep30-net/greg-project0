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


        public void AddOrder(dom.Order ordDom)
        {
            if (ordDom.OrderId != 0)
            {
                Console.WriteLine($"Order ID is set to {ordDom.OrderId}, which will be ignored.");
            }
            Entities.Receipt ordEnt = Mapper.MapOrder(ordDom);
            ordEnt.CustomerId = 0;
            _dbContext.Add(ordEnt);
            //Don't forget to save!
        }
        public void AddBasket(dom.Order ordDom, int dbId)
        {
            var basket = Mapper.MapBasket(ordDom, dbId);
            foreach(Entities.Basket item in basket)
            {
                _dbContext.Add(item);
            }
            //Don't forget to save!
        }



        public IEnumerable<dom.Order> GetOrders(int custId = -1)
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                        .ThenInclude(basket => basket.Product);
            
            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<dom.Order> GetOrdersByCustomer(int custId )
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                     .ThenInclude(basket => basket.Product)
                    .Where(r => r.CustomerId == custId);
            
            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<dom.Order> GetOrdersByLocation(int locId)
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                     .ThenInclude(basket => basket.Product)
                    .Where(r => r.LocationId == locId);
            
            return items.Select(Mapper.MapOrder);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
