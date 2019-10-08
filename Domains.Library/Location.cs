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

       
        //fields
        private string storeName;
        private string address;
        private int storeID;
        private List<Product> inventory;

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

        public List<Product> Inventory
        {
            get { return inventory; }
        }

        //Constructor
        public Location(string name, string address, List<Product> startupInventory)
        {
            StoreName = name;
            Address = address;
            storeID = Location.nextID;
            Location.nextID++;
            inventory = startupInventory;

        }

        
        //adds a new product to inventory
        public void AddNewItem(Product newItem)
        {
            bool alreadyExists = false;
            foreach (Product item in inventory)
            {
                if (newItem.ProductID == item.ProductID)
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

        //adds a new product, with a custom quantity
        //useful if you are adding the same product to different locations in different quantities
        public void AddNewItem(Product newItem, int newQuantity)
        {
            bool alreadyExists = false;
            foreach (Product item in inventory)
            {
                if (newItem.ProductID == item.ProductID)
                {
                    alreadyExists = true;
                }
            }
            if (alreadyExists)
            {
                Console.WriteLine("The item you are trying to add already exists in the inventory.");
            }
            else
            {
                newItem.Quantity = newQuantity;
                inventory.Add(newItem);
            }
        }

        //return true if successfully found item
        //out Product product is the matched product if true, or null if false.

        public bool FindItemByName(string name, out Product product)
        {
            //loops through inventory comparing product until found
            foreach(Product item in inventory)
            {
                if(item.ProductName == name)
                {
                    product = item;
                    return true;
                }
            }
            Console.WriteLine("Item is not in inventory. FindItem() defaulted to empty item");
            product = null;
            return false;
        }

        //adjusts the quanity of a product in the inventory
        //increase if quantity is positive, decrease if quantity is negative
        //returns true if successful
        public bool AdjustQuantity(Product product, int quantity)
        {
            if (product.Quantity + quantity < 0)
                return false;
            product.Quantity += quantity;
            return true;
        }


        //Will be implemented after Order.cs is implemented
        public bool ProcessOrder(Order order)
        {
            return false;
        }

        public string InventoryToString()
        {
            string inventoryInStringForm = "";
            foreach(Product product in inventory)
            {
                inventoryInStringForm += product.ToString();
            }
            return inventoryInStringForm;
        }



    }

}
