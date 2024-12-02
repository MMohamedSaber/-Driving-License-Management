using System;
using System.Data;
using System.Data.SqlClient;

namespace DLMDataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationByLicenseID(ref int localLicenseID, ref int applicationID, ref int licenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    localLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    applicationID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetLocalDrivingLicenseApplicationByApplicationID(ref int localLicenseID, ref int applicationID, ref int licenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    localLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    applicationID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View ORDER BY ApplicationDate DESC";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {
                // Handle exception if necessary
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool UpdateLicenseApplication(int LocalLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"
            UPDATE LocalDrivingLicenseApplications
            SET 
                ApplicationID = @ApplicationID, 
                LicenseClassID = @LicenseClassID
            WHERE 
                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseAppID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseAppID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static int AddNewLocalDrivingLicenseApplication(int applicationID, int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"
            INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
            VALUES (@ApplicationID, @LicenseClassID)     
            SELECT SCOPE_IDENTITY();";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int InsertdID))
                {
                    rowsAffected = InsertdID;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected ;
        }
    }
}
