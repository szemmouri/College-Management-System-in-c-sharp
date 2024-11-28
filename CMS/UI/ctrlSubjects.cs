using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlSubjects : UserControl
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

                btnAddSubject.Visible = _Visible;
            }
        }
        private DataTable _AllSubjectData;
        public ctrlSubjects()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _AllSubjectData = clsSubject.GetAllSubjects();
            dgvSubjects.DataSource = _AllSubjectData;
        }
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            frmAddUpdateSubjects frm = new frmAddUpdateSubjects();
            frm.ShowDialog();
            LoadData();
        }

        private void addNewSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateSubjects frm = new frmAddUpdateSubjects();
            frm.ShowDialog();
            LoadData();
        }

        private void updateSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateSubjects frm = new frmAddUpdateSubjects((int)dgvSubjects.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            LoadData();
        }

        private void deleteSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SubjectID = (int)dgvSubjects.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you shore you want to Delete Subject? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvSubjects.Rows.Count > 0)
                {
                    
                    if (clsSubject.DeleteSubject(SubjectID))
                    {
                        MessageBox.Show($"The Subject with ID: {SubjectID} Deleted Successfully", "Student Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The Subject with ID: {SubjectID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show($"Subject with ID: {SubjectID} Not Fund", "Not Fund");
                }
            }

        }
    }
}
