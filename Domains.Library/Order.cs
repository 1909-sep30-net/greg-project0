using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    public class Order
    {
        //fields affected by Properties
        private Customer orderCustomer;
        private Location orderLocation;
        private int orderId;

        /// <summary>
        /// The items on the order and the quantity of them
        /// </summary>
        private Dictionary<Product, int> basket;//<Product object, int quantity>

        /// <summary>
        /// The Customer who made the order
        /// </summary>
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

        /// <summary>
        /// The Location where the order was name.
        /// </summary>
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

        /// <summary>
        /// The Order ID. Should only be set by db!!!
        /// </summary>
        public int OrderId
        {
            get { return orderId; }
            set
            {
                if (value < 100000 || value >= 200000)
                    throw new ArgumentOutOfRangeException("Order Id # must be 100000 <= # < 200000");
                else
                    orderId = value;
            }
        }

        /// <summary>
        /// Constructor for an order.
        /// </summary>
        /// <param name="customer">The customer of the order</param>
        /// <param name="location">The location of the order</param>
        /// <param name="orderId">The id of the order - should only be set by db!</param>
        public Order(Customer customer, Location location, int orderId)
        {
            OrderCustomer = customer;
            OrderLocation = location;
            OrderId = orderId;
            basket = new Dictionary<Product, int>() { };//initialize an empty basket
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
