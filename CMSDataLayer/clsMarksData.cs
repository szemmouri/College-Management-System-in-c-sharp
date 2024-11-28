using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace CMSDataLayer
{
    public class clsMarksData
    {
        public static bool FindMarkByID(int MarkID, ref int SubjectID, ref int StudentID, ref decimal Mark)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMarkByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MarkID", MarkID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SubjectID = (int)reader["SubjectID"];
                                StudentID = (int)reader["StudentID"];
                                Mark = (decimal)reader["Mark"];
                                isFound = true;

                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return isFound;
        }
        public static int AddNewMark(int SubjectID, int StudentID, decimal Mark)
        {
            int MarkID = -1; 
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewMark", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", SubjectID);
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@Mark", Mark);


                        SqlParameter outputIdParam = new SqlParameter("@NewMarkID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();


                        MarkID = (int)outputIdParam.Value;
                        return MarkID;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateMark(int MarkID, int SubjectID, int StudentID, decimal Mark)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateMark", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MarkID", MarkID);
                        command.Parameters.AddWithValue("@SubjectID", SubjectID);
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@Mark", Mark);


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
        public static DataTable GetAllMarks()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllMarks", connection))
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

        public static bool DeleteMark(int MarkID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteMark", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@MarkID", DbType.Int32) { Value = MarkID });

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
