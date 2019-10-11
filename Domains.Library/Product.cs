using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    
    public class Product
    {

        //fields affected by properties
        private string productName;
        private string productDescription;
        private int productID;


        /// <summary>
        /// The product name. Cannot be null, empty, or longer than 50 characters.
        /// </summary>
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

        /// <summary>
        /// The product description. Cannot be null, empty, or longer than 200 characters.
        /// </summary>
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

        /// <summary>
        /// The product id. Must be bewteen 1 and 1000, inclusive.
        /// </summary>
        public int ProductID
        {
            get { return productID; }
            set
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Product Id must be greater than 0 but less than or equal to 1000.");
                else
                    productID = value;
            }
        }

        /// <summary>
        /// Constructor of a new Product
        /// </summary>
        /// <param name="name">The Product name</param>
        /// <param name="description">The product description</param>
        /// <param name="productId">The product Id, needs to be set by db!</param>
        public Product(string name, string description, int productId)
        {
            ProductName = name;
            ProductDescription = description;
            ProductID = productId;
                        
        }

        public override string ToString()
        {
            return $"ID: {this.ProductID},  NAME: {this.ProductName}, DESCRIPTION: {this.ProductDescription}";
        }
    }
}
