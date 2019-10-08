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
    public class Product
    {

        //static fields
        private static int nextID = 0;

        //fields
        private string productName;
        private string productDescription;
        private int productID;
        private int quantity;


        //Properties
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        public int ProductID
        {
            get { return productID; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //Constructor
        //Constructor auto-sets Id based on static nextID
        //Will need to be editted with ID assignment is implemented
        //needs check that quantity is > 0
        //needs to reject new Products with same name
        public Product(string name, string description, int quantity)
        {
            ProductName = name;
            ProductDescription = description;
            productID = Product.nextID;
            Product.nextID++;
            this.quantity = quantity;            
        }

        public override string ToString()
        {
            return $"{this.ProductID} >> {this.ProductName} :: {this.Quantity} in stock\n";
        }
    }
}
