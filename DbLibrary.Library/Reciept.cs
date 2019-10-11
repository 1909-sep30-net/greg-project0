using System;
using System.Collections.Generic;

namespace DbLibrary.Library
{
    public partial class Reciept
    {
        public Reciept()
        {
            Basket = new HashSet<Basket>();
        }

        public int RecieptId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RecieptTimestamp { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
