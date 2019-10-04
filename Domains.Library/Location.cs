using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    /*
     * NOTES 
     * Id is currently a private property only accessed in the Customer constructor
     * Any adjustment to ID must be made in constructor as it affects static nextID field
     */
    public class Location
    {
        //static fields
        private static int nextID = 0;

        //struct to connect a product with the amount in stock
        private struct InventoryItem
        {
            public Product product;
            public int quantity;
        }

        //fields
        private string storeName;
        private string address;
        private int storeID;
        private List<InventoryItem> inventory;

        //Properties
        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int StoreID
        {
            get { return storeID; }
        }

        //Constructor
        public Location(string name, string address)
        {
            StoreName = name;
            Address = address;
            storeID = Location.nextID;
            Location.nextID++;

        }
    }
}
