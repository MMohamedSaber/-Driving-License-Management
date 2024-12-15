using System;
using System.Data;
using System.Data.SqlClient;

namespace DLMDataAccessLayer
{
    public class clsDriversData
    {
        // Add New Driver
        public static int AddNewDriver(int personID, int createdByUser, DateTime createdDate)
        {
            int newDriverID = -1;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
                INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUser);
            cmd.Parameters.AddWithValue("@CreatedDate", createdDate);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int inserted))
                {
                    newDriverID = inserted;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding new driver: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return newDriverID;
        }

        // Find Driver by ID
        public static bool FindByID(int driverID, ref int personID, ref int createdByUser, ref DateTime createdDate)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    personID = (int)reader["PersonID"];
                    createdByUser = (int)reader["CreatedByUser"];
                    createdDate = (DateTime)reader["CreatedDate"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving driver by ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        // Update Driver
        public static bool UpdateDriver(int driverID, int personID, int createdByUser, DateTime createdDate)
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
                UPDATE Drivers
                SET PersonID = @PersonID,
                    CreatedByUser = @CreatedByUser,
                    CreatedDate = @CreatedDate
                WHERE DriverID = @DriverID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@CreatedByUser", createdByUser);
            cmd.Parameters.AddWithValue("@CreatedDate", createdDate);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating driver: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Delete Driver
        public static bool DeleteDriver(int driverID)
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "DELETE FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting driver: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Get All Drivers
        public static DataTable GetAllDrivers()
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Drivers";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all drivers: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static DataTable GetDriverRowByDriverID(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT LicenseID,ApplicationID,LicenseClass,IssueDate,ExpirationDate,IsActive 
                            from Drivers inner Join  Licenses on Licenses.LicenseID =Drivers.DriverID
                            where Drivers.DriverID	=@DriverID
                        order by Drivers.DriverID desc;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
    }
}
