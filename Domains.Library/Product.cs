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
        

        //Properties
        public string ProductName
        {
            get { return productName; }
            //set { productName = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Product name cannot be null or empty string.");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Product First Name cannot be greater than 50 characters.");
                else
                    productName = value;
            }
        }

        public string ProductDescription
        {
            get { return productDescription; }
            //set { productDescription = value; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentOutOfRangeException("Description cannot be greater than 200 characters.");
                else
                    productName = value;
            }
        }

        public int ProductID
        {
            get { return productID; }
        }

        //Constructor
        //Constructor auto-sets Id based on static nextID
        //Will need to be editted with ID assignment is implemented
        //needs check that quantity is > 0
        //needs to reject new Products with same name
        public Product(string name, string description)
        {
            ProductName = name;
            ProductDescription = description;
            productID = Product.nextID;
            Product.nextID++;
                        
        }

        public override string ToString()
        {
            return $"ID: {this.ProductID},  NAME: {this.ProductName}, DESCRIPTION: {this.ProductDescription}";
        }
    }
}
