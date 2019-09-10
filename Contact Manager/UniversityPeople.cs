using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class UniversityPeople
    {
        // public properites
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = (isValidString(value)) ? value : 
                            throw new ArgumentException("First Name is null or empty string");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = (isValidString(value)) ? value : 
                            throw new ArgumentException("Last Name is null or empty string");
            }
        }
        public string AcademicDepartment
        {
            get { return academicDepartment; }
            set
            {
                academicDepartment = (isValidString(value)) ? value : 
                                     throw new ArgumentException("Academic department is null or empty string");
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (value != "Faculty" || value != "Student")
                {
                    throw new ArgumentException("Category only can be either Faculty or Student");
                }
                else
                {
                    category = value;
                }
            }
        }


        // private properties
        private string firstName;
        private string lastName;
        private string academicDepartment;
        private string category;

        // constructors
        public UniversityPeople(string fName, string lName, string acadDepartment, string category)
        {
            firstName = (isValidString(fName)) ? fName : 
                         throw new ArgumentException("First Name is null or empty string");

            lastName = (isValidString(lName)) ? lName : 
                         throw new ArgumentException("Last Name is null or empty string");

            academicDepartment = (isValidString(acadDepartment)) ? acadDepartment : 
                                  throw new ArgumentException("Academic department is null or empty string");

            this.category = (category == "Faculty" || category == "Student") ? category :
                             throw new ArgumentException("Can only be Faculty or Student");
            
        }

        public UniversityPeople(string fromFile)
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            firstName = tokens[0];
            lastName = tokens[1];
            category = tokens[2];
            academicDepartment = tokens[3];
        }

        // override ToString()
        public override string ToString()
        {
            return $"First Name: {firstName}, Last Name: {lastName}, " +
                    $"Academic Department: {academicDepartment}";
        }

        // ToFileString
        public virtual string ToFileString()
        {
            string toFileString = "";
            toFileString += $"{FirstName}|";
            toFileString += $"{LastName}|";
            toFileString += $"{Category}|";            
            toFileString += $"{AcademicDepartment}";

            return toFileString;
        }

        // ToFormatedString
        public virtual string ToFormattedString()
        {
            string theString = "";

            theString += $"{FirstName,-30}";
            theString += $"{LastName,-32}";
            theString += $"{Category,-36}";
            theString += $"{AcademicDepartment,-30}";

            return theString;

        }

        // string validation method
        protected bool isValidString (string str)
        {
            return (!string.IsNullOrEmpty(str)) ? true : false;
        }
    }
}
