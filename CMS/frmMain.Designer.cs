namespace CMS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnNaveBar = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnEnterMarks = new System.Windows.Forms.Button();
            this.btnTeachers = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnHome = new System.Windows.Forms.Panel();
            this.pnNaveBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnNaveBar
            // 
            this.pnNaveBar.BackColor = System.Drawing.Color.LightCyan;
            this.pnNaveBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnNaveBar.Controls.Add(this.btnAdmin);
            this.pnNaveBar.Controls.Add(this.btnLogout);
            this.pnNaveBar.Controls.Add(this.btnStudents);
            this.pnNaveBar.Controls.Add(this.btnCourses);
            this.pnNaveBar.Controls.Add(this.btnSubjects);
            this.pnNaveBar.Controls.Add(this.btnUsers);
            this.pnNaveBar.Controls.Add(this.btnEnterMarks);
            this.pnNaveBar.Controls.Add(this.btnTeachers);
            this.pnNaveBar.Controls.Add(this.btnHome);
            this.pnNaveBar.Controls.Add(this.lblName);
            this.pnNaveBar.Controls.Add(this.pbProfilePic);
            this.pnNaveBar.Controls.Add(this.label1);
            this.pnNaveBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNaveBar.Location = new System.Drawing.Point(0, 0);
            this.pnNaveBar.Name = "pnNaveBar";
            this.pnNaveBar.Size = new System.Drawing.Size(233, 681);
            this.pnNaveBar.TabIndex = 2;
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.ImageIndex = 7;
            this.btnAdmin.ImageList = this.imageList1;
            this.btnAdmin.Location = new System.Drawing.Point(12, 513);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdmin.Size = new System.Drawing.Size(185, 47);
            this.btnAdmin.TabIndex = 11;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.ImageIndex = 3;
            this.btnLogout.ImageList = this.imageList1;
            this.btnLogout.Location = new System.Drawing.Point(14, 579);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(185, 47);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.ImageIndex = 9;
            this.btnStudents.ImageList = this.imageList1;
            this.btnStudents.Location = new System.Drawing.Point(12, 155);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(185, 47);
            this.btnStudents.TabIndex = 9;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.ImageIndex = 1;
            this.btnCourses.ImageList = this.imageList1;
            this.btnCourses.Location = new System.Drawing.Point(12, 217);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCourses.Size = new System.Drawing.Size(185, 47);
            this.btnCourses.TabIndex = 8;
            this.btnCourses.Text = "Courses";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.ImageIndex = 5;
            this.btnSubjects.ImageList = this.imageList1;
            this.btnSubjects.Location = new System.Drawing.Point(12, 282);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSubjects.Size = new System.Drawing.Size(185, 47);
            this.btnSubjects.TabIndex = 7;
            this.btnSubjects.Text = "Subjects";
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.ImageIndex = 6;
            this.btnUsers.ImageList = this.imageList1;
            this.btnUsers.Location = new System.Drawing.Point(12, 449);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(185, 47);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnEnterMarks
            // 
            this.btnEnterMarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterMarks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnterMarks.ImageIndex = 4;
            this.btnEnterMarks.ImageList = this.imageList1;
            this.btnEnterMarks.Location = new System.Drawing.Point(14, 396);
            this.btnEnterMarks.Name = "btnEnterMarks";
            this.btnEnterMarks.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEnterMarks.Size = new System.Drawing.Size(185, 47);
            this.btnEnterMarks.TabIndex = 5;
            this.btnEnterMarks.Text = "    Enter Marks";
            this.btnEnterMarks.UseVisualStyleBackColor = true;
            this.btnEnterMarks.Click += new System.EventHandler(this.btnEnterMarks_Click);
            // 
            // btnTeachers
            // 
            this.btnTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeachers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeachers.ImageIndex = 8;
            this.btnTeachers.ImageList = this.imageList1;
            this.btnTeachers.Location = new System.Drawing.Point(12, 343);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTeachers.Size = new System.Drawing.Size(185, 47);
            this.btnTeachers.TabIndex = 4;
            this.btnTeachers.Text = "Teachers";
            this.btnTeachers.UseVisualStyleBackColor = true;
            this.btnTeachers.Click += new System.EventHandler(this.btnTeachers_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.ImageIndex = 2;
            this.btnHome.ImageList = this.imageList1;
            this.btnHome.Location = new System.Drawing.Point(12, 93);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(185, 47);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(85, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Admin";
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = global::CMS.Properties.Resources.Std_img;
            this.pbProfilePic.Location = new System.Drawing.Point(12, 12);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.Size = new System.Drawing.Size(67, 46);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePic.TabIndex = 0;
            this.pbProfilePic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "___________";
            // 
            // pnHome
            // 
            this.pnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHome.Location = new System.Drawing.Point(233, 0);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(831, 681);
            this.pnHome.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.pnHome);
            this.Controls.Add(this.pnNaveBar);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnNaveBar.ResumeLayout(false);
            this.pnNaveBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnNaveBar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnEnterMarks;
        private System.Windows.Forms.Button btnTeachers;
        private System.Windows.Forms.Panel pnHome;
    }
}

