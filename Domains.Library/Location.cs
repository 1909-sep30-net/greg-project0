using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    
    public class Location
    {
        //fields affected by Properties
        private string storeName;
        private string address;
        private int storeID;

        /// <summary>
        /// The store's inventory of Products and quantities
        /// </summary>
        public Dictionary<Product, int> inventory;

        /// <summary>
        /// The store's name. Cannot be null, empty, or longer than 50 characters.
        /// </summary>
        public string StoreName
        {
            get { return storeName; }
            //set { storeName = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Store/Location name cannot be null or empty string.");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Store/Location name cannot be greater than 50 characters.");
                else
                    storeName = value;
            }
        }

        /// <summary>
        /// The store's address name. Cannot be null, empty, or longer than 163 characters.
        /// </summary>
        public string Address
        {
            get { return address; }
            //set { address = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Address cannot be null or empty string.");
                else if (value.Length > 163)//163 derived from DB 50 (Street) + 1 (space) + 50 (City) + 1 (space) + 50 (State) + 1 (space) + 10 (ZIP)
                    throw new ArgumentOutOfRangeException("Address cannot be greater than 163 characters.");
                else
                    address = value;
            }
        }

        /// <summary>
        /// The Store's ID, should only be set by db!!!
        /// </summary>
        public int StoreID
        {
            get { return storeID; }
            set{
                if (value <= 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Product Id must be greater than 0 but less than or equal to 1000.");
                else
                    StoreID = value;
            }
        }

        /// <summary>
        /// The sotre's inventory
        /// </summary>
        public Dictionary<Product, int> Inventory
        {
            get { return inventory; }
        }

        /// <summary>
        /// The constructor for a new Location/Store
        /// </summary>
        /// <param name="name">The store's name</param>
        /// <param name="address">The Store's address</param>
        /// <param name="storeId">The Store's Id - should be set by db!</param>
        public Location(string name, string address, int storeId)
        {
            StoreName = name;
            Address = address;
            StoreID = storeId;
            inventory = new Dictionary<Product, int> { };//initialize an empty inventory
            
        }

        
        //adds a new product to inventory
        public bool AddNewItem(Product newItem, int quantity)
        {
            if (newItem == null)
            {
                return false;
            }
            bool alreadyExists = false;
            foreach (KeyValuePair<Product,int> item in inventory)
            {
                if (item.Key == newItem)
                {
                    alreadyExists = true;
                    break;
                }
            }
            if(alreadyExists)
            {
                Console.WriteLine("The item you are trying to add already exists in the inventory. Try adjusting quantity instead.");
                return false;
            }
            else
            {
                inventory.Add(newItem, quantity);
                return true;
            }
        }

        //return true if successfully found item
        //out Product product is the matched product if true, or null if false.

        public bool FindItemByName(string name, out Product product)
        {
            //loops through inventory comparing product until found
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                if (item.Key.ProductName == name)
                {
                    product = item.Key;
                    return true;
                }
            }
            Console.WriteLine("Item is not in inventory.");
            product = null;
            return false;
        }

        //adjusts the quanity of a product in the inventory
        //increase if quantity is positive, decrease if quantity is negative
        //returns true if successful
        public bool AdjustQuantity(Product product, int quantity)
        {
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                if (item.Key == product)
                {
                    if(item.Value + quantity >= 0)
                    {
                        inventory[product] = item.Value + quantity;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Product found, but only {item.Value} in stock. You requested {-1 * quantity}. Please try again.");
                        return false;
                    }
                                    }
            }
            //when item is not found in inventory
            Console.WriteLine("Product not found in this Location's inventory.");
            return false;
        }


        //Will be implemented after Order.cs is implemented
        public bool ProcessOrder(Order order)
        {
            return false;
        }

        public string InventoryToString()
        {
            string str = "";
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                str += $"Quantity = {item.Value} >> {item.Key.ToString()}\n";//\n in Product ToString method
            }
            return str;
        }

        public override string ToString()
        {
            return $"ID : {StoreID},  NAME: {StoreName},  ADDRESS: {Address} ";
        }



    }

}
