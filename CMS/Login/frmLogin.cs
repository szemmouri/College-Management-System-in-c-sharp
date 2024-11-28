using CMS.Classes;
using CMSBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CMS.Login
{
    public partial class frmLogin : Form
    {
        private clsUsers user;
        private int RoleID = 0;

        private enum enLoginAs { Student = 1, Teacher = 2, Admin = 3 }
        private enLoginAs LoginAs = enLoginAs.Admin;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "", strRoleID = "";

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password, ref strRoleID))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;

                int roleID = Convert.ToInt32(strRoleID);
                switch (roleID)
                {
                    case 1:
                        btStudent_Click(sender, e);
                        break;

                    case 2:
                        btnTeacher_Click(sender, e);
                        break;

                    case 3:
                        btnAdmin_Click(sender, e);
                        break;
                }

            }
            else
            {
                btnAdmin_Click(sender, e);
                chkRememberMe.Checked = false;

            }
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginAs = enLoginAs.Admin;
            SetButtonStyles(btnAdmin, btnTeacher, btnStudent);
        }
        private void btnTeacher_Click(object sender, EventArgs e)
        {
            LoginAs = enLoginAs.Teacher;
            SetButtonStyles(btnTeacher, btnAdmin, btnStudent);
        }
        private void btStudent_Click(object sender, EventArgs e)
        {
            LoginAs = enLoginAs.Student;
            SetButtonStyles(btnStudent, btnAdmin, btnTeacher);

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            switch (LoginAs)
            {

                case enLoginAs.Admin:
                    user = clsUsers.FindUserByUserNameAndPassword(username, password, (int)enLoginAs.Admin);
                    RoleID = (int)enLoginAs.Admin;
                    break;

                case enLoginAs.Teacher:
                    user = clsUsers.FindUserByUserNameAndPassword(username, password, (int)enLoginAs.Teacher);
                    RoleID = (int)enLoginAs.Teacher;
                    break;

                case enLoginAs.Student:
                    user = clsUsers.FindUserByUserNameAndPassword(username, password, (int)enLoginAs.Student);
                    RoleID = (int)enLoginAs.Student;
                    break;
            }

            if (user != null)
            {
                string strRoleID = RoleID.ToString();
                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPasswordInRegistry(username, password, strRoleID);

                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPasswordInRegistry("", "", "");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUsername.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    clsGlobal.RoleID = RoleID;
                    clsGlobal.CurrentUser = user;
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    this.Close();

                }
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetButtonStyles(Button activeButton, params Button[] inactiveButtons)
        {
            activeButton.BackColor = Color.Turquoise;
            activeButton.FlatAppearance.BorderColor = Color.DodgerBlue;
            activeButton.FlatAppearance.BorderSize = 2;

            foreach (var button in inactiveButtons)
            {
                button.BackColor = Color.Transparent;
                button.FlatAppearance.BorderColor = Color.White;
                button.FlatAppearance.BorderSize = 1;
            }
        }

    }
}
