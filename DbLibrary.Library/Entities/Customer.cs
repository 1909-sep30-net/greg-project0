using System;
using System.Collections.Generic;

namespace DbLibrary.Library.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerAddress { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
