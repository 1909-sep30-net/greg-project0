using System;
using System.Linq;
using dom = Domains.Library;

namespace DbLibrary.Library
{
    public static class Mapper
    {
        public static dom.Customer MapCustomer(Entities.Customer custEnt)
        {
            return new dom.Customer(custEnt.FirstName, custEnt.LastName, custEnt.CustomerId);
        }

        public static Entities.Customer MapCustomer(dom.Customer custDom)
        {
            return new Entities.Customer
            {
                //CustomerId = custDom.CustID,
                FirstName = custDom.FirstName,
                LastName = custDom.LastName
            };
        }

        public static dom.Product MapProduct(Entities.Product prodEnt)
        {
            return new dom.Product(prodEnt.ProductName, prodEnt.ProductDescription, prodEnt.ProductId);
        }

        public static dom.Location MapLocation(Entities.Location locEnt)
        {
            string address = $"{locEnt.Street} {locEnt.City} {locEnt.State} {locEnt.ZipCode}";
            var loc = new dom.Location(locEnt.LocationName, address, locEnt.LocationId);  
            foreach(Entities.Inventory item in locEnt.Inventory)
            {
                var prod = MapProduct(item.Product);
                loc.AddNewItem(prod, item.Quantity);
            }
            return loc;
        }
        
        //note that Domain order = Entity reciept
        public static dom.Order MapOrder(Entities.Reciept ordEnt)
        {
            var cust = MapCustomer(ordEnt.Customer);
            var loc = MapLocation(ordEnt.Location);
            var ord = new dom.Order(cust, loc, ordEnt.RecieptId);
            foreach(Entities.Basket item in ordEnt.Basket)
            {
                var prod = MapProduct(item.Product);
                ord.AddItemToBasket(prod, item.Quantity);
            }
            return ord;
        }
    }
}
