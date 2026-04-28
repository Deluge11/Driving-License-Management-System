using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.InfoStructs;

namespace DVLD_Data
{
    public class clsDataTestType
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM TestTypes";

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

        public static bool Get(int id, out stTestTypeInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestTypeID", id);

            info = new stTestTypeInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.TestTypeID = (int)reader["TestTypeID"];
                    info.TestTypeTitle = (string)reader["TestTypeTitle"];
                    info.TestTypeDescription = (string)reader["TestTypeDescription"];
                    info.TestTypeFees = (decimal)reader["TestTypeFees"];

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

        public static bool Update(stTestTypeInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE TestTypes SET
                TestTypeTitle = @TestTypeTitle,
                TestTypeDescription = @TestTypeDescription,
                TestTypeFees = @TestTypeFees
                WHERE TestTypeID = @TestTypeID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestTypeID", info.TestTypeID);
            sqlCommand.Parameters.AddWithValue("@TestTypeTitle", info.TestTypeTitle);
            sqlCommand.Parameters.AddWithValue("@TestTypeDescription", info.TestTypeDescription);
            sqlCommand.Parameters.AddWithValue("@TestTypeFees", info.TestTypeFees);

            try
            {
                sqlConnection.Open();
                isUpdated = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isUpdated;
        }


    }
}
