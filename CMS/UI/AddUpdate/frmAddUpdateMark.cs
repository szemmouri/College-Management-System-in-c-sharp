using CMSBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.UI.AddUpdate
{
    public partial class frmAddUpdateMark : Form
    {
        private clsMarks Mark;
        private int _MarkID = -1;
        public frmAddUpdateMark()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateMark(int MarkID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _MarkID = MarkID;

        }

        private enum enMode { AddNew = 0, Update =1 };
        private enMode _Mode;

        private void _ResetDefaultValues()
        {


            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Mark";
                this.Text = "Add New Mark";
                Mark = new clsMarks();

            }
            else
            {
                lblTitle.Text = "Update Mark";
                this.Text = "Update Mark";

            }

            txtMark.Text = "";
            cbSubjectName.SelectedIndex = 0;
        }
        private void _FillSubjectBox()
        {
            DataTable dt = new DataTable();
            dt = clsSubject.GetAllSubjects();

            cbSubjectName.DataSource = dt;
            cbSubjectName.DisplayMember = "SubjectName";
        }
        private void _LoadData()
        {
            Mark = clsMarks.Find(_MarkID);

            if (Mark == null)
                MessageBox.Show("");
            else
            {
                ctrlStudentInfoCart1.SearchBar = false;
                ctrlStudentInfoCart1.LoadStudentData(Mark.StudentID);


                lblMarkID.Text = _MarkID.ToString();
                txtMark.Text = Mark.Mark.ToString();
                cbSubjectName.SelectedIndex = cbSubjectName.FindString(Mark.SubjectInfo.SubjectName);
            }
        
        }
        private void frmAddUpdateMark_Load(object sender, EventArgs e)
        {
            _FillSubjectBox();
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ctrlStudentInfoCart1.StudentID == -1 || string.IsNullOrEmpty(ctrlStudentInfoCart1.StudentID.ToString()))
            {
                MessageBox.Show("Please Find A Student.", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Mark.SubjectID = clsSubject.Find(cbSubjectName.Text).SubjectID;
            Mark.StudentID = ctrlStudentInfoCart1.StudentID;
            Mark.Mark = Convert.ToDecimal(txtMark.Text);

            if (Mark.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Mark";
                this.Text = "Update Mark";
                lblMarkID.Text = Mark.MarkID.ToString();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else           
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void cbSubjectName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbSubjectName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbSubjectName, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(cbSubjectName, null);
            }
        }

        private void txtMark_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMark.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMark, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtMark, null);
            }
        }
    }
}
