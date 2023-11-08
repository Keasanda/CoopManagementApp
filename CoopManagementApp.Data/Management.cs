using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopManagementApp.Data
{

    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }

    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class Contact
    {
        public int ContactID { get; set; }
        public int? PersonID { get; set; }
        public Person Person { get; set; }
        public int? CompanyID { get; set; }
        public Company Company { get; set; }
        public string Position { get; set; }
        public string TelephoneNumber { get; set; }
    }




}
