using CMSBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace CMS.UI
{
    public partial class ctrlHome : UserControl
    {
        DataTable students = clsStudents.GetAllStudents();
        DataTable courses = clsCourses.GetAllCourses();
        DataTable teachers = clsTeachers.GetAllTeachers();
        DataTable subjects = clsSubject.GetAllSubjects();
        public ctrlHome()
        {
            InitializeComponent();
        }

        private void ctrlHome_Load(object sender, EventArgs e)
        {
            lblCoursesCount.Text = courses.Rows.Count.ToString();
            lblStudentCount.Text = students.Rows.Count.ToString();
            lblSubjectsCount.Text = subjects.Rows.Count.ToString();
            lblTeachersCount.Text = teachers.Rows.Count.ToString();
        }
    }
}
