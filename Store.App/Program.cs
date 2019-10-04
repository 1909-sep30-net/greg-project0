using System;
using Domains.Library;
using Store.Library;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Location("Walmart", "123 Main St");
            Console.WriteLine(store.StoreName);
            Console.WriteLine(store.Address);
        }
    }
}
