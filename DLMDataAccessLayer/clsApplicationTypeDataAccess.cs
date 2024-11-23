using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DLMDataAccessLayer
{
    public class clsApplicationTypeDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
        SELECT 
            ApplicationTypeID as ID, 
            ApplicationTypeTitle as Title, 
            ApplicationFees as Fees
        FROM 
            ApplicationTypes
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

            }
            finally
            {
                connection.Close();
            }

            return dt;


        }


        public static bool FindByID(ref int id,ref  string applicationTypeTitle, ref double fees)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    id = (int)reader["ApplicationTypeID"];
                    applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    fees = Convert.ToDouble(reader["ApplicationFees"]);
                   
                }
                reader.Close();

            }
            catch (Exception e)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;





        }

        public static bool UpdateAppType(int id,string apptitle,double fees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"UPDATE ApplicationTypes
                       SET 
                         ApplicationTypeTitle = @ApplicationTypeTitle,
                         ApplicationFees = @ApplicationFees
                         WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", id);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", apptitle);
            command.Parameters.AddWithValue("@ApplicationFees", fees);
          



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false; // Optionally, log the exception for debugging
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);




        }


    }
}
