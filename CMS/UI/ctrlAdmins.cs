using CMS.Classes;
using CMS.Properties;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlAdmins : UserControl
    {
        private clsAdmins _Admin;
        public ctrlAdmins()
        {
            InitializeComponent();
            _LoadData();
        }
        private void _LoadData()
        {
            int UserID = clsGlobal.CurrentUser.UserID;
            clsAdmins admin = clsAdmins.FindByUserID(UserID);

            if (admin != null) {

                _Admin = admin;
                lblAdminID.Text = admin.AdminID.ToString();
                lblFirstName.Text = admin.FirstName;
                lblLastName.Text = admin.LastName;
                lblDateOfBirth.Text = admin.DateOfBirth.ToString("dd/MM/yyyy");
                lblGender.Text = admin.Gender == 0 ? "Male" : "Female";
                lblAddress.Text = admin.Address;
                lblUserName.Text = admin.UserInfo.UserName;
                lblPhoneNumber.Text = admin.PhoneNumber;
                lblEmail.Text = admin.Email;

                try
                {
                    if (string.IsNullOrEmpty(admin.ImagePath))
                    {
                        pbProfile.Image = admin.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                    }
                    else
                    {
                        pbProfile.Image = Image.FromFile(admin.ImagePath);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                    pbProfile.Image = admin.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }

            }
        }
        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            frmAddUpdateAdmin frm = new frmAddUpdateAdmin();
            frm.ShowDialog();
            _LoadData();
        }
        private void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            frmAddUpdateAdmin frm = new frmAddUpdateAdmin(_Admin.AdminID);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
