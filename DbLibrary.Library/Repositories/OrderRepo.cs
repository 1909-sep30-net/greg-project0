using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dom = Domains.Library;
using Microsoft.EntityFrameworkCore;

namespace DbLibrary.Library.Repositories
{
    /// <summary>
    /// A Repository of Functions revolving around Domain Orders and Entity Reciepts and Entity Baskets.
    /// </summary>
    public class OrderRepo
    {
        /// <summary>
        /// The Context of the database
        /// </summary>
        private readonly Entities.Project0Context _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public OrderRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Maps and adds a Domain Order to the database.
        /// NOTE: This doesn't map or app anything from Order.basket to the database. To do so, use AddBasket().
        /// </summary>
        /// <param name="ordDom">A domain order</param>
        public void AddOrder(dom.Order ordDom)
        {
            if (ordDom.OrderId != 0)
            {
                Console.WriteLine($"Order ID is set to {ordDom.OrderId}, which will be ignored.");
            }
            Entities.Receipt ordEnt = Mapper.MapOrder(ordDom);
            ordEnt.ReceiptId = 0;
            _dbContext.Add(ordEnt);
            //Don't forget to save!
        }

        /// <summary>
        /// Map and add the items in a Domain Order's basket to the database.
        /// </summary>
        /// <param name="dbId">The ID of the Domain Order's Entity Reciept counterpart in the database.</param>
        public void AddBasket(dom.Order ordDom)
        {
            var basket = Mapper.MapBasket(ordDom, ordDom.OrderId);
            foreach(Entities.Basket item in basket)
            {
                _dbContext.Add(item);                
            }
            //Don't forget to save!

        }


        /// <summary>
        /// Get a list of Domain Orders
        /// </summary>
        /// <returns>A list of Domain Orders</returns>z
        public IEnumerable<dom.Order> GetOrders()
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                        .ThenInclude(basket => basket.Product);
                        
            return items.Select(Mapper.MapOrder);
        }

        /// <summary>
        /// Get a list of Domain Orders, filtered by orderId
        /// </summary>
        /// <param name="ordId">An Order Id</param>
        /// <returns>A list of Domain Orders</returns>
        public IEnumerable<dom.Order> GetOrderById(int ordId)
        {
            IQueryable<Entities.Receipt> items = _dbContext.Receipt
                    .Include(r => r.Customer).AsNoTracking()
                    .Include(r => r.Location).AsNoTracking()
                    .Include(r => r.Basket)
                        .ThenInclude(basket => basket.Product)
                    .Where(r => r.ReceiptId == ordId);

            return items.Select(Mapper.MapOrder);
        }

        /// <summary>
        /// Get a list of Domain Orders, filtered by a customerId
        /// </summary>
        /// <param name="custId">A Customer Id</param>
        /// <returns>A list of Domain Customers</returns>
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

        /// <summary>
        /// Get a list of Domain Orders, filtered by a locationId
        /// </summary>
        /// <param name="custId">A Location Id</param>
        /// <returns>A list of Domain Customers</returns>
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

        /// <summary>
        /// Commits and saves changes to the Database
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
