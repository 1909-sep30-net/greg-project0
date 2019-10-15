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
        /// The product name. Cannot be null or empty.
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            //set { productName = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Product name cannot be null or empty string.");
                else
                    productName = value;
            }
        }

        /// <summary>
        /// The product description. Cannot be longer than 200 characters.
        /// </summary>
        public string ProductDescription
        {
            get { return productDescription; }
            //set { productDescription = value; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentException("Description cannot be greater than 200 characters.");
                else
                    productName = value;
            }
        }

        /// <summary>
        /// The product id. Should only be trusted if this Location was mapped over from a database entity.
        /// </summary>
        public int ProductID
        {
            get { return productID; }
            set
            {
                    productID = value;
            }
        }

        /// <summary>
        /// Constructor of a new Product
        /// </summary>
        /// <param name="name">The Product name</param>
        /// <param name="description">The product description</param>
        /// <param name="productId">The product Id, should only be trusted if this Location was mapped over from a database entity.</param>
        public Product(string name, string description, int productId)
        {
            ProductName = name;
            ProductDescription = description;
            ProductID = productId;
                        
        }

        /// <summary>
        /// Overrides the base ToString()
        /// A formatted respresentation of this Product
        /// </summary>
        /// <returns>A formatted respresentation of this Product</returns>
        public override string ToString()
        {
            string str = $"\nID: {this.ProductID} \n\tNAME: {this.ProductName}";
            if (this.ProductDescription != null)
                str += $"\n\tDESCRIPTION: { this.ProductDescription}";
            return str;
        }
    }
}
