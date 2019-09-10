using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Manager
{
    public partial class addFacultyForm : Form
    {
        // public properties
        public bool EditMode = false;  // to store if it is under edit mode

        public string FirstName;
        public string LastName;
        public string AcademicDepartment;
        public FacultyContact FacultyContact;

        // private boolean variables to store validation results
        private bool haveValidFirstName = false;
        private bool haveValidLastName = false;
        private bool haveValidAcademicDepartment = false;
        private bool haveValidEmailAddress = false;
        private bool haveValidOfficeBuilding = false;

        public addFacultyForm()
        {
            InitializeComponent();
        }

        // add button click event handler
        private void AddButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null; // variable for bad field name
            string adviceString = null; // variable for the advice string

            if (!haveValidFirstName)
            {
                badFieldName = "First Name";
                adviceString = "Enter First Name";
            }
            else if (!haveValidLastName)
            {
                badFieldName = "Last Name";
                adviceString = "Enter Last Name";
            }
            else if (!haveValidAcademicDepartment)
            {
                badFieldName = "Academic Department";
                adviceString = "Enter Academic Department";
            }
            else if (!haveValidEmailAddress)
            {
                badFieldName = "Email Address";
                adviceString = "Enter Email Address";
            }
            else if (!haveValidOfficeBuilding)
            {
                badFieldName = "Office Building";
                adviceString = "Enter Office Building";
            }

            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}.\n{adviceString}", "Data Entry Error");
                return;
            }

            // assign faculty contact object 
            FacultyContact = new FacultyContact(emailAddressTextBox.Text.Trim(),
                                                officeLocationBuildingTextBox.Text.Trim());

            DialogResult = DialogResult.OK;
        }

        // cancel button click event
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // validations
        // check first name
        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Trim().Length == 0)
            {
                haveValidFirstName = false;
            }
            else
            {
                haveValidFirstName = true;
                FirstName = firstNameTextBox.Text.Trim();
            }

        }

        // check last name
        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lastNameTextBox.Text.Trim().Length == 0)
            {
                haveValidLastName = false;
            }
            else
            {
                haveValidLastName = true;
                LastName = lastNameTextBox.Text.Trim();
            }

        }

        // check academic department
        private void AcademicDepartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (academicDepartmentTextBox.Text.Trim().Length == 0)
            {
                haveValidAcademicDepartment = false;
            }
            else
            {
                haveValidAcademicDepartment = true;
                AcademicDepartment = academicDepartmentTextBox.Text.Trim();
            }
        }

        // check email address
        private void EmailAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailAddressTextBox.Text.Trim().Length == 0)
            {
                haveValidEmailAddress = false;
            }
            else
            {
                haveValidEmailAddress = true;
            }
        }

        // check office location building
        private void OfficeLocationBuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (officeLocationBuildingTextBox.Text.Trim().Length == 0)
            {
                haveValidOfficeBuilding = false;
            }
            else
            {
                haveValidOfficeBuilding = true;
            }
        }

        // turn it to edit mode
        private void addFacultyForm_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                firstNameTextBox.Text = FirstName;
                lastNameTextBox.Text = LastName;
                academicDepartmentTextBox.Text = AcademicDepartment;
                emailAddressTextBox.Text = FacultyContact.Email;
                officeLocationBuildingTextBox.Text = FacultyContact.OfficeBuilding;

                addButton.Text = "Update";
                this.Text = "Upate Faculty";

            }
        }
    }
}
