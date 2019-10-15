using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dom = Domains.Library;


namespace DbLibrary.Library.Repositories
{
    public class LocationRepo
    {
        private readonly Entities.Project0Context _dbContext;

        public LocationRepo(Entities.Project0Context dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<dom.Location> GetLocations(int locId = -1)
        {
            IQueryable<Entities.Location> items = _dbContext.Location
                .Include(l => l.Inventory).AsNoTracking()
                .Include(l => l.Receipt).AsNoTracking();

            if (locId != -1)
                items = items.Where(l => l.LocationId == locId);
            
            return items.Select(Mapper.MapLocation);
        }
    }
}
