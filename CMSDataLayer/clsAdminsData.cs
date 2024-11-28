using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSDataLayer
{
    public class clsAdminsData
    {
        public static bool GetAdminByID(int AdminID, ref int PersonID, ref int UserID, ref int UserRoleID)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetAdminByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AdminID", AdminID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                UserID = (int)reader["UserID"];
                                UserRoleID = (int)reader["UserRoleID"];
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
        public static bool GetAdminByUserID(int UserID, ref int AdminID, ref int PersonID, ref int UserRoleID)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetAdminByUserID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                AdminID = (int)reader["AdminID"];
                                UserRoleID = (int)reader["UserRoleID"];
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
        public static int AddNewAdmin(int PersonID, int UserID, int UserRoleID)
        {
            int AdminID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewAdmin", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);

                        SqlParameter outputIdParam = new SqlParameter("@NewAdminID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        AdminID = (int)outputIdParam.Value;
                        return AdminID;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateAdmin(int AdminID, int PersonID, int UserID, int UserRoleID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateAdmin", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AdminID", AdminID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);


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
        public static DataTable GetAllAdmins()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllAdmins", connection))
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
        public static bool DeleteAdmin(int AdminID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteAdmin", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AdminID", DbType.Int32) { Value = AdminID });

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
