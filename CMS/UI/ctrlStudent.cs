using CMS.Classes;
using CMS.UI.Add;
using CMSBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlStudent : UserControl
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

                btnAddStudent.Visible = _Visible;
            }
        }
        public ctrlStudent()
        {
            InitializeComponent();
            LoadStudentsData();
        }

        private DataTable dtStudent = new DataTable();

        public void LoadStudentsData()
        {
            dtStudent = clsStudents.GetAllStudents();

            dgvStudent.DataSource = dtStudent;
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddUpdateStudent frm = new frmAddUpdateStudent();
            frm.ShowDialog();
            LoadStudentsData();

        }
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateStudent();
            frm.ShowDialog();
            LoadStudentsData();

        }
        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count > 0) 
            {
                int StudentID = (int)dgvStudent.CurrentRow.Cells[0].Value; // Access the value of the first cell in the current row
                frmAddUpdateStudent frm = new frmAddUpdateStudent(StudentID); 
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Student With ID Not Fund", "Not Fund");
            }
            LoadStudentsData();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFillterby.Text)
            {
                case "Student ID":
                    FilterColumn = "StudentID";
                    break;

                case "Name":
                    FilterColumn = "FirstName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dtStudent.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "StudentID" && clsValidation.IsNumber(txtFilterValue.Text))
                //in this case we deal with integer not string.

                dtStudent.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            if (FilterColumn == "FirstName")
                dtStudent.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shore you want to Delete Student? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvStudent.Rows.Count > 0)
                {
                    int StudentID = (int)dgvStudent.CurrentRow.Cells[0].Value;
                    if (clsStudents.DeleteStudent(StudentID))
                    {
                        MessageBox.Show($"The Student with ID: {StudentID} Deleted Successfully", "Student Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The Student with ID: {StudentID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Student Not Fund", "Not Fund");
                }
            }

            LoadStudentsData();
        }
    }
}