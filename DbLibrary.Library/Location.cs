using System;
using System.Collections.Generic;

namespace DbLibrary.Library
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Reciept = new HashSet<Reciept>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Reciept> Reciept { get; set; }
    }
}
