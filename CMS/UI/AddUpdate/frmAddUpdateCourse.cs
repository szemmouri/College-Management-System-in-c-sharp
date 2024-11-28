using CMSBusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class frmAddUpdateCourse : Form
    {
        private clsCourses course;
        private int CourseID = -1;
        private enum enMode { Add = 0, Update = 1 }
        enMode _Mode = enMode.Add;

        public frmAddUpdateCourse()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddUpdateCourse(int courseID)
        {
            InitializeComponent();
            CourseID = courseID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {


            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add New Course";
                this.Text = "Add New Course";
                course = new clsCourses();
            }
            else
            {
                lblTitle.Text = "Update Course";
                this.Text = "Update Course";

            }

            txtCourseName.Text = "";
            txtCourseDescription.Text = "";
        }
        private void _LoadCourseData()
        {
            course = clsCourses.Find(CourseID);

            if (course != null)
            {
                lblCourseID.Text = course.CourseID.ToString();
                txtCourseName.Text = course.CourseName;
                txtCourseDescription.Text = course.CourseDescription;
            }
            else
                MessageBox.Show($"Course with ID: {CourseID} Not Found", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void frmAddUpdateCourse_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadCourseData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            course.CourseName = txtCourseName.Text;
            course.CourseDescription = txtCourseDescription.Text;

            if (course.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Course";
                lblCourseID.Text = course.CourseID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }
    }

}
