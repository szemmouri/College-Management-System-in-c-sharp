using CMSBusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class frmUpdateUsers : Form
    {
        private clsUsers _User;
        private int _UserID = -1;
    
      
        public frmUpdateUsers(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {

            lblTitle.Text = "Update User";
            this.Text = "Update User";
            txtUserName.Text = "";
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtVerifyNewPassword.Text = "";
        }
        private void _LoadUserData()
        {
            _User = clsUsers.Find(_UserID);

            if (_User != null) {

                lblUserID.Text = _User.UserID.ToString();
                txtUserName.Text = _User.UserName;
                txtCurrentPassword.Text = _User.Password;
            }else
                MessageBox.Show($"User with ID: {_User} Not Found", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void frmAddUpdateUsers_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadUserData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (!userName.Equals(_User.UserName, StringComparison.OrdinalIgnoreCase))
            {
                // Make sure the new username is not used by another person
                if (clsUsers.IsUserExists(userName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used for another Person!");
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
        private void txtVerifyNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVerifyNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVerifyNewPassword, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtVerifyNewPassword, null);
            }
            
            if(txtVerifyNewPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVerifyNewPassword, "Please Verify Password, it not the same!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtVerifyNewPassword, null);
            }
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtVerifyNewPassword.Text.Trim();

            if (_User.Save())
            {

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
    }
}
