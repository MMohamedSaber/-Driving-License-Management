using System;
using System.Data;
using System.Data.SqlClient;

namespace DLMDataAccessLayer
{
    public class clsLicenseClassesDataAccess
    {
        // Get all License Classes
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
                SELECT * 
                FROM LicenseClasses
            ";

            SqlCommand cmd = new SqlCommand(Query, connection);

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
            catch (Exception e)
            {
                // Handle exception
                throw new Exception("Error fetching all license classes", e);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        // Get License Class by ID
        public static bool GetLicenseClassByID(
            int LicenseClassID,
            ref string ClassName,
            ref string ClassDescription,
            ref int MinimumAllowedAge,
            ref int DefaultValidityLength,
            ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        // Insert a new License Class
        public static bool AddNewLicenseClass(
            string ClassName,
            string ClassDescription,
            int MinimumAllowedAge,
            int DefaultValidityLength,
            float ClassFees)
        {
            bool isInserted = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
                INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees)
            ";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                connection.Open();
                isInserted = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error inserting new license class", e);
            }
            finally
            {
                connection.Close();
            }

            return isInserted;
        }

        // Update an existing License Class
        public static bool UpdateLicenseClass(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            int MinimumAllowedAge,
            int DefaultValidityLength,
            float ClassFees)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
                UPDATE LicenseClasses
                SET 
                    ClassName = @ClassName,
                    ClassDescription = @ClassDescription,
                    MinimumAllowedAge = @MinimumAllowedAge,
                    DefaultValidityLength = @DefaultValidityLength,
                    ClassFees = @ClassFees
                WHERE LicenseClassID = @LicenseClassID
            ";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                connection.Open();
                isUpdated = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error updating license class", e);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        // Delete a License Class
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            bool isDeleted = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                isDeleted = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting license class", e);
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }
    }
}
