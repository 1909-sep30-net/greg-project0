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
        private DateTime orderTimestamp;

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

        public DateTime OrderTimestamp
        {
            get { return orderTimestamp; }
            set { orderTimestamp = value; }
        }

        /// <summary>
        /// Constructor for an order without a timestamp.
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
            OrderTimestamp = DateTime.Now;
        }

        /// <summary>
        /// Constructor for an order with a Timestamp
        /// </summary>
        /// <param name="customer">The customer of the order</param>
        /// <param name="location">The location of the order</param>
        /// <param name="orderId">The id of the order. Should only be trusted if this Location was mapped over from a database entity.</param>
        /// <param name="datetime">The Timestamp of the order</param>
        public Order(Customer customer, Location location, int orderId, DateTime datetime)
        {
            OrderCustomer = customer;
            OrderLocation = location;
            OrderId = orderId;
            basket = new Dictionary<Product, int>() { };//initialize an empty basket
            OrderTimestamp = datetime;
        }

        public Order()
        {
            OrderCustomer = null;
            OrderLocation = null;
            OrderId = 0;
            basket = null;
            OrderTimestamp = default(DateTime);
        }

        /// <summary>
        /// Adjust the quantity of a product in the basket.
        /// </summary>
        /// <param name="product">The product in the inventory</param>
        /// <param name="quantity">The amount to add( or subtract) to the quantity.</param>
        /// <returns>If product is found and adjustment to quantity is reasonable, true. Else, false.</returns>
        public bool AdjustQuantity(Product product, int quantity)
        {
            foreach (KeyValuePair<Product, int> item in basket)
            {
                if (item.Key.ProductID == product.ProductID)
                {
                    if (item.Value + quantity >= 0)
                    {
                        basket[item.Key] = item.Value + quantity;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Product found, but only {item.Value} in basket. You requested tried to decrease the quantity by {-1 * quantity}. Please try again.");
                        return false;
                    }
                }
            }
            //when item is not found in inventory
            Console.WriteLine("Product not found in this Location's inventory.");
            return false;
        }

        public decimal CalculateCostOfBasket()
        {
            decimal total = 0m;
            foreach(KeyValuePair<Product, int> item in basket)
            {
                total += item.Key.Cost * item.Value;
            }
            return Math.Round(total, 2);
        }

        /// <summary>
        /// Calculated the number of items in the basket.
        /// </summary>
        /// <returns>The number of items in the basket</returns>
        public int CalculateNumberOfItemsInBasket()
        {
            int result = 0;
            foreach (KeyValuePair<Product, int> item in basket)
            {
                result += item.Value;
            }
            return result;
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
                var prod = item.Key;
                str += $"\n{prod.ToString()} \n\t\tQuantity: {item.Value}";
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
            return $"\nOrder ID: {this.OrderId} \n\tCustomer ID: {this.OrderCustomer.CustID}\tCustomer Name: {this.OrderCustomer.FullName}" +
                $"\n\tLocation ID: {this.OrderLocation.StoreID}\tLocation Name: {this.OrderLocation.StoreName}" +
                $"\n\tTimestamp: {this.OrderTimestamp}\n\tNumber of Items: {this.CalculateNumberOfItemsInBasket()}" +
                $"\n\tTotal Cost: {this.CalculateCostOfBasket()}";
        }


    }
}
