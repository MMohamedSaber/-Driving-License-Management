using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DLMDataAccessLayer
{
    public class clsDetainData
    {

        public static bool IsLicenseDetainedByLicenseID(int LicenseID)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM DetainedLicenses WHERE 
                         LicenseID= @LicenseID and 
                         IsReleased=0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
        // Get all Detains as a DataTable
        public static DataTable GetAllDetainTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT * FROM DetainedLicenses";

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

        // Add a new Detain record
        public static int AddNewDetain(

            int LicenseID,
            DateTime DetainDate,
            float FinFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int ReleasedByUserID,
            int ReleaseApplicationID
        )
        {
            int detainId = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
            INSERT INTO DetainedLicenses
            ( LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
            VALUES 
            ( @LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FinFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (ReleaseDate != null)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    detainId = inserted;
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

            return detainId;
        }

        // Update an existing Detain record by its ID
        public static bool UpdateDetainById(
            int detainId,
            int licenseId,
            DateTime detainDate,
            float finFees,
            int createdByUserID,
            bool isReleased,
            DateTime? releaseDate,
            int releasedByUserID,
            int releaseApplicationID
        )
        {
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"
            UPDATE Detains
            SET 
                LicenseID = @LicenseID, 
                DetainDate = @DetainDate, 
                FineFees = @FineFees, 
                CreatedByUserID = @CreatedByUserID, 
                IsReleased = @IsReleased, 
                ReleaseDate = @ReleaseDate, 
                ReleasedByUserID = @ReleasedByUserID, 
                ReleaseApplicationID = @ReleaseApplicationID
            WHERE 
                DetainID = @DetainID;";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);
            command.Parameters.AddWithValue("@LicenseID", licenseId);
            command.Parameters.AddWithValue("@DetainDate", detainDate);
            command.Parameters.AddWithValue("@FineFees", finFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsReleased", isReleased);
            if (releaseDate!=null)
            {
                command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

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

        // Delete a Detain record by its ID
        public static bool DeleteDetainById(int detainId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);

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

        // Check if a Detain record exists by its ID
        public static bool IsDetainExist(int detainId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);

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

        public static bool FindDetainByID(int detainID, ref int licenseID, ref DateTime detainDate, ref float fineFees,
                                  ref int createdByUserID, ref bool isReleased, ref DateTime releaseDate,
                                  ref int releasedByUserID, ref int releaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
        SELECT DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, 
               IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID
        FROM DetainedLicenses
        WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())  // If a row is returned
                {
                    isFound = true;
                    // Directly cast values from the reader
                    detainID = (int)reader["DetainID"];
                    licenseID = (int)reader["LicenseID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    fineFees = (float)reader["FineFees"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];
                    releaseDate = (DateTime)reader["ReleaseDate"];
                    releasedByUserID = (int)reader["ReleasedByUserID"];
                    releaseApplicationID = (int)reader["ReleaseApplicationID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., log error)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool FindDetainByLicenseID(int licenseID, ref int detainID, ref DateTime detainDate, ref float fineFees,
                                 ref int createdByUserID, ref bool isReleased, ref DateTime? releaseDate,
                                 ref int releasedByUserID, ref int releaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
        SELECT DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, 
               IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID
        FROM DetainedLicenses
        WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())  // If a row is returned
                {
                    isFound = true;
                    // Directly cast values from the reader
                    detainID = (int)reader["DetainID"];
                    licenseID = (int)reader["LicenseID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    fineFees =  Convert.ToSingle(reader["FineFees"]) ;
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];
                    if (reader["ReleaseDate"] != DBNull.Value)
                    {
                        releaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    else
                    {
                        releaseDate = null;
                    }
                    releasedByUserID = (int)reader["ReleasedByUserID"];
                    releaseApplicationID = (int)reader["ReleaseApplicationID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., log error)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }

    
}
