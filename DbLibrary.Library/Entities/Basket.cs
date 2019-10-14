using System;
using System.Collections.Generic;

namespace DbLibrary.Library.Entities
{
    public partial class Basket
    {
        public int BasketId { get; set; }
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
