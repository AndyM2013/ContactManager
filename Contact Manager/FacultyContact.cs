using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class FacultyContact
    {
        // public properties
        public string Email
        {
            get { return email; }
            set
            {
                email = (isValidString(value)) ? value :
                             throw new ArgumentException("Mail address is null or empty string");
            }
        }

        public string OfficeBuilding
        {
            get { return officeBuilding; }
            set
            {
                officeBuilding = (isValidString(value)) ? value :
                                    throw new ArgumentException("Mail address is null or empty string");
            }
        }

        // private properties
        private string email;
        private string officeBuilding;


        // constructor
        public FacultyContact(string email, string office)
        {
            this.email = (isValidString(email)) ? email :
                                throw new ArgumentException("Mail address is null or empty string");

            officeBuilding = (isValidString(office)) ? office :
                                    throw new ArgumentException("Office Building is null or empty string");

        }

        // string validation method
        protected bool isValidString(string str)
        {
            return (!string.IsNullOrEmpty(str)) ? true : false;
        }

        // function to check if the contact object is null
        public static bool isNull(FacultyContact contact)
        {
            return (contact == null) ? true : false;
        }

    }
}
