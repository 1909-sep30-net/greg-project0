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
                CustomerId = custDom.CustID,
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
        
        //note that Domain order = Entity receipt
        public static dom.Order MapOrder(Entities.Receipt ordEnt)
        {
            Console.WriteLine(ordEnt.CustomerId); //prints 1000
            var custDom = MapCustomer(ordEnt.Customer); //Customer is null, throws null exception. Not null in db, the id printing is evidence of that.
            var locDom = MapLocation(ordEnt.Location);
            var ordDom= new dom.Order(custDom, locDom, ordEnt.ReceiptId);
            foreach(Entities.Basket item in ordEnt.Basket)
            {
                var prodDom = MapProduct(item.Product);
                ordDom.AddItemToBasket(prodDom, item.Quantity);
            }
            return ordDom;
        }
    }
}
