using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    class Student : UniversityPeople
    {
        // public properties
        public StudentContact Contact
        {
            get { return contact; }
            set
            {
                Contact = (!StudentContact.isNull(value)) ? value :
                                            throw new ArgumentException("Null value is unaccepted");
            }
        }

        public int GraduationYear
        {
            get { return graduationYear; }
            set
            {
                graduationYear = (isValidGraduationYear(value))? value : 
                                    throw new ArgumentException("Graduation year is invalided");
            }
        }

        public List<string> CourseList = new List<string>();

        // private properties
        private StudentContact contact;
        private int graduationYear;
        //private List<string> courseList; 
        

        // constructors
        public Student(string fname, string lname, string department, StudentContact contact, string type, int year, List<string> courses): 
                       base(fname, lname, department, type)
        {
            this.contact = (!StudentContact.isNull(contact)) ? contact :
                                 throw new ArgumentException("Null value is unaccepted");

            graduationYear = (isValidGraduationYear(year)) ? year :
                                throw new ArgumentException("Graduation year is invalided");

            if (courses == null)
            {
                courses = new List<string> { " " };
            }
            else
            {
                CourseList = courses;
            }
        }

        // constructor using from file string to create a new student
        public Student(string fromFile): base(fromFile)
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            contact = new StudentContact(tokens[4], tokens[5]);
            graduationYear = int.Parse(tokens[6]);

            if (tokens.Length > 6)
            {

                for (int i = 7; i < tokens.Length; i++)
                {
                    CourseList.Add(tokens[i]);
                }
            }
        }


        // override ToString()
        public override string ToString()
        {
            return base.ToString() + $", Email Address: {Contact.Email}, "+ 
                                    $"Snail Mail Address: {Contact.MailAddress}, " +
                                    $"Graduation Year: {graduationYear}";
        }

        // override ToFileString()
        public override string ToFileString()
        {
            string courses = "";
            foreach (string s in CourseList)
            {
                courses += "|" + s;
            }
            return base.ToFileString() + $"|{Contact.Email}|" + $"{Contact.MailAddress}|" + $"{GraduationYear}" + $"{courses}";
        }

        // graduation years validation
        private bool isValidGraduationYear(int yr)
        {
            int currentYear = DateTime.Now.Date.Year;
            return (currentYear <= yr && yr <= (currentYear + 10)) ? true : false;
        }
    }
}
