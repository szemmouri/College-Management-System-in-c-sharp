namespace CMS.UI
{
    partial class ctrlHome
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCoursesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubjectsCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTeachersCount = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(254, 144);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(345, 48);
            this.lblWelcome.TabIndex = 12;
            this.lblWelcome.Text = "Welcome Admin";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 259);
            this.panel1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::CMS.Properties.Resources.home;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(408, 83);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(437, 267);
            this.panel4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(333, 222);
            this.panel4.TabIndex = 2;
            // 
            // lblCoursesCount
            // 
            this.lblCoursesCount.AutoSize = true;
            this.lblCoursesCount.Location = new System.Drawing.Point(59, 168);
            this.lblCoursesCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCoursesCount.Name = "lblCoursesCount";
            this.lblCoursesCount.Size = new System.Drawing.Size(19, 19);
            this.lblCoursesCount.TabIndex = 13;
            this.lblCoursesCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Courses";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblCoursesCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(15, 326);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 214);
            this.panel3.TabIndex = 22;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CMS.Properties.Resources.courceshomepage;
            this.pictureBox2.Location = new System.Drawing.Point(25, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 103);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Location = new System.Drawing.Point(60, 170);
            this.lblStudentCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(19, 19);
            this.lblStudentCount.TabIndex = 13;
            this.lblStudentCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Students";
            // 
            // lblSubjectsCount
            // 
            this.lblSubjectsCount.AutoSize = true;
            this.lblSubjectsCount.Location = new System.Drawing.Point(70, 171);
            this.lblSubjectsCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSubjectsCount.Name = "lblSubjectsCount";
            this.lblSubjectsCount.Size = new System.Drawing.Size(19, 19);
            this.lblSubjectsCount.TabIndex = 13;
            this.lblSubjectsCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Subjects";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lblSubjectsCount);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Location = new System.Drawing.Point(460, 326);
            this.panel6.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(162, 214);
            this.panel6.TabIndex = 23;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CMS.Properties.Resources.subjects;
            this.pictureBox4.Location = new System.Drawing.Point(21, 21);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(116, 103);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // lblTeachersCount
            // 
            this.lblTeachersCount.AutoSize = true;
            this.lblTeachersCount.Location = new System.Drawing.Point(64, 168);
            this.lblTeachersCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTeachersCount.Name = "lblTeachersCount";
            this.lblTeachersCount.Size = new System.Drawing.Size(19, 19);
            this.lblTeachersCount.TabIndex = 13;
            this.lblTeachersCount.Text = "0";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(41, 140);
            this.label70.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(83, 19);
            this.label70.TabIndex = 12;
            this.label70.Text = "Teachers";
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.lblTeachersCount);
            this.panel7.Controls.Add(this.label70);
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Location = new System.Drawing.Point(675, 326);
            this.panel7.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(162, 214);
            this.panel7.TabIndex = 25;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CMS.Properties.Resources.facultyhomepage;
            this.pictureBox5.Location = new System.Drawing.Point(25, 24);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(109, 103);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lblStudentCount);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Location = new System.Drawing.Point(230, 326);
            this.panel5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(162, 214);
            this.panel5.TabIndex = 24;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CMS.Properties.Resources.studenthomepage;
            this.pictureBox3.Location = new System.Drawing.Point(25, 22);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(109, 103);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // ctrlHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ctrlHome";
            this.Size = new System.Drawing.Size(853, 681);
            this.Load += new System.EventHandler(this.ctrlHome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblCoursesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblSubjectsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTeachersCount;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
    }
}
