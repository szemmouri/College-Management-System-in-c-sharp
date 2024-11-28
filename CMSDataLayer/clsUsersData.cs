using System.Data.SqlClient;
using System.Data;
using System;


namespace CMSDataLayer
{
    public class clsUsersData
    {

        public static bool FindUserByUserNameAndPassword(string UserName, string Password, int RoleID, ref int UserID, ref int UserRoleID, ref bool IsActive)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetLoginDetails", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@RoleID", RoleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) {

                                isFound = true;

                                UserID = (int)reader["UserID"];
                                UserRoleID = (int)reader["UserRoleID"];
                                IsActive = (bool)reader["IsActive"];

                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return isFound;
        }

        public static bool GetUserByID(int UserID, ref int UserRoleID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                UserRoleID = (int)reader["UserRoleID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
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
        public static bool GetUserByUsername(string UserName,ref int UserID, ref int UserRoleID, ref string Password, ref bool IsActive)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByUsername", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                UserRoleID = (int)reader["UserRoleID"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
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
        public static int AddNewUser(int UserRoleID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        SqlParameter parameter = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(parameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        UserID = (int)command.Parameters["@NewUserID"].Value;
                        return UserID;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateUser(int UserID, int UserRoleID, string UserName, string Password, bool IsActive)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);


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
        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@UserID", DbType.Int32) { Value = UserID });

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
        public static bool IsUserExists(string Username)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsUserExists", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", Username);

                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int existsStatus))
                    {
                        IsExist = (existsStatus == 1);
                    }
                }
            }

            return IsExist;
        }
        public static DataTable GetAllUseers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllUses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }


                }
                catch (Exception ex)
                {

                }
            }

            return dt;
        }
    }
}
