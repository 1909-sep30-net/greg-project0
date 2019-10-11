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
    public class Customer
    {
        //static fields
        private static int nextID = 0;

        //fields
        private string firstName;
        private string lastName;
        private int custID;

        //Properties
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
                    firstName = value;
            }
        }

        //returns string - formatted full name
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        public int CustID
        {
            get { return custID; }
        }

        

        //Constructor auto-sets Id based on static nextID
        //Will need to be editted with ID assignment is implemented
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            custID = Customer.nextID;
            Customer.nextID++;
        }

        public override string ToString()
        {
            return $"ID:{CustID},  FIRST NAME: {FirstName},  LAST NAME: {LastName}";
        }




    }
}
