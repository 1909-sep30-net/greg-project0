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
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
