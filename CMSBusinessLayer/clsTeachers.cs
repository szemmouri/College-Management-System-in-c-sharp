using CMSDataLayer;
using System;
using System.Data;

namespace CMSBusinessLayer
{
    public class clsTeachers : clsPeople
    {
        public int TeacherID { get; set; }
        public int DepartmentID { get; set; }
        public clsDepartments DepartmentInfo { get; set; }
        public Decimal Salary { get; set; }
        public int UserID { get; set; }
        public clsUsers UserInfo { get; set; }
        clsUserRoles userRoles { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsTeachers()
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

            TeacherID = -1;
            PersonID = -1;
            DepartmentID = -1;
            Salary = -1;
            UserID = -1;

            Mode = enMode.AddNew;
            this.UserInfo = new clsUsers();
            userRoles = new clsUserRoles();
        }
        public clsTeachers(int teacherID, int departmentID, decimal salary, int userID,
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

            //Teacher
            TeacherID = teacherID;
            DepartmentID = departmentID;
            Salary = salary;
            UserID = userID;

            Mode = enMode.Update;
            this.DepartmentInfo = clsDepartments.Find(departmentID);
            this.UserInfo = clsUsers.Find(UserID);
            this.userRoles = clsUserRoles.Find(PersonID);
        }

        public static clsTeachers Find(int teacherID)
        {
            decimal salary = -1;
            int  departmentID = -1, personID = -1, UserID = -1;

            if (clsTeachersData.GetTeacherByID(teacherID, ref personID, ref departmentID, ref salary, ref UserID))
            {
                clsPeople person = clsPeople.Find(personID);

                if (person != null)
                {

                    return new clsTeachers(teacherID, departmentID, salary, UserID, person.PersonID, person.FirstName, person.LastName,
                        person.Gender, person.DateOfBirth, person.Email, person.PhoneNumber, person.Address, person.ImagePath);
                }
                else
                    return null;
            }
            else
                return null;
        }
        private bool _AddNewTeacher()
        {
            this.TeacherID = clsTeachersData.AddNewTeacher(this.PersonID, this.DepartmentID, this.Salary, this.UserID);
            return (this.TeacherID != -1);
        }

        private bool _UpdateTeacher()
        {
            return clsTeachersData.UpdateTeacher(this.TeacherID, this.PersonID, this.DepartmentID, this.Salary, this.UserID);
        }

        static public DataTable GetAllTeachers()
        {
            return clsTeachersData.GetAllTeachers();
        }

        public bool Save()
        {
            //Save person
            base.Mode = (clsPeople.enMode)Mode;
            if (!base.Save())
                return false;

            // add role as a student
            userRoles.Mode = (clsUserRoles.enMode)Mode;
            userRoles.RoleID = clsUserRoles.enRoleID.Teacher;
            userRoles.PersonID = PersonID;
            if (!userRoles.Save())
                return false;

            //Save User info
            UserInfo.Mode = (clsUsers.enMode)Mode;
            UserInfo.UserRoleID = userRoles.UserRoleID;
            UserInfo.IsActive = true; //  yes user is active
            if (!UserInfo.Save())
                return false;

            this.UserID = UserInfo.UserID;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTeacher())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTeacher();
            }

            return false;
        }

        public static bool DeleteTeacher(int TeacherID)
        {

            clsTeachers teacher = clsTeachers.Find(TeacherID);
            if (teacher != null)
            {
                if (clsTeachersData.DeleteTeacher(TeacherID) && clsUsers.DeleteUser(teacher.UserID) && clsUserRoles.DeleteUserRole(teacher.userRoles.UserRoleID))
                    return clsPeople.DeletePerson(teacher.PersonID);
                else
                    return false;
            }
            return false;
        }
    }
}
