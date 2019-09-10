using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Contact_Manager
{
    public partial class contactManagerForm : Form
    {
        // This list is used to store all contact objects
        List<UniversityPeople> peopleList = new List<UniversityPeople>();

        public string Filepath = null; // to save the file path

        private bool changesMade = false; // boolean variable to check if any change were made

        public contactManagerForm()
        {
            InitializeComponent();
        }

        // Faculty in the context menu has been clicked
        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a faculty object, properites will be assigned in the createNewFaculty function
            UniversityPeople person = null;

            person = createNewFaculty();

            // store the new faculty and display it in the contact list box
            if (person != null)
            {
                peopleList.Add(person);
                allContactListBox.Items.Add(person.ToFormattedString());
            }

            changesMade = true;
        }

        // Student in the context menu has been clicked
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a student object, properites will be assigned in the createNewFaculty function
            UniversityPeople person = null;

            person = creatNewStudent();

            // store the new student and display it in the contact list box
            if (person != null)
            {
                peopleList.Add(person);
                allContactListBox.Items.Add(person.ToFormattedString());
            }

            changesMade = true;
        }

        // create a new faculty
        private UniversityPeople createNewFaculty()
        {
            addFacultyForm aff = new addFacultyForm();

            DialogResult result;
            result = aff.ShowDialog();
            if (result != DialogResult.OK)
            {
                return null;
            }

            UniversityPeople newFaculty = new Faculty(aff.FirstName,
                                                      aff.LastName,
                                                      aff.AcademicDepartment,
                                                      aff.FacultyContact,
                                                      "Faculty");

            return newFaculty;
        }

        // create a new student
        private UniversityPeople creatNewStudent()
        {
            addStudentForm asf = new addStudentForm();

            DialogResult result;
            result = asf.ShowDialog();
            if (result != DialogResult.OK)
            {
                return null;
            }

            UniversityPeople newStudent = new Student(asf.FirstName,
                                                      asf.LastName,
                                                      asf.AcademicDepartment,
                                                      asf.StudentContact,
                                                      "Student",
                                                      asf.GraduationYear,
                                                      asf.CourseList);

            return newStudent;
        }

        // open menu selected
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // let the user pick the file to open

            OpenFileDialog ofd = new OpenFileDialog();

            // get the file path
            ofd.Title = "Select a Contact List";
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            ofd.FilterIndex = 1;

            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // check dialog result
            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            // create a new object 
            UniversityPeople p = null;

            // save the file path
            Filepath = ofd.FileName;
           
            try
            {
                StreamReader input = new StreamReader(ofd.FileName);

                while (!input.EndOfStream)
                {
                    string peopleType = input.ReadLine();
                    switch (peopleType)
                    {
                        case "Faculty":
                            p = new Faculty(input.ReadLine());  // create a new faculty
                            break;
                        case "Student":
                            p = new Student(input.ReadLine()); // create a new student
                            break;
                        default:
                            MessageBox.Show("Unknown product in the file");
                            p = null;
                            break;
                    }

                    // add the new object to people list and list box
                    if (p != null)
                    {
                        peopleList.Add(p);
                        allContactListBox.Items.Add(p.ToFormattedString());
                    }
                }

                // close the file
                input.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not load. {excp.Message}");
                return;
            }
        }

        // exit the applicaiton
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changesMade)
            {
                if (DialogResult.Yes != MessageBox.Show($"Would you like to save changes before you Exit?",
                                    "Confirmation", MessageBoxButtons.YesNo))
                {
                    //if the user does not wish to save the file
                    //exit the application
                    Application.Exit();
                }
                else
                {
                    //if changes have been made and the user wants to save the file
                    //call the save event handler to perform the save action before exit.
                    SaveContactsToolStripMenuItem_Click(sender, e);
                }
            }
            //if no changes have been made just exit the application
            Application.Exit();
        }


        // save the current contacts
        private void SaveContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save to a new file
            if (Filepath == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = "Save this constact list";
                sfd.Filter = "Text File|*.txt|All Files|*.*";
                sfd.FilterIndex = 1;

                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                DialogResult result = sfd.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    StreamWriter output = new StreamWriter(sfd.FileName);
                    foreach (UniversityPeople up in peopleList)
                    {
                        output.WriteLine(UniversityPeopleTypeString(up));
                        output.WriteLine(up.ToFileString());
                    }
                    output.Close();
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"File did not write. {excp.Message}");
                    return;
                }
                changesMade = false;
                MessageBox.Show($"Contact List have been save in {sfd.FileName}");
            }
            // save to the current file
            else
            {
                try
                {
                    StreamWriter output = new StreamWriter(Filepath);
                    foreach (UniversityPeople up in peopleList)
                    {
                        output.WriteLine(UniversityPeopleTypeString(up));
                        output.WriteLine(up.ToFileString());
                    }
                    output.Close();
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"File did not write. {excp.Message}", "Error");
                    return;
                }
                changesMade = false;
                MessageBox.Show($"Contact List have been save in {Filepath}", "Save Successful");
            }
        }

        // set person's typle
        private string UniversityPeopleTypeString(UniversityPeople up)
        {
            if (up is Faculty)
                return "Faculty";
            else if (up is Student)
                return "Student";
            else
                return "Unknown";
        }

        // edit event handller
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Console.WriteLine("edit has been selected");

            // make sure we have sth selected
            int index = allContactListBox.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You have to select first");
                return;
            }


            UniversityPeople p = peopleList[index]; // create a new university people object

            if (p.Category == "Faculty")
            {

                editFaculty(index);
                changesMade = true;
            }
            else if (p.Category == "Student")
            {
                editStudent(index);
                changesMade = true;
            }
            else
            {
                MessageBox.Show("Unknow contact trying to be edited");
            }
        }

        
        private void editFaculty(int index)
        {
            addFacultyForm aff = new addFacultyForm();
            aff.EditMode = true;

            // cast the university people object to faculty
            Faculty f = (Faculty)peopleList[index];

            // assign the faculty object's property values to the form
            aff.FirstName = f.FirstName;
            aff.LastName = f.LastName;
            aff.AcademicDepartment = f.AcademicDepartment;
            aff.FacultyContact = new FacultyContact(f.Contact.Email, f.Contact.OfficeBuilding);

            // show the dialog and wait for an OK

            DialogResult result = aff.ShowDialog();

            // if answer was OK update the product inventory with the new values and update display

            if (result != DialogResult.OK) return;

            // save the changes back to list
            UniversityPeople up = new Faculty(aff.FirstName,
                                              aff.LastName,
                                              aff.AcademicDepartment,
                                              aff.FacultyContact,
                                              "Faculty");

            peopleList[index] = up;
            allContactListBox.Items[index] = up.ToFormattedString();

        }

        private void editStudent(int index)
        {
            addStudentForm asf = new addStudentForm();
            asf.EditMode = true;

            Student s = (Student)peopleList[index];

            Console.WriteLine(s.ToString());

            // preload the objects' property value
            asf.FirstName = s.FirstName;
            asf.LastName = s.LastName;
            asf.AcademicDepartment = s.AcademicDepartment;
            asf.StudentContact = new StudentContact(s.Contact.Email, s.Contact.MailAddress);
            asf.GraduationYear = s.GraduationYear;
            asf.CourseList = s.CourseList;

            // show the dialog and wait for an OK

            DialogResult result = asf.ShowDialog();

            // if answer was OK update the product inventory with the new values and update display

            if (result != DialogResult.OK) return;

            UniversityPeople up = new Student(asf.FirstName,
                                              asf.LastName,
                                              asf.AcademicDepartment,
                                              asf.StudentContact,
                                              "Student",
                                              asf.GraduationYear,
                                              asf.CourseList);

            peopleList[index] = up;
            allContactListBox.Items[index] = up.ToFormattedString();
        }

        private void firstNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear already selected items
            allContactListBox.ClearSelected();

            // open the search form dialogue
            SearchForm sh = new SearchForm();
            sh.Title = "Enter a first name";

            DialogResult result = sh.ShowDialog();

            string fname; // to save the input first name

            // set the selection mode to accept multi line selection
            allContactListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;

            if (result == DialogResult.OK)
            {
                Console.WriteLine(sh.SearchResult);
                fname = sh.SearchResult;

                for (int i = 0; i < peopleList.Count; i++)
                {
                    if (peopleList[i].FirstName.ToLower() == fname)
                    {
                        // highlight the search results
                        allContactListBox.SetSelected(i, true);

                    }
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                throw new ArgumentException("Unknown button selected");
            }
        }

        private void lastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear already selected items
            allContactListBox.ClearSelected();

            // open the search form dialogue
            SearchForm sh = new SearchForm();
            sh.Title = "Enter a last name";

            DialogResult result = sh.ShowDialog();

            string lname; // to save the input last name

            // set the selection mode to accept multi line selection
            allContactListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;

            if (result == DialogResult.OK)
            {
                Console.WriteLine(sh.SearchResult);
                lname = sh.SearchResult;

                for (int i = 0; i < peopleList.Count; i++)
                {
                    if (peopleList[i].LastName.ToLower() == lname)
                    {
                        allContactListBox.SetSelected(i, true);

                    }
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                throw new ArgumentException("Unknown button selected");
            }
        }

        private void firstNameAndLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear already selected items
            allContactListBox.ClearSelected();

            SearchForm sh = new SearchForm();
            sh.Title = "Enter a full name";

            DialogResult result = sh.ShowDialog();

            string fname; // variable to store input first name
            string lname; // variable to store input last name

            allContactListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;

            if (result == DialogResult.OK)
            {
                Console.WriteLine(sh.SearchResult);

                // split the search input string to first name and last name
                var tokens = sh.SearchResult.Split();
                fname = tokens[0];
                lname = tokens[1];

                for (int i = 0; i < peopleList.Count; i++)
                {
                    string fullName = peopleList[i].FirstName.ToLower() +
                                      peopleList[i].LastName.ToLower();
                    if (fullName == (fname + lname))
                    {
                        allContactListBox.SetSelected(i, true);
                    }
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                throw new ArgumentException("Unknown button selected");
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pop a save as file dialogue 
            SaveFileDialog sfd = new SaveFileDialog();

            // get the filepath
            sfd.Title = "Select File to save";

            sfd.Filter = "Text Files|*.txt|All Files|*.*";
            sfd.FilterIndex = 1;

            DialogResult result = sfd.ShowDialog();

            // if the dialog is not finished, then return
            if (result != DialogResult.OK)
            {
                return;
            }
            //save the filepath variable 
            Filepath = sfd.FileName.ToString();
            try
            {
                StreamWriter output = new StreamWriter(Filepath);
                foreach (UniversityPeople up in peopleList)
                {
                    output.WriteLine(UniversityPeopleTypeString(up));
                    output.WriteLine(up.ToFileString());
                }
                //close the file
                output.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not write. {excp.Message}", "Error");
                return;
            }

            MessageBox.Show($"Contact List have been save in {Filepath}", "Save Successful");
        }

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check to see if the user selcted an item
            //before performing the delete opertaion
            int index = allContactListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("You must select an item to be deleted");
                return;
            }
            //pop confirmation dialogue that the item is about to be deleted
            UniversityPeople person = peopleList[index];

            if (DialogResult.Yes != MessageBox.Show($"Are you sure you wish to delete {person.FirstName}'s details?",
                                    "Confirmation", MessageBoxButtons.YesNo))
            {
                return;
            }
            //delete the item and remote it from the education people list
            //remove it from the listbox display as well
            peopleList.RemoveAt(index);
            allContactListBox.Items.RemoveAt(index);
            changesMade = true;
        }

        // about menu event
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This University contact management application \n" +
                            "developed by: Andy Meng \n" +
                            "For more information please Andy Meng.");
        }
    }
}
