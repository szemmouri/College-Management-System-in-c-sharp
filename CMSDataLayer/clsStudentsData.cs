using System;
using System.Data;
using System.Data.SqlClient;


namespace CMSDataLayer
{
    public class clsStudentsData
    {

        public static bool GetStudentByID(int StudentID ,ref int PersonID,ref int UserID, ref string FatherName, ref string MotherName)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetStudentByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        connection.Open();
                        
                        using(SqlDataReader reader = command.ExecuteReader()) {

                            IsFund = true;

                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                UserID = (int)reader["UserID"];
                                FatherName = (string)reader["FatherName"];
                                MotherName = (string)reader["MotherName"];
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
        public static int AddNewStudent(int PersonID, int UserID, string FatherName, string MotherName)
        {
            int StudentID = -1;
            try { 
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                
                using(SqlCommand command = new SqlCommand("SP_AddNewStudent", connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@FatherName", FatherName);
                    command.Parameters.AddWithValue("@MotherName", MotherName);

                    //Method 1
                    //SqlParameter outputIdParam = new SqlParameter();
                    //outputIdParam.ParameterName = "@NewStudentID";
                    //outputIdParam.DbType = DbType.Int32;
                    //outputIdParam.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(outputIdParam);

                    // Method 2
                    SqlParameter outputIdParam = new SqlParameter("@NewStudentID", SqlDbType.Int) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    StudentID = (int)outputIdParam.Value;
                    return StudentID ;
                }
            }
            }catch
            {
                throw;
            }
        }
        public static bool UpdateStudent(int StudentID, int PersonID, int UserID, string FatherName, string MotherName)
        {
            int RowsAffected = 0;

            try {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@FatherName", FatherName);
                        command.Parameters.AddWithValue("@MotherName", MotherName);


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
        public static DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllStudents", connection))
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

        public static bool IsStudentExist(int StudentID)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsStudentExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", StudentID);

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

        public static bool DeleteStudent(int StudentID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@StudentID", DbType.Int32) { Value = StudentID });

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
