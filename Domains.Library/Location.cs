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
        public struct InventoryItem
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

        public List<InventoryItem> Inventory
        {
            get { return inventory; }
        }

        //Constructor
        public Location(string name, string address)
        {
            StoreName = name;
            Address = address;
            storeID = Location.nextID;
            Location.nextID++;

        }

        //add new item

        //replenish inventory method

        //sell single item
        //sell multiple of item
        public void AddNewItem(InventoryItem newItem)
        {
            bool alreadyExists = false;
            foreach (InventoryItem item in inventory)
            {
                if (newItem.product == item.product)
                {
                    alreadyExists = true;
                }
            }
            if(alreadyExists)
            {
                Console.WriteLine("The item you are trying to add already exists in the inventory.");
            }
            else
            {
                inventory.Add(newItem);
            }
        }

        //returns default empty item, not optimal
        
        private InventoryItem FindItem(Product product)
        {
            //loops through inventory comparing product until found
            foreach(InventoryItem item in inventory)
            {
                if(item.product == product)
                {
                    return item;
                }
            }
            Console.WriteLine("Item is not in inventory. FindItem() defaulted to empty item");
            return new InventoryItem();
        }

        //increase the quanity of a product in the inventory
        //returns true if successful
        public bool AdjustQuantity(Product product, int quantity)
        {
            var item = FindItem(product);
            if(item.quantity == -1)
            {
                return false;
            }
            item.quantity += quantity;
            return true;
        }

        //Will be implemented after Order.cs is implemented
        public bool ProcessOrder(Order order)
        {
            return false;
        }
        


        
        
    }

}
