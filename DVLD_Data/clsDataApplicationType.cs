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
    public class clsDataApplicationType
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM ApplicationTypes";

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

        public static bool Get(int id, out stApplicationTypeInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", id);

            info = new stApplicationTypeInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    info.ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    info.ApplicationFees = (decimal)reader["ApplicationFees"];

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

        public static bool Update(stApplicationTypeInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE ApplicationTypes SET
                ApplicationTypeTitle = @ApplicationTypeTitle,
                ApplicationFees = @ApplicationFees
                WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", info.ApplicationTypeID);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeTitle", info.ApplicationTypeTitle);
            sqlCommand.Parameters.AddWithValue("@ApplicationFees", info.ApplicationFees);

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
