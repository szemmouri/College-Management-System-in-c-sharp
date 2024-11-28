using System;
using System.Data.SqlClient;
using System.Data;


namespace CMSDataLayer
{
    public class clsCoursesData
    {
        public static bool GetCourseByID(int CourseID, ref string CourseName, ref string CourseDescription)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetCourseByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CourseID", CourseID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                CourseName = (string)reader["CourseName"];
                                CourseDescription = (string)reader["CourseDescription"];

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
        public static int AddNewCourse(string CourseName, string CourseDescription)
        {
            int CourseID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CourseName", CourseName);
                        command.Parameters.AddWithValue("@CourseDescription", CourseDescription);

                        SqlParameter parameter = new SqlParameter("@NewCourseID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(parameter);

                        connection.Open();

                        command.ExecuteNonQuery();

                        CourseID = (int)parameter.Value;

                    }
                }
            }
            catch {
                throw;
            }
            return CourseID;

        }

        public static bool UpdateCourse(int CourseID, string CourseName, string CourseDescription)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CourseID", CourseID);
                        command.Parameters.AddWithValue("@CourseName", CourseName);
                        command.Parameters.AddWithValue("@CourseDescription", CourseDescription);

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
        public static DataTable GetAllCourses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllCourses", connection))
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

        public static bool DeleteCourse(int CourseID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@CourseID", DbType.Int32) { Value = CourseID });

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
