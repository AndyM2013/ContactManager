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
    public partial class addStudentForm : Form
    {
        /*To edit an item in a listbox, all you need is a simple editbox that 
         * overlays on a listbox item.The idea is to create a TextBox control 
         * and keep it hidden and show it whenever required.
         */
        private System.Windows.Forms.TextBox editBox;

        // public properties
        public bool EditMode = false; // variable for edit mode on and off

        public string FirstName;
        public string LastName;
        public string AcademicDepartment;
        public StudentContact StudentContact;
        public int GraduationYear;
        public List<string> CourseList = new List<string>();
       
        // private boolean to store validation results
        private bool haveValidFirstName = false;
        private bool haveValidLastName = false;
        private bool haveValidAcademicDepartment = false;
        private bool haveValidEmailAddress = false;
        private bool haveValidSnailMailAddress = false;
        private bool haveValidGraduationYear = false;
   
        public addStudentForm()
        {
            InitializeComponent();
        }

        // add button event handler
        private void addButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null; // variable for bad field name
            string adviceString = null; // variable for advice string

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
                badFieldName = "Department";
                adviceString = "Enter Department";
            }
            else if (!haveValidEmailAddress)
            {
                badFieldName = "Email Address";
                adviceString = "Enter Email Address";
            }
            else if (!haveValidSnailMailAddress)
            {
                badFieldName = "Mail Address";
                adviceString = "Enter Mailing Address";
            }
            else if (!haveValidGraduationYear)
            {
                badFieldName = "Graduation Year";
                adviceString = "Enter Graduation Year";
            }

            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}.\n{adviceString}", "Data Entry Error");
                return;
            }

            // assign student contact object
            StudentContact = new StudentContact(emailAddressTextBox.Text.Trim(),
                                                snailMailAddressTextBox.Text.Trim());

            DialogResult = DialogResult.OK;
        }


        // cancel button click event handler
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        //validations
        // first name validation
        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
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

        // last name validation
        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
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

        // academic department validation
        private void academicDepartmentTextBox_TextChanged(object sender, EventArgs e)
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

        // email address validation
        private void emailAddressTextBox_TextChanged(object sender, EventArgs e)
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

        // mailing address validation
        private void snailMailAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (snailMailAddressTextBox.Text.Trim().Length == 0)
            {
                haveValidSnailMailAddress = false;
            }
            else
            {
                haveValidSnailMailAddress = true;
            }
        }

        // graduation year validation
        // for this assignment, I assume the maximum years to taking a degree is 10 years
        private void graduationYearTextBox_TextChanged(object sender, EventArgs e)
        {            
            int currentYear = DateTime.Now.Date.Year;

            if (graduationYearTextBox.Text.Trim().Length == 0)
            {
                haveValidGraduationYear = false;
            }

            int input = int.Parse(graduationYearTextBox.Text.Trim());

            if (input < currentYear || input > (currentYear + 10))
            {

                haveValidGraduationYear = false;
            }
            else
            {
                haveValidGraduationYear = true;
                GraduationYear = input;
            }

        }

        
        private void addStudentForm_Load(object sender, EventArgs e)
        {

            // if editMode is true then reload the student's contact info
            // config the editBox to edit course list items
            if (EditMode)
            {
                editBox = new System.Windows.Forms.TextBox();
                editBox.Location = new System.Drawing.Point(0, 0);
                editBox.Size = new System.Drawing.Size(0, 0);
                editBox.Hide();
                courseListListBox.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
                editBox.Text = "";
                editBox.BackColor = Color.Beige;
                editBox.Font = new Font("Varanda", 15, FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Pixel);
                editBox.ForeColor = Color.Blue;
                editBox.BorderStyle = BorderStyle.FixedSingle;

                //Two events are added to the EditBox

                //KeyPress event to check if the enter key is 
                //pressed when the user has finished editing the item.

                //LostFocus event in case the user edits the item and 
                //instead of using the enter key to indicate the end of editing, 
                //the user clicks some other item in the list box.
                editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
                editBox.LostFocus += new System.EventHandler(this.FocusOver);

                firstNameTextBox.Text = FirstName;
                lastNameTextBox.Text = LastName;
                academicDepartmentTextBox.Text = AcademicDepartment;
                emailAddressTextBox.Text = StudentContact.Email;
                snailMailAddressTextBox.Text = StudentContact.MailAddress;
                graduationYearTextBox.Text = GraduationYear.ToString();

                if (CourseList != null)
                {
                    foreach (string c in CourseList)
                    {
                        courseListListBox.Items.Add(c);
                    }
                }

                addButton.Text = "Update";
                this.Text = "Upate Student";

            }
        }

        // trigger the add course dialogue
        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            AddCoursesForm addCourse = new AddCoursesForm();
            DialogResult result = addCourse.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            // save the added course to course list
            CourseList.Add(addCourse.Course);
            courseListListBox.Items.Add(addCourse.Course);
        }

        // save the change
        private void FocusOver(object sender, System.EventArgs e)
        {
            courseListListBox.Items[courseListListBox.SelectedIndex] = editBox.Text.Trim();
            CourseList[courseListListBox.SelectedIndex] = editBox.Text.Trim();
            editBox.Hide();
        }

        // save the change
        private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                courseListListBox.Items[courseListListBox.SelectedIndex] = editBox.Text.Trim();
                CourseList[courseListListBox.SelectedIndex] = editBox.Text.Trim();
                editBox.Hide();
            }
        }

        // create a edit box. The listbox item text message has been assigned 
        // to the edit box text. 
        private void CreateEditBox(object sender)
        {
            courseListListBox = (ListBox)sender;
            int itemSelected = courseListListBox.SelectedIndex;
            Rectangle r = courseListListBox.GetItemRectangle(itemSelected);
            string itemText = (string)courseListListBox.Items[itemSelected];
            editBox.Location = new System.Drawing.Point(r.X + 10, r.Y + 10);
            editBox.Size = new System.Drawing.Size(r.Width - 10, r.Height - 10);
            editBox.Show();
            courseListListBox.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
            editBox.Text = itemText;
            editBox.Focus();
            editBox.SelectAll();
            editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
            editBox.LostFocus += new System.EventHandler(this.FocusOver);
        }

        // when user click enter, trigger the createEditBox function
        private void CourseListListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                CreateEditBox(sender);
        }

        // double click to trigger the createEditBox function
        private void CourseListListBox_DoubleClick(object sender, EventArgs e)
        {
            CreateEditBox(sender);
        }
    }
}



