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
    class Customer
    {
        //static fields
        static int nextID = 0;

        //fields
        private string firstName;
        private string lastName;
        private int id;

        //Properties
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        //returns string - formatted full name
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        //in future, implement a local database that checks ids in use and set id
        //based on data already in db
        private int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Constructor auto-sets Id based on static nextID
        //Will need to be editted with ID assignment is implemented
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = Customer.nextID;
            Customer.nextID++;
        }






    }
}
