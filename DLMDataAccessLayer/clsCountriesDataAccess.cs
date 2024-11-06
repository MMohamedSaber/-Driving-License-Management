using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DLMDataAccessLayer
{
    public static class clsCountriesDataAccess
    {

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from Countries";

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
            catch (Exception)
            {


            }
            finally
            {
                connection.Close();
            }
            return dt;

        }


        public static bool GetCountryInfoByName(ref int ID, ref string countryname)
        {
           bool IsFound=false;  
            SqlConnection connection=new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from Countries where @CountryName=CountryName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", countryname);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                IsFound = Reader.HasRows;
                if (Reader.Read())
                {
                    IsFound = true;
                    ID = (int)Reader["CountryID"];
                    countryname = (string)Reader["CountryName"];
                   

                }


            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close ();
            }

            return IsFound;
        }



        public static bool GetCountryInfoBybyID(ref int ID, ref string countryname)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string Query = "Select * from Countries where @CountryID=CountryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                IsFound = Reader.HasRows;
                if (Reader.Read())
                {
                    IsFound = true;
                    ID = (int)Reader["CountryID"];
                    countryname = (string)Reader["CountryName"];


                }


            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }
}
