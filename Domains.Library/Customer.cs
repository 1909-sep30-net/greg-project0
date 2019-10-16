using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Library
{
    public class Customer
    {
        
        //Fields affected by Properties
        private string firstName;
        private string lastName;
        private string address;
        private int custID;

        //Properties
        /// <summary>
        /// The customer's first name. Cannot be null or empty.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set 
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Customer name cannot be null or empty string.");
                else
                    firstName = value;
            }
        }

        /// <summary>
        /// The customer's last name.  Cannot be null or empty.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Customer Last name cannot be null or empty string.");
                else
                    lastName = value;
            }
        }

        /// <summary>
        /// The customer's address in one long string. Cannot be null or empty.
        /// </summary>
        public string Address
        {
            get { return address; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Address cannot be null or empty string.");
                else
                    address = value;
            }
        }

        /// <summary>
        /// Returns the customer's full name, a representation of the first and last names.
        /// </summary>
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        /// <summary>
        /// The customer's id. Should only be trusted if this customer was mapped from a database entity.
        /// </summary>
        public int CustID
        {
            get { return custID; }
            set
            {
                custID = value;
            }
        }

        

        /// <summary>
        /// Constructer for a new Customer
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="custID">The ID of the customer: only useful if this Customer was mapped over from a Database entity.</param>
        public Customer(string firstName, string lastName, string address, int custID = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            CustID = custID;
        }

        public Customer()
        {
            FirstName = null;
            LastName = null;
            Address = null;
            CustID = 0;
        }

        /// <summary>
        /// Overrides the base ToString
        /// Prints out Customer in an organized format.
        /// </summary>
        /// <returns>A formatted string with Customer info</returns>
        public override string ToString()
        {
            return $"\tID:{CustID} \n\tFIRST NAME: {FirstName} \n\tLAST NAME: {LastName} \n\tAddress: {Address}";
        }




    }
}
