using System;
using System.Collections.Generic;
using System.Linq;
using dom = Domains.Library;

namespace DbLibrary.Library
{
    public static class Mapper
    {
        public static dom.Customer MapCustomer(Entities.Customer custEnt)
        {
            return new dom.Customer(custEnt.FirstName, custEnt.LastName, custEnt.CustomerAddress, custEnt.CustomerId);
        }


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

        public static dom.Product MapProduct(Entities.Product prodEnt)
        {
            return new dom.Product(prodEnt.ProductName, prodEnt.ProductDescription, prodEnt.ProductId);
        }

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
        
        //note that Domain order = Entity receipt
        public static dom.Order MapOrder(Entities.Receipt ordEnt)
        {
            //Console.WriteLine(ordEnt.CustomerId); //prints 1000
            var custDom = MapCustomer(ordEnt.Customer); 
            var locDom = MapLocation(ordEnt.Location);
            var ordDom= new dom.Order(custDom, locDom, ordEnt.ReceiptId);
            foreach(Entities.Basket item in ordEnt.Basket)
            {
                var prodDom = MapProduct(item.Product);
                ordDom.basket.Add(prodDom, item.Quantity);
                    
                    //AddItemToBasket(prodDom, item.Quantity);
            }
            return ordDom;
        }

        public static Entities.Receipt MapOrder(dom.Order ordDom)
        {
            return new Entities.Receipt
            {
                LocationId = ordDom.OrderLocation.StoreID,
                CustomerId = ordDom.OrderCustomer.CustID,
            };
        }

        public static IEnumerable<Entities.Basket> MapBasket(dom.Order ordDom, int dbId)
        {
            var list = new List<Entities.Basket> { };
            foreach(KeyValuePair<dom.Product, int> item in ordDom.basket)
            {
                list.Add(new Entities.Basket { ProductId = item.Key.ProductID, Quantity = item.Value });
            }
            return list;
        }
    }
}
