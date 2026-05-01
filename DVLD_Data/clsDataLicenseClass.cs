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
    public class clsDataLicenseClass
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT * FROM LicenseClasses";

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

        public static bool Get(int id, out stLicenseClassInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseClassID", id);

            info = new stLicenseClassInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LicenseClassID = (int)reader["LicenseClassID"];
                    info.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    info.ClassFees = (decimal)reader["ClassFees"];
                    info.ClassDescription = (string)reader["ClassDescription"];
                    info.ClassName = (string)reader["ClassName"];
                    info.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
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

        public static bool Get(string name, out stLicenseClassInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ClassName", name);

            info = new stLicenseClassInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.LicenseClassID = (int)reader["LicenseClassID"];
                    info.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    info.ClassFees = (decimal)reader["ClassFees"];
                    info.ClassDescription = (string)reader["ClassDescription"];
                    info.ClassName = (string)reader["ClassName"];
                    info.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
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

        public static bool Update(stLicenseClassInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE LicenseClasses SET
                ClassName = @ClassName,
                ClassFees = @ClassFees,
                MinimumAllowedAge = @MinimumAllowedAge,
                DefaultValidityLength = @DefaultValidityLength,
                ClassDescription = @ClassDescription
                WHERE LicenseClassID = @LicenseClassID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@LicenseClassID", info.LicenseClassID);
            sqlCommand.Parameters.AddWithValue("@ClassName", info.ClassName);
            sqlCommand.Parameters.AddWithValue("@ClassFees", info.ClassFees);
            sqlCommand.Parameters.AddWithValue("@MinimumAllowedAge", info.MinimumAllowedAge);
            sqlCommand.Parameters.AddWithValue("@DefaultValidityLength", info.DefaultValidityLength);
            sqlCommand.Parameters.AddWithValue("@ClassDescription", info.ClassDescription);

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
