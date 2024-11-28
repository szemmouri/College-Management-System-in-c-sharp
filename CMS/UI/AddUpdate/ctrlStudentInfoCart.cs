using CMS.Properties;
using CMSBusinessLayer;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class ctrlStudentInfoCart : UserControl
    {

        private int _StudentID = -1;
        public ctrlStudentInfoCart()
        {
            InitializeComponent();
        }
        public int StudentID { get { return _StudentID; } }

        bool _IsEnabled = true;
        public bool SearchBar { set { _IsEnabled = value; } }
        public void LoadStudentData(int StudentID)
        {
            _StudentID = StudentID;
            clsStudents student = clsStudents.Find(StudentID);

            if (student == null)
            {

                MessageBox.Show($"Student With ID: {StudentID} Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtSearchBar.Enabled = _IsEnabled;
                lblStudentID.Text = StudentID.ToString();
                lblFirstName.Text = student.FirstName;
                lblLastName.Text = student.LastName;
                lblDateOfBirth.Text = student.DateOfBirth.ToString();
                lblGender.Text = student.Gender == 0 ? "Male" : "Female";
                lblEmail.Text = student.Email;
                lblAddress.Text = student.Address;
                lblUserName.Text = student.UserInfo.UserName;
                lblFatherName.Text = student.FatherName;
                lblPhoneNumber.Text = student.PhoneNumber;
                try
                {
                    if (string.IsNullOrEmpty(student.ImagePath))
                    {
                        pbProfile.Image = student.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                    }
                    else
                    {
                        pbProfile.Image = Image.FromFile(student.ImagePath);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                    pbProfile.Image = student.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }

            }
        }

        private void txtUserIDToFind_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearchBar.Text))
                 return; 

            int StudentID = -1;
            if (int.TryParse(txtSearchBar.Text, out int parsedID))
            {
                StudentID = parsedID;
                LoadStudentData(StudentID);
            }
            else
                MessageBox.Show($"Please Enter a Valid Student Number", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
