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
    public partial class SearchForm : Form
    {
        // title property
        public string Title
        {
            get { return this.Text; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Null or empty input");
                }
                else
                {
                    this.Text = value;
                }
            }
        }

        public string SearchResult; // return the search text input

        private bool isValidString = false;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // valid the input text first
            validString(searchTextBox.Text.Trim());

            if (!isValidString)
            {
                MessageBox.Show("Entered string cannot be null or empty");
                return;
            }
            else
            {
                SearchResult = searchTextBox.Text.Trim().ToLower();
            }
            // dismiss the dialog by setting DialogResult
            DialogResult = DialogResult.OK;
        }

        // cancel button event handler
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // validation function to check if an input string is null or empty
        private void validString (string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                isValidString = false;
            }
            else
            {
                isValidString = true;
            }
        }
    }
}
