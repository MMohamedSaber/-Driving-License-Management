using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;

namespace DLMDataAccessLayer
{
    public class clsLicenseData
    {
        // Create (Add New License)
        public static int AddNewLicense(
            int applicationID,
            int driverID,
            int licenseClass,
            DateTime issueDate,
            DateTime expirationDate,
            string notes,
            float paidFees,
            bool isActive,
            byte issueReason,
            int createdByUserID)
        {
            int newLicenseID = -1;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
                INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.Parameters.AddWithValue("@Notes", notes);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@IssueReason", issueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int inserted))
                {
                    newLicenseID = inserted;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return newLicenseID;
        }

        // Read (Get License by ID)
        public static bool FindByID( int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
                            ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
                            ref float paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    licenseID = (int)reader["LicenseID"];
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"].ToString();
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason =(byte) reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }



        public static bool FindByApplicationID(  int applicationID , ref int licenseID, ref int driverID, ref int licenseClass,
                         ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
                         ref float paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    licenseID = (int)reader["LicenseID"];
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"].ToString();
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason = (byte)reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool FindByApplicationID(
         ref int applicationID,
         ref int licenseID,
         ref int driverID,
         ref int licenseClass,
         ref DateTime issueDate,
         ref DateTime expirationDate,
         ref string notes,
         ref float paidFees,
         ref bool isActive,
         ref byte issueReason,
         ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    licenseID = (int)reader["LicenseID"];
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"].ToString();
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason =(byte) reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving license by application ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool UpdateLicense(
            int licenseID,
            int applicationID,
            int driverID,
            int licenseClass,
            DateTime issueDate,
            DateTime expirationDate,
            string notes,
            float paidFees,
            bool isActive,
            byte issueReason,
            int createdByUserID)
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
        UPDATE Licenses
        SET ApplicationID = @ApplicationID,
            DriverID = @DriverID,
            LicenseClass = @LicenseClass,
            IssueDate = @IssueDate,
            ExpirationDate = @ExpirationDate,
            Notes = @Notes,
            PaidFees = @PaidFees,
            IsActive = @IsActive,
            IssueReason = @IssueReason,
            CreatedByUserID = @CreatedByUserID
        WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.Parameters.AddWithValue("@Notes", notes);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@IssueReason", issueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating license: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool DeleteLicense(int licenseID)
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting license: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable GetAllLicenses()
        {
            SqlConnection conn = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT * FROM Licenses";
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all licenses: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static bool IsLicenseExist(int licenseClassID, int ApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM Licenses WHERE LicenseClass= @LicenseClass and 
                                                       ApplicationID=@ApplicationID 
                                                      and IsActive=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClass", licenseClassID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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


      public static bool  ActiveLicenseByLicenseID(int licenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1 FROM Licenses WHERE LicenseID= @LicenseID  
                                                      and IsActive=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

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
    }
}
