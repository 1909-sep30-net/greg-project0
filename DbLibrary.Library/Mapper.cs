using System;
using System.Linq;

namespace DbLibrary.Library
{
    public static class Mapper
    {
        public static Domains.Library.Customer MapCustomer(Entities.Customer custSQL)
        {
            Console.WriteLine(custSQL.CustomerId);
            return new Domains.Library.Customer(custSQL.FirstName, custSQL.LastName, custSQL.CustomerId);
        }

        public static Domains.Library.Product MapProduct(Entities.Product prodSQL)
        {
            return new Domains.Library.Product(prodSQL.ProductName, prodSQL.ProductDescription, prodSQL.ProductId);
        }

        public static Domains.Library.Location MapLocation(Entities.Location locSQL)
        {
            string address = $"{locSQL.Street} {locSQL.City} {locSQL.State} {locSQL.ZipCode}";
            var loc = new Domains.Library.Location(locSQL.LocationName, address, locSQL.LocationId);  
            foreach(Entities.Inventory item in locSQL.Inventory)
            {
                var prod = MapProduct(item.Product);
                loc.AddNewItem(prod, item.Quantity);
            }
            return loc;
        }
        
        //note that Domain order = Entity reciept
        public static Domains.Library.Order MapOrder(Entities.Reciept ordSQL)
        {
            var cust = MapCustomer(ordSQL.Customer);
            var loc = MapLocation(ordSQL.Location);
            var ord = new Domains.Library.Order(cust, loc, ordSQL.RecieptId);
            foreach(Entities.Basket item in ordSQL.Basket)
            {
                var prod = MapProduct(item.Product);
                ord.AddItemToBasket(prod, item.Quantity);
            }
            return ord;
        }
    }
}
