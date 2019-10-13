using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dom = Domains.Library;


namespace DbLibrary.Library.Repositories
{
    public class ProductRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public ProductRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<dom.Product> GetProducts()
        {
            IQueryable<Entities.Product> items = _dbContext.Product;

            return items.Select(Mapper.MapProduct);
        }
    }
}
