using CMS.Classes;
using CMS.Properties;
using CMSBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class frmAddUpdateTeachers : Form
    {

        private int _TeacherID = -1;
        private clsTeachers _Teacher;

        public frmAddUpdateTeachers()
        {
            InitializeComponent();
            Mode = enMode.AddNwe;
        }

        public frmAddUpdateTeachers(int TeacherID)
        {
            InitializeComponent();
            _TeacherID = TeacherID;
            Mode = enMode.Update;
        }

        enum enMode { AddNwe = 0, Update = 1 }
        enMode Mode;

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

        private void _FillDepartmentsBox()
        {
            DataTable dt = new DataTable();

            dt = clsDepartments.GetAllDepartments();

            cbDepartment.DataSource = dt;
            cbDepartment.DisplayMember = "DepartmentName";

        }
        private void _ResetDefaultValues()
        {


            if (Mode == enMode.AddNwe)
            {
                lblTitle.Text = "Add New Teacher";
                this.Text = "Add New Teacher";
                _Teacher = new clsTeachers();
            }
            else
            {
                lblTitle.Text = "Update Teacher";
                this.Text = "Update Teacher";

            }

            //set default image for the person.
            if (rbMale.Checked)
                pbProfile.Image = Resources.Male_512;
            else
                pbProfile.Image = Resources.Female_512;

            //hide/show the remove link incase there is no image for the person.
            llRemoveImage.Visible = (pbProfile.ImageLocation != null);


            DateOfBirth.MaxDate = DateTime.Now;
            DateOfBirth.Value = DateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            DateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtFirstName.Text = "";
            txtLastName.Text = "";
            rbMale.Checked = true;
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtSalary.Text = "";
            cbDepartment.SelectedIndex = 0;


        }

        private void _LoadData()
        {
            _Teacher = clsTeachers.Find(_TeacherID);

            if (_Teacher == null)
            {

                return;
            }
            else
            {
                lblTeacherID.Text = _Teacher.TeacherID.ToString();
                txtFirstName.Text = _Teacher.FirstName;
                txtLastName.Text = _Teacher.LastName;
                rbMale.Checked = _Teacher.Gender == 0;
                rbFemale.Checked = _Teacher.Gender == 1;
                DateOfBirth.Value = _Teacher.DateOfBirth;
                txtEmail.Text = _Teacher.Email;
                txtPhoneNumber.Text = _Teacher.PhoneNumber;
                txtAddress.Text = _Teacher.Address;
                //load person image incase it was set.
                try
                {
                    if (string.IsNullOrEmpty(_Teacher.ImagePath))
                    {
                        pbProfile.Image = _Teacher.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                    }
                    else
                    {
                        pbProfile.Image = Image.FromFile(_Teacher.ImagePath);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                    pbProfile.Image = _Teacher.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }

                //hide/show the remove link incase there is no image for the person.
                llRemoveImage.Visible = (_Teacher.ImagePath != "");


                txtUserName.Text = _Teacher.UserInfo.UserName;
                txtPassword.Text = _Teacher.UserInfo.Password;
                txtSalary.Text = _Teacher.Salary.ToString();
                cbDepartment.SelectedIndex = cbDepartment.FindString(_Teacher.DepartmentInfo.DepartmentName);

            }
        }

        private void frmAddUpdateTeachers_Load(object sender, EventArgs e)
        {
            _FillDepartmentsBox();
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


            _Teacher.FirstName = txtFirstName.Text.Trim();
            _Teacher.LastName = txtLastName.Text.Trim();
            _Teacher.Gender = rbMale.Checked ? (byte)0 : (byte)1;
            _Teacher.DateOfBirth = DateOfBirth.Value;
            _Teacher.Email = txtEmail.Text.Trim();
            _Teacher.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Teacher.Address = txtAddress.Text.Trim();
            _Teacher.ImagePath = pbProfile.ImageLocation;
            if (pbProfile.ImageLocation != null)
                _Teacher.ImagePath = pbProfile.ImageLocation;
            else
                _Teacher.ImagePath = "";


            _Teacher.UserInfo.UserName = txtUserName.Text.Trim();
            _Teacher.UserInfo.Password = txtPassword.Text.Trim();
            _Teacher.Salary = Convert.ToDecimal(txtSalary.Text.Trim());
            _Teacher.DepartmentID = clsDepartments.Find(cbDepartment.Text).DepartmentID;

            if (_Teacher.Save())
            {

                //change form mode to update.
                Mode = enMode.Update;
                lblTitle.Text = "Update Teacher";
                lblTeacherID.Text = _Teacher.TeacherID.ToString();

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
            if (_Teacher.ImagePath != pbProfile.ImageLocation)
            {
                if (_Teacher.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Teacher.ImagePath);
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
            if (!userName.Equals(_Teacher.UserInfo.UserName, StringComparison.OrdinalIgnoreCase))
            {
                // Make sure the new username is not used by another Teacher
                if (clsUsers.IsUserExists(userName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used for another Teacher!");
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


        private void cbDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbDepartment.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbDepartment, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(cbDepartment, null);
            }
        }
    }
}
