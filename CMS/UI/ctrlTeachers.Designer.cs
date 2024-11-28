namespace CMS.UI
{
    partial class ctrlTeachers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.addNewTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFillterby = new System.Windows.Forms.ComboBox();
            this.lblF = new System.Windows.Forms.Label();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.cbFillterby);
            this.panel1.Controls.Add(this.txtFilterValue);
            this.panel1.Controls.Add(this.btnAddTeacher);
            this.panel1.Controls.Add(this.lblF);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 197);
            this.panel1.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(258, 54);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(265, 48);
            this.lblWelcome.TabIndex = 14;
            this.lblWelcome.Text = "All Teachers";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTeacherToolStripMenuItem,
            this.updateTeacherToolStripMenuItem,
            this.delTeacherToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(210, 118);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddTeacher.BackColor = System.Drawing.Color.White;
            this.btnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTeacher.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTeacher.Image = global::CMS.Properties.Resources.plus;
            this.btnAddTeacher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTeacher.Location = new System.Drawing.Point(654, 142);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAddTeacher.Size = new System.Drawing.Size(164, 47);
            this.btnAddTeacher.TabIndex = 4;
            this.btnAddTeacher.Text = "   Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = false;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // addNewTeacherToolStripMenuItem
            // 
            this.addNewTeacherToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11F);
            this.addNewTeacherToolStripMenuItem.Image = global::CMS.Properties.Resources.plus;
            this.addNewTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewTeacherToolStripMenuItem.Name = "addNewTeacherToolStripMenuItem";
            this.addNewTeacherToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.addNewTeacherToolStripMenuItem.Text = "Add New Teacher";
            this.addNewTeacherToolStripMenuItem.Click += new System.EventHandler(this.addNewTeacherToolStripMenuItem_Click);
            // 
            // updateTeacherToolStripMenuItem
            // 
            this.updateTeacherToolStripMenuItem.Image = global::CMS.Properties.Resources.edit_32;
            this.updateTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateTeacherToolStripMenuItem.Name = "updateTeacherToolStripMenuItem";
            this.updateTeacherToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.updateTeacherToolStripMenuItem.Text = "Update Teacher";
            this.updateTeacherToolStripMenuItem.Click += new System.EventHandler(this.updateTeacherToolStripMenuItem_Click);
            // 
            // delTeacherToolStripMenuItem
            // 
            this.delTeacherToolStripMenuItem.Image = global::CMS.Properties.Resources.Delete_User_32;
            this.delTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.delTeacherToolStripMenuItem.Name = "delTeacherToolStripMenuItem";
            this.delTeacherToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.delTeacherToolStripMenuItem.Text = "Delete Teacher";
            this.delTeacherToolStripMenuItem.Click += new System.EventHandler(this.delTeacherToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.teacher;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(351, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilterValue.Location = new System.Drawing.Point(302, 153);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(218, 27);
            this.txtFilterValue.TabIndex = 19;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // cbFillterby
            // 
            this.cbFillterby.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFillterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFillterby.FormattingEnabled = true;
            this.cbFillterby.Items.AddRange(new object[] {
            "None",
            "Teacher ID",
            "Teacher Name"});
            this.cbFillterby.Location = new System.Drawing.Point(156, 153);
            this.cbFillterby.Name = "cbFillterby";
            this.cbFillterby.Size = new System.Drawing.Size(140, 27);
            this.cbFillterby.TabIndex = 20;
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.Location = new System.Drawing.Point(5, 156);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(145, 19);
            this.lblF.TabIndex = 16;
            this.lblF.Text = "Find Teacher By:";
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.AllowUserToAddRows = false;
            this.dgvTeachers.AllowUserToDeleteRows = false;
            this.dgvTeachers.AllowUserToOrderColumns = true;
            this.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeachers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeachers.Location = new System.Drawing.Point(0, 197);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.ReadOnly = true;
            this.dgvTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeachers.Size = new System.Drawing.Size(831, 484);
            this.dgvTeachers.TabIndex = 2;
            // 
            // ctrlTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTeachers);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlTeachers";
            this.Size = new System.Drawing.Size(831, 681);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delTeacherToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFillterby;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvTeachers;
    }
}
