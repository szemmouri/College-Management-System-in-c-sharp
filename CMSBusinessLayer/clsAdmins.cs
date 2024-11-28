using CMSDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSBusinessLayer
{
    public class clsAdmins : clsPeople
    {
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public int UserRoleID { get; set; }
        public clsUsers UserInfo { get; set; }
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; }

        // User Role
        clsUserRoles userRoles;
        public clsAdmins()
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

            AdminID = -1;
            UserID = -1;
            this.UserInfo = new clsUsers();
            UserRoleID = -1;

            this.Mode = enMode.AddNew;
            userRoles = new clsUserRoles();

        }
        public clsAdmins(int adminID, int userID, int userRoleID, int personID, 
            string firstName, string lastName, byte gender, DateTime dateOfBirth, string email, string phoneNumber, string address, string imagePath)
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


            AdminID = adminID;
            UserID = userID;
            UserRoleID = userRoleID;

            this.UserInfo = clsUsers.Find(UserID);
            this.Mode = enMode.Update;
            userRoles = clsUserRoles.Find(personID);
        }


        public static clsAdmins Find(int AdminID)
        {
            int personID = -1, UserID = -1, userRoleID = -1;

            if (clsAdminsData.GetAdminByID(AdminID, ref personID, ref UserID, ref userRoleID))
            {
                clsPeople person = clsPeople.Find(personID);

                if (person != null)
                {

                    return new clsAdmins(AdminID, UserID, userRoleID, person.PersonID, person.FirstName, person.LastName,
                        person.Gender, person.DateOfBirth, person.Email, person.PhoneNumber, person.Address, person.ImagePath);
                }
                else
                    return null;
            }
            else
                return null;
        }
        public static clsAdmins FindByUserID(int UserID)
        {
            int personID = -1, AdminID = -1, userRoleID = -1;

            if (clsAdminsData.GetAdminByUserID(UserID, ref AdminID, ref personID, ref userRoleID))
            {
                clsPeople person = clsPeople.Find(personID);

                if (person != null)
                {

                    return new clsAdmins(AdminID, UserID, userRoleID, person.PersonID, person.FirstName, person.LastName,
                        person.Gender, person.DateOfBirth, person.Email, person.PhoneNumber, person.Address, person.ImagePath);
                }
                else
                    return null;
            }
            else
                return null;
        }
        private bool _AddNewAdmin()
        {
            this.AdminID = clsAdminsData.AddNewAdmin(this.PersonID, this.UserID, this.UserRoleID);
            return (this.AdminID != -1);
        }
        private bool _UpdateAdmin()
        {
            return clsAdminsData.UpdateAdmin(this.AdminID, this.PersonID, this.UserID, this.UserRoleID);
        }
        static public DataTable GetAllAdmins()
        {
            return clsAdminsData.GetAllAdmins();
        }
        public bool Save()
        {
            //Save person
            base.Mode = (clsPeople.enMode)Mode;
            if (!base.Save())
                return false;

            // add role as a Admin
            userRoles.Mode = (clsUserRoles.enMode)Mode;
            userRoles.RoleID = clsUserRoles.enRoleID.Admin; //role is Admin
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
                    if (_AddNewAdmin())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAdmin();
            }

            return false;
        }
        public static bool DeleteAdmin(int AdminID)
        {

            clsAdmins admin = clsAdmins.Find(AdminID);
            if (admin != null)
            {
                if (clsAdminsData.DeleteAdmin(AdminID) && clsUsers.DeleteUser(admin.UserID) && clsUserRoles.DeleteUserRole(admin.UserRoleID))                 
                    return clsPeople.DeletePerson(admin.PersonID);
                else
                    return false;
            }
            return false;
        }

    }
}
