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
    public class clsDataInternationalLicense
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM InternationalLicenses";

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
            InternationalLicenseID ID,
            ApplicationID AppID,
            IssuedUsingLocalLicenseID LocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive
            FROM InternationalLicenses
            WHERE DriverID = @DriverID";

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

        public static bool GetByInternationalLicenseId(int id, out stInternationalLicense info)
        {
            bool isFound = false;
            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", id);

            info = new stInternationalLicense();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.DriverID = (int)reader["DriverID"];
                    info.IssueDate = (DateTime)reader["IssueDate"];
                    info.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    info.IsActive = (bool)reader["IsActive"];
                    info.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
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

        public static bool GetByLocalLicenseId(int id, out stInternationalLicense info)
        {
            bool isFound = false;
            string query = "SELECT * FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", id);

            info = new stInternationalLicense();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.DriverID = (int)reader["DriverID"];
                    info.IssueDate = (DateTime)reader["IssueDate"];
                    info.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    info.IsActive = (bool)reader["IsActive"];
                    info.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
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

        //public static bool GetByApplicationId(int id, out stLicenseInfo info)
        //{
        //    bool isFound = false;
        //    string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";
        //    SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
        //    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

        //    sqlCommand.Parameters.AddWithValue("@ApplicationID", id);

        //    info = new stLicenseInfo();

        //    try
        //    {
        //        sqlConnection.Open();
        //        SqlDataReader reader = sqlCommand.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            info.LicenseID = (int)reader["LicenseID"];
        //            info.ApplicationID = (int)reader["ApplicationID"];
        //            info.DriverID = (int)reader["DriverID"];
        //            info.LicenseClass = (int)reader["LicenseClass"];
        //            info.IssueDate = (DateTime)reader["IssueDate"];
        //            info.ExpirationDate = (DateTime)reader["ExpirationDate"];
        //            info.Notes = (string)reader["Notes"];
        //            info.PaidFees = (decimal)reader["PaidFees"];
        //            info.IsActive = (bool)reader["IsActive"];
        //            info.IssueReason = (byte)reader["IssueReason"];
        //            info.CreatedByUserID = (int)reader["CreatedByUserID"];

        //            isFound = true;
        //        }

        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }


        //    return isFound;

        //}

        public static bool Update(stInternationalLicense info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE InternationalLicenses
                SET
                ApplicationID                =  @ApplicationID,
                DriverID                     =  @DriverID,
                IssuedUsingLocalLicenseID    =  @IssuedUsingLocalLicenseID,
                IssueDate                    =  @IssueDate,
                ExpirationDate               =  @ExpirationDate,
                IsActive                     =  @IsActive,
                CreatedByUserID              =  @CreatedByUserID
                WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", info.InternationalLicenseID);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@DriverID", info.DriverID);
            sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", info.IssuedUsingLocalLicenseID);
            sqlCommand.Parameters.AddWithValue("@IssueDate", info.IssueDate);
            sqlCommand.Parameters.AddWithValue("@ExpirationDate", info.ExpirationDate);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);

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

        public static bool Add(stInternationalLicense info, out int licenseId)
        {
            licenseId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO InternationalLicenses
                (
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicationID,
                    @DriverID,
                    @IssuedUsingLocalLicenseID,
                    @IssueDate,
                    @ExpirationDate,
                    @IsActive,
                    @CreatedByUserID
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@DriverID", info.DriverID);
            sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", info.IssuedUsingLocalLicenseID);
            sqlCommand.Parameters.AddWithValue("@IssueDate", info.IssueDate);
            sqlCommand.Parameters.AddWithValue("@ExpirationDate", info.ExpirationDate);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", info.CreatedByUserID);

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

        public static bool IsDriverHaveInternationalLicense(int driverId)
        {
            bool found = false;
            string query =
            @"SELECT Found = 1 FROM InternationalLicenses IL
            WHERE IL.IssuedUsingLocalLicenseID IN
            (
            SELECT L.LicenseID FROM Licenses L
            WHERE L.DriverID = @DriverId
            )";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@DriverId", driverId);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    found = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                found = false;
            }
            finally
            {
                sqlConnection.Close();
            }


            return found;
        }
        

    }
}
