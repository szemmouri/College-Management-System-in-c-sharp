using CMS.Classes;
using CMS.Properties;
using CMSBusinessLayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class frmAddUpdateAdmin : Form
    {
        private int _AdminID = -1;
        private clsAdmins _Admin;

        enum enMode { AddNwe = 0, Update = 1 }
        enMode Mode;
        public frmAddUpdateAdmin()
        {
            InitializeComponent();
            Mode = enMode.AddNwe;

        }
        public frmAddUpdateAdmin(int AdminID)
        {
            InitializeComponent();
            _AdminID = AdminID;
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

        private void frmAddUpdateAdmin_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.Update)
                _LoadData();
        }

        private void _ResetDefaultValues()
        {


            if (Mode == enMode.AddNwe)
            {
                lblTitle.Text = "Add New Admin";
                this.Text = "Add New Admin";
                _Admin = new clsAdmins();
            }
            else
            {
                lblTitle.Text = "Update Admin";
                this.Text = "Update Admin";

            }

            //set default image for the person.

             rbMale.Checked = true;
             pbProfile.Image = Resources.Male_512;

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (pbProfile.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-14);
            DateOfBirth.Value = DateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            DateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtLastName.Text = "";
            rbMale.Checked = true;
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";


        }

        private void _LoadData()
        {
            _Admin = clsAdmins.Find(_AdminID);

            if (_Admin == null)
            {

                return;
            }
            else
            {
                lblAdminID.Text = _Admin.AdminID.ToString();
                txtFirstName.Text = _Admin.FirstName;
                txtLastName.Text = _Admin.LastName;
                rbMale.Checked = _Admin.Gender == 0;
                rbFemale.Checked = _Admin.Gender == 1;
                DateOfBirth.Value = _Admin.DateOfBirth;
                txtEmail.Text = _Admin.Email;
                txtPhoneNumber.Text = _Admin.PhoneNumber;
                txtAddress.Text = _Admin.Address;
                //load person image incase it was set.
                try
                {
                    if (string.IsNullOrEmpty(_Admin.ImagePath))
                    {
                        pbProfile.Image = _Admin.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                    }
                    else
                    {
                        pbProfile.Image = Image.FromFile(_Admin.ImagePath);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                    pbProfile.Image = _Admin.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }

                //hide/show the remove linke incase there is no image for the person.
                llRemoveImage.Visible = (_Admin.ImagePath != "");


                txtUserName.Text = _Admin.UserInfo.UserName;
                txtPassword.Text = _Admin.UserInfo.Password;

            }
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


            _Admin.FirstName = txtFirstName.Text.Trim();
            _Admin.LastName = txtLastName.Text.Trim();
            _Admin.Gender = rbMale.Checked ? (byte)0 : (byte)1;
            _Admin.DateOfBirth = DateOfBirth.Value;
            _Admin.Email = txtEmail.Text.Trim();
            _Admin.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Admin.Address = txtAddress.Text.Trim();
            _Admin.ImagePath = pbProfile.ImageLocation;
            if (pbProfile.ImageLocation != null)
                _Admin.ImagePath = pbProfile.ImageLocation;
            else
                _Admin.ImagePath = "";


            _Admin.UserInfo.UserName = txtUserName.Text.Trim();
            _Admin.UserInfo.Password = txtPassword.Text.Trim();

            if (_Admin.Save())
            {

                //change form mode to update.
                Mode = enMode.Update;
                lblTitle.Text = "Update Admin";
                lblAdminID.Text = _Admin.AdminID.ToString();

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
            if (_Admin.ImagePath != pbProfile.ImageLocation)
            {
                if (_Admin.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Admin.ImagePath);
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
            if (!userName.Equals(_Admin.UserInfo.UserName, StringComparison.OrdinalIgnoreCase))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pbProfile.Image = Resources.Male_512;
            else
                pbProfile.Image = Resources.Female_512;
        }
    }
}
