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
    public partial class AddCoursesForm : Form
    {
        // public property
        public string Course;

        // boolean to save the validation result
        private bool haveValidCourseName = false;

        public AddCoursesForm()
        {
            InitializeComponent();
        }

        // course text box change event handler
        private void CourseTextBox_TextChanged(object sender, EventArgs e)
        {
            if (courseTextBox.Text.Length == 0)
            {
                haveValidCourseName = false;
            }
            else
            {
                haveValidCourseName = true;
                Course = courseTextBox.Text.Trim();
            }
        }

        // add button event handler
        private void AddButton_Click(object sender, EventArgs e)
        {
            string badFieldName = null;
            string adviceString = null;

            if (!haveValidCourseName)
            {
                badFieldName = "Course";
                adviceString = "Enter Course Here";
            }
            if (badFieldName != null)
            {
                MessageBox.Show($"Invalid {badFieldName}, \n{adviceString}", "Data Entry Error");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        // cancel button event handler
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
