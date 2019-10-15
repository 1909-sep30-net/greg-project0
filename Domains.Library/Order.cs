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
        /// The Products of the order and the quantity of them
        /// </summary>
        public Dictionary<Product, int> basket;//<Product object, int quantity>

        /// <summary>
        /// The Customer who made the order
        /// </summary>
        public Customer OrderCustomer
        {
            get { return orderCustomer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Customer cannot be null.");
                else
                    orderCustomer = value;
            }
        }

        /// <summary>
        /// The Location where the order was made. Cannot be null.
        /// </summary>
        public Location OrderLocation
        {
            get { return orderLocation; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Location cannot be null.");
                else
                    orderLocation = value;
            }
        }

        /// <summary>
        /// The Order ID. Should only be trusted if this Location was mapped over from a database entity.
        /// </summary>
        public int OrderId
        {
            get { return orderId; }
            set
            {
                    orderId = value;
            }
        }

        /// <summary>
        /// Constructor for an order.
        /// </summary>
        /// <param name="customer">The customer of the order</param>
        /// <param name="location">The location of the order</param>
        /// <param name="orderId">The id of the order. Should only be trusted if this Location was mapped over from a database entity.</param>
        public Order(Customer customer, Location location, int orderId)
        {
            OrderCustomer = customer;
            OrderLocation = location;
            OrderId = orderId;
            basket = new Dictionary<Product, int>() { };//initialize an empty basket
        }

        /// <summary>
        /// A formatted representation of the products and quantities in this order's basket
        /// </summary>
        /// <returns> A formatted representation of the products and quantities in this order's basket</returns>
        public string BasketToString()
        {
            string str = "";
            foreach (KeyValuePair<Product, int> item in basket)
            {
                str += $"\n{item.Key.ToString()} \n\t\tQuantity: {item.Value}";
            }
            return str;
        }

        /// <summary>
        /// Overrides the base ToString()
        /// A formatted respresentation of this Order
        /// </summary>
        /// <returns>A formatted respresentation of this Order</returns>
        public override string ToString()
        {
            return $"\nOrder ID: {this.OrderId} \n\tCustomer ID: {this.OrderCustomer.CustID} \n\tLocation ID: {this.OrderLocation.StoreID}";
        }


    }
}
