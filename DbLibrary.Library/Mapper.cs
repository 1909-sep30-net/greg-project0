using System;
using System.Collections.Generic;
using System.Linq;
using dom = Domains.Library;

namespace DbLibrary.Library
{
    /// <summary>
    /// Contains static methods for mapping between *Domain* objects and *Entity* objects.
    /// *Domain* means the user-defined classes in Domains.Library
    /// *Entity* means the auto-generated classed in DbLibrary.Library.Entities
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Map an Entity Customer into a Domain Customer
        /// </summary>
        /// <param name="custEnt">An Entity Customer</param>
        /// <returns>A Domain Customer</returns>
        public static dom.Customer MapCustomer(Entities.Customer custEnt)
        {
            return new dom.Customer(custEnt.FirstName, custEnt.LastName, custEnt.CustomerAddress, custEnt.CustomerId);
        }

        /// <summary>
        /// Map a Domain Customer into an Entity Customer
        /// </summary>
        /// <param name="custDom">A Domain Customer</param>
        /// <returns>An Entity Customer</returns>
        public static Entities.Customer MapCustomer(dom.Customer custDom)
        {
            return new Entities.Customer
            {
                CustomerId = custDom.CustID,
                FirstName = custDom.FirstName,
                LastName = custDom.LastName,
                CustomerAddress = custDom.Address
            };
        }

        /// <summary>
        /// Maps an Entity Product into a Domain Product
        /// </summary>
        /// <param name="prodEnt">An Entity Product</param>
        /// <returns>A Domain Product</returns>
        public static dom.Product MapProduct(Entities.Product prodEnt)
        {
            return new dom.Product(prodEnt.ProductName, prodEnt.ProductDescription, prodEnt.ProductId, prodEnt.UnitCost);
        }

        /// <summary>
        /// Maps an Entity Location to a Domain Location
        /// </summary>
        /// <param name="locEnt">An Entity Location</param>
        /// <returns>A Domain Location</returns>
        public static dom.Location MapLocation(Entities.Location locEnt)
        {
            var loc = new dom.Location(locEnt.LocationName, locEnt.LocationAddress, locEnt.LocationId);  
            foreach(Entities.Inventory item in locEnt.Inventory)
            {
                var prod = MapProduct(item.Product);
                loc.AddNewItem(prod, item.Quantity);
            }
            return loc;
        }

        /// <summary>
        /// Maps a Domain Location to an entity Location
        /// </summary>
        /// <param name="locDom">A Domain Location</param>
        /// <returns>An Entity Location</returns>
        public static Entities.Location MapLocation(dom.Location locDom)
        {
            return new Entities.Location
            {
                LocationId = 0,
                LocationName = locDom.StoreName,
                LocationAddress = locDom.Address
            };
        }

        /// <summary>
        /// Maps an Domain Location's inventory to a List of Entity Inventories
        /// </summary>
        /// <param name="locDom">A Domain Location</param>
        /// <returns>A List of Entity Inventories</returns>
        public static IEnumerable<Entities.Inventory> MapInventory(dom.Location locDom)
        {
            var list = new List<Entities.Inventory> { };
            foreach (KeyValuePair<dom.Product, int> item in locDom.inventory)
            {
                list.Add(new Entities.Inventory { ProductId = item.Key.ProductID, Quantity = item.Value, LocationId = locDom.StoreID });
            }
            return list;
        }
        
        /// <summary>
        /// Maps an Entity Reciept and Basket into a Domain Order
        /// </summary>
        /// <param name="ordEnt">An Entity Reciept and basket</param>
        /// <returns>A Domain Order</returns>
        public static dom.Order MapOrder(Entities.Receipt ordEnt)
        {
            var custDom = MapCustomer(ordEnt.Customer); 
            var locDom = MapLocation(ordEnt.Location);
            var ordDom= new dom.Order(custDom, locDom, ordEnt.ReceiptId,ordEnt.ReceiptTimestamp);
            foreach(Entities.Basket item in ordEnt.Basket)
            {
                var prodDom = MapProduct(item.Product);
                ordDom.basket.Add(prodDom, item.Quantity);
                    
                    //AddItemToBasket(prodDom, item.Quantity);
            }
            return ordDom;
        }

        /// <summary>
        /// Maps a Domain Order into an Entity Reciept
        /// </summary>
        /// <param name="ordDom">A Domain Order</param>
        /// <returns>An Entity Reciept</returns>
        public static Entities.Receipt MapOrder(dom.Order ordDom)
        {
            return new Entities.Receipt
            {
                LocationId = ordDom.OrderLocation.StoreID,
                CustomerId = ordDom.OrderCustomer.CustID,
                ReceiptTimestamp = ordDom.OrderTimestamp
            };
        }

        /// <summary>
        /// Maps a Domain Order's Basket into a list of Entity Baskets
        /// </summary>
        /// <param name="ordDom">A Domain Order</param>
        /// <param name="dbId">The Id of the Domain from the Database Entity associated with it.</param>
        /// <returns>A list of Entity Baskets</returns>
        public static IEnumerable<Entities.Basket> MapBasket(dom.Order ordDom, int dbId)
        {
            var list = new List<Entities.Basket> { };
            foreach(KeyValuePair<dom.Product, int> item in ordDom.basket)
            {
                list.Add(new Entities.Basket { ProductId = item.Key.ProductID, Quantity = item.Value, ReceiptId = dbId });
            }
            return list;
        }
    }
}
