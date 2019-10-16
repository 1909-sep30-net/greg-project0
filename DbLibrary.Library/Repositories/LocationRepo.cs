using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dom = Domains.Library;


namespace DbLibrary.Library.Repositories
{
    /// <summary>
    /// A Repository of Functions revolving around Domain Locations and Entity Locations and Entity Inventories.
    /// </summary>
    public class LocationRepo
    {
        /// <summary>
        /// The Context of the database
        /// </summary>
        private readonly Entities.Project0Context _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public LocationRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Gets a list of Domain Locations
        /// Can be filtered by LocationId
        /// </summary>
        /// <param name="locId">A LocationId to filter by</param>
        /// <returns>A List of Domain Locations</returns>
        public IEnumerable<dom.Location> GetLocations(int locId = -1)
        {
            IQueryable<Entities.Location> items = _dbContext.Location
                .Include(l => l.Inventory)
                .ThenInclude(i => i.Product)
                .Include(l => l.Receipt).AsNoTracking();

            if (locId != -1)
                items = items.Where(l => l.LocationId == locId);
            
            return items.Select(Mapper.MapLocation);
        }

        /// <summary>
        /// Updates the Database Inventory with changes made to it's parallel Domain
        /// </summary>
        /// <param name="locDom">The domain Location with the inventory which will update the database</param>
        public void UpdateInventory(dom.Location locDom)
        {
            Entities.Location currentEntity = _dbContext.Location
                                                .Include(l => l.Inventory)
                                                .FirstOrDefault(l => l.LocationId == locDom.StoreID);

            foreach (Entities.Inventory item in currentEntity.Inventory)
            {
                item.Quantity = locDom.inventory.Where(i => i.Key.ProductID == item.ProductId).FirstOrDefault().Value;
            }
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
