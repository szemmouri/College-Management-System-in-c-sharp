namespace CMS.UI
{
    partial class ctrlCourses
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
            this.cbFillterby = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblF = new System.Windows.Forms.Label();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCourse_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.cbFillterby);
            this.panel1.Controls.Add(this.txtFilterValue);
            this.panel1.Controls.Add(this.lblF);
            this.panel1.Controls.Add(this.btnAddCourse);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 205);
            this.panel1.TabIndex = 1;
            // 
            // cbFillterby
            // 
            this.cbFillterby.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFillterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFillterby.FormattingEnabled = true;
            this.cbFillterby.Items.AddRange(new object[] {
            "None",
            "Course ID",
            "Course Name"});
            this.cbFillterby.Location = new System.Drawing.Point(148, 172);
            this.cbFillterby.Name = "cbFillterby";
            this.cbFillterby.Size = new System.Drawing.Size(126, 27);
            this.cbFillterby.TabIndex = 21;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilterValue.Location = new System.Drawing.Point(279, 172);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(197, 27);
            this.txtFilterValue.TabIndex = 20;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // lblF
            // 
            this.lblF.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblF.AutoSize = true;
            this.lblF.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.Location = new System.Drawing.Point(14, 175);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(135, 19);
            this.lblF.TabIndex = 19;
            this.lblF.Text = "Find Course By:";
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCourse.BackColor = System.Drawing.Color.White;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Image = global::CMS.Properties.Resources.plus;
            this.btnAddCourse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCourse.Location = new System.Drawing.Point(660, 152);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAddCourse.Size = new System.Drawing.Size(159, 47);
            this.btnAddCourse.TabIndex = 17;
            this.btnAddCourse.Text = "    Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.cources;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(392, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(305, 87);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(244, 48);
            this.lblWelcome.TabIndex = 14;
            this.lblWelcome.Text = "All Courses";
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AllowUserToOrderColumns = true;
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCourses.Location = new System.Drawing.Point(0, 205);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(831, 291);
            this.dgvCourses.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCourseToolStripMenuItem,
            this.updateCourseToolStripMenuItem,
            this.deleteCourse_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 118);
            // 
            // addNewCourseToolStripMenuItem
            // 
            this.addNewCourseToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11F);
            this.addNewCourseToolStripMenuItem.Image = global::CMS.Properties.Resources.plus;
            this.addNewCourseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewCourseToolStripMenuItem.Name = "addNewCourseToolStripMenuItem";
            this.addNewCourseToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.addNewCourseToolStripMenuItem.Text = "Add New Course";
            this.addNewCourseToolStripMenuItem.Click += new System.EventHandler(this.addNewCourseToolStripMenuItem_Click);
            // 
            // updateCourseToolStripMenuItem
            // 
            this.updateCourseToolStripMenuItem.Image = global::CMS.Properties.Resources.edit_32;
            this.updateCourseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateCourseToolStripMenuItem.Name = "updateCourseToolStripMenuItem";
            this.updateCourseToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.updateCourseToolStripMenuItem.Text = "Update Course";
            this.updateCourseToolStripMenuItem.Click += new System.EventHandler(this.updateCourseToolStripMenuItem_Click);
            // 
            // deleteCourse_ToolStripMenuItem
            // 
            this.deleteCourse_ToolStripMenuItem.Image = global::CMS.Properties.Resources.Delete_User_32;
            this.deleteCourse_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteCourse_ToolStripMenuItem.Name = "deleteCourse_ToolStripMenuItem";
            this.deleteCourse_ToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.deleteCourse_ToolStripMenuItem.Text = "Delete Course";
            this.deleteCourse_ToolStripMenuItem.Click += new System.EventHandler(this.deleteCourse_ToolStripMenuItem_Click);
            // 
            // ctrlCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctrlCourses";
            this.Size = new System.Drawing.Size(831, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCourse_ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFillterby;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblF;
    }
}
