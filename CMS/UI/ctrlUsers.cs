using CMS.Classes;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CMS.UI
{
    public partial class ctrlUsers : UserControl
    {
        DataTable _AllUsersData;

        //permissions
        private bool _Visible = false;
        public bool Visibility
        {
            set
            {
                _Visible = value;
                contextMenuStrip1.Visible = _Visible;
                if (_Visible == false)
                    contextMenuStrip1.Items.Clear();

            }
        }

        public ctrlUsers()
        {
            InitializeComponent();
            _LoadUsersData();
        }

        private void _LoadUsersData()
        {
            _AllUsersData = clsUsers.GetAllUsers();
            dgvUsers.DataSource = _AllUsersData;

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFillterby.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Role Name":
                    FilterColumn = "RoleName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllUsersData.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "UserID" && clsValidation.IsNumber(txtFilterValue.Text))
                //in this case we deal with integer not string.

                _AllUsersData.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            if((FilterColumn == "RoleName" || FilterColumn == "UserName" || FilterColumn == "FullName"))
                _AllUsersData.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }
        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUsers frm = new frmUpdateUsers((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadUsersData();
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shore you want to Delete User? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvUsers.Rows.Count > 0)
                {
                    int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
                    if (clsUsers.DeleteUser(UserID))
                    {
                        MessageBox.Show($"The User with ID: {UserID} Deleted Successfully", "User Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The User with ID: {UserID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("User Not Fund", "Not Fund");
                }
            }
        }

    }
}
