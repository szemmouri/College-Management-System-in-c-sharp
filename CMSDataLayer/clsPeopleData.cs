using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace CMSDataLayer
{
    public class clsPeopleData
    {
        public static bool FindPersonByID(int PersonID, ref string FirstName, ref string LastName, ref byte Gender, 
            ref DateTime DateOfBirth, ref string Email, ref string PhoneNumber, ref string Address, ref string ImagePath)
        {
            bool IsFund = false;

            try { 
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindPersonByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) {

                                IsFund = true;
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = (byte)reader["Gender"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Email = (string)reader["Email"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                Address = (string)reader["Address"];
                                ImagePath = (string)reader["ImagePath"];
                            }
                        }
                        
                    }
                }
            }
            catch
            {
                IsFund = false;
            }
            return IsFund;
        }

        public static bool FindPersonByUserRoleID(int UserRoleID, ref int PersonID, ref string FirstName, ref string LastName, ref byte Gender,
            ref DateTime DateOfBirth, ref string Email, ref string PhoneNumber, ref string Address, ref string ImagePath)
        {
            bool IsFund = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindPersonByUserRoleID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserRoleID", UserRoleID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                IsFund = true;
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = (byte)reader["Gender"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Email = (string)reader["Email"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                Address = (string)reader["Address"];
                                ImagePath = (string)reader["ImagePath"];
                            }
                        }

                    }
                }
            }
            catch
            {
                IsFund = false;
            }
            return IsFund;
        }

        public static int AddNewPerson(string FirstName, string LastName, byte Gender,
               DateTime DateOfBirth, string Email, string PhoneNumber, string Address, string ImagePath)
        {
            int PersonID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)).Value = FirstName;
                        command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50)).Value = LastName;
                        command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.TinyInt)).Value = Gender;
                        command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date)).Value = DateOfBirth;
                        command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100)).Value = Email;
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 20)).Value = PhoneNumber;
                        command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200)).Value = Address;

                        command.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 100)).Value = string.IsNullOrEmpty(ImagePath)? DBNull.Value : (object)ImagePath ;

                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();
                        PersonID = (int)outputIdParam.Value;
                    }
                }
            }
            catch 
            {
                throw;
            }
            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string LastName, byte Gender,
             DateTime DateOfBirth, string Email, string PhoneNumber, string Address, string ImagePath)
        {
            int RowsAffected = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = FirstName });
                        command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = LastName });
                        command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.TinyInt) { Value = Gender });
                        command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime) { Value = DateOfBirth });
                        command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = Email });
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 20) { Value = PhoneNumber });
                        command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = Address });
                        command.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200) { Value = string.IsNullOrEmpty(ImagePath)? DBNull.Value: (object)ImagePath });
                        command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }

            return RowsAffected > 0;
        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            try {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PersonID", DbType.Int32) { Value = PersonID });

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
