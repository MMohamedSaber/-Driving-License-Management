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
    public class clsPoepleDataAccess
    {


        
        clsPoepleDataAccess(int personID,string nationalNo,string firstName,string secondName,string thirdName,string LastName
            ,DateTime dateofBirth,int gendor,string address,string phone,string email,string nationalitycountryid,string imagepath)
        { }
             
        
        public static  bool GetPoepleInfo( int personID,ref string nationalNo,ref  string firstName,ref string secondName,
           ref string thirdName,ref string lastName,ref DateTime dateOfBirth,ref int gender,ref string address  ,ref string phone,
             ref  string email,ref int nationalityCountryID,ref string imagepath)
        {
          

            bool IsFound= false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from People Where PersonID=@PersonID";

            SqlCommand cmd = new  SqlCommand(Query,connection);
            cmd.Parameters.AddWithValue("@PersonID",personID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                 
                    IsFound = true;
                    nationalNo = (string)reader["NationalNo"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = Convert.ToInt32(reader["Gendor"]); // Assuming Gender is an integer
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    nationalityCountryID = (int)reader["NationalityCountryID"];
                    imagepath= reader["ImagePath"] != DBNull.Value? (string)reader["ImagePath"]:"";
                }
                reader.Close();
            }
            catch(Exception )
            {
                return false;
            }
            finally
            {
                    connection.Close();
            }

            return IsFound;


        }

        public static bool IsPersonExist(string nationalNo)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select Found=1 from People where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                IsFound = Reader.HasRows;


            }
            catch (Exception)
            {
                IsFound = false;

            }
            finally { connection.Close(); }
            return IsFound;

        }


       
        public static DataTable GetAllDataFromPersonTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from People";

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


        public static int AddNewPerson( string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, int gender, string address, string phone,
              string email, int nationalityCountryID, string imagepath)
        {

            int PersonID=0;
            SqlConnection connection=new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = @"Insert INTO People(NationalNo,FirstName,SecondName,
                            ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)  
                            Values(@nationalNo,@firstName,@secondName,@thirdName,@lastName,@dateOfBirth,@gender,
                                  @address,@phone,@email,@nationalityCountryID,@imagepath)
                            SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            // Adding parameters with values
            command.Parameters.AddWithValue("@nationalNo", nationalNo);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@secondName", secondName);
            command.Parameters.AddWithValue("@thirdName", thirdName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth); // Use DateTime type
            command.Parameters.AddWithValue("@gender", gender);           // Assuming gender is string like "Male"/"Female"
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID); // Assuming integer (country ID)
            if (imagepath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", imagepath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }


            try
            {
                connection.Open();
                object result =command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    PersonID = inserted;
                }

            }
            catch (Exception)
            {

            }
            finally
            { 
            connection.Close(); 
            
            }

            return PersonID;    

        }


        public static bool UpdatePerson(int id,string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, int gender, string address, string phone,
              string email, int nationalityCountryID, string imagepath)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"UPDATE People
                     SET NationalNo = @NationalNo,
                         FirstName = @FirstName,
                         SecondName = @SecondName,
                         ThirdName = @ThirdName,
                         LastName = @LastName,
                         DateOfBirth = @DateOfBirth,
                         Gendor = @Gender,
                         Address = @Address,
                         Phone = @Phone,
                         Email = @Email,
                         NationalityCountryID = @NationalityCountryID,
                         ImagePath = @ImagePath
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", id);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            // Handle optional ImagePath parameter
            if (!string.IsNullOrEmpty(imagepath))
            {
                command.Parameters.AddWithValue("@ImagePath", imagepath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

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


        public static bool DeletePerson(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Delete from People Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

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

        public static bool IsExistInAnotherTable(int ID)
        {
            bool IsFound = false;
            SqlConnection connection= new SqlConnection(DataAccessSetting.ConnectionString);
            string query = "Select Isfound=1 from Applications where ApplicantPersonID=@ApplicantPersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", ID);
            try
            {
                connection.Open();
                SqlDataReader Read = cmd.ExecuteReader();

                IsFound = Read.HasRows;

            }catch(Exception )
            {
                IsFound = false;
            }
            finally
            {
                    connection.Close() ;    
            }
            return IsFound; 

        }
    }
}
