using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class StudentContact
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

        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                mailAddress = (isValidString(value)) ? value :
                                    throw new ArgumentException("Mail address is null or empty string");
            }

        }

        // private properties
        private string email;
        private string mailAddress;


        // constructor
        public StudentContact(string email, string mailAddress)
        {
            this.email = (isValidString(email)) ? email :
                                throw new ArgumentException("Mail address is null or empty string");

            this.mailAddress = (isValidString(mailAddress)) ? mailAddress :
                                    throw new ArgumentException("Mail address is null or empty string");


        }

        // string validation method
        protected bool isValidString(string str)
        {
            return (!string.IsNullOrEmpty(str)) ? true : false;
        }

        // function to check is an object is null 
        public static bool isNull(StudentContact contact)
        {
            return (contact == null) ? true : false;
        }

    }
}
