using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CMSDataLayer;

namespace CMSBusinessLayer
{
    public class clsStudents : clsPeople
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public clsUsers UserInfo { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;

        // User Role
        clsUserRoles userRoles;
        public clsStudents()
        {
            base.PersonID = -1;
            base.FirstName = "";
            base.LastName = "";
            base.Gender = 0;
            base.DateOfBirth = DateTime.MinValue;
            base.PhoneNumber = "";
            base.Email = "";
            base.Address = "";
            base.ImagePath = "";

            this.StudentID = -1;
            this.UserID = -1;
            this.UserInfo = new clsUsers();
            this.FatherName = "";
            this.MotherName = "";

            this.Mode = enMode.AddNew;
            userRoles = new clsUserRoles();
        }
        public clsStudents(int studentID, int UserID, string fatherName, string motherName,
            int personID, string firstName, string lastName, byte gender, DateTime dateOfBirth, string email, string phoneNumber, string address, string imagePath)
        {
            //person
            base.PersonID = personID;
            base.FirstName = firstName;
            base.LastName = lastName;
            base.Gender = gender;
            base.DateOfBirth = dateOfBirth;
            base.PhoneNumber = phoneNumber;
            base.Email = email;
            base.Address = address;
            base.ImagePath = imagePath;

            //student
            this.StudentID = studentID;
            this.UserID = UserID;
            this.UserInfo = clsUsers.Find(UserID);
            this.FatherName = fatherName;
            this.MotherName = motherName;

            this.Mode = enMode.Update;

            userRoles = clsUserRoles.Find(personID);
        }

        public static clsStudents Find(int StudentID)
        {
            string   fatherName = "", motherName = "";
            int personID = -1, UserID = -1;

            if (clsStudentsData.GetStudentByID(StudentID, ref personID, ref UserID, ref fatherName, ref motherName))
            {
                clsPeople person = clsPeople.Find(personID);

                if (person != null)
                {

                    return new clsStudents(StudentID, UserID, fatherName, motherName, person.PersonID, person.FirstName, person.LastName,
                        person.Gender, person.DateOfBirth, person.Email, person.PhoneNumber, person.Address, person.ImagePath);
                }
                else
                    return null;
            }
            else
                return null;
        }
        private bool _AddNewStudent()
        {
            this.StudentID = clsStudentsData.AddNewStudent(this.PersonID, this.UserID, this.FatherName, this.MotherName);
            return (this.StudentID != -1);
        }

        private bool _UpdateStudent()
        {
            return clsStudentsData.UpdateStudent(this.StudentID, this.PersonID, this.UserID, this.FatherName, this.MotherName);
        }

        static public DataTable GetAllStudents()
        {
            return clsStudentsData.GetAllStudents();
        }

        public bool Save()
        {
            //Save person
            base.Mode = (clsPeople.enMode)Mode;
            if (!base.Save())
                return false;

            // add role as a student
            userRoles.Mode = (clsUserRoles.enMode)Mode;
            userRoles.RoleID = clsUserRoles.enRoleID.Student;
            userRoles.PersonID = PersonID;
            if(!userRoles.Save())
                return false;

            //Save User info
            UserInfo.Mode = (clsUsers.enMode)Mode;
            UserInfo.UserRoleID = userRoles.UserRoleID;
            UserInfo.IsActive = true; //  yes user is active
            if(!UserInfo.Save())
                return false;

            this.UserID = UserInfo.UserID;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateStudent();
            }

            return false;
        }

        public static bool IsStudentExist(int StudentID)
        {
            return clsStudentsData.IsStudentExist(StudentID);
        }

        public static bool DeleteStudent(int StudentID) {

            clsStudents student = clsStudents.Find(StudentID);
            if(student != null)
            {
                if (clsStudentsData.DeleteStudent(StudentID) && clsUsers.DeleteUser(student.UserID) && clsUserRoles.DeleteUserRole(student.userRoles.UserRoleID))
                    return clsPeople.DeletePerson(student.PersonID);
                else
                    return false;
            }
            return false;
        }
    }
}
