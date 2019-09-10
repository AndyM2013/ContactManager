using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class Faculty : UniversityPeople
    {
        // public properties
        public FacultyContact Contact
        {
            get { return contact; }
            set
            {
                contact = (!FacultyContact.isNull(value)) ? value :
                               throw new ArgumentException("Null value is unaccepted");
            }
        }

        // private properties
        private FacultyContact contact;

        // constructors
        public Faculty(string fname, string lname, string department, FacultyContact fc, string type): 
                       base(fname, lname, department, type)
        {
            contact = (!FacultyContact.isNull(fc)) ? fc :
                           throw new ArgumentException("Null value is unaccepted");
        }

        public Faculty(string fromFile): base(fromFile)
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            contact = new FacultyContact(tokens[4], tokens[5]);

        }

        // override ToString()
        public override string ToString()
        {
            return base.ToString() + $", Email Address: {contact.Email}, " + $"Office Location Building: {contact.OfficeBuilding}";
        }

        // override ToFileString()
        public override string ToFileString()
        {
            return base.ToFileString() + $"|{contact.Email}|" + $"{contact.OfficeBuilding}";
        }
    }
}
