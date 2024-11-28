using CMS.Classes;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlTeachers : UserControl
    {
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

                btnAddTeacher.Visible = _Visible;
            }
        }
        private DataTable _AllTeachersData = new DataTable();
        public ctrlTeachers()
        {
            InitializeComponent();
            _LoadTeachersData();
        }

        private void _LoadTeachersData()
        {
            _AllTeachersData = clsTeachers.GetAllTeachers();

            dgvTeachers.DataSource = _AllTeachersData;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = ""; 
            


            switch (cbFillterby.Text)
            {
                case "Teacher ID":
                    FilterColumn = "TeacherID";
                    break;

                case "Teacher Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if(cbFillterby.Text.Trim() == "" || cbFillterby.Text == "None")
            {
                _AllTeachersData.DefaultView.RowFilter = "";
                return;
            }
            if (FilterColumn == "TeacherID" && clsValidation.IsNumber(txtFilterValue.Text))
                //in this case we deal with integer not string.

                _AllTeachersData.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            if (FilterColumn == "FirstName")
                _AllTeachersData.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            frmAddUpdateTeachers frm = new frmAddUpdateTeachers();
            frm.ShowDialog();
            _LoadTeachersData();
        }

        private void addNewTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddTeacher_Click(sender, e);
        }

        private void updateTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmAddUpdateTeachers frm = new frmAddUpdateTeachers((int)dgvTeachers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadTeachersData();
        }

        private void delTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shore you want to Delete Teacher? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvTeachers.Rows.Count > 0)
                {
                    int TeacherID = (int)dgvTeachers.CurrentRow.Cells[0].Value;
                    if (clsTeachers.DeleteTeacher(TeacherID))
                    {
                        MessageBox.Show($"The Teacher with ID: {TeacherID} Deleted Successfully", "Student Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The Teacher with ID: {TeacherID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Teacher Not Fund", "Not Fund");
                }
            }

            _LoadTeachersData();
        }
    }
}
