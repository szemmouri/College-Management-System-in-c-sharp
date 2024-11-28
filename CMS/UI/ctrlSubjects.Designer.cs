namespace CMS.UI
{
    partial class ctrlSubjects
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
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addNewSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.btnAddSubject);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 185);
            this.panel1.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(246, 78);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(382, 48);
            this.lblWelcome.TabIndex = 14;
            this.lblWelcome.Text = "Subjects Manager";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSubjectToolStripMenuItem,
            this.updateSubjectToolStripMenuItem,
            this.deleteSubjectToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 118);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddSubject.BackColor = System.Drawing.Color.White;
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Image = global::CMS.Properties.Resources.plus;
            this.btnAddSubject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSubject.Location = new System.Drawing.Point(669, 135);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAddSubject.Size = new System.Drawing.Size(159, 47);
            this.btnAddSubject.TabIndex = 17;
            this.btnAddSubject.Text = "   Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.subject;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(392, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // addNewSubjectToolStripMenuItem
            // 
            this.addNewSubjectToolStripMenuItem.Image = global::CMS.Properties.Resources.plus;
            this.addNewSubjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewSubjectToolStripMenuItem.Name = "addNewSubjectToolStripMenuItem";
            this.addNewSubjectToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.addNewSubjectToolStripMenuItem.Text = "Add New Subject";
            this.addNewSubjectToolStripMenuItem.Click += new System.EventHandler(this.addNewSubjectToolStripMenuItem_Click);
            // 
            // updateSubjectToolStripMenuItem
            // 
            this.updateSubjectToolStripMenuItem.Image = global::CMS.Properties.Resources.edit_32;
            this.updateSubjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateSubjectToolStripMenuItem.Name = "updateSubjectToolStripMenuItem";
            this.updateSubjectToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.updateSubjectToolStripMenuItem.Text = "Update Subject";
            this.updateSubjectToolStripMenuItem.Click += new System.EventHandler(this.updateSubjectToolStripMenuItem_Click);
            // 
            // deleteSubjectToolStripMenuItem
            // 
            this.deleteSubjectToolStripMenuItem.Image = global::CMS.Properties.Resources.Delete_32_2;
            this.deleteSubjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteSubjectToolStripMenuItem.Name = "deleteSubjectToolStripMenuItem";
            this.deleteSubjectToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.deleteSubjectToolStripMenuItem.Text = "Delete Subject";
            this.deleteSubjectToolStripMenuItem.Click += new System.EventHandler(this.deleteSubjectToolStripMenuItem_Click);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AllowUserToOrderColumns = true;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubjects.Location = new System.Drawing.Point(0, 185);
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(831, 311);
            this.dgvSubjects.TabIndex = 6;
            this.dgvSubjects.UseWaitCursor = true;
            // 
            // ctrlSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctrlSubjects";
            this.Size = new System.Drawing.Size(831, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSubjectToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSubjects;
    }
}
