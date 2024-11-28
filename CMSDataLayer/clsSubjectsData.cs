using System;
using System.Data;
using System.Data.SqlClient;

namespace CMSDataLayer
{
    public class clsSubjectsData
    {
        public static bool GetSubjectByID(int SubjectID, ref string SubjectName, ref int DepartmentID, ref string Level, ref string Prerequisites, ref string Description, ref string SemesterOffered)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", SubjectID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                SubjectName = (string)reader["SubjectName"];
                                DepartmentID = (int)reader["DepartmentID"];
                                Level = (string)reader["Level"];
                                Prerequisites = reader["Prerequisites"] != DBNull.Value ? (string)reader["Prerequisites"] : null;
                                Description = (string)reader["Description"];
                                SemesterOffered = (string)reader["SemesterOffered"];
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
        public static bool GetSubjectByName(string SubjectName, ref int SubjectID, ref int DepartmentID, ref string Level, ref string Prerequisites, ref string Description, ref string SemesterOffered)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectByName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectName", SubjectName);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                SubjectID = (int)reader["SubjectID"];
                                DepartmentID = (int)reader["DepartmentID"];
                                Level = (string)reader["Level"];
                                Prerequisites = reader["Prerequisites"] != DBNull.Value ? (string)reader["Prerequisites"] : null;
                                Description = (string)reader["Description"];
                                SemesterOffered = (string)reader["SemesterOffered"];
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
        public static int AddNewSubject(string SubjectName, int DepartmentID, string Level, string Prerequisites, string Description, string SemesterOffered)
        {
            int SubjectID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewSubject", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectName", SubjectName);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@Level", Level);
                        command.Parameters.AddWithValue("@Prerequisites", string.IsNullOrEmpty(Prerequisites)? DBNull.Value : (object)Prerequisites);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@SemesterOffered", SemesterOffered);

                        //Method 1
                        //SqlParameter outputIdParam = new SqlParameter();
                        //outputIdParam.ParameterName = "@NewStudentID";
                        //outputIdParam.DbType = DbType.Int32;
                        //outputIdParam.Direction = ParameterDirection.Output;
                        //command.Parameters.Add(outputIdParam);

                        // Method 2
                        SqlParameter outputIdParam = new SqlParameter("@NewSubjectID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        SubjectID = (int)outputIdParam.Value;
                        return SubjectID;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateSubject(int SubjectID, string SubjectName, int DepartmentID, string Level, string Prerequisites, string Description, string SemesterOffered)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateSubject", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", SubjectID);
                        command.Parameters.AddWithValue("@SubjectName", SubjectName);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@Level", Level);
                        command.Parameters.AddWithValue("@Prerequisites", string.IsNullOrEmpty(Prerequisites) ? DBNull.Value : (object)Prerequisites);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@SemesterOffered", SemesterOffered);


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
        public static DataTable GetAllSubjects()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllSubjects", connection))
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
        public static bool DeleteSubject(int SubjectID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteSubject", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@SubjectID", DbType.Int32) { Value = SubjectID });

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
