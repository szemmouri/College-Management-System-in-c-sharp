using System;
using System.Data.SqlClient;
using System.Data;

namespace CMSDataLayer
{
    public class clsUserRolesData
    {
        public static bool GetUserRoleByPersonID(int PersonID, ref int UserRoleID, ref int roleID)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserRoleByPersonID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                UserRoleID = (int)reader["UserRoleID"];
                                roleID = (int)reader["roleID"];         
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return IsFund;
        }
        public static int AddNewUserRole(int personID, int roleID)
        {
            int userRoleID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddUserRoles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                        command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                        SqlParameter outputParameter = new SqlParameter("@NewUserRoleID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParameter.Value != DBNull.Value)
                        {
                            userRoleID = Convert.ToInt32(outputParameter.Value);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new ApplicationException("An error occurred while adding a new user role.", ex);
            }

            return userRoleID;
        }
        public static bool UpdateUserRole(int UserRoleID, int personID, int roleID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUserRole", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);
                        command.Parameters.AddWithValue("@personID", personID);
                        command.Parameters.AddWithValue("@roleID", roleID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                        return RowsAffected > 0;

                    }
                }
            }
            catch
            {
                throw;
            }

        }
        public static bool DeleteUserRole(int UserRoleID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteUserRole", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@UserRoleID", DbType.Int32) { Value = UserRoleID });

                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
            return (RowsAffected > 0);
        }
    }
}
