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
    public class clsDataApplication
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM Applications";

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

        public static bool GetById(int id, out stApplicationInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Applications WHERE ApplicationID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", id);

            info = new stApplicationInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    info.ApplicationDate = (DateTime)reader["ApplicationDate"];
                    info.LastStatusDate = (DateTime)reader["LastStatusDate"];
                    info.ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    info.ApplicationStatus = (byte)reader["ApplicationStatus"];
                    info.PaidFees = (decimal)reader["PaidFees"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static bool Exists(int id)
        {
            bool isFound = false;
            string query = @"SELECT 1 FROM Applications WHERE ApplicationID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                sqlConnection.Open();
                isFound = sqlCommand.ExecuteScalar() != null;
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

        public static bool UpdateStatus(int applicationId, int statusId)
        {
            bool isChanged = false;
            string query = @"Update Applications SET ApplicationStatus = @status WHERE ApplicationID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", applicationId);
            sqlCommand.Parameters.AddWithValue("@status", statusId);

            try
            {
                sqlConnection.Open();
                isChanged = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isChanged;
        }

        public static bool Update(stApplicationInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE Applications
                SET
                    ApplicantPersonID = @ApplicantPersonID,
                    ApplicationDate = @ApplicationDate,
                    ApplicationStatus = @ApplicationStatus,
                    PaidFees = @PaidFees,
                    CreatedByUserID = @CreatedByUserID,
                    ApplicationTypeID = @ApplicationTypeID,
                    LastStatusDate = @LastStatusDate
                WHERE ApplicationID = @ApplicationID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", info.ApplicantPersonID);
            sqlCommand.Parameters.AddWithValue("@ApplicationDate", info.ApplicationDate);
            sqlCommand.Parameters.AddWithValue("@ApplicationStatus", info.ApplicationStatus);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", info.ApplicationTypeID);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate", info.LastStatusDate);

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

        public static bool Add(stApplicationInfo info, out int applicationID)
        {
            applicationID = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO Applications
                (
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationStatus,
                    PaidFees,
                    CreatedByUserID,
                    ApplicationTypeID,
                    LastStatusDate
                )
                VALUES
                (
                    @ApplicantPersonID,
                    @ApplicationDate,
                    @ApplicationStatus,
                    @PaidFees,
                    @CreatedByUserID,
                    @ApplicationTypeID,
                    @LastStatusDate
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", info.ApplicantPersonID);
            sqlCommand.Parameters.AddWithValue("@ApplicationDate", info.ApplicationDate);
            sqlCommand.Parameters.AddWithValue("@ApplicationStatus", info.ApplicationStatus);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", info.ApplicationTypeID);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate", info.LastStatusDate);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    applicationID = Convert.ToInt32(result);
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

        public static bool Delete(int applicationID)
        {
            bool isDeleted = false;

            string query = "DELETE FROM Applications WHERE ApplicationID=@ApplicationID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                sqlConnection.Open();
                isDeleted = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isDeleted;
        }

        public static bool Delete(int licenseId, int personId)
        {
            bool isDeleted = false;

            string query = "DELETE FROM Applications WHERE ApplicationID=@ApplicationID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", personId);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", licenseId);

            try
            {
                sqlConnection.Open();
                isDeleted = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isDeleted;
        }
    }
}
