using CMS.Login;
using CMS.UI;
using CMS.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using CMSBusinessLayer;
using CMS.Properties;
using static CMSBusinessLayer.clsUserRoles;
using System.IO;

namespace CMS
{
    public partial class frmMain : Form
    {

        private ctrlHome home;
        private ctrlStudent student;
        private ctrlCourses course;
        private ctrlSubjects subject;
        private ctrlTeachers teacher;
        private ctrlMarks mark;
        private ctrlUsers user;
        private ctrlAdmins admin;
        public frmMain()
        {
            InitializeComponent();
            _Permissions();
        }

        private void _Permissions()
        {
            int RoleID = clsGlobal.RoleID;

            switch (RoleID)
            {
                case 1:
                    btnAdmin.Visible = false;
                    btnUsers.Visible = false;
                    btnEnterMarks.Visible = false;

                    if(student != null)
                        student.Visibility = false;
                    if (course != null)
                        course.Visibility = false;
                    if (subject != null)
                        subject.Visibility = false;
                    if (teacher != null)
                        teacher.Visibility = false;
                    break;
                    
                case 2:
                    btnAdmin.Visible = false;
                    btnUsers.Visible = false;

                    if (student != null)
                        student.Visibility = false;
                    if (course != null)
                        course.Visibility = false;
                    if (subject != null)
                        subject.Visibility = false;
                    if (teacher != null)
                        teacher.Visibility = false;
                    break;

                case 3:
                    //admin has all the Permissions
                    break;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadHome();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

            _GetPersonNameAndImage();

            _MakeProfilePicRounded();

            LoadHome();
        }

        private void _GetPersonNameAndImage()
        {
            clsPeople person = clsPeople.FindPersonByUserRoleID(clsGlobal.CurrentUser.UserRoleID);

            lblName.Text = person.FirstName + " " + person.LastName;

            try
            {
                if (string.IsNullOrEmpty(person.ImagePath))
                {
                    pbProfilePic.Image = person.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
                }
                else
                {
                    pbProfilePic.Image = Image.FromFile(person.ImagePath);
                }
            }
            catch (FileNotFoundException)
            {
                // If the image file is not found, set a default image based on the person's gender
                pbProfilePic.Image = person.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
                MessageBox.Show("An error occurred while loading the profile picture: " + ex.Message);
                pbProfilePic.Image = person.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
            }

        }
        private void _MakeProfilePicRounded()
        {
            // Create a rectangle that matches the size of the picture box
            Rectangle r = new Rectangle(0, 0, pbProfilePic.Width, pbProfilePic.Height);

            // Create a graphics path and add an ellipse that matches the rectangle's bounds
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(r);

            // Set the region of the picture box to the elliptical path
            pbProfilePic.Region = new Region(gp);
        }
        private void LoadHome()
        {
            home = new ctrlHome();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(home);
            home.Dock = DockStyle.Fill;
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            student = new ctrlStudent();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(student);
            student.Dock = DockStyle.Fill;
            _Permissions();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            course = new ctrlCourses();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(course);
            course.Dock = DockStyle.Fill;
            _Permissions();

        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            subject = new ctrlSubjects();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(subject);
            subject.Dock = DockStyle.Fill;
            _Permissions();

        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            teacher = new ctrlTeachers();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(teacher);
            teacher.Dock = DockStyle.Fill;
            _Permissions();

        }

        private void btnEnterMarks_Click(object sender, EventArgs e)
        {
            mark = new ctrlMarks();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(mark);
            mark.Dock = DockStyle.Fill;
            _Permissions();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            user = new ctrlUsers();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(user);
            user.Dock = DockStyle.Fill;
            _Permissions();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            admin = new ctrlAdmins();
            pnHome.Controls.Clear();
            pnHome.Controls.Add(admin);
            admin.Dock = DockStyle.Fill;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new frmLogin();
            frm.ShowDialog();
            
        }


    }
}
