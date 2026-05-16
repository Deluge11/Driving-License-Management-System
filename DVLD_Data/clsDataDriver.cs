using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataDriver
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM Drivers";

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

        public static bool GetById(int id, out stDriverInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@DriverID", id);

            info = new stDriverInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.DriverID = (int)reader["DriverID"];
                    info.PersonID = (int)reader["PersonID"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];
                    info.CreatedDate = (DateTime)reader["CreatedDate"];

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

        public static bool GetByPersonId(int id, out stDriverInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", id);

            info = new stDriverInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.DriverID = (int)reader["DriverID"];
                    info.PersonID = (int)reader["PersonID"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];
                    info.CreatedDate = (DateTime)reader["CreatedDate"];

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

        public static bool Update(stDriverInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE Drivers
                SET
                   PersonID=@PersonID,
                   CreatedByUserID = @CreatedByUserID,
                   CreatedDate=@CreatedDate
                WHERE DriverID = @DriverID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@DriverID", info.DriverID);
            sqlCommand.Parameters.AddWithValue("@PersonID", info.PersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", info.CreatedDate);

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

        public static bool Add(stDriverInfo info, out int personId)
        {
            personId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO People
                (
                  PersonID,
                  CreatedByUserID,
                  CreatedDate,
                )
                VALUES
                (
                  @PersonID, 
                  @CreatedByUserID,
                  @CreatedDate
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", info.PersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", info.CreatedDate);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    personId = Convert.ToInt32(result);
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isInserted = false;
            }
            finally
            {
                sqlConnection.Close();
            }


            return isInserted;
        }

    }
}
