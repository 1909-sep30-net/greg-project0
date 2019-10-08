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
            set { orderCustomer = value; }
        }
        public Location OrderLocation
        {
            get { return orderLocation; }
            set { orderLocation = value; }
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
            basket = new Dictionary<Product, int>();
        }

        /*
         * Attempts to add a product to the basket
         * if product exists in Location inventory, with enough in stock to fulfill request, add to basket and remove from inventory - returs true
         * else returns false
         *
        public bool addProduct(Product product, int quantity)
        {
            if(OrderLocation.Inventory.Contains(product))
            {
                if(product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    basket.Add(product, quantity);
                    return true;
                }
            }
            return false;
        }

        /*
         * Attempts to remove a product from the basket
         * if product exists in basket, with enough in basket to fulfill request, add to inventory and remove from basket - returns true
         * else returns false
         *
        public bool returnProduct(Product product, int quantity)
        {
            if(basket.ContainsKey(product))
            {
                int numberInBasket;
                basket.TryGetValue(product, out numberInBasket);
                if(numberInBasket >= quantity)
                {
                    int newQuantity = numberInBasket - quantity;
                    basket.Remove(product);
                    basket.Add(product, newQuantity);
                    product.Quantity += quantity;
                    return true;
                }
            }
            return false;
        }
        */


    }
}
