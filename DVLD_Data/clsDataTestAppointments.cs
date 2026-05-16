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
    public class clsDataTestAppointments
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments";

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

        public static DataTable Get(int applicationId, int testTypeId)
        {
            string query = @"
            SELECT 
                TestAppointmentID,
                AppointmentDate,
                PaidFees,
                IsLocked 
            FROM TestAppointments
            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND
            TestTypeID = @TestTypeID";

            SqlConnection connection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationId);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);

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


        public static bool Get(int id, out stTestAppointmentInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", id);

            info = new stTestAppointmentInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.IsLocked = (bool)reader["IsLocked"];
                    info.TestTypeID = (int)reader["TestTypeID"];
                    info.PaidFees = (decimal)reader["PaidFees"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];
                    info.TestAppointmentID = (int)reader["TestAppointmentID"];
                    info.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    info.LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    info.RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? (int)reader["RetakeTestApplicationID"] : -1;


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

        public static bool Update(stTestAppointmentInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE TestAppointments
                SET
                    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                    AppointmentDate = @AppointmentDate,
                    CreatedByUserID = @CreatedByUserID,
                    IsLocked = @IsLocked,
                    PaidFees = @PaidFees,
                    RetakeTestApplicationID = @RetakeTestApplicationID,
                    TestTypeID = @TestTypeID
                WHERE TestAppointmentID = @TestAppointmentID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", info.TestAppointmentID);
            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", info.LocalDrivingLicenseApplicationID);
            sqlCommand.Parameters.AddWithValue("@AppointmentDate", info.AppointmentDate);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@IsLocked", info.IsLocked);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@TestTypeID", info.TestTypeID);
            sqlCommand.Parameters.AddWithValue("@RetakeTestApplicationID",
            info.RetakeTestApplicationID == -1 ? (object)DBNull.Value : info.RetakeTestApplicationID);

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

        public static bool Add(stTestAppointmentInfo info, out int testAppintmentId)
        {
            testAppintmentId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO TestAppointments
                (
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    CreatedByUserID,
                    IsLocked,
                    PaidFees,
                    RetakeTestApplicationID,
                    TestTypeID        
                )
                VALUES
                (
                    @LocalDrivingLicenseApplicationID,
                    @AppointmentDate,
                    @CreatedByUserID,
                    @IsLocked,
                    @PaidFees,
                    @RetakeTestApplicationID,
                    @TestTypeID        
                );

                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", info.LocalDrivingLicenseApplicationID);
            sqlCommand.Parameters.AddWithValue("@AppointmentDate", info.AppointmentDate);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@IsLocked", info.IsLocked);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@TestTypeID", info.TestTypeID);
            sqlCommand.Parameters.AddWithValue("@RetakeTestApplicationID",
            info.RetakeTestApplicationID == -1 ? (object)DBNull.Value : info.RetakeTestApplicationID);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    testAppintmentId = Convert.ToInt32(result);
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
