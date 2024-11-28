using CMS.Classes;
using CMS.Properties;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMS.UI.Add
{
    public partial class frmAddUpdateStudent : Form
    {
        private int _StudentID = -1;
        private clsStudents Student;

        enum enMode{ AddNwe =0, Update = 1 }
        enMode Mode;


        public frmAddUpdateStudent()
        {
            InitializeComponent();
            Mode = enMode.AddNwe;
        }
        public frmAddUpdateStudent(int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            Mode = enMode.Update;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbProfile.Load(selectedFilePath);
                llRemoveImage.Visible = true;

            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbProfile.ImageLocation = null;



            if (rbMale.Checked)
                pbProfile.Image = Resources.Male_512;
            else
                pbProfile.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetDefaultValues()
        {


            if (Mode == enMode.AddNwe)
            {
                lblTitle.Text = "Add New Student";
                this.Text = "Add New Student";
                Student = new clsStudents();
            }
            else
            {
                lblTitle.Text = "Update Student";
                this.Text = "Update Student";

            }

            //set default image for the person.
            if (rbMale.Checked)
                pbProfile.Image = Resources.Male_512;
            else
                pbProfile.Image = Resources.Female_512;

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (pbProfile.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-14);
            DateOfBirth.Value = DateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            DateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtFaterName.Text = "";
            txtLastName.Text = "";
            rbMale.Checked = true;
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtFaterName.Text = "";
            txtMotherName.Text = "";


        }

        private void _LoadData()
        {
            Student = clsStudents.Find(_StudentID);

            if (Student == null)
            {

                return;
            }
            else
            {
                lblStudentID.Text = Student.StudentID.ToString();
                txtFirstName.Text = Student.FirstName;
                txtLastName.Text = Student.LastName;
                rbMale.Checked = Student.Gender == 0;
                rbFemale.Checked = Student.Gender == 1; 
                DateOfBirth.Value = Student.DateOfBirth;
                txtEmail.Text = Student.Email;
                txtPhoneNumber.Text = Student.PhoneNumber;
                txtAddress.Text = Student.Address;
                //load person image incase it was set.
                try
                {
                    if (string.IsNullOrEmpty(Student.ImagePath))
                    {
                        pbProfile.Image = Student.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                    }
                    else
                    {
                        pbProfile.Image = Image.FromFile(Student.ImagePath);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                    pbProfile.Image = Student.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }

                //hide/show the remove linke incase there is no image for the person.
                llRemoveImage.Visible = (Student.ImagePath != "");


                txtUserName.Text = Student.UserInfo.UserName;
                txtPassword.Text = Student.UserInfo.Password;
                txtFaterName.Text = Student.FatherName;
                txtMotherName.Text = Student.MotherName;

            }
        }

        private void frmAddUpdateStudent_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.Update)
                _LoadData();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbProfile.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbProfile.Image = Resources.Female_512;
        }

        //  Save
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;


            Student.FirstName = txtFirstName.Text.Trim();
            Student.LastName = txtLastName.Text.Trim();
            Student.Gender = rbMale.Checked ? (byte)0 : (byte)1;
            Student.DateOfBirth = DateOfBirth.Value;
            Student.Email = txtEmail.Text.Trim();
            Student.PhoneNumber = txtPhoneNumber.Text.Trim();
            Student.Address = txtAddress.Text.Trim();
            Student.ImagePath = pbProfile.ImageLocation;
            if (pbProfile.ImageLocation != null)
                Student.ImagePath = pbProfile.ImageLocation;
            else
                Student.ImagePath = "";


            Student.UserInfo.UserName = txtUserName.Text.Trim();
            Student.UserInfo.Password = txtPassword.Text.Trim();
            Student.FatherName = txtFaterName.Text.Trim();
            Student.MotherName = txtMotherName.Text.Trim();

            if (Student.Save()) {

                //change form mode to update.
                Mode = enMode.Update;
                lblTitle.Text = "Update Student";
                lblStudentID.Text = Student.StudentID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };

        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the Student image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //Student.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (Student.ImagePath != pbProfile.ImageLocation)
            {
                if (Student.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(Student.ImagePath);
                    }
                    catch (IOException)
                    {
                        throw;
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbProfile.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                     string SourceImageFile = pbProfile.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbProfile.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            // Trim the username input
            string userName = txtUserName.Text.Trim();

            // Check if the username field is empty
            if (string.IsNullOrEmpty(userName))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            // Check if the username is being changed
            if (!userName.Equals(Student.UserInfo.UserName, StringComparison.OrdinalIgnoreCase))
            {
                // Make sure the new username is not used by another student
                if (clsUsers.IsUserExists(userName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used for another student!");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {
                // If the username hasn't changed, clear any error
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Student == null)
                MessageBox.Show("Error: Please add a Student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            else
            {
                frmUpdateUsers frm = new frmUpdateUsers(Student.UserID);
                frm.ShowDialog();

            }
            frmAddUpdateStudent_Load(null, null);
        }
    }

}
