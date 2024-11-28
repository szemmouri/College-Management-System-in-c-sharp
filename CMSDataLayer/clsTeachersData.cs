using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDataLayer
{
    public class clsTeachersData
    {
        public static bool GetTeacherByID(int TeacherID, ref int PersonID, ref int DepartmentID, ref Decimal Salary, ref int UserID)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetTeacherByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", TeacherID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                UserID = (int)reader["UserID"];
                                DepartmentID = (int)reader["DepartmentID"];
                                Salary = (decimal)reader["Salary"];
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
        public static int AddNewTeacher( int PersonID, int DepartmentID, Decimal Salary, int UserID)
        {
            int StudentID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_AddNewTeacher", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@Salary", Salary);


                        // Method 2
                        SqlParameter outputIdParam = new SqlParameter("@NewTeacherID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        StudentID = (int)outputIdParam.Value;
                        return StudentID;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateTeacher(int TeacherID, int PersonID, int DepartmentID, Decimal Salary, int UserID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", TeacherID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                        command.Parameters.AddWithValue("@Salary", Salary);


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
        public static DataTable GetAllTeachers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllTeachers", connection))
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
        public static bool DeleteTeacher(int TeacherID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TeacherID", DbType.Int32) { Value = TeacherID });

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
