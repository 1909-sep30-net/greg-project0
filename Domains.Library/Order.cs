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
    public class Order
    {
        //static fields
        private static int nextID = 0;

        //fields
        private Customer orderCustomer;
        private Location orderLocation;
        private int orderId;

        private Dictionary<Product, int> basket;//<Product object, int quantity>

        //Properties
        public Customer OrderCustomer
        {
            get { return orderCustomer; }
            //set { orderCustomer = value; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Customer cannot be null.");
                else
                    orderCustomer = value;
            }
        }
        public Location OrderLocation
        {
            get { return orderLocation; }
            //set { orderLocation = value; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Location/Address cannot be null.");
                else
                    orderLocation = value;
            }
        }
        public int OrderId
        {
            get { return orderId; }
        }

        //Constructor
        public Order(Customer customer, Location location)
        {
            OrderCustomer = customer;
            OrderLocation = location;
            orderId = Order.nextID;
            Order.nextID++;
            basket = new Dictionary<Product, int>() { };
        }

        /*
         * Attempts to add a product to the basket
         * if product exists in Location inventory, with enough in stock to fulfill request, add to basket and remove from inventory - returs true
         * else returns false
         */
        public bool AddItemToBasket(Product product, int quantity)
        {
            bool success = OrderLocation.AdjustQuantity(product, -1 * quantity);
            if(success)
            {
                basket.Add(product, quantity);
            }
            return success;

            /*
            if(OrderLocation.Inventory.ContainsKey(product))
            {
                if(OrderLocation.Inventory[product] >= quantity)
                {
                    OrderLocation.Inventory[product] -= quantity;
                    basket.Add(product, quantity);
                    return true;
                }
            }
            return false;
            */
        }

        /*
         * Attempts to remove a product from the basket
         * if product exists in basket, with enough in basket to fulfill request, add to inventory and remove from basket - returns true
         * else returns false
         */
        public bool ReturnProduct(Product product)
        {
            if (basket.ContainsKey(product))
            {
                OrderLocation.Inventory[product] += basket[product];
                basket.Remove(product);
                return true;
            }    
            return false;
        }

        public override string ToString()
        {
            string str = "";
            foreach(KeyValuePair<Product, int> item in basket)
            {
                str += $"    QUANTITY: {item.Value},  {item.Key.ToString()}\n";
            }
            return str;
        }


    }
}
