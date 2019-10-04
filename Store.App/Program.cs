using System;
using Domains.Library;
using Store.Library;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Customer class
            var cust1 = new Customer("Greg", "Favrot");
            var cust2 = new Customer("Mark", "Moore");
            Console.WriteLine(cust1.FullName + " " + cust1.CustID);
            Console.WriteLine(cust2.FirstName + " " + cust2.LastName + " " + cust2.CustID);

            //Test Product class
            var prod1 = new Product("book", "can be read to gain info");
            var prod2 = new Product("coke", "");

            Console.WriteLine(prod1.ProductName + " " + prod1.ProductDescription + " " + prod1.ProductID);
            Console.WriteLine(prod2.ProductName + " " + prod2.ProductDescription + " " + prod2.ProductID);

            ;
        }
    }
}
