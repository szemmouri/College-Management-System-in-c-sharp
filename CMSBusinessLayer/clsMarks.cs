using CMSDataLayer;
using System;
using System.Data;

namespace CMSBusinessLayer
{
    public class clsMarks
    {
        public int MarkID { get; set; }
        public int SubjectID { get; set; }
        public clsSubject SubjectInfo { get; set; }
        public int StudentID { get; set; }
        public decimal Mark { get; set; } 

        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public clsMarks()
        {
            MarkID = -1;
            SubjectID = -1;
            StudentID = -1;
            Mark = -1;

            _Mode = enMode.AddNew;
        }
        public clsMarks(int markID, int subjectID, int studentID, decimal mark)
        {
            MarkID = markID;
            SubjectID = subjectID;
            StudentID = studentID;
            SubjectInfo = clsSubject.Find(StudentID);
            Mark = mark;

            _Mode = enMode.Update;
        }

        public static clsMarks Find(int markID)
        {
            int subjectID = -1, studentID = -1;
            decimal mark = -1m;

            if (clsMarksData.FindMarkByID(markID, ref subjectID, ref studentID, ref mark))
                return new clsMarks(markID, subjectID, studentID, mark);
            else
                return null;
        }
        private bool _AddNewMark()
        {
            this.MarkID = clsMarksData.AddNewMark(this.SubjectID, this.StudentID, this.Mark);
            return this.MarkID != -1;
        }
        private bool _UpdateMark()
        {
            return clsMarksData.UpdateMark(MarkID, SubjectID, StudentID, Mark);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMark())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMark();
            }
            return false;

        }

        public static DataTable GetAllMarks()
        {
            return clsMarksData.GetAllMarks();
        }

        public static bool DeleteMark(int MarkID)
        {
            return clsMarksData.DeleteMark(MarkID);
        }
    }
}
