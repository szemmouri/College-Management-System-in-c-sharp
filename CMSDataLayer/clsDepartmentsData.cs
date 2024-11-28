using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDataLayer
{
    public class clsDepartmentsData
    {
        public static bool GetDepartmentByID( int DepartmentID, ref string DepartmentName, ref string Description)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetDepartmentByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                DepartmentName = (string)reader["DepartmentName"];
                                Description = (string)reader["Description"];
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

        public static bool GetDepartmentByName(string DepartmentName, ref int DepartmentID, ref string Description)
        {
            bool IsFund = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetDepartmentByName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DepartmentName", DepartmentName);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            IsFund = true;

                            if (reader.Read())
                            {
                                DepartmentID = (int)reader["DepartmentID"];
                                Description = (string)reader["Description"];
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

        public static DataTable GetAllDepartments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllDepartments", connection))
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
