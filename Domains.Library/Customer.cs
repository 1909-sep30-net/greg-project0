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
        private int custID;

        //Properties
        /// <summary>
        /// The customer's first name. Cannot be null, empty, or longer than 50 characters.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set 
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Customer name cannot be null or empty string.");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Customer First Name cannot be greater than 50 characters.");
                else
                    firstName = value;
            }
        }

        /// <summary>
        /// The customer's last name.  Cannot be null, empty, or longer than 50 characters.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            //set { lastName = value; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Customer Last name cannot be null or empty string.");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Customer Last Name cannot be greater than 50 characters.");
                else
                    lastName = value;
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
        /// Returns the customer's id.
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
        /// <param name="custID">The ID of the customer: must come from the Db!</param>
        public Customer(string firstName, string lastName, int custID = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            CustID = custID;
        }

        public override string ToString()
        {
            return $"ID:{CustID},  FIRST NAME: {FirstName},  LAST NAME: {LastName}";
        }




    }
}
