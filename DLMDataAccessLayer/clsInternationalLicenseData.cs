using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace DLMDataAccessLayer
{
    public class clsInternationalLicenseData
    {


        // Create International License
        public static int CreateInternationalLicense(int applicationId, int driverId, int issuedUsingLocalLicenseId,
      DateTime issuedDate, DateTime expirationDate, bool isActive, int createdByUser)
        {
            int internationalLicenseId = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
    INSERT INTO InternationalLicenses
    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
    VALUES
    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssuedDate, @ExpirationDate, @IsActive, @CreatedByUserID);
    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@DriverID", driverId);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseId);
            command.Parameters.AddWithValue("@IssuedDate", issuedDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUser);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int insertedId))
                {
                    internationalLicenseId = insertedId;
                }
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseId;
        }

        // Get International License by ID
        public static bool GetInternationalLicenseById(ref int internationalLicenseId, ref int applicationId, ref int driverId,
            ref int issuedUsingLocalLicenseId, ref DateTime issuedDate, ref DateTime expirationDate, ref bool isActive,
            ref int createdByUser)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    internationalLicenseId = (int)reader["InternationalLicenseID"];
                    applicationId = (int)reader["ApplicationID"];
                    driverId = (int)reader["DriverID"];
                    issuedUsingLocalLicenseId = (int)reader["IssuedUseingLocalDrivingLicenseID"];
                    issuedDate = (DateTime)reader["IssuedDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
                    createdByUser = (int)reader["CreatedByUser"];
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

        // Get All International Licenses
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses";

            SqlCommand command = new SqlCommand(query, connection);
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

        // Update International License by ID
        public static bool UpdateInternationalLicenseById(int internationalLicenseId, int applicationId, int driverId,
            int issuedUsingLocalLicenseId, DateTime issuedDate, DateTime expirationDate, bool isActive, int createdByUser)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
            UPDATE InternationalLicenses
            SET
                ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                IssuedUseingLocalDrivingLicenseID = @IssuedUseingLocalLicenseID,
                IssuedDate = @IssuedDate,
                ExpirationDate = @ExpirationDate,
                IsActive = @IsActive,
                CreatedByUser = @CreatedByUser
            WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseId);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@DriverID", driverId);
            command.Parameters.AddWithValue("@IssuedUseingLocalLicenseID", issuedUsingLocalLicenseId);
            command.Parameters.AddWithValue("@IssuedDate", issuedDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUser", createdByUser);

            int rowsAffected = 0;
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

        // Delete International License by ID
        public static bool DeleteInternationalLicenseById(int internationalLicenseId)
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseId);

            int rowsAffected = 0;
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

        // Check if International License Exists
        public static bool IsInternationalLicenseExist(int LocalLicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM InternationalLicenses WHERE
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                              and IsActive=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);

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


        public static  bool IsHaveLicenseOfClassThree(int LicenseID)
        {





            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT Found = 1
                                 FROM Licenses
                             INNER JOIN InternationalLicenses ON
                             InternationalLicenses.IssuedUsingLocalLicenseID =@LicenseID
                              WHERE Licenses.LicenseClass = 3";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LicenseID);

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

        public static DataTable GetDriverRowByDriverID(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses where DriverID=@DriverID";



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
    }
}
