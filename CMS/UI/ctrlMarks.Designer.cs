namespace CMS.UI
{
    partial class ctrlMarks
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
            this.btnAddMark = new System.Windows.Forms.Button();
            this.cbFillterby = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblF = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMark_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.btnAddMark);
            this.panel1.Controls.Add(this.cbFillterby);
            this.panel1.Controls.Add(this.txtFilterValue);
            this.panel1.Controls.Add(this.lblF);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 214);
            this.panel1.TabIndex = 1;
            // 
            // btnAddMark
            // 
            this.btnAddMark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddMark.BackColor = System.Drawing.Color.White;
            this.btnAddMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMark.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMark.Image = global::CMS.Properties.Resources.plus;
            this.btnAddMark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMark.Location = new System.Drawing.Point(655, 161);
            this.btnAddMark.Name = "btnAddMark";
            this.btnAddMark.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAddMark.Size = new System.Drawing.Size(164, 47);
            this.btnAddMark.TabIndex = 4;
            this.btnAddMark.Text = "   Add Mark";
            this.btnAddMark.UseVisualStyleBackColor = false;
            this.btnAddMark.Click += new System.EventHandler(this.btnAddMark_Click);
            // 
            // cbFillterby
            // 
            this.cbFillterby.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFillterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFillterby.FormattingEnabled = true;
            this.cbFillterby.Items.AddRange(new object[] {
            "None",
            "Mark ID",
            "Mark",
            "Student Name",
            "Subject Name"});
            this.cbFillterby.Location = new System.Drawing.Point(140, 172);
            this.cbFillterby.Name = "cbFillterby";
            this.cbFillterby.Size = new System.Drawing.Size(140, 27);
            this.cbFillterby.TabIndex = 18;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilterValue.Location = new System.Drawing.Point(286, 172);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(218, 27);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // lblF
            // 
            this.lblF.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblF.AutoSize = true;
            this.lblF.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.Location = new System.Drawing.Point(14, 175);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(120, 19);
            this.lblF.TabIndex = 16;
            this.lblF.Text = "Find Mark By:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.courceshomepage;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(392, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(318, 54);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 48);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "All Marks";
            // 
            // dgvMarks
            // 
            this.dgvMarks.AllowUserToAddRows = false;
            this.dgvMarks.AllowUserToDeleteRows = false;
            this.dgvMarks.AllowUserToOrderColumns = true;
            this.dgvMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarks.BackgroundColor = System.Drawing.Color.White;
            this.dgvMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarks.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarks.Location = new System.Drawing.Point(0, 214);
            this.dgvMarks.MultiSelect = false;
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.ReadOnly = true;
            this.dgvMarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarks.Size = new System.Drawing.Size(831, 467);
            this.dgvMarks.TabIndex = 7;
            this.dgvMarks.UseWaitCursor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMarkToolStripMenuItem,
            this.updateMarkToolStripMenuItem,
            this.deleteMark_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 118);
            // 
            // addNewMarkToolStripMenuItem
            // 
            this.addNewMarkToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11F);
            this.addNewMarkToolStripMenuItem.Image = global::CMS.Properties.Resources.plus;
            this.addNewMarkToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewMarkToolStripMenuItem.Name = "addNewMarkToolStripMenuItem";
            this.addNewMarkToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.addNewMarkToolStripMenuItem.Text = "Add New Mark";
            this.addNewMarkToolStripMenuItem.Click += new System.EventHandler(this.addNewMarkToolStripMenuItem_Click);
            // 
            // updateMarkToolStripMenuItem
            // 
            this.updateMarkToolStripMenuItem.Image = global::CMS.Properties.Resources.edit_32;
            this.updateMarkToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateMarkToolStripMenuItem.Name = "updateMarkToolStripMenuItem";
            this.updateMarkToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.updateMarkToolStripMenuItem.Text = "Update Mark";
            this.updateMarkToolStripMenuItem.Click += new System.EventHandler(this.updateMarkToolStripMenuItem_Click);
            // 
            // deleteMark_ToolStripMenuItem
            // 
            this.deleteMark_ToolStripMenuItem.Image = global::CMS.Properties.Resources.Delete_32_2;
            this.deleteMark_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteMark_ToolStripMenuItem.Name = "deleteMark_ToolStripMenuItem";
            this.deleteMark_ToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.deleteMark_ToolStripMenuItem.Text = "Delete Mark";
            this.deleteMark_ToolStripMenuItem.Click += new System.EventHandler(this.deleteMark_ToolStripMenuItem_Click);
            // 
            // ctrlMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvMarks);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlMarks";
            this.Size = new System.Drawing.Size(831, 681);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddMark;
        private System.Windows.Forms.ComboBox cbFillterby;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewMarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMark_ToolStripMenuItem;
    }
}
