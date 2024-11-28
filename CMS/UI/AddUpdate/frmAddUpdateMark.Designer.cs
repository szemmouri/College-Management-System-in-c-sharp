namespace CMS.UI.AddUpdate
{
    partial class frmAddUpdateMark
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSubjectName = new System.Windows.Forms.ComboBox();
            this.lblMarkID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ljljkj = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlStudentInfoCart1 = new CMS.UI.AddUpdate.ctrlStudentInfoCart();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.cbSubjectName);
            this.groupBox2.Controls.Add(this.lblMarkID);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtMark);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ljljkj);
            this.groupBox2.Location = new System.Drawing.Point(34, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1135, 115);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mark Info";
            // 
            // cbSubjectName
            // 
            this.cbSubjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjectName.FormattingEnabled = true;
            this.cbSubjectName.Location = new System.Drawing.Point(243, 61);
            this.cbSubjectName.Name = "cbSubjectName";
            this.cbSubjectName.Size = new System.Drawing.Size(264, 27);
            this.cbSubjectName.TabIndex = 141;
            this.cbSubjectName.Validating += new System.ComponentModel.CancelEventHandler(this.cbSubjectName_Validating);
            // 
            // lblMarkID
            // 
            this.lblMarkID.AutoSize = true;
            this.lblMarkID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMarkID.Location = new System.Drawing.Point(239, 23);
            this.lblMarkID.Name = "lblMarkID";
            this.lblMarkID.Size = new System.Drawing.Size(57, 19);
            this.lblMarkID.TabIndex = 140;
            this.lblMarkID.Text = "??????";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.Location = new System.Drawing.Point(155, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 19);
            this.label12.TabIndex = 139;
            this.label12.Text = "Mark ID:";
            // 
            // txtMark
            // 
            this.txtMark.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMark.Location = new System.Drawing.Point(783, 61);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(301, 27);
            this.txtMark.TabIndex = 137;
            this.txtMark.Validating += new System.ComponentModel.CancelEventHandler(this.txtMark_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(703, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 138;
            this.label9.Text = "Mark:";
            // 
            // ljljkj
            // 
            this.ljljkj.AutoSize = true;
            this.ljljkj.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ljljkj.Location = new System.Drawing.Point(113, 64);
            this.ljljkj.Name = "ljljkj";
            this.ljljkj.Size = new System.Drawing.Size(113, 19);
            this.ljljkj.TabIndex = 136;
            this.ljljkj.Text = "Subject Name:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::CMS.Properties.Resources.Prev_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(34, 591);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 41);
            this.btnClose.TabIndex = 142;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Image = global::CMS.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1027, 591);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 41);
            this.btnSave.TabIndex = 141;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 138);
            this.panel1.TabIndex = 140;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.cources;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(573, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(451, 62);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 48);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Add New Mark";
            // 
            // ctrlStudentInfoCart1
            // 
            this.ctrlStudentInfoCart1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ctrlStudentInfoCart1.BackColor = System.Drawing.Color.White;
            this.ctrlStudentInfoCart1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ctrlStudentInfoCart1.Location = new System.Drawing.Point(22, 145);
            this.ctrlStudentInfoCart1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlStudentInfoCart1.Name = "ctrlStudentInfoCart1";
            this.ctrlStudentInfoCart1.Size = new System.Drawing.Size(1147, 316);
            this.ctrlStudentInfoCart1.TabIndex = 144;
            // 
            // frmAddUpdateMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 646);
            this.Controls.Add(this.ctrlStudentInfoCart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddUpdateMark";
            this.Text = "Add/Update Mark";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddUpdateMark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlStudentInfoCart ctrlStudentInfoCart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbSubjectName;
        private System.Windows.Forms.Label lblMarkID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ljljkj;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
    }
}