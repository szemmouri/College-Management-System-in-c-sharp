using CMS.Properties;
using CMSBusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace CMS.UI.AddUpdate
{
    public partial class frmAddUpdateSubjects : Form
    {
        private clsSubject subject;
        private int subjectID = -1;

        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        public frmAddUpdateSubjects()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateSubjects(int SubjectID)
        {
            InitializeComponent();
            subjectID = SubjectID;
            _Mode = enMode.Update;
        }

        private void _FillDepartmentsBox()
        {
            DataTable dt = new DataTable();

            dt = clsDepartments.GetAllDepartments();

            cbDepartments.DataSource = dt;
            cbDepartments.DisplayMember = "DepartmentName";

        }
        private void _ResetDefaultValues()
        {


            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Subject";
                this.Text = "Add New Subject";
                subject = new clsSubject();
            }
            else
            {
                lblTitle.Text = "Update Subject";
                this.Text = "Update Subject";

            }

            txtSubjectName.Text ="";
            cbDepartments.SelectedIndex = 1;
            txtLevel.Text = ""  ;
            txtDescription.Text = "";
            txtPrerequisites.Text = "";
            cbSemesterOffered.SelectedIndex = 1;

        }
        private void _LoadData()
        {
            subject = clsSubject.Find(subjectID);

            if (subject != null) {

                lblSubjectID.Text = subject.SubjectID.ToString();
                txtSubjectName.Text = subject.SubjectName;
                cbDepartments.SelectedIndex = cbDepartments.FindString(subject.DepartmentInfo.DepartmentName); 
                txtLevel.Text = subject.Level;
                txtDescription.Text = subject.Description;
                txtPrerequisites.Text = subject.Prerequisites;
                cbSemesterOffered.Text = subject.SemesterOffered;
            }
            else
            {
                MessageBox.Show($"Subject with ID: {subjectID} not Found! ", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAddUpdateSubjects_Load(object sender, EventArgs e)
        {
            _FillDepartmentsBox();
            _ResetDefaultValues();


            if (_Mode == enMode.Update)
                _LoadData();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            subject.SubjectName = txtSubjectName.Text;
            subject.DepartmentID =clsDepartments.Find(cbDepartments.Text).DepartmentID;
            subject.Level = txtLevel.Text;
            subject.Prerequisites = txtPrerequisites.Text;
            subject.Description = txtDescription.Text;
            subject.SemesterOffered = cbSemesterOffered.Text;

            if (subject.Save())
            {
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Subject";
                lblSubjectID.Text = subject.SubjectID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cbPrerequisites_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbSemesterOffered.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbSemesterOffered, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(cbSemesterOffered, null);
            }
        }
    }
}
