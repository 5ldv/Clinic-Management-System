using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicManagement_DataAccess
{
    public class clsDepartmentData
    {
        public static bool GetDepartmentByID(short DepartmentID, ref string DepartmentName, ref string Location)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Departments WHERE DepartmentID = @DepartmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;

                    DepartmentName = (string)reader["DepartmentName"];
                    Location = (string)reader["Location"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewDepartment(string DepartmentName, string Location)
        {
            int DepartmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Departments (DepartmentName, Location)
                            VALUES (@DepartmentName, @Location)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            command.Parameters.AddWithValue("@Location", Location);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DepartmentID = insertedID;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DepartmentID;
        }
        public static bool UpdateDepartment(short DepartmentID, string DepartmentName, string Location)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Departments  
                            SET 
                            DepartmentName = @DepartmentName, 
                            Location = @Location
                            WHERE DepartmentID = @DepartmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            command.Parameters.AddWithValue("@Location", Location);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteDepartment(short DepartmentID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete Departments 
                                where DepartmentID = @DepartmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DoesDepartmentExist(string DepartmentName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Departments WHERE DepartmentName = @DepartmentName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentName", DepartmentName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllDepartments()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Departments";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }

            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
