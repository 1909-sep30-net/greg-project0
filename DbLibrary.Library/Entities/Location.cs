using System;
using System.Collections.Generic;

namespace DbLibrary.Library.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Receipt = new HashSet<Receipt>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
