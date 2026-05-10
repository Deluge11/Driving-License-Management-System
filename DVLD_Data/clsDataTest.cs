using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataTest
    {
        public static bool Add(stTestInfo info, out int testId)
        {
            testId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO Tests
                (
                  TestAppointmentID,
                  TestResult,
                  CreatedByUserID,
                  Notes
                )
                VALUES
                (
                  @TestAppointmentID,
                  @TestResult,
                  @CreatedByUserID,
                  @Notes
                );

                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", info.TestAppointmentID);
            sqlCommand.Parameters.AddWithValue("@TestResult", info.TestResult);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@Notes", info.Notes);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    testId = Convert.ToInt32(result);
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


        public static bool Get(int id, out stTestInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Tests WHERE TestID = @TestID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestID", id);

            info = new stTestInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.TestID = (int)reader["TestID"];
                    info.TestResult = (bool)reader["TestResult"];
                    info.TestAppointmentID = (int)reader["TestAppointmentID"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];
                    info.Notes = (string)reader["Notes"];
                 

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

        public static bool Update(stTestInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE Tests
                SET
                    TestAppointmentID = @TestAppointmentID,
                    TestResult = @TestResult,
                    CreatedByUserID = @CreatedByUserID,
                    Notes = @Notes
                WHERE TestID = @TestID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestID", info.TestID);
            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", info.TestAppointmentID);
            sqlCommand.Parameters.AddWithValue("@TestResult", info.TestResult);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@Notes", info.Notes);

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
