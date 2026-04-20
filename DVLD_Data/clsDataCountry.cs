using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataCountry
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM Countries";

            SqlConnection connection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();

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

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool Get(string name, out stCountryInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryName", name);

            info = new stCountryInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.CountryID = (int)reader["CountryID"];
                    info.CountryName = (string)reader["CountryName"];

                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isFound;

        }

        public static bool Get(int id, out stCountryInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", id);

            info = new stCountryInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.CountryID = (int)reader["CountryID"];
                    info.CountryName = (string)reader["CountryName"];

                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isFound;

        }
    }
}
