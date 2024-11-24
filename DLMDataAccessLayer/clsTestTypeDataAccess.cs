using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMDataAccessLayer
{
    public class clsTestTypeDataAccess

    {


        public static DataTable GetAllTestType()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
        SELECT 
            TestTypeID as ID, 
            TestTypeTitle as Title, 
            TestTypeDescription as Description,
            TestTypeFees as Fees
        FROM 
            TestTypes
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

       public static bool  GetTestType(ref int testTypeID, ref string title, ref string TestDescription, ref double Fees)
        {
            bool isfound=false;

            SqlConnection connection=new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"Select * from TestTypes where TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isfound = true;
                if (reader.Read()) // Move to the first row, if it exists
                {
                    testTypeID = (int)reader["TestTypeID"];
                    title = (string)reader["TestTypeTitle"];
                    TestDescription = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToDouble(reader["TestTypeFees"]);

                }
                reader.Close();
            }
            catch (Exception)
            {
                isfound = false;

            }
            finally
            {
                connection.Close ();
            }

            return isfound;


        }

        public static bool UpdateTestType(int id, string testtitle,string testDescription ,double fees)
        {

          
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"UPDATE TestTypes
                       SET 
                         TestTypeTitle = @TestTypeTitle,
                         TestTypeDescription = @TestTypeDescription,
                         TestTypeFees = @TestTypeFees

                         WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", id);
            command.Parameters.AddWithValue("@TestTypeTitle", testtitle);
            command.Parameters.AddWithValue("@TestTypeDescription", testDescription);
            command.Parameters.AddWithValue("@TestTypeFees", fees);




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
