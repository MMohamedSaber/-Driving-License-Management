using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMDataAccessLayer
{
    public class clsUsersDataAccess
    {

        public clsUsersDataAccess()
        {
                
        }

        public static bool IsUserExistByUserNameAndPassword(string username,string  password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE UserName = @UserName AND Password = @Password And IsActive=1" ;

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                isFound = reader.HasRows;
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
