using CMSDataLayer;
using System;


namespace CMSBusinessLayer
{
    public class clsUserRoles
    {
        public enum enRoleID { Student = 1, Teacher = 2, Admin = 3 }

        public enRoleID RoleID;
        public int UserRoleID {  get; set; }
        public enRoleID roleID {  get; set; }
        public int PersonID {  get; set; }

        public enum enMode { AddNew = 0, Update = 1}
        public enMode Mode { get; set; }
        public clsUserRoles()
        {
            UserRoleID = -1;
            roleID = enRoleID.Student;
            PersonID = -1;

            Mode = enMode.AddNew;
        }

        public clsUserRoles(int roleID, int userRoleID, int personID)
        {
            UserRoleID = userRoleID;
            this.roleID = (enRoleID)roleID;
            PersonID = personID;

            Mode = enMode.Update;

        }

        public static clsUserRoles Find(int PersonID)
        {
            int userRoleID = -1, roleID = -1;

            if (clsUserRolesData.GetUserRoleByPersonID(PersonID, ref userRoleID, ref roleID))
                return new clsUserRoles(roleID, userRoleID, PersonID);
            else
                return null;
        }
        private bool _AddNewUsrRole()
        {
            this.UserRoleID = clsUserRolesData.AddNewUserRole(this.PersonID, (int)this.roleID);
            return this.UserRoleID != -1;
        }

        private bool _UpdateUserRole()
        {
            return clsUserRolesData.UpdateUserRole(this.UserRoleID, this.PersonID, (int) this.RoleID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUsrRole())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUserRole();
            }

            return false;
        }

        public static bool DeleteUserRole(int UserRoleID)
        {
            return clsUserRolesData.DeleteUserRole(UserRoleID);
        }
    }
}
