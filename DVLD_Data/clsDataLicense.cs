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
    public class clsDataLicense
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM Licenses";

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

        public static DataTable GetAll(int driverId)
        {
            string query =
            @"SELECT
            L.LicenseID,
            L.ApplicationID,
            LC.ClassName,
            L.IssueDate,
            L.ExpirationDate,
            L.IsActive 
            FROM Licenses L
            INNER JOIN LicenseClasses LC ON LC.LicenseClassID = L.LicenseClass
            WHERE L.DriverID = @DriverID";

            SqlConnection connection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driverId);

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

        public static bool GetByLicenseId(int id, out stLicenseInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseID", id);

            info = new stLicenseInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LicenseID = (int)reader["LicenseID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.DriverID = (int)reader["DriverID"];
                    info.LicenseClass = (int)reader["LicenseClass"];
                    info.IssueDate = (DateTime)reader["IssueDate"];
                    info.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    info.Notes = (string)reader["Notes"];
                    info.PaidFees = (decimal)reader["PaidFees"];
                    info.IsActive = (bool)reader["IsActive"];
                    info.IssueReason = (byte)reader["IssueReason"];
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

        public static bool GetByApplicationId(int id, out stLicenseInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", id);

            info = new stLicenseInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LicenseID = (int)reader["LicenseID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.DriverID = (int)reader["DriverID"];
                    info.LicenseClass = (int)reader["LicenseClass"];
                    info.IssueDate = (DateTime)reader["IssueDate"];
                    info.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    info.Notes = (string)reader["Notes"];
                    info.PaidFees = (decimal)reader["PaidFees"];
                    info.IsActive = (bool)reader["IsActive"];
                    info.IssueReason = (byte)reader["IssueReason"];
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

        public static bool Update(stLicenseInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE Licenses
                SET
                ApplicationID   =  @ApplicationID,
                CreatedByUserID =  @CreatedByUserID,
                PaidFees        =  @PaidFees,
                IsActive        =  @IsActive,
                DriverID        =  @DriverID,
                LicenseClass    =  @LicenseClass,
                ExpirationDate  =  @ExpirationDate,
                IssueDate       =  @IssueDate,
                IssueReason     =  @IssueReason,
                Notes           =  @Notes
                WHERE LicenseID = @LicenseID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseID", info.LicenseID);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);
            sqlCommand.Parameters.AddWithValue("@DriverID", info.DriverID);
            sqlCommand.Parameters.AddWithValue("@LicenseClass", info.LicenseClass);
            sqlCommand.Parameters.AddWithValue("@ExpirationDate", info.ExpirationDate);
            sqlCommand.Parameters.AddWithValue("@IssueDate", info.IssueDate);
            sqlCommand.Parameters.AddWithValue("@IssueReason", info.IssueReason);
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

        public static bool Add(stLicenseInfo info, out int licenseId)
        {
            licenseId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO Licenses
                (
                    ApplicationID,
                    CreatedByUserID,
                    PaidFees,
                    IsActive,
                    DriverID,
                    LicenseClass,
                    ExpirationDate,
                    IssueDate,
                    IssueReason,
                    Notes
                )
                VALUES
                (
                    @ApplicationID,
                    @CreatedByUserID,
                    @PaidFees,
                    @IsActive,
                    @DriverID,
                    @LicenseClass,
                    @ExpirationDate,
                    @IssueDate,
                    @IssueReason,
                    @Notes
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@PaidFees", info.PaidFees);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);
            sqlCommand.Parameters.AddWithValue("@DriverID", info.DriverID);
            sqlCommand.Parameters.AddWithValue("@LicenseClass", info.LicenseClass);
            sqlCommand.Parameters.AddWithValue("@ExpirationDate", info.ExpirationDate);
            sqlCommand.Parameters.AddWithValue("@IssueDate", info.IssueDate);
            sqlCommand.Parameters.AddWithValue("@IssueReason", info.IssueReason);
            sqlCommand.Parameters.AddWithValue("@Notes", info.Notes);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    licenseId = Convert.ToInt32(result);
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
