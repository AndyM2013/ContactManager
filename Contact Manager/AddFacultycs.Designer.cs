namespace Contact_Manager
{
    partial class addFacultyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstNameTextLabel = new System.Windows.Forms.Label();
            this.lastNameTextLabel = new System.Windows.Forms.Label();
            this.academicDepartmentTextLabel = new System.Windows.Forms.Label();
            this.contactInformationTextLabel = new System.Windows.Forms.Label();
            this.emailAddressTextLabel = new System.Windows.Forms.Label();
            this.officeLocationBuildingTextLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.academicDepartmentTextBox = new System.Windows.Forms.TextBox();
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.officeLocationBuildingTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameTextLabel
            // 
            this.firstNameTextLabel.Location = new System.Drawing.Point(-54, 29);
            this.firstNameTextLabel.Name = "firstNameTextLabel";
            this.firstNameTextLabel.Size = new System.Drawing.Size(219, 28);
            this.firstNameTextLabel.TabIndex = 0;
            this.firstNameTextLabel.Text = "First Name:";
            this.firstNameTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastNameTextLabel
            // 
            this.lastNameTextLabel.Location = new System.Drawing.Point(-54, 57);
            this.lastNameTextLabel.Name = "lastNameTextLabel";
            this.lastNameTextLabel.Size = new System.Drawing.Size(219, 28);
            this.lastNameTextLabel.TabIndex = 0;
            this.lastNameTextLabel.Text = "Last Name:";
            this.lastNameTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // academicDepartmentTextLabel
            // 
            this.academicDepartmentTextLabel.Location = new System.Drawing.Point(-54, 85);
            this.academicDepartmentTextLabel.Name = "academicDepartmentTextLabel";
            this.academicDepartmentTextLabel.Size = new System.Drawing.Size(219, 28);
            this.academicDepartmentTextLabel.TabIndex = 0;
            this.academicDepartmentTextLabel.Text = "Academic Department:";
            this.academicDepartmentTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contactInformationTextLabel
            // 
            this.contactInformationTextLabel.Location = new System.Drawing.Point(-54, 113);
            this.contactInformationTextLabel.Name = "contactInformationTextLabel";
            this.contactInformationTextLabel.Size = new System.Drawing.Size(219, 28);
            this.contactInformationTextLabel.TabIndex = 0;
            this.contactInformationTextLabel.Text = "Contact Information:";
            this.contactInformationTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emailAddressTextLabel
            // 
            this.emailAddressTextLabel.Location = new System.Drawing.Point(-54, 141);
            this.emailAddressTextLabel.Name = "emailAddressTextLabel";
            this.emailAddressTextLabel.Size = new System.Drawing.Size(219, 28);
            this.emailAddressTextLabel.TabIndex = 0;
            this.emailAddressTextLabel.Text = "Email Address:";
            this.emailAddressTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // officeLocationBuildingTextLabel
            // 
            this.officeLocationBuildingTextLabel.Location = new System.Drawing.Point(-54, 169);
            this.officeLocationBuildingTextLabel.Name = "officeLocationBuildingTextLabel";
            this.officeLocationBuildingTextLabel.Size = new System.Drawing.Size(219, 28);
            this.officeLocationBuildingTextLabel.TabIndex = 0;
            this.officeLocationBuildingTextLabel.Text = "Office Location Building:";
            this.officeLocationBuildingTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(172, 36);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(247, 20);
            this.firstNameTextBox.TabIndex = 1;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.FirstNameTextBox_TextChanged);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(171, 65);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(247, 20);
            this.lastNameTextBox.TabIndex = 2;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.LastNameTextBox_TextChanged);
            // 
            // academicDepartmentTextBox
            // 
            this.academicDepartmentTextBox.Location = new System.Drawing.Point(171, 93);
            this.academicDepartmentTextBox.Name = "academicDepartmentTextBox";
            this.academicDepartmentTextBox.Size = new System.Drawing.Size(247, 20);
            this.academicDepartmentTextBox.TabIndex = 3;
            this.academicDepartmentTextBox.TextChanged += new System.EventHandler(this.AcademicDepartmentTextBox_TextChanged);
            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.Location = new System.Drawing.Point(171, 149);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new System.Drawing.Size(247, 20);
            this.emailAddressTextBox.TabIndex = 4;
            this.emailAddressTextBox.TextChanged += new System.EventHandler(this.EmailAddressTextBox_TextChanged);
            // 
            // officeLocationBuildingTextBox
            // 
            this.officeLocationBuildingTextBox.Location = new System.Drawing.Point(171, 177);
            this.officeLocationBuildingTextBox.Name = "officeLocationBuildingTextBox";
            this.officeLocationBuildingTextBox.Size = new System.Drawing.Size(247, 20);
            this.officeLocationBuildingTextBox.TabIndex = 5;
            this.officeLocationBuildingTextBox.TextChanged += new System.EventHandler(this.OfficeLocationBuildingTextBox_TextChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(300, 229);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(381, 229);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // addFacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 285);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.officeLocationBuildingTextBox);
            this.Controls.Add(this.emailAddressTextBox);
            this.Controls.Add(this.academicDepartmentTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.officeLocationBuildingTextLabel);
            this.Controls.Add(this.emailAddressTextLabel);
            this.Controls.Add(this.contactInformationTextLabel);
            this.Controls.Add(this.academicDepartmentTextLabel);
            this.Controls.Add(this.lastNameTextLabel);
            this.Controls.Add(this.firstNameTextLabel);
            this.Name = "addFacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Faculty";
            this.Load += new System.EventHandler(this.addFacultyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameTextLabel;
        private System.Windows.Forms.Label lastNameTextLabel;
        private System.Windows.Forms.Label academicDepartmentTextLabel;
        private System.Windows.Forms.Label contactInformationTextLabel;
        private System.Windows.Forms.Label emailAddressTextLabel;
        private System.Windows.Forms.Label officeLocationBuildingTextLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox academicDepartmentTextBox;
        private System.Windows.Forms.TextBox emailAddressTextBox;
        private System.Windows.Forms.TextBox officeLocationBuildingTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}