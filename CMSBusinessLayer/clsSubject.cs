using CMSDataLayer;
using CMSBusinessLayer;
using System.Data;

namespace CMSBusinessLayer
{
    public class clsSubject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int DepartmentID { get; set; }
        public clsDepartments DepartmentInfo { get; set; }
        public string Level { get; set; }
        public string Prerequisites { get; set; }
        public string Description { get; set; }
        public string SemesterOffered { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;

        public clsSubject(int subjectID, string subjectName, int departmentID, string level, string prerequisites, string description, string semesterOffered)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            DepartmentID = departmentID;
            DepartmentInfo = clsDepartments.Find(departmentID);
            Level = level;
            Prerequisites = prerequisites;
            Description = description;
            SemesterOffered = semesterOffered;

            Mode = enMode.Update;
        }

        public clsSubject()
        {
            SubjectID = -1;
            SubjectName = "";
            DepartmentID = -1;
            Level = "";
            Prerequisites = "";
            Description = "";
            SemesterOffered = "";

            Mode = enMode.AddNew;

        }

        public static clsSubject Find(int subjectID)
        {
            string subjectName = "",  level = "", prerequisites = "", description = "", semesterOffered = "";
            int departmentID = -1;

            bool isFound = clsSubjectsData.GetSubjectByID(subjectID, ref subjectName, ref departmentID, ref level, ref prerequisites, ref description, ref semesterOffered);

            if(isFound)
                return new clsSubject(subjectID, subjectName, departmentID, level, prerequisites, description, semesterOffered);
            else
                return null;
            
        }
        public static clsSubject Find(string subjectName)
        {
            string level = "", prerequisites = "", description = "", semesterOffered = "";
            int departmentID = -1, subjectID = -1;

            bool isFound = clsSubjectsData.GetSubjectByName(subjectName, ref subjectID, ref departmentID, ref level, ref prerequisites, ref description, ref semesterOffered);

            if (isFound)
                return new clsSubject(subjectID, subjectName, departmentID, level, prerequisites, description, semesterOffered);
            else
                return null;

        }
        private bool _AddNewSubject()
        {
            this.SubjectID = clsSubjectsData.AddNewSubject(this.SubjectName, this.DepartmentID, this.Level, this.Prerequisites, this.Description, this.SemesterOffered);
            return (this.SubjectID != -1);
        }

        private bool _UpdateSubject()
        {
            return clsSubjectsData.UpdateSubject(this.SubjectID, this.SubjectName, this.DepartmentID, this.Level, this.Prerequisites, this.Description, this.SemesterOffered);
        }

        static public DataTable GetAllSubjects()
        {
            return clsSubjectsData.GetAllSubjects();
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubject())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSubject();
            }

            return false;
        }

        public static bool DeleteSubject(int subjectID)
        {

            return clsSubjectsData.DeleteSubject(subjectID);
        }

    }
}
