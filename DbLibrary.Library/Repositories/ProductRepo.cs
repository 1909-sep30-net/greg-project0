using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dom = Domains.Library;
using Microsoft.EntityFrameworkCore;

namespace DbLibrary.Library.Repositories
{
    /// <summary>
    /// A Repository of Functions revolving around Domain Products and Entity Products.
    /// </summary>
    public class ProductRepo
    {
        /// <summary>
        /// The Context of the database
        /// </summary>
        private readonly Entities.Project0Context _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public ProductRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Gets a list of Domain Products
        /// Can be filtered by ProductId
        /// </summary>
        /// <param name="prodId">A ProductId to filter by</param>
        /// <returns>A List of Domain Products</returns>
        public IEnumerable<dom.Product> GetProducts(int prodId = -1)
        {
            IQueryable<Entities.Product> items = _dbContext.Product
                .Include(p => p.Basket).AsNoTracking()
                .Include(p => p.Inventory)
                .ThenInclude(i => i.Location);

            if (prodId != -1)
                items = items.Where(p => p.ProductId == prodId);

            return items.Select(Mapper.MapProduct);
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
