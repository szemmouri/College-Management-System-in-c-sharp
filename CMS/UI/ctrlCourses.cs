using CMS.Classes;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlCourses : UserControl
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

                btnAddCourse.Visible = _Visible;
            }
        }

        private DataTable _AllCourses;

        public ctrlCourses()
        {
            InitializeComponent();
            LoadCoursesList(); // Load data
        }

        public void LoadCoursesList()
        {
            _AllCourses = clsCourses.GetAllCourses();

            dgvCourses.DataSource = _AllCourses;
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            frmAddUpdateCourse frm = new frmAddUpdateCourse();
            frm.ShowDialog();
            // refresh data
            LoadCoursesList();
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCourse frm = new frmAddUpdateCourse();
            frm.ShowDialog();
            LoadCoursesList();
        }

        private void updateCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCourse frm = new frmAddUpdateCourse((int)dgvCourses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            LoadCoursesList();
        }

        private void deleteCourse_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shore you want to Delete this Course? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvCourses.Rows.Count > 0)
                {
                    int CourseID = (int)dgvCourses.CurrentRow.Cells[0].Value;
                    if (clsCourses.DeleteCourse(CourseID))
                    {
                        MessageBox.Show($"The Course with ID: {CourseID} Deleted Successfully", "Course Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The Course with ID: {CourseID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("the Course Not Fund", "Not Fund");
                }
            }

            LoadCoursesList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
     
            string FilterColumn = "";

            // Get the selected filter column
            switch (cbFillterby.Text)
            {
                case "Course ID":
                    FilterColumn = "CourseID";
                    break;

                case "Course Name":
                    FilterColumn = "CourseName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllCourses.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "CourseID" && clsValidation.IsNumber(txtFilterValue.Text))
                //in this case we deal with integer not string.

                _AllCourses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            if(FilterColumn == "CourseName")
                _AllCourses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

    }
}
