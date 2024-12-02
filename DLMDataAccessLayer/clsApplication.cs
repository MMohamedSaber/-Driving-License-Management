using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DLMDataAccessLayer
{
    public class clsApplicationData
    {
        public static bool GetApplicationById(ref int appId, ref int personId, ref DateTime appDatetime, ref int appTypeID,
            ref byte appStatus, ref DateTime lastStatusdate, ref float paidfees, ref int createdbyuserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", appId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    appId = (int)reader["ApplicationID"];
                    personId = (int)reader["ApplicantPersonID"];
                    appDatetime = (DateTime)reader["ApplicationDate"];
                    appTypeID = (int)reader["ApplicationTypeID"];
                    appStatus = (byte)reader["ApplicationStatus"];
                    lastStatusdate = (DateTime)reader["LastStatusDate"];
                    paidfees = Convert.ToSingle(reader["PaidFees"]);
                    createdbyuserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";

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

        public static int CreateApplication(int personId, DateTime appDatetime, int appTypeID,
            byte appStatus, DateTime lastStatusdate, double paidfees, int createdbyuserID)
        {
            int applicationId = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
            INSERT INTO Applications 
            (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
            VALUES 
            (@PersonID, @AppDateTime, @AppTypeID, @AppStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@AppDateTime", appDatetime);
            command.Parameters.AddWithValue("@AppTypeID", appTypeID);
            command.Parameters.AddWithValue("@AppStatus", appStatus);
            command.Parameters.AddWithValue("@LastStatusDate", lastStatusdate);
            command.Parameters.AddWithValue("@PaidFees", paidfees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdbyuserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    applicationId = inserted;
                }
            }
            catch (Exception)
            {
                // Handle exception if necessary
            }
            finally
            {
                connection.Close();
            }

            return applicationId;
        }

        public static bool UpdateApplicationById(int appId, int personId, DateTime appDatetime, int appTypeID,
            byte appStatus, DateTime lastStatusdate, float paidfees, int createdbyuserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"
            UPDATE Applications
            SET 
                ApplicantPersonID = @PersonID, 
                ApplicationDate = @AppDateTime, 
                ApplicationTypeID = @AppTypeID, 
                ApplicationStatus = @AppStatus, 
                LastStatusDate = @LastStatusDate, 
                PaidFees = @PaidFees, 
                CreatedByUserID = @CreatedByUserID
            WHERE 
                ApplicationID = @ApplicationID;";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", appId);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@AppDateTime", appDatetime);
            command.Parameters.AddWithValue("@AppTypeID", appTypeID);
            command.Parameters.AddWithValue("@AppStatus", appStatus);
            command.Parameters.AddWithValue("@LastStatusDate", lastStatusdate);
            command.Parameters.AddWithValue("@PaidFees", paidfees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdbyuserID);

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

        public static bool DoesApplicationExist(int applicationId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool CheckApplicationByPersonAndLicense(int applicationPersonId, int licenseClassId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
            SELECT Found =1
            FROM Applications
            INNER JOIN LocalDrivingLicenseApplications 
            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            WHERE ApplicantPersonID = @ApplicantPersonID 
            AND ApplicationStatus = 1
            AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", applicationPersonId);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DeleteApplicationById(int applicationId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);

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

        public static bool UpdateStatusByApplicationIDAndNewStatus(int applicationId, short NewStatus)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"
            UPDATE Applications
            SET 
                ApplicationStatus = @ApplicationStatus, 
                LastStatusDate = @LastStatusDate
                
            WHERE 
                ApplicationID = @ApplicationID;";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@ApplicationStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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
    }
}
