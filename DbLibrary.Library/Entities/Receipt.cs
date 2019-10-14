using System;
using System.Collections.Generic;

namespace DbLibrary.Library.Entities
{
    public partial class Receipt
    {
        public Receipt()
        {
            Basket = new HashSet<Basket>();
        }

        public int ReceiptId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReceiptTimestamp { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
