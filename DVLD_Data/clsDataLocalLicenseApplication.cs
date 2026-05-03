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
    public class clsDataLocalLicenseApplication
    {
        public static DataTable GetAll()
        {
            string query = 
            @"
            SELECT 

            LDLA.LocalDrivingLicenseApplicationID ApplicationID,
            LC.ClassName,
            NationalNo,
            FirstName + ' ' + LastName AS FullName,
            ApplicationDate,
            CASE 
            	WHEN ApplicationStatus = 1 THEN 'New'
            	WHEN ApplicationStatus = 2 THEN 'Cancelled'
            	WHEN ApplicationStatus = 3 THEN 'Completed'
            	ELSE 'Unknown'
            END AS ApplicationStatus,
            COUNT(T.TestID) PassedTests

            FROM LocalDrivingLicenseApplications LDLA
            INNER JOIN Applications App ON App.ApplicationID = LDLA.ApplicationID
            INNER JOIN LicenseClasses LC ON LC.LicenseClassID = LDLA.LicenseClassID
            INNER JOIN People PLL ON PLL.PersonID = App.ApplicantPersonID
            LEFT JOIN TestAppointments TP ON TP.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
            LEFT JOIN Tests T ON T.TestAppointmentID = TP.TestAppointmentID AND T.TestResult = 1

            GROUP BY 
            LDLA.LocalDrivingLicenseApplicationID,
            LC.ClassName,
            NationalNo,
            FirstName,
            LastName,
            ApplicationDate,
            ApplicationStatus";

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

        public static bool GetByLocalId(int id, out stLocalLicenseApplicationInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", id);

            info = new stLocalLicenseApplicationInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetByGeneralId(int id, out stLocalLicenseApplicationInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", id);

            info = new stLocalLicenseApplicationInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    info.ApplicationID = (int)reader["ApplicationID"];
                    info.LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool Update(stLocalLicenseApplicationInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE LocalDrivingLicenseApplications SET
                ApplicationID = @ApplicationID,
                LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", info.LocalDrivingLicenseApplicationID);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", info.LicenseClassID);

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

        public static bool Add(stLocalLicenseApplicationInfo info, out int applicationID)
        {
            applicationID = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO LocalDrivingLicenseApplications
                (
                    ApplicationID,
                    LicenseClassID
                )
                VALUES
                (
                    @ApplicationID,
                    @LicenseClassID
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", info.ApplicationID);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", info.LicenseClassID);

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

        public static bool IsPersonApplyOnThisLicense(int personId, int licenseId)
        {

            bool canApply = false;

            //Semi Join
            string query =
            @"SELECT Found = 1 FROM Applications App
            WHERE 
            App.ApplicationStatus = 1 AND
            App.ApplicantPersonID = @ApplicantPersonID AND
            App.ApplicationID IN 
            (
            SELECT LDLA.ApplicationID FROM LocalDrivingLicenseApplications LDLA
            WHERE LDLA.LicenseClassID = @LicenseClassID
            )";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", personId);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", licenseId);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    canApply = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                canApply = false;
            }
            finally
            {
                sqlConnection.Close();
            }


            return canApply;
        }


        public static bool Delete(int applicationID)
        {
            bool isDeleted = false;

            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationID);

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
