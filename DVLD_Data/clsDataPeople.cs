using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataPeople
    {
        public static DataTable GetAll()
        {
            string query = @"SELECT 
                                *,
                                CASE
                                    WHEN Gendor = 1 THEN 'Female'
                                    ELSE 'Male'
                                END as GendorName
                            FROM People";

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

        public static bool GetById(int id, out stPersonInfo info)
        {
            bool isFound = false;
            string query = @"SELECT 
                                *,
                                CASE
                                    WHEN Gendor = 1 THEN 'Female'
                                    ELSE 'Male'
                                END as GendorName
                            FROM People WHERE PersonID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", id);

            info = new stPersonInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.PersonID = (int)reader["PersonID"];
                    info.NationalNo = (string)reader["NationalNo"];
                    info.FirstName = (string)reader["FirstName"];
                    info.SecondName = (string)reader["SecondName"];
                    info.ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null;
                    info.LastName = (string)reader["LastName"];
                    info.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    info.Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    info.Address = (string)reader["Address"];
                    info.NationalityCountryId = (int)reader["NationalityCountryId"];
                    info.Phone = (string)reader["Phone"];
                    info.ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                    info.Gender = (byte)reader["Gendor"];

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
            string query = @"SELECT 1 FROM People WHERE PersonID = @Id";
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

        public static bool Exists(string nationalNo)
        {
            bool isFound = false;
            string query = @"SELECT 1 FROM People WHERE NationalNo = @NationalNo";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@NationalNo", nationalNo);

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

        public static bool GetByNationalNo(string nationalNo, out stPersonInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@NationalNo", nationalNo);

            info = new stPersonInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.PersonID = (int)reader["PersonID"];
                    info.NationalNo = (string)reader["NationalNo"];
                    info.FirstName = (string)reader["FirstName"];
                    info.SecondName = (string)reader["SecondName"];
                    info.ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null;
                    info.LastName = (string)reader["LastName"];
                    info.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    info.Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    info.Address = (string)reader["Address"];
                    info.NationalityCountryId = (int)reader["NationalityCountryId"];
                    info.Phone = (string)reader["Phone"];
                    info.ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                    info.Gender = (byte)reader["Gendor"];

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

        public static bool Update(stPersonInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE People
                SET
                    NationalNo = @NationalNo,
                    FirstName = @FirstName,
                    SecondName = @SecondName,
                    ThirdName = @ThirdName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    Gendor = @Gendor,
                    Address = @Address,
                    Phone = @Phone,
                    Email = @Email,
                    NationalityCountryId = @NationalityCountryId,
                    ImagePath = @ImagePath
                WHERE PersonID = @PersonID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", info.PersonID);
            sqlCommand.Parameters.AddWithValue("@NationalNo", info.NationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", info.FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", info.SecondName);
            sqlCommand.Parameters.AddWithValue("@LastName", info.LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", info.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Address", info.Address);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryId", info.NationalityCountryId);
            sqlCommand.Parameters.AddWithValue("@Phone", info.Phone);
            sqlCommand.Parameters.AddWithValue("@Gendor", info.Gender);

            if (string.IsNullOrEmpty(info.ThirdName))
                sqlCommand.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@ThirdName", info.ThirdName);

            if (string.IsNullOrEmpty(info.ImagePath))
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@ImagePath", info.ImagePath);

            if (string.IsNullOrEmpty(info.Email))
                sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@Email", info.Email);

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

        public static bool Add(stPersonInfo info, out int personId)
        {
            personId = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO People
                (
                    NationalNo,
                    FirstName,
                    SecondName,
                    ThirdName,
                    LastName,
                    DateOfBirth,
                    Gendor,
                    Address,
                    Phone,
                    Email,
                    NationalityCountryId,
                    ImagePath
                )
                VALUES
                (
                    @NationalNo,
                    @FirstName,
                    @SecondName,
                    @ThirdName,
                    @LastName,
                    @DateOfBirth,
                    @Gendor,
                    @Address,
                    @Phone,
                    @Email,
                    @NationalityCountryId,
                    @ImagePath
                );
                
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", info.PersonID);
            sqlCommand.Parameters.AddWithValue("@NationalNo", info.NationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", info.FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", info.SecondName);
            sqlCommand.Parameters.AddWithValue("@LastName", info.LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", info.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Address", info.Address);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryId", info.NationalityCountryId);
            sqlCommand.Parameters.AddWithValue("@Phone", info.Phone);
            sqlCommand.Parameters.AddWithValue("@Gendor", info.Gender);

            if (string.IsNullOrEmpty(info.ThirdName))
                sqlCommand.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@ThirdName", info.ThirdName);

            if (string.IsNullOrEmpty(info.ImagePath))
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@ImagePath", info.ThirdName);

            if (string.IsNullOrEmpty(info.Email))
                sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@Email", info.ThirdName);

            try
            {
                sqlConnection.Open();
                isInserted = true;
                object result = sqlCommand.ExecuteScalar();
                personId = result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
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

        public static bool Delete(int personId)
        {
            bool isDeleted = false;

            string query = "DELETE FROM People WHERE PersonID=@PersonID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", personId);

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
