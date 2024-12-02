using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
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


        public static bool IsCorrectPassword(string username, string password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE UserName = @UserName AND Password = @Password ";

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
        public static DataTable GettAllDataUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"
        SELECT 
            Users.UserID, 
            People.PersonID, 
            CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName) AS FullName, 
            Users.UserName,       
            Users.IsActive
        FROM 
            Users
        INNER JOIN 
            People ON Users.PersonID = People.PersonID";

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
        public static bool GetUserInfoByPersonID( ref int personID,ref int userID, ref string userName,ref string
            password,ref bool isActive)
        {

            bool isFound = false;
            SqlConnection connection=new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from Users Where PersonID=@PersonID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception e)
            {
                isFound = false;
            }
            finally
            {
                connection.Close() ;
            }
            return isFound  ;

        }


        public static bool GetUserInfoByUserName(ref int personID, ref int userID, ref string userName, ref string
           password, ref bool isActive)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from Users Where UserName=@UserName";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@UserName", userName);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
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
        public static int AddNewUser(int personID,string userName, string passwore, bool isactive)
        {

            int UserID = -1;
            SqlConnection connection=new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Insert INTO Users(PersonID,UserName,Password,
                            IsActive )
                            Values(@PersonID,@UserName,@Password,@IsActive)
                            SELECT SCOPE_IDENTITY()";

            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", passwore);
            command.Parameters.AddWithValue("@IsActive", isactive);

            try
            {
                connection.Open ();

                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int InsertedID))
                {
                    UserID= InsertedID; 

                }

            }catch(Exception e)
            {

            } 
            finally
            {
                connection.Close();

            }

            return UserID;  
        }
    
        public static bool IsUserExist(int userID)
        {

            bool IsFound= false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from Users where UserID=@UserID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);


            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                IsFound = Reader.HasRows;


            }
            catch (Exception)
            {

             IsFound = false;
            }finally    { connection.Close(); }

            return IsFound;
        }

        public static bool UpdateUser(int userID,int personID,string userName,string password,bool isActive)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"UPDATE Users
                       SET PersonID = @PersonID,
                         UserName = @UserName,
                         Password = @Password,
                         IsActive = @IsActive 
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);
          
           

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


        public static bool DeleteUser(int userID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Delete from Users Where UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);


        }
        //public static bool IsCorrectPassword(string password)
        //{

        //    bool IsFound = false;
        //    SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
        //    string query = @"Select Found=1 from Users where Password=@Password";


        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Password", password);


        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();
        //        IsFound = Reader.HasRows;


        //    }
        //    catch (Exception)
        //    {

        //        IsFound = false;
        //    }
        //    finally { connection.Close(); }

        //    return IsFound;

        //}
    }
}
