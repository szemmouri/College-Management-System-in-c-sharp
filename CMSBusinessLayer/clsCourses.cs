using CMSDataLayer;
using System;
using System.Data;

namespace CMSBusinessLayer
{
    public class clsCourses
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;

        public clsCourses()
        {
            CourseID = -1; 
            CourseName = ""; 
            CourseDescription = "";
            Mode = enMode.AddNew;

        }

        public clsCourses(int courseID, string courseName, string courseDescription)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseDescription = courseDescription;
            Mode = enMode.Update;
        }

        private bool _AddNewCourse()
        {
            this.CourseID = clsCoursesData.AddNewCourse(this.CourseName, this.CourseDescription);
            return (this.CourseID != -1);
        }
        private bool _UpdateCourse()
        {
            return  clsCoursesData.UpdateCourse(this.CourseID, this.CourseName, this.CourseDescription);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCourse())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateCourse();
            }

            return false;
        }
        public static clsCourses Find(int courseID)
        {
            string courseName = "", courseDescription = "";

            bool isFund = clsCoursesData.GetCourseByID(courseID, ref courseName, ref courseDescription);

            if (isFund)
                return new clsCourses(courseID, courseName, courseDescription);
            else
                return null;
        }
        public static bool DeleteCourse(int courseID)
        {
            return clsCoursesData.DeleteCourse(courseID);
        }
        public static DataTable GetAllCourses()
        {
            return clsCoursesData.GetAllCourses();
        }
    }

}
