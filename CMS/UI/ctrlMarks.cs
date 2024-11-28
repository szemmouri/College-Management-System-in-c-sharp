using CMS.Classes;
using CMS.UI.AddUpdate;
using CMSBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;


namespace CMS.UI
{
    public partial class ctrlMarks : UserControl
    {
        DataTable _AllMarksData = new DataTable();
        public ctrlMarks()
        {
            InitializeComponent();
            _LoadMarks();
        }

        private void _LoadMarks()
        {
            _AllMarksData = clsMarks.GetAllMarks();
            dgvMarks.DataSource = _AllMarksData;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFillterby.Text)
            {
                case "Mark ID":
                    FilterColumn = "MarkID";
                    break;

                case "Student Name":
                    FilterColumn = "StudentName";
                    break;

                case "Subject Name":
                    FilterColumn = "SubjectName";
                    break;

                case "Mark":
                    FilterColumn = "Mark";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllMarksData.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "MarkID" || FilterColumn == "Mark" && clsValidation.IsNumber(txtFilterValue.Text))
                //in this case we deal with integer not string.

                _AllMarksData.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            if (FilterColumn == "StudentName" || FilterColumn == "SubjectName")
                _AllMarksData.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            frmAddUpdateMark frm = new frmAddUpdateMark();
            frm.ShowDialog();
            _LoadMarks();
        }

        private void addNewMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddMark_Click(sender, e);
        }

        private void updateMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateMark frm = new frmAddUpdateMark((int)dgvMarks.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadMarks();
        }

        private void deleteMark_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MarkID = (int)dgvMarks.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you shore you want to Delete Mark? ", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dgvMarks.Rows.Count > 0)
                {

                    if (clsMarks.DeleteMark(MarkID))
                    {
                        MessageBox.Show($"The Mark with ID: {MarkID} Deleted Successfully", "Mark Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"The Mark with ID: {MarkID} Not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show($"Mark with ID: {MarkID} Not Fund", "Not Fund");
                }
            }

        }
    }
}
