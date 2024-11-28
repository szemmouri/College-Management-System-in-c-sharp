using CMSDataLayer;
using System;
using System.Data;


namespace CMSBusinessLayer
{
    public class clsUsers
    {

        public int UserID { get; set; }
        public int UserRoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public clsUsers(int userID, int userRoleID, string userName, string password, bool isActive)
        {
            UserID = userID;
            UserRoleID = userRoleID;
            UserName = userName;
            Password = password;
            IsActive = isActive;

            Mode = enMode.Update;
        }
        public clsUsers()
        {
            UserID = -1;
            UserRoleID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            Mode = enMode.AddNew;
        }

        public static clsUsers FindUserByUserNameAndPassword(string username, string password, int roleID)
        {
            int userRoleID = -1, userID = -1;
            bool isActive = false;

            if (clsUsersData.FindUserByUserNameAndPassword(username, password, roleID, ref userID, ref userRoleID, ref isActive))
                return new clsUsers(userID, userRoleID, username, password, isActive);

            else
                return null;
            
        }
        public static clsUsers Find(int userID) {

            int userRoleID = -1;
            string userName = "", password = "";
            bool isActive = false;

            if (clsUsersData.GetUserByID(userID, ref userRoleID, ref userName, ref password, ref isActive))
                return new clsUsers(userID, userRoleID, userName, password, isActive);
            else
                return null;

        }
        public static clsUsers Find(string userName)
        {

            int userRoleID = -1 , userID = -1;
            string  password = "";
            bool isActive = false;

            if (clsUsersData.GetUserByUsername(userName, ref userID, ref userRoleID, ref password, ref isActive))
                return new clsUsers(userID, userRoleID, userName, password, isActive);
            else
                return null;

        }
        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(UserRoleID, UserName, Password, IsActive);

            return this.UserID != -1;
        }
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(UserID, UserRoleID ,UserName, Password, IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }
        public static bool DeleteUser(int userID)
        {
            return clsUsersData.DeleteUser(userID);
        }
        public static bool IsUserExists(string Username)
        {
            return clsUsersData.IsUserExists(Username);
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUseers();
        }

    }
    

}
