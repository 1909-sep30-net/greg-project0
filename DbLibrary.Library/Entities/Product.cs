using System;
using System.Collections.Generic;

namespace DbLibrary.Library.Entities
{
    public partial class Product
    {
        public Product()
        {
            Basket = new HashSet<Basket>();
            Inventory = new HashSet<Inventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitCost { get; set; }

        public virtual ICollection<Basket> Basket { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
