using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DVLD_Data.InfoStructs
{
    public class clsDataDetainedLicense
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM DetainedLicenses";

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

        public static bool IsLicenseDetained(int licenseId)
        {
            bool found = false;

            string query = @"
            SELECT Found = 1 FROM DetainedLicenses WHERE
            LicenseID = @LicenseID AND IsReleased = 0";

            SqlConnection connection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    found = true;
                }
            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static bool GetByLicenseId(int id, out stDetainedLicenseInfo info)
        {
            bool isFound = false;

            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseID", id);

            info = new stDetainedLicenseInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LicenseID = (int)reader["LicenseID"];
                    info.DetainID = (int)reader["DetainID"];
                    info.DetainDate = (DateTime)reader["DetainDate"];
                    info.FineFees = (decimal)reader["FineFees"];
                    info.CreatedByUserID = (int)reader["CreatedByUserID"];
                    info.IsReleased = (bool)reader["IsReleased"];

                    info.ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                        ? (DateTime?)null : (DateTime)reader["ReleaseDate"];

                    info.ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                          ? (int?)null : (int)reader["ReleasedByUserID"];

                    info.ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                          ? (int?)null : (int)reader["ReleaseApplicationID"];

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

        public static bool Update(stDetainedLicenseInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE DetainedLicenses
                SET
                LicenseID=@LicenseID,
                DetainDate=@DetainDate,
                FineFees=@FineFees,
                CreatedByUserID=@CreatedByUserID,
                IsReleased=@IsReleased,
                ReleaseDate=@ReleaseDate,
                ReleasedByUserID=@ReleasedByUserID,
                ReleaseApplicationID=@ReleaseApplicationID
                WHERE DetainID = @DetainID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@DetainID", info.DetainID);
            sqlCommand.Parameters.AddWithValue("@LicenseID", info.LicenseID);
            sqlCommand.Parameters.AddWithValue("@DetainDate", info.DetainDate);
            sqlCommand.Parameters.AddWithValue("@FineFees", info.FineFees);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@IsReleased", info.IsReleased);
            sqlCommand.Parameters.AddWithValue("@ReleaseDate", info.ReleaseDate);
            sqlCommand.Parameters.AddWithValue("@ReleasedByUserID", info.ReleasedByUserID);
            sqlCommand.Parameters.AddWithValue("@ReleaseApplicationID", info.ReleaseApplicationID);

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

        public static bool Add(stDetainedLicenseInfo info, out int detainedId)
        {
            detainedId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO DetainedLicenses
                (
                   LicenseID,
                   DetainDate,
                   FineFees,
                   CreatedByUserID,
                   IsReleased,
                   ReleaseDate,
                   ReleasedByUserID,
                   ReleaseApplicationID
                )
                VALUES
                (
                   @LicenseID,
                   @DetainDate,
                   @FineFees,
                   @CreatedByUserID,
                   @IsReleased,
                   @ReleaseDate,
                   @ReleasedByUserID,
                   @ReleaseApplicationID
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseID", info.LicenseID);
            sqlCommand.Parameters.AddWithValue("@DetainDate", info.DetainDate);
            sqlCommand.Parameters.AddWithValue("@FineFees", info.FineFees);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@IsReleased", info.IsReleased);
            sqlCommand.Parameters.AddWithValue("@ReleaseDate", info.ReleaseDate ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ReleasedByUserID", info.ReleasedByUserID ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ReleaseApplicationID", info.ReleaseApplicationID ?? (object)DBNull.Value);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    detainedId = Convert.ToInt32(result);
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
