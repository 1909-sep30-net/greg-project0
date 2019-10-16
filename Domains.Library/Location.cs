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
        /// The store's name. Cannot be null or empty.
        /// </summary>
        public string StoreName
        {
            get { return storeName; }
            //set { storeName = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Store/Location name cannot be null or empty string.");
                else
                    storeName = value;
            }
        }

        /// <summary>
        /// The store's address name. Cannot be null or empty.
        /// </summary>
        public string Address
        {
            get { return address; }
            //set { address = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Address cannot be null or empty string.");
                else
                    address = value;
            }
        }

        /// <summary>
        /// The Store's ID. Should only be trusted if this Location was mapped over from a database entity.
        /// </summary>
        public int StoreID
        {
            get { return storeID; }
            set {
                    storeID = value;
                }
        }

        /// <summary>
        /// The location's inventory
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
        /// <param name="storeId">The Store's Id - Only trusted if this Location was mapped over from a database entity.</param>
        public Location(string name, string address, int storeId)
        {
            StoreName = name;
            Address = address;
            StoreID = storeId;
            inventory = new Dictionary<Product, int> { };//initialize an empty inventory
            
        }

        public Location()
        {
            StoreName = null;
            Address = null;
            StoreID = 0;
            inventory = null;//initialize an empty inventory

        }


        /// <summary>
        /// Adds a new product and quantity to this location's inventory
        /// </summary>
        /// <param name="newItem">A Product</param>
        /// <param name="quantity">The amount of the Product to add</param>
        /// <returns>If item is not null and is new to the inventory, true. Else, false.</returns>
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
            else//Success Case
            {
                inventory.Add(newItem, quantity);
                return true;
            }
        }

        /// <summary>
        /// Attempts to find an item by id in the inventory.
        /// </summary>
        /// <param name="id">The id of the item to find</param>
        /// <returns>If the item is found, true. Else, false.</returns>
        public bool FindItemById(int id)
        {
            //loops through inventory comparing product until found
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                if (item.Key.ProductID == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adjust the quantity of a product in the inventory.
        /// </summary>
        /// <param name="product">The product in the inventory</param>
        /// <param name="quantity">The amount to add( or subtract) to the quantity.</param>
        /// <returns>If product is found and adjustment to quantity is resonable, true. Else, false.</returns>
        public bool AdjustQuantity(Product product, int quantity)
        {
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                if (item.Key.ProductID == product.ProductID)
                {
                    if(item.Value + quantity >= 0)
                    {
                        inventory[item.Key] = item.Value + quantity;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Product found, but only {item.Value} in stock. You requested tried to decrease the quantity by {-1 * quantity}. Please try again.");
                        return false;
                    }
                }
            }
            //when item is not found in inventory
            Console.WriteLine("Product not found in this Location's inventory.");
            return false;
        }

        /// <summary>
        /// A formatted representation of the products and quantities in this location's inventory
        /// </summary>
        /// <returns> A formatted representation of the products and quantities in this location's inventory</returns>
        public string InventoryToString()
        {
            string str = "";
            foreach (KeyValuePair<Product, int> item in inventory)
            {
                str += $"\n{item.Key.ToString()} \n\t\tQuantity: {item.Value}";
            }
            return str;
        }

        /// <summary>
        /// Overrides the base ToString()
        /// A formatted respresentation of this Location
        /// </summary>
        /// <returns>A formatted respresentation of this Location</returns>
        public override string ToString()
        {
            return $"\tID : {StoreID} \n\tNAME: {StoreName} \n\tADDRESS: {Address}";
        }



    }

}
