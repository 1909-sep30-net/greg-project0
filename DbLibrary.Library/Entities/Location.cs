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
        public string LocationAddress { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
